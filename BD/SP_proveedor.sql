CREATE PROCEDURE SP_LISTADO_PROV
@cTexto varchar(80) =''
AS
BEGIN
   SELECT id,
          nombre,
          email,
          telefono,
		  direccion
   FROM Proveedor
   WHERE estado = 1
   AND (nombre LIKE '%' + @cTexto + '%'
        OR email LIKE '%' + @cTexto + '%'
        OR telefono LIKE '%' + @cTexto + '%'
        OR direccion LIKE '%' + @cTexto + '%') -- Filtrar por cualquier columna
   ORDER BY id
END;

  execute USP_LISTADO_PROV


CREATE PROCEDURE SP_GUARDAR_PROV
@opcion int=1, --1=Nuevo Registro / 2=Actualizar Registro 
@id int,
@nombre varchar(50),    
@email varchar(100),    
@telefono varchar(20),    
@direccion varchar(300)
AS    
if @opcion=1 --Nuevo Registro    
 begin    
   INSERT INTO Proveedor(nombre,    
                         email,    
						 telefono,
						 direccion,
						 estado)
                  values(@nombre,    
                         @email,    
                         @telefono,    
                         @direccion,    
                         1);    
   end;    
else --Actualizar Registro    
   begin    
   UPDATE Proveedor SET nombre=@nombre,    
                        email=@email,    
                        telefono=@telefono,    
                        direccion=@direccion   
                   where id=@id;    
   end; 
GO


CREATE PROCEDURE SP_ACTIVO_PROV
@id int,
@estado int

AS
 UPDATE Proveedor SET estado=@estado
                 where id= @id;

GO




 
