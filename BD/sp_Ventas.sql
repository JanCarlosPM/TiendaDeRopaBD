--//SP ACTUALIZAR STOCK para ventas
CREATE PROCEDURE SP_ActualizarStockVenta
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
        SELECT @InventarioID = id
        FROM Inventario
        WHERE id_producto = @ProductoID;
        
        -- Verificar si se encontró el producto en el inventario
        IF @InventarioID IS NULL
        BEGIN
            SELECT 'No se encontró ningún producto en el inventario con la categoría especificada.' AS Mensaje;
            RETURN;
        END;

        -- Actualizar el stock del producto en el inventario y la fecha de ingreso
        UPDATE Inventario
        SET existencia = existencia - @Cantidad,
            fecha_ingreso = @FechaIngreso
        WHERE id = @InventarioID;

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
