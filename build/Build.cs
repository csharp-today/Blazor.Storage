using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Useful;
using Nuke.Useful.Builds;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : AzureDevOpsLibraryBuild
{
    public static int Main () => Execute<Build>(x => x.PushPreRelease2);

    private Target PushPreRelease2 => _ => _
        .DependsOn(PackProduction)
        .Requires(() => FeedUser)
        .Requires(() => FeedSecret)
        .Executes(() =>
        {
            System.Diagnostics.Debugger.Launch();
            using var config = NuGetConfig.Create(Packer.PreReleaseOutput, FeedUrl, FeedUser, FeedSecret);
            var packages = GlobFiles(Packer.PreReleaseOutput, "*.nupkg");
            foreach (var pkg in packages)
            {
                DotNetNuGetPush(s => s
                    .SetTargetPath(pkg)
                    .SetWorkingDirectory(Packer.PreReleaseOutput)
                    .SetForceEnglishOutput(true)
                    .SetSource(config.FeedName)
                    .SetApiKey("NuGet requires the key but Azure DevOps ignores it"));
            }
        });
}
