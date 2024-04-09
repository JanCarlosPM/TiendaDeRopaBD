--//SP INVENTARIO

CREATE PROCEDURE [dbo].[SP_Inventario]
    @id_producto_inventario INT,
    @cantidad_comprada INT
AS
BEGIN
    UPDATE Inventario
    SET existencia = existencia + @cantidad_comprada
    WHERE id = @id_producto_inventario;
END;
GO

--//SP GUARDAR FACTURA

CREATE PROCEDURE [dbo].[SP_GuardarFactura]
    @cod_factura NCHAR(10),
    @fecha DATETIME,
    @subtotal FLOAT,
    @iva FLOAT,
    @total FLOAT,
    @forma_pago NVARCHAR(50),
    @tipo INT
AS
BEGIN
    INSERT INTO Factura (cod_factura, fecha, subtotal, iva, total, forma_pago, tipo)
    VALUES (@cod_factura, @fecha, @subtotal, @iva, @total, @forma_pago, @tipo);
END;
GO

--//SP LISTAR PRODUCTOS

CREATE PROCEDURE [dbo].[SP_ListarProductos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        categoria, 
        tela, 
        talla, 
        estilo, 
        descripcion, 
        marca, 
        precio
    FROM 
        Producto;
END;
GO

--//SP NUMERO DE FACTURA

CREATE PROCEDURE [dbo].[SP_NumeroFactura]
AS
BEGIN
    DECLARE @UltimoNumeroFactura INT;

    -- Obtener el último número de factura registrado
    SELECT @UltimoNumeroFactura = MAX(CAST(SUBSTRING(cod_factura, 4, LEN(cod_factura)) AS INT))
    FROM Factura;

    -- Si no hay registros, iniciar desde 1
    IF @UltimoNumeroFactura IS NULL
    BEGIN
        SET @UltimoNumeroFactura = 0;
    END

    -- Generar el próximo número de factura
    DECLARE @ProximoNumeroFactura VARCHAR(10);
    SET @ProximoNumeroFactura = 'FAC' + RIGHT('0000' + CAST(@UltimoNumeroFactura + 1 AS VARCHAR(5)), 4);

    -- Devolver el próximo número de factura
    SELECT @ProximoNumeroFactura AS NuevoNumeroFactura;
END;
GO

--//SP LISTAR PRODUCTOS POR FILTRO (CATEGORIA)

CREATE PROCEDURE [dbo].[SP_ObtenerProductosFiltro]
    @categoria NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        categoria, 
        tela, 
        talla, 
        estilo, 
        descripcion, 
        marca, 
        precio
    FROM 
        Producto
    WHERE 
        @categoria IS NULL OR categoria = @categoria;
END;
GO