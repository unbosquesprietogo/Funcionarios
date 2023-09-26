create database BASEDEDATOS1;

use BASEDEDATOS1;

DROP TABLE Funcionario;
-- Crear la tabla de Funcionarios
CREATE TABLE Funcionario (
    idFuncionario INT PRIMARY KEY,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    fechaNacimiento DATE,
    documentoIdentificacion VARCHAR(20)
);

DROP TABLE Contacto;
-- Crear la tabla de Contacto
CREATE TABLE Contacto (
    idContacto INT PRIMARY KEY,
    correoElectronico VARCHAR(100),
    telefono VARCHAR(20),
    fax VARCHAR(20),
    idFuncionario INT,
    FOREIGN KEY (idFuncionario) REFERENCES Funcionario(idFuncionario)
);

DROP TABLE Ubicacion;
-- Crear la tabla de Ubicación
CREATE TABLE Ubicacion (
    idUbicacion INT PRIMARY KEY,
    ciudad VARCHAR(50),
    pais VARCHAR(50),
    idFuncionario INT,
    FOREIGN KEY (idFuncionario) REFERENCES Funcionario(idFuncionario)
);

DROP TABLE Direccion;
-- Crear la tabla de Direccion
CREATE TABLE Direccion (
    idDireccion INT PRIMARY KEY,
    calle VARCHAR(50),
    carrera VARCHAR(50),
    numero INT,
    complemento VARCHAR(50),
    idUbicacion INT,
    FOREIGN KEY (idUbicacion) REFERENCES Ubicacion(idUbicacion)
);

INSERT INTO Funcionario (idFuncionario, nombre, apellido, fechaNacimiento, documentoIdentificacion)
VALUES
(1, 'Juan', 'Perez', '1990-05-15', '12345'),
(2, 'Maria', 'Gomez', '1985-08-20', '54321'),
(3, 'Carlos', 'Lopez', '1992-03-10', '78901');


INSERT INTO Contacto (idContacto, correoElectronico, telefono, fax, idFuncionario)
VALUES
(1, 'juan.perez@email.com', '123456789', '987654321', 1),
(2, 'maria.gomez@email.com', '987654321', '123456789', 2),
(3, 'carlos.lopez@email.com', '111111111', '222222222', 3);


INSERT INTO Ubicacion (idUbicacion, ciudad, pais, idFuncionario)
VALUES
(1, 'Ciudad A', 'Pais 1', 1),
(2, 'Ciudad B', 'Pais 2', 2),
(3, 'Ciudad C', 'Pais 3', 3);

INSERT INTO Direccion (idDireccion, calle, carrera, numero, complemento, idUbicacion)
VALUES
(1, 'Calle 123', 'Carrera 456', 789, 'Complemento 1', 1),
(2, 'Calle 789', 'Carrera 101', 112, 'Complemento 2', 2),
(3, 'Calle 333', 'Carrera 555', 777, 'Complemento 3', 3);


create procedure sp_ObtenerFuncionarios
as
begin
	select * from Funcionario
end;

CREATE PROCEDURE sp_ObtenerFuncionario
    @idFuncionario INT
AS
BEGIN
    SELECT
        idFuncionario,
        nombre,
        apellido,
        fechaNacimiento,
        documentoIdentificacion
    FROM
        Funcionario
    WHERE
        idFuncionario = @idFuncionario;
END;