-- Insertar carreras
INSERT INTO Carrera (Nombre) VALUES 
('Ingeniería de Sistemas'),
('Administración de Empresas'),
('Medicina'),
('Derecho');
GO

-- Insertar estudiantes
INSERT INTO Estudiante (Paterno, Materno, Nombres, FechaNacimiento, Correo, CarreraId) VALUES
('Pérez', 'Gómez', 'Juan', '2000-05-15', 'juan.perez@universidad.edu', 1),
('López', 'Martínez', 'Ana María', '1999-08-22', 'ana.lopez@universidad.edu', 2),
('García', NULL, 'Carlos', '2001-03-10', 'carlos.garcia@universidad.edu', 1),
('Mendoza', 'Rojas', 'Lucía', '1998-11-30', 'lucia.mendoza@universidad.edu', 3);
GO