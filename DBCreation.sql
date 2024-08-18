-- Create the database
CREATE DATABASE ArtGallery;
GO

-- Use the newly created database
USE ArtGallery;
GO

-- Create the Galleries table
CREATE TABLE Galleries
(
    GalleryId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(200),
    EstablishmentDate DATETIME2,
    Description TEXT
);
GO

-- Create the Artists table
CREATE TABLE Artists
(
    ArtistId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    BirthDate DATETIME2,
    DeathDate DATETIME2 NULL,
    Nationality NVARCHAR(50),
    Biography TEXT
);
GO

-- Create the Artworks table
CREATE TABLE Artworks
(
    ArtworkId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    CreationDate DATETIME,
    Type NVARCHAR(100),
    Description TEXT,
    GalleryId INT,
    ArtistId INT,
    EstimatedValue DECIMAL(18, 2),

    -- Define foreign keys
    FOREIGN KEY (GalleryId) REFERENCES Galleries(GalleryId),
    FOREIGN KEY (ArtistId) REFERENCES Artists(ArtistId)
);
GO
