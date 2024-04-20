--//SP ACTUALIZAR STOCK
ALTER PROCEDURE [dbo].[SP_ActualizarStock]
    @categorias NVARCHAR(MAX),
    @cantidades NVARCHAR(MAX),
    @fechasIngreso NVARCHAR(MAX)
AS
BEGIN
    DECLARE @CategoriaList TABLE (Categoria NVARCHAR(MAX));
    DECLARE @CantidadList TABLE (Cantidad INT);
    DECLARE @FechaIngresoList TABLE (FechaIngreso DATE);
    
    INSERT INTO @CategoriaList (Categoria) SELECT value FROM STRING_SPLIT(@categorias, ',');
    INSERT INTO @CantidadList (Cantidad) SELECT value FROM STRING_SPLIT(@cantidades, ',');
    INSERT INTO @FechaIngresoList (FechaIngreso) SELECT value FROM STRING_SPLIT(@fechasIngreso, ',');

    DECLARE @Categoria NVARCHAR(MAX), @Cantidad INT, @FechaIngreso DATE;

    DECLARE cursorCategoria CURSOR FOR SELECT Categoria FROM @CategoriaList;
    DECLARE cursorCantidad CURSOR FOR SELECT Cantidad FROM @CantidadList;
    DECLARE cursorFecha CURSOR FOR SELECT FechaIngreso FROM @FechaIngresoList;

    OPEN cursorCategoria;
    OPEN cursorCantidad;
    OPEN cursorFecha;

    FETCH NEXT FROM cursorCategoria INTO @Categoria;
    FETCH NEXT FROM cursorCantidad INTO @Cantidad;
    FETCH NEXT FROM cursorFecha INTO @FechaIngreso;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @ProductoID INT;
        DECLARE @InventarioID INT;
        DECLARE @EstadoAnterior INT;

        -- Obtener el ID del producto en base a la categoría
        SELECT @ProductoID = id
        FROM Producto
        WHERE categoria = @Categoria;
        
        -- Verificar si se encontró el producto
        IF @ProductoID IS NULL
        BEGIN
            SELECT 'No se encontró ningún producto con la categoría especificada.' AS Mensaje;
            RETURN;
        END;

        -- Obtener el ID del producto en el inventario
        SELECT @InventarioID = id, @EstadoAnterior = estado
        FROM Inventario
        WHERE id_producto = @ProductoID;

        -- Si no existe un registro en el inventario, lo creamos con un estado predeterminado
        IF @InventarioID IS NULL
        BEGIN
            INSERT INTO Inventario (id_producto, existencia, fecha_ingreso, estado)
            VALUES (@ProductoID, @Cantidad, @FechaIngreso, 1); -- Aquí se asigna el estado predeterminado
        END
        ELSE
        BEGIN
            -- Actualizar el stock del producto en el inventario y la fecha de ingreso
            UPDATE Inventario
            SET existencia = existencia + @Cantidad,
                fecha_ingreso = @FechaIngreso
            WHERE id = @InventarioID;

            -- Si el producto estaba en estado "2", cambiarlo a estado "1"
            IF @EstadoAnterior = 2
            BEGIN
                UPDATE Inventario
                SET estado = 1
                WHERE id = @InventarioID;
            END;
        END;

        -- Actualizar el estado del producto
        UPDATE Producto
        SET estado = (CASE WHEN @Cantidad > 0 THEN 1 ELSE 2 END) -- Si la cantidad es positiva, estado = 1, de lo contrario, estado = 2
        WHERE id = @ProductoID;

        FETCH NEXT FROM cursorCategoria INTO @Categoria;
        FETCH NEXT FROM cursorCantidad INTO @Cantidad;
        FETCH NEXT FROM cursorFecha INTO @FechaIngreso;
    END

    CLOSE cursorCategoria;
    CLOSE cursorCantidad;
    CLOSE cursorFecha;
    DEALLOCATE cursorCategoria;
    DEALLOCATE cursorCantidad;
    DEALLOCATE cursorFecha;
    
    SELECT 'El stock del producto se actualizó correctamente.' AS Mensaje;
