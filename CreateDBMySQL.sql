CREATE DATABASE ConcesionarioDB;

use ConcesionarioDB;

CREATE TABLE Vehiculo (
    VehiculoID INT PRIMARY KEY IDENTITY(1,1),
    Marca VARCHAR(100) NOT NULL,
    Modelo VARCHAR(100) NOT NULL,
    Año INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    EsImportado BIT NOT NULL
);

CREATE TABLE Coche (
    VehiculoID INT PRIMARY KEY, 
    
    TipoCarroceria VARCHAR(100) NOT NULL,
    
    AcabadoID INT NOT NULL,
    
    FOREIGN KEY (VehiculoID) REFERENCES Vehiculo(VehiculoID),
    FOREIGN KEY (AcabadoID) REFERENCES Acabado(AcabadoID)
);

CREATE TABLE Motor (
    MotorID INT PRIMARY KEY IDENTITY(1,1),
    PotenciaCV INT NOT NULL,
    Cilindrada DECIMAL(3,1) NOT NULL,
    TipoCombustible VARCHAR(50) NOT NULL
);

CREATE TABLE Rueda (
    RuedaID INT PRIMARY KEY IDENTITY(1,1),
    DiametroPulgadas INT NOT NULL,
    AnchoMm INT NOT NULL,
    Perfil INT NULL
);

CREATE TABLE Acabado (
    AcabadoID INT PRIMARY KEY IDENTITY(1,1),
    NombreAcabado VARCHAR(100) NOT NULL,
    MultiplicadorPrecio DECIMAL(3,2) NOT NULL,
    
    MotorID INT NOT NULL,
    RuedaID INT NOT NULL,
    
    FOREIGN KEY (MotorID) REFERENCES Motor(MotorID),
    FOREIGN KEY (RuedaID) REFERENCES Rueda(RuedaID)
);