CREATE PROCEDURE USP_LISTADO_PROV
AS
BEGIN
   SELECT nombre,
          email,
          telefono,
		  direccion
   FROM Proveedor
   WHERE estado = 1
END;

   execute USP_LISTADO_PROV

  

CREATE PROCEDURE USP_GUARDAR_PROV
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


CREATE PROCEDURE ACTIVO_PROV
@id int,
@estado int

AS
 UPDATE ACTIVO_PROV SET estado=@estado
                 where id= @id;

GO




 