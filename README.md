# NBA Statistics API

An ASP.NET Core Web API that provides NBA player statistics for the Houston Rockets during the 2025 season. The API fetches data from an external NBA service and exposes endpoints for player information and stats.

## Features

- List all Houston Rockets player statistics for the 2025 season
- Retrieve detailed stats for a specific player by ID
- Pagination support for large datasets
- OpenAPI (Scalar) documentation available in development

## Technologies

- C\#
- ASP.NET Core
- System.Text.Json
- Scalar.AspNetCore (OpenAPI integration)

## Getting Started

1. **Clone the repository:**
   ```
   git clone <repository-url>
   ```

2. **Navigate to the project folder:**
   ```
   cd NbaStatistics
   ```

3. **Run the application:**
   ```
   dotnet run
   ```

## API Endpoints

- `GET /Player`  
  Returns a list of all player statistics.

- `GET /Player/{playerId}`  
  Returns statistics for a specific player.

## Configuration

- API settings and logging levels can be adjusted in `appsettings.json` and `appsettings.Development.json`.
