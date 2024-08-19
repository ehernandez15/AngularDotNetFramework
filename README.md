# AngularDotNetFramework
Application created with C# .Net Framework, EntityFramework, SQL Server and Angular

### Step 1: Environment Setup

##### 1.1. Installation of Necessary Tools

*  Visual Studio 2019 or 2022 for backend development in .NET Framework. (Install all dependencies needed for .Net Framework 4.7.2)

* Node.js for Angular development.

* SQL Server for the database.

* Postman for API testing.

* Angular CLI for creating and managing the frontend in Angular.

##### 1.2. Configure NuGet to use online sources:

Open the NuGet configuration:

In Visual Studio, go to Tools > NuGet Package Manager > Package Manager Settings.

Configure package sources:

In the left menu, select Package Sources.

Here, you will see a list of available package sources. There may only be a local source checked.

To add the official NuGet repository, click the add (+) button.

Add the official NuGet source:

In the Name field, you can enter a descriptive name like "NuGet Official."

In the Source field, enter the URL of the official NuGet repository: https://api.nuget.org/v3/index.json.

Click Update or Add to save the configuration.

##### 1.3. Versions used for this project:

* .Net Framework 4.7.2 

* EntityFramework 6.5.1

* SQL Server 16 

* Angular CLI: 17.3.8

* Node: 22.2.0 (Unsupported)

* Package Manager: npm 10.7.0


### Step 2: Create the Database in SQL Server

##### 2.1. Database Design

Use the DBCreation script to create the following tables: 

* Galleries
* Artworks
* Artists

ER diagram 

    Galleries
    +------------------------+
    | GalleryId (PK)         |
    | Name                   |
    | Location               |
    | EstablishmentDate      |
    | Description            |
    +------------------------+
            | 1
            |
            | N
    +------------------------+
    | Artworks               |
    +------------------------+
    | ArtworkId (PK)         |
    | Title                  |
    | CreationDate           |
    | Type                   |
    | Description            |
    | GalleryId (FK)         |
    | ArtistId (FK)          |
    | EstimatedValue         |
    +------------------------+
            | N
            |
            | 1
    +------------------------+
    | Artists                |
    +------------------------+
    | ArtistId (PK)          |
    | Name                   |
    | BirthDate              |
    | DeathDate              |
    | Nationality            |
    | Biography              |
    +------------------------+

### Step 3: Create the Backend in .NET Framework
##### 3.1. Create an API Project in .NET Framework
Open Visual Studio.

Create a new project of type ASP.NET Web Application (.NET Framework).

Select Web API as the project type.

##### 3.2. Configure Entity Framework
Install Entity Framework using NuGet Package Manager.

    Install-Package EntityFramework

Configure the **DbContext** and entities.

In the project, create a folder named **Data**.

Inside it, create the **AppDbContext.cs** class.

Add the connection string to **Web.config**, placing it inside the configuration tag.

          <connectionStrings>
            <add name="AppDbContext" connectionString="Data Source=localhost;Initial Catalog=ShoppingCartDB;Integrated Security=True;" providerName="System.Data.SqlClient" />
          </connectionStrings>


 Inside the **Data** folder, create a folder named **Entities**. These classes will contain the models that represent the tables in the database. These models should have the same structure, attributes, and equivalent data types from SQL to C#.


##### 3.3. Create the DTOs for each DB entity
In the **Models** folder, create a new folder named **Dtos**.

DTOs are crucial for managing data transfer efficiently and securely in an application. They provide a means to:

* Encapsulate and structure data.
* Improve performance by reducing data transfer sizes.
* Enhance security by hiding sensitive information.
* Separate concerns and decouple application layers.
* Simplify communication and maintain flexibility in data management.

Inside the **Dtos** folder, create the classes **GalleryDTO**, **ArtistDTO**, and **ArtworkDTO**.

##### 3.4. Create Controllers for the API

Install Microsoft.AspNet.WebApi from NuGet Package Manager.

Within the **Controllers** folder of the project, create a folder named **API**. Inside that folder, create an API controller for each of the entities in the database.

    Right-click on the folder, select Add Controller, then 
    choose Web API Controller - Empty.

* **GalleryAPIController**
* **ArtworkAPIController**
* **ArtistAPIController**

Add the corresponding logic for each controller.

Ensure that the configuration in Global.asax.cs contains the line

    GlobalConfiguration.Configure(WebApiConfig.Register);

This line should be added before the line

    RouteConfig.RegisterRoutes(RouteTable.Routes);

Otherwise, the route configuration for the Web API controllers will be overwritten.                

To test the endpoints, you can import the Postman collection in the repository named 

    AngularDotNetFramework.postman_collection.json






        