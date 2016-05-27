require 'albacore'

msbuild_command = "C:/Program Files (x86)/MSBuild/14.0/Bin/MSBuild.exe"
if !File.file?(msbuild_command)
  raise "MSBuild not found"
end

nuget_command  = ".nuget/nuget.exe"
nunit_command  = "packages/NUnit.Runners.2.6.3/tools/nunit-console.exe"
xunit_command = "packages/xunit.runner.console.2.0.0/tools/xunit.console.exe"

solution        = "FakeItEasy.sln"
assembly_info   = "src/CommonAssemblyInfo.cs"
version         = IO.read(assembly_info)[/AssemblyInformationalVersion\("([^"]+)"\)/, 1]
version_suffix  = ENV["VERSION_SUFFIX"]
nuspec          = "src/FakeItEasy/FakeItEasy.nuspec"
analyzer_nuspec = "src/FakeItEasy.Analyzer/FakeItEasy.Analyzer.nuspec"
logs            = "artifacts/logs"
output          = "artifacts/output"
tests           = "artifacts/tests"

unit_tests = [
  "tests/FakeItEasy.Tests/bin/Release/FakeItEasy.Tests.dll",
  "tests/FakeItEasy.Analyzer.Tests/bin/Release/FakeItEasy.Analyzer.Tests.dll"
]

integration_tests = [
  "tests/FakeItEasy.IntegrationTests/bin/Release/FakeItEasy.IntegrationTests.dll",
  "tests/FakeItEasy.IntegrationTests.VB/bin/Release/FakeItEasy.IntegrationTests.VB.dll"
]

specs = "tests/FakeItEasy.Specs/bin/Release/FakeItEasy.Specs.dll"

approval_tests = "tests/FakeItEasy.Tests.Approval/bin/Release/FakeItEasy.Tests.Approval.dll"

repo = 'FakeItEasy/FakeItEasy'
release_issue_labels = ['P2', 'build', 'documentation']

release_body = <<-eos
* **Changed**: _&lt;description&gt;_ - _#&lt;issue number&gt;_
* **New**: _&lt;description&gt;_ - _#&lt;issue number&gt;_
* **Fixed**: _&lt;description&gt;_ - _#&lt;issue number&gt;_

With special thanks for contributions to this release from:

* _&lt;user's actual name&gt;_ - _@&lt;github_userid&gt;_
eos

ssl_cert_file_url = "http://curl.haxx.se/ca/cacert.pem"

Albacore.configure do |config|
  config.log_level = :verbose
end

desc "Execute default tasks"
task :default => [ :vars, :unit, :integ, :spec, :pack ]

desc "Print all variables"
task :vars do
  print_vars(local_variables.sort.map { |name| [name.to_s, (eval name.to_s)] })
end

desc "Restore NuGet packages"
exec :restore do |cmd|
  cmd.command = nuget_command
  cmd.parameters "restore #{solution}"
end

directory logs

desc "Clean solution"
task :clean => [logs] do
  run_msbuild solution, "Clean", msbuild_command
end

