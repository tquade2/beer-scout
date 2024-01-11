## Overview

This project marked the culmination of my efforts, alongside two talented collaborators, [Daniel Kennedy](https://www.linkedin.com/in/daniel-kennedy-/) and [Garrett Choate](https://www.linkedin.com/in/garrettchoate/), as our final capstone project during our time at Tech Elevator's coding bootcamp in Columbus, OH.

This project is a full-stack application that uses Vue.js for the frontend, C#/.NET for the backend, and MS SQL Server Managment Studio (SSMS) for the database. The application is a beer scouting platform where users and brewers can view, add, and edit information about beers and breweries.

## Frontend

The frontend of the application is built with Vue.js and is located in the `vue` directory. It uses Vuex for state management, as mentioned in `vue/README.md`. The application's views are located in `vue/src/views` and include pages for viewing, adding, and editing beers and breweries, as well as user registration and login.

## Backend

The backend of the application is built with C#/.NET and is located in the `dotnet` directory. It includes a BeerScout project, as seen in `dotnet/BeerScout/BeerScout.csproj`. The backend handles API requests from the frontend and interacts with the database. It also includes security features, as mentioned in `dotnet/README.md`.

## Database

The database for the application is built with Microsoft SQL Server Managment Studio (SSMS). The SQL script for the database is located in `database/capstone.sql`.

## Development

For development instructions, please refer to the README files in the `vue` and `dotnet` directories.
