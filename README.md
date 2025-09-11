# Skeleton Project for .NET with DDD

This project aims to be a skeleton for future projects using .NET Core with DDD pattern.



The project is setup with Entity Framework, and is configured to utilize PostgreSQL as the database, however it can easily be changed into another database.



## 🌟 About The Project

The goal of the project was to have a initial architecture to rely on when creating new projects, without having to research and create a new one from scratch. This project has basic functionalities such as authentication, policies, separation of concerns, persistence on the database, and as efficient design based on clean architecture.



## ✨ Layers

⦁	API: The API layer is responsible for handling requests, basic authentication, authorization.



⦁	Application: The Application orchestrates the entire system, calling the appropriate methods and mapping resulting entities to DTOs, it is basically a bridge between the API to the core of the project.



⦁	Domain: The Domain is the main core of the system, handling the business logic, whether validating new entities or updating their values, it also defines contracts to be fulfilled by the repository.



⦁	Infrastructure: The Infrastructure is the persistence layer, where all communication with the database happens, it is responsible of storing and retrieving data.



⦁	Unit Tests: The Unit Tests are a safety measure to help development validating if new code changes doesn’t impact old methods, assuring they still behave in the intended way.



## 💻 Built With

⦁	.NET 8.0 (C#)



⦁	Entity Framework Core 9.0.8



⦁	PostgreSQL



## 🚀 Getting Started

Download the .NET C# editor of your preference, for personal projects I usually like Visual Studio Community.



https://visualstudio.microsoft.com/pt-br/vs/community/



If you plan on keep using PostgreSQL, you can find at:



https://www.postgresql.org/download/



## 📦 Installation

Clone the repo

```

gh repo clone vmarjunior/skeleton-repository

```



Navigate and change your default connection in appsettings.json

```

PUT YOUR CONNECTION STRING HERE:

"DefaultConnection": "Host=localhost;Port=5432;Database=MySolutionDB;Username=admin;Password=admin"

```



Delete the migration folder if you altered the database, and run the migrations again on PowerShell:

```

Navigate to the API Project with 'cd API'



RUN 1: dotnet ef migrations add UserUpdate -s '../API' -p '../Infrastructure'

RUN 2: dotnet ef database update

```



## 📖 Usage

The project uses the SwaggerUI to expose the controllers, to authenticate with the users seeded to the user table you can use the following:

```

1.Admin User (Full Access):

Email: admin@admin.com

Password: admin

```

```

2.Auditor User (Limited Access):

Email: audit@audit.com

Password: admin

```

