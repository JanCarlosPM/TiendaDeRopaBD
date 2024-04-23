USE TiendaRopa
GO

-- SP para ingresar un nuevo producto
CREATE OR ALTER PROCEDURE [dbo].[SP_InsertarProducto]
    @categoria NVARCHAR(50),
    @tela NVARCHAR(50),
    @talla NVARCHAR(5),
    @estilo NVARCHAR(50),
    @descripcion NVARCHAR(200),
    @marca NVARCHAR(50),
    @nombre_proveedor NVARCHAR(50),
    @precio FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @id_proveedor INT;

    -- Buscar el ID del proveedor en base a su nombre
    SELECT @id_proveedor = id
    FROM Proveedor
    WHERE nombre = @nombre_proveedor;

    -- Insertar el producto si se encontró el proveedor
    IF @id_proveedor IS NOT NULL
    BEGIN
        INSERT INTO Producto (categoria, tela, talla, estilo, descripcion, marca, id_proveedor, precio, estado)
        VALUES (@categoria, @tela, @talla, @estilo, @descripcion, @marca, @id_proveedor, @precio, 1);

        PRINT 'Producto insertado correctamente.';
    END
    ELSE
    BEGIN
        PRINT 'El proveedor con nombre ' + @nombre_proveedor + ' no existe.';
    END
END
GO
        
CREATE OR ALTER PROCEDURE [dbo].[SP_ListarProductos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        P.categoria, 
        P.tela, 
        P.talla, 
        P.estilo, 
        P.descripcion, 
        P.marca,
        PR.nombre AS proveedor,
        P.precio
    FROM 
        Producto AS P
    INNER JOIN
        Proveedor AS PR ON P.id_proveedor = PR.id;
END;
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_EditarProducto]
    @categoria NVARCHAR(50),
    @tela NVARCHAR(50),
    @talla NVARCHAR(5),
    @estilo NVARCHAR(50),
    @descripcion NVARCHAR(200),
    @marca NVARCHAR(50),
    @nombre_proveedor NVARCHAR(50),
    @precio FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @id_proveedor INT;

    SELECT @id_proveedor = id
    FROM Proveedor
    WHERE nombre = @nombre_proveedor;

    IF @id_proveedor IS NOT NULL
    BEGIN
        UPDATE Producto
        SET tela = @tela,
            talla = @talla,
            estilo = @estilo,
            descripcion = @descripcion,
            marca = @marca,
            id_proveedor = @id_proveedor,
            precio = @precio
        WHERE categoria = @categoria;

        PRINT 'Producto editado correctamente.';
    END
    ELSE
    BEGIN
        PRINT 'El proveedor con nombre ' + @nombre_proveedor + ' no existe.';
    END
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_ObtenerNombresProveedores]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT nombre FROM Proveedor WHERE estado = 1;
END
GO
