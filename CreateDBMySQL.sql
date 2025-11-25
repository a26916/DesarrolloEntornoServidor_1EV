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