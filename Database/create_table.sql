CREATE TABLE TipoCombustivel
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(50) NOT NULL
);

-- Inserindo valores do enum TipoCombustivel
INSERT INTO TipoCombustivel (Nome)
VALUES
    ('GASOLINA'),
    ('DIESEL'),
    ('ETANOL'),
    ('GNV'),
    ('HIBRIDO'),
    ('ELETRICO');
CREATE TABLE Carro
(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Marca NVARCHAR(100) NOT NULL,
    Placa NVARCHAR(10) NOT NULL,
    Cor NVARCHAR(50) NOT NULL,
    AnoFabricacao INT NOT NULL,
    TipoCombustivelId INT FOREIGN KEY REFERENCES TipoCombustivel(Id)
);