desc "Update version number and create milestone, release, and release checklist issue"
task :next_version, :new_version do |asm, args|
  new_version = args.new_version or
    fail "ERROR: A new version is required, e.g.: rake next_version[2.3.0]"

  current_branch = `git rev-parse --abbrev-ref HEAD`.strip()

  if current_branch != 'master'
    fail "ERROR: Current branch is '#{current_branch}'. Must be on branch 'master' to set new version."
  end if

  new_branch = "set-version-to-" + new_version

  require 'octokit'

  ssl_cert_file = get_temp_ssl_cert_file(ssl_cert_file_url)

  client = Octokit::Client.new(:netrc => true)

  puts "Creating branch '#{new_branch}'..."
  `git checkout -b #{new_branch}`
  puts "Created branch '#{new_branch}'."

  puts "Setting version to '#{new_version}' in '#{assembly_info}'..."
  Rake::Task["set_version_in_assemblyinfo"].invoke(new_version)
  puts "Set version to '#{new_version}' in '#{assembly_info}'."

  puts "Committing '#{assembly_info}'..."
  `git commit -m "setting version to #{new_version}" #{assembly_info}`
  puts "Committed '#{assembly_info}'."

  puts "Pushing '#{new_branch}' to origin..."
  `git push origin #{new_branch}"`
  puts "Pushed '#{new_branch}' to origin."

  puts "Creating pull request..."
  pull_request = client.create_pull_request(
    repo,
    "master",
    "#{client::user.login}:#{new_branch}",
    "set version to #{new_version} for next release",
    "preparing for #{new_version}"
  )
  puts "Created pull request \##{pull_request.number} '#{pull_request.title}'."

  release_description = new_version + ' release'

  puts "Creating milestone '#{new_version}'..."
  milestone = client.create_milestone(
    repo,
    new_version,
    :description => release_description
    )
  puts "Created milestone '#{new_version}'."

  puts "Creating issue '#{release_description}'..."
  is_pre_release = true
  issue = client.create_issue(
    repo,
    release_description,
    create_issue_body(is_pre_release: false),
    :labels => release_issue_labels,
    :milestone => milestone.number
    )
  puts "Created issue \##{issue.number} '#{release_description}'."

  puts "Creating release '#{new_version}'..."
  client.create_release(
    repo,
    new_version,
    :name => new_version,
    :draft => true,
    :body => release_body
    )
  puts "Created release '#{new_version}'."
end

desc "Update assembly info"
assemblyinfo :set_version_in_assemblyinfo, :new_version do |asm, args|
  new_version = args.new_version

  # not using asm.version and asm.file_version due to StyleCop violations
  asm.custom_attributes = {
    :AssemblyVersion => new_version,
    :AssemblyFileVersion => new_version,
    :AssemblyInformationalVersion => new_version
  }
  asm.input_file = assembly_info
  asm.output_file = assembly_info
end

desc "Build solution"
task :build => [:clean, :restore, logs] do
  run_msbuild solution, "Build", msbuild_command
end

directory tests

desc "Execute unit tests"
nunit :unit => [:build, tests] do |nunit|
  nunit.command = nunit_command
  nunit.assemblies unit_tests
  nunit.options "/result=#{tests}/TestResult.Unit.xml", "/nologo"
end

desc "Execute integration tests"
nunit :integ => [:build, tests] do |nunit|
  nunit.command = nunit_command
  nunit.assemblies integration_tests
  nunit.options "/result=#{tests}/TestResult.Integration.xml", "/nologo"
end

desc "Execute specifications"
task :spec => [:build, tests] do
    xunit = XUnitTestRunner.new
    xunit.command = xunit_command
    xunit.assembly = specs
    xunit.options "-noshadow", "-nologo", "-notrait", "\"explicit=yes\"", "-xml", "#{tests}/TestResult.Specifications.xml"
    xunit.execute
end

desc "Execute approval tests"
nunit :approve => [:build, tests] do |nunit|
  nunit.command = nunit_command
  nunit.assemblies approval_tests
  nunit.options "/result=#{tests}/TestResult.Approval.xml", "/nologo"
end

directory output

desc "create the nuget package"
exec :pack => [:build, output] do |cmd|
  cmd.command = nuget_command
  cmd.parameters "pack #{nuspec} -Version #{version}#{version_suffix} -OutputDirectory #{output}"
end

desc "create the analyzer nuget package"
exec :pack => [:build, output] do |cmd|
  cmd.command = nuget_command
  cmd.parameters "pack #{analyzer_nuspec} -Version #{version}#{version_suffix} -OutputDirectory #{output}"
end

