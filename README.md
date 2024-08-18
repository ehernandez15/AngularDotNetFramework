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


### Paso 3: Crear el backend en .NET Framework

##### 3.1. Crear un proyecto de API en .NET Framework
Abre Visual Studio.

Crea un nuevo proyecto de tipo ASP.NET Web Application (.NET Framework). 
        
Selecciona Web API como el tipo de proyecto.

##### 3.2. Configurar Entity Framework
Instala Entity Framework mediante NuGet Package Manager.
        
Install-Package EntityFramework

Configura el DbContext y las entidades.

En el proyecto crear una carpeta llamada Data

Dentro de ella crear la clase AppDbContext.cs

Agregar la string de conexion al Web.config, agregarla dentro de la etiqueta configuration

          <connectionStrings>
            <add name="AppDbContext" connectionString="Data Source=localhost;Initial Catalog=ShoppingCartDB;Integrated Security=True;" providerName="System.Data.SqlClient" />
          </connectionStrings>