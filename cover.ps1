$coverage_dir = 'artifacts\coverage'


Function Cover([string] $assembly)
{
    .\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe `
        -register `
        -filter:+[FakeItEasy]FakeItEasy* `
        -target:packages\xunit.runner.console.2.0.0\tools\xunit.console.exe `
        "-targetargs:tests\$assembly\bin\Release\$assembly.dll -noshadow -nologo -notrait explicit=yes -xml artifacts\tests\$assembly.TestResults.xml" `
        -output:$coverage_dir\$assembly.xml
}


if (Test-Path $coverage_dir)  { Remove-Item -Recurse $coverage_dir }
New-Item -Type Directory $coverage_dir > $nul

'FakeItEasy.Analyzer.Tests', `
'FakeItEasy.IntegrationTests', `
'FakeItEasy.IntegrationTests.VB', `
'FakeItEasy.Specs', `
'FakeItEasy.Tests', `
'FakeItEasy.Tests.Approval' | ForEach-Object { Cover $_ }

.\packages\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe -reports:$coverage_dir\*.xml -targetdir:$coverage_dir