END;

--//SP LISTAR INVENTARIO
CREATE PROCEDURE SP_ListarInventario
AS
BEGIN
    SELECT P.categoria,
           P.tela,
           P.talla,
           P.estilo,
           P.descripcion,
           P.marca,
           P.precio,
           I.existencia,
           I.fecha_ingreso
    FROM Inventario AS I
    INNER JOIN Producto AS P ON I.id_producto = P.id
    WHERE I.estado <> 2;
END;

    
--//SP GUARDAR DETALLES FACTURA
    
CREATE PROCEDURE SP_DetalleFactura
    @categorias NVARCHAR(MAX),
    @cantidades NVARCHAR(MAX),
    @precios NVARCHAR(MAX),
    @cod_factura NCHAR(10)
AS
BEGIN
    DECLARE @id_factura INT;

    -- Buscar el ID de la factura basado en el cod_factura
    SELECT @id_factura = id FROM Factura WHERE cod_factura = @cod_factura;

    -- Verificar si se encontró la factura
    IF @id_factura IS NULL
    BEGIN
        SELECT 'No se encontró la factura con el código especificado.' AS Mensaje;
        RETURN;
    END;

    DECLARE @CategoriaList TABLE (Categoria NVARCHAR(MAX));
    DECLARE @CantidadList TABLE (Cantidad INT);
    DECLARE @PrecioList TABLE (PrecioVenta FLOAT);
    
    INSERT INTO @CategoriaList (Categoria) SELECT value FROM STRING_SPLIT(@categorias, ',');
    INSERT INTO @CantidadList (Cantidad) SELECT value FROM STRING_SPLIT(@cantidades, ',');
    INSERT INTO @PrecioList (PrecioVenta) SELECT value FROM STRING_SPLIT(@precios, ',');
    
    DECLARE @Categoria NVARCHAR(MAX), @Cantidad INT, @PrecioVenta FLOAT;

    DECLARE cursorCategoria CURSOR FOR SELECT Categoria FROM @CategoriaList;
    DECLARE cursorCantidad CURSOR FOR SELECT Cantidad FROM @CantidadList;
    DECLARE cursorPrecio CURSOR FOR SELECT PrecioVenta FROM @PrecioList;

    OPEN cursorCategoria;
    OPEN cursorCantidad;
    OPEN cursorPrecio;

    FETCH NEXT FROM cursorCategoria INTO @Categoria;
    FETCH NEXT FROM cursorCantidad INTO @Cantidad;
    FETCH NEXT FROM cursorPrecio INTO @PrecioVenta;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @ProductoID INT;
        DECLARE @InventarioID INT;

        -- Obtener el ID del producto en base a la categoría
        SELECT @ProductoID = id
        FROM Producto
        WHERE categoria = @Categoria;
        
        -- Obtener el ID del producto en el inventario
        SELECT @InventarioID = id
        FROM Inventario
        WHERE id_producto = @ProductoID;
        
        -- Insertar el detalle de factura
        INSERT INTO DetalleFactura (id_producto_inventario, cantidad, precio_venta, id_factura)
        VALUES (@InventarioID, @Cantidad, @PrecioVenta, @id_factura);

        FETCH NEXT FROM cursorCategoria INTO @Categoria;
        FETCH NEXT FROM cursorCantidad INTO @Cantidad;
        FETCH NEXT FROM cursorPrecio INTO @PrecioVenta;
    END

    CLOSE cursorCategoria;
    CLOSE cursorCantidad;
    CLOSE cursorPrecio;
    DEALLOCATE cursorCategoria;
    DEALLOCATE cursorCantidad;
    DEALLOCATE cursorPrecio;
    
    SELECT 'Todos los detalles de la factura se registraron correctamente.' AS Mensaje;
END;

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
