# BeerScout Readme

![BeerScout Logo](https://example.com/beerscout-logo.png)

Welcome to BeerScout, a beer and brewery finder web application! BeerScout is an evolving project that began as the final capstone at Tech Elevator. It is built using C#, .NET, ASP.NET, ADO.NET, Axios, Vue.js, and utilizes a T-SQL database. This README will provide you with essential information to set up and contribute to the BeerScout project.

## Table of Contents
1. [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
2. [Project Structure](#project-structure)
3. [Development](#development)
4. [Database](#database)
5. [Contributing](#contributing)
6. [License](#license)

## Getting Started

### Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet) (3.1 or higher)
- [Node.js](https://nodejs.org/) (14.x or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the BeerScout repository:

   ```shell
   git clone https://github.com/yourusername/beerscout.git
   cd beerscout
   ```

2. Install required Node.js modules:

   ```shell
   cd beerscout-client
   npm install
   ```

3. Build the .NET application:

   ```shell
   cd beerscout-api
   dotnet build
   ```

4. Create the database:

   - Use SQL Server Management Studio (SSMS) to execute the SQL scripts provided in the `database-scripts` folder.

5. Configure the application:

   - In the `beerscout-api` folder, locate the `appsettings.json` file and update the database connection string as needed.

6. Start the application:

   - Run the API:

     ```shell
     cd beerscout-api
     dotnet run
     ```

   - Run the client:

     ```shell
     cd beerscout-client
     npm run serve
     ```

7. Open your web browser and navigate to `http://localhost:8080` to access BeerScout.

## Project Structure

The BeerScout project has the following structure:

- `beerscout-api`: Contains the .NET Core API for handling beer and brewery data.
- `beerscout-client`: Houses the Vue.js frontend for the BeerScout application.
- `database-scripts`: Includes SQL scripts to create and populate the database.

## Development

During development, you can use the following commands:

- To start the .NET API:

  ```shell
  cd beerscout-api
  dotnet run
  ```

- To start the Vue.js client:

  ```shell
  cd beerscout-client
  npm run serve
  ```

## Database

BeerScout utilizes a T-SQL database to store beer and brewery information. You can find the database schema and sample data in the `database-scripts` folder. To update the database schema, you may need to modify the SQL scripts in this directory.

## Contributing

We welcome contributions to BeerScout! Please follow these guidelines when contributing:

1. Fork the repository and create a new branch for your feature or bug fix.

2. Make your changes and test them thoroughly.

3. Ensure that your code adheres to coding standards and conventions.

4. Create a clear and concise pull request with a detailed description of your changes.

5. Be responsive to any feedback or questions related to your contribution.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

Thank you for your interest in BeerScout! We hope you enjoy using and contributing to this project. If you have any questions or encounter any issues, please feel free to open an issue on GitHub or contact us at beerscout@example.com. Cheers! 🍻
