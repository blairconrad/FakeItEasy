#r ".\packages\Octokit.0.26.0\lib\net45\Octokit.dll"
#r ".\packages\system.runtime.interopservices.runtimeinformation\4.0.0\lib\net45\System.Runtime.InteropServices.RuntimeInformation.dll"

using Octokit;

var version = Args.FirstOrDefault();
if (version == null)
{
    throw new Exception("No version supplied");
}


System.Console.WriteLine(version);

var branchName = $"release/{version}";

var token = ReadTokenFromNetrc();

var gitHubClient = new GitHubClient(new ProductHeaderValue("FakeItEasy-build-scripts"));
gitHubClient.Credentials = new Credentials(token);
var user = await gitHubClient.User.Get("shiftkey");
System.Console.WriteLine(user.PublicRepos);


Cmd("git", $"checkout -b {branchName}");
Cmd("git", $"push upstream {branchName}");

// git checkout --quiet master
// git merge --quiet --no-ff $branchName
// git branch --delete $branchName
// git tag $NewVersion
// git push --tags $RemoteName HEAD


public static string ReadTokenFromNetrc()
{
    const string githubApiHost = "api.github.com";
    var netrcContents = File.ReadAllText(Path.Combine(Environment.GetEnvironmentVariable("HOME"), ".netrc"));
    var tokens = netrcContents.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

    int lastTokenToCheck = tokens.Length - 1;
    int i = 0;
    for (; i < lastTokenToCheck; i += 2)
    {
        if (tokens[i] == "machine" && tokens[i + 1] == githubApiHost)
        {
            break;
        }
    }

    for (; i < lastTokenToCheck; ++i)
    {
        if (tokens[i] == "password")
        {
            return tokens[i + 1];
        }
    }

    throw new Exception($"Can't find password for {githubApiHost} in .netrc file");
}

public static void Cmd(string fileName, string args)
{
    using (var process = new Process())
    {
        process.StartInfo = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = args,
            UseShellExecute = false,
        };

        Console.WriteLine($"Running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'...");
        process.Start();
        process.WaitForExit();
        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException($"The command exited with code {process.ExitCode}.");
        }
    }
}
