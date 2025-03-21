# Simple Games Web API

A basic ASP.NET Core Web API that provides endpoints to manage a collection of video games.

## Features

- Get list of all games
- Get game by ID
- Create new game
- Update existing game
- Delete game
- Health check endpoint (/ping)
- API info endpoint (/)

## Prerequisites

- .NET 9.0 SDK or later
- An IDE like Visual Studio or VS Code

## Installation

1. Clone the repository
2. Navigate to the project directory:
   ```bash
   cd dotnet-games-api
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Run the project:
   ```bash
   dotnet run
   ```

The API will start running on http://localhost:5270 by default.