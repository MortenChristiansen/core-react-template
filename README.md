# Requirements

- [.NET Core](https://www.microsoft.com/net/download)
- [Node.js](https://nodejs.org/)

# Building and running the app

Ensure you have an environment variable called `ASPNETCORE_Environment` with value of `Development`. On Windows (in non-PowerShell prompts), run `SET ASPNETCORE_Environment=Development`. On Linux or macOS, run `export ASPNETCORE_Environment=Development`.

Run `dotnet build` to verify your app builds correctly. On the first run, the build process restores npm dependencies, which can take several minutes. Subsequent builds are much faster.

Run `dotnet run` to start the app.