def create_release_issue_body(is_pre_release: false)
  if is_pre_release
    next_release_instruction = <<-eos.gsub /^\s+/, ""
      - [ ] run `rake next_version[new_version]` to
          - create a pull request that changes the version in CommonAssemblyInfo.cs to the expected version (of form _xx.yy.zz_)
          - create a new milestone for the next release
          - create a new issue (like this one) for the next release, adding it to the new milestone
          - create a new draft GitHub Release
    eos
  else
    next_release_instruction = <<-eos.gsub /^\s+/, ""
      - if there's to be a new pre-release issue
        - [ ] run `rake pre_release[version_suffix]` to create a new draft GitHub Release and a new issue (like this one) for the next release, adding it to the current milestone
        - [ ] change `VERSION_SUFFIX` on the [CI Server](http://teamcity.codebetter.com/admin/editBuildParams.html?id=buildType:bt929)
    eos
  end

  <<-eos.gsub /^\s+/, ""
    **Ready** when all other issues on this milestone are **Done** and closed.

    - [ ] run code analysis in VS in *Release* mode and address violations (send a regular PR which must be merged before continuing)
    - [ ] if necessary, change `VERSION_SUFFIX` on the [CI Server](http://teamcity.codebetter.com/admin/editBuildParams.html?id=buildType:bt929)
          to appropriate "-beta123" or "" (for non-betas) value and initiate a build
    - [ ] check build
    -  edit draft release in [GitHub UI](https://github.com/FakeItEasy/FakeItEasy/releases):
        - [ ] complete release notes, mentioning non-owner contributors, if any (move release notes forward from any pre-releases to the current release)
        - [ ] attach nupkg(s) - main package and/or analyzer, whichever have new content
        - [ ] publish the release
    - [ ] push NuGet package
    - [ ] de-list pre-release or superseded buggy NuGet packages if present
    - [ ] update website with contributors list (if in place)
    - [ ] tweet, mentioning contributors and post link as comment here for easy retweeting ;-)
    - [ ] post tweet in [Gitter](https://gitter.im/FakeItEasy/FakeItEasy)
    - [ ] post links to the NuGet and GitHub release in each issue in this milestone, with thanks to contributors
    #{next_release_instruction}
    - [ ] close this milestone
  eos
end

def print_vars(variables)

  scalars = []
  vectors = []

  variables.each { |name, value|
    if value.respond_to?('each')
      vectors << [name, value.map { |v| v.to_s }]
    else
      string_value = value.to_s
      lines = string_value.lines
      if lines.length > 1
        vectors << [name, lines]
      else
        scalars << [name, string_value]
      end
    end
  }

  scalar_name_column_width = scalars.map { |s| s[0].length }.max
  scalars.each { |name, value|
    puts "#{name}:#{' ' * (scalar_name_column_width - name.length)} #{value}"
  }

  puts
  vectors.select { |name, value| !['release_body', 'release_issue_body', 'release_issue_labels'].include? name }.each { |name, value|
    puts "#{name}:"
    puts value.map {|v| "  " + v }
    puts ""
  }
end

def run_msbuild(solution, target, command)
  cmd = Exec.new
  cmd.command = command
  cmd.parameters "#{solution} /target:#{target} /p:configuration=Release /nr:false /verbosity:minimal /nologo /fl /flp:LogFile=artifacts/logs/#{target}.log;Verbosity=Detailed;PerformanceSummary"
  cmd.execute
end

# Get a temporary SSL cert file if necessary.
# If ENV["SSL_CERT_FILE"] is set, will return nil.
# Otherwise, attempts to download a known
# SSL cert file, sets ENV["SSL_CERT_FILE"]
# to point at it, and returns the file (mostly so it will
# stay in scope while it's needed).
def get_temp_ssl_cert_file(ssl_cert_file_url)
  ssl_cert_file_path = ENV["SSL_CERT_FILE"]
  if ssl_cert_file_path
    return nil
  end

  puts "Environment variable SSL_CERT_FILE is not set. Downloading a cert file from '#{ssl_cert_file_url}'..."

  require 'open-uri'
  require 'tempfile'

  file = Tempfile.new('ssl_cert_file')
  file.binmode
  file << open(ssl_cert_file_url).read
  file.close

  ENV["SSL_CERT_FILE"] = file.path

  puts "Downloaded cert file to '#{ENV['SSL_CERT_FILE']}'."
  return file
end
