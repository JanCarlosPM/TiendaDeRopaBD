INSERT INTO [dbo].[Proveedor] ([nombre], [email], [telefono], [direccion], [estado])
VALUES
    ('Proveedor 1', 'proveedor1@example.com', '123456789', 'Dirección 1', 1),
    ('Proveedor 2', 'proveedor2@example.com', '987654321', 'Dirección 2', 1),
    ('Proveedor 3', 'proveedor3@example.com', '555555555', 'Dirección 3', 1);

	SELECT * FROM Proveedor

INSERT INTO [dbo].[Producto] ([categoria], [tela], [talla], [estilo], [descripcion], [marca], [id_proveedor], [precio], [estado])
VALUES
    ('Camisas', 'Algodón', 'M', 'Casual', 'Camisa de manga larga', 'Marca A', 1, 25.99, 1),
    ('Pantalones', 'Mezclilla', '32', 'Slim Fit', 'Pantalón de mezclilla', 'Marca B', 2, 39.99, 1),
    ('Zapatos', 'Cuero', '42', 'Formal', 'Zapatos de cuero negro', 'Marca C', 3, 59.99, 1);

	SELECT * FROM Producto

	INSERT INTO [dbo].[Inventario] ([id_producto], [existencia], [fecha_ingreso], [estado])
VALUES
    (1, 50, '2024-04-01', 1),
    (2, 30, '2024-04-02', 1),
    (3, 20, '2024-04-03', 1);

	SELECT * FROM Inventario

INSERT INTO [dbo].[Factura] ([cod_factura], [fecha], [subtotal], [iva], [total], [forma_pago], [tipo])
VALUES
    ('FAC001', '2024-04-01 10:00:00', 100.00, 12.00, 112.00, 'Tarjeta de crédito', 1),
    ('FAC002', '2024-04-02 11:30:00', 150.00, 18.00, 168.00, 'Efectivo', 1);

	SELECT * FROM Factura

	INSERT INTO [dbo].[DetalleFactura] ([id_producto_inventario], [cantidad], [precio_venta], [id_factura])
VALUES
    (1, 2, 25.00, 1), 
    (2, 1, 40.00, 1), 
    (3, 3, 50.00, 2), 
    (1, 1, 25.00, 2); 

	SELECT * FROM DetalleFactura
