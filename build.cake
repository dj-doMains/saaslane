var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var outputDirectory = Directory("./artifacts");

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(outputDirectory);
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore();
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var settings = new DotNetCoreBuildSettings
        {
            Configuration = configuration,
            OutputDirectory = outputDirectory
        };

        var projects = GetFiles("./src/**/*.csproj");
        foreach(var project in projects)
        {
            DotNetCoreBuild(project.FullPath, settings);
        }
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var settings = new DotNetCoreTestSettings
        {
            Configuration = configuration,
            NoBuild = false
        };

        var projects = GetFiles("./tests/**/*.csproj");
        foreach(var project in projects)
        {
            DotNetCoreTest(project.FullPath, settings);
        }
    });

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
    {
        var settings = new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = outputDirectory
        };

		var projects = GetFiles("./src/**/*.csproj");
        foreach (var project in projects)
        {
            DotNetCorePack(project.FullPath, settings);
        }
    });


Task("Default")
	.IsDependentOn("Pack");

RunTarget(target);