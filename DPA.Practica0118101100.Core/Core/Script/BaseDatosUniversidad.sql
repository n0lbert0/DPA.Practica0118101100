-- =============================================
-- Crear la base de datos (opcional)
-- =============================================
USE master;
GO

IF DB_ID('UniversidadDB') IS NOT NULL
    DROP DATABASE UniversidadDB;
GO

CREATE DATABASE UniversidadDB;
GO

USE UniversidadDB;
GO

-- =============================================
-- Crear tabla: Carrera
-- =============================================
CREATE TABLE Carrera (
    Id INT PRIMARY KEY IDENTITY(1,1),  -- Autoincremental desde 1
    Nombre NVARCHAR(100) NOT NULL       -- Nombre de la carrera
);
GO

-- =============================================
-- Crear tabla: Estudiante
-- =============================================
CREATE TABLE Estudiante (
    Id INT PRIMARY KEY IDENTITY(1,1),           -- Autoincremental
    Paterno NVARCHAR(50) NOT NULL,              -- Apellido paterno
    Materno NVARCHAR(50) NULL,                  -- Apellido materno (puede ser nulo)
    Nombres NVARCHAR(100) NOT NULL,             -- Nombres del estudiante
    FechaNacimiento DATE NOT NULL,              -- Fecha de nacimiento
    Correo NVARCHAR(100) NOT NULL UNIQUE,       -- Correo único
    CarreraId INT NOT NULL                      -- FK hacia Carrera
);
GO

-- =============================================
-- Crear clave foránea: Estudiante.CarreraId -> Carrera.Id
-- =============================================
ALTER TABLE Estudiante
ADD CONSTRAINT FK_Estudiante_Carrera 
FOREIGN KEY (CarreraId) REFERENCES Carrera(Id);
GO

-- =============================================
-- Índice opcional para mejorar búsquedas por correo
-- =============================================
CREATE INDEX IX_Estudiante_Correo ON Estudiante(Correo);
GO