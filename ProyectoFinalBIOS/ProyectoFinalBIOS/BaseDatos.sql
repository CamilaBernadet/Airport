use master
go

------------------------------------------------------------------------------------------------------------------
if exists(Select * FROM SysDataBases WHERE name='ProyectoFinalBIOS')
BEGIN
	DROP DATABASE ProyectoFinalBIOS
END
go

CREATE DATABASE ProyectoFinalBIOS
go

------------------------------------------------------------------------------------------------------------------

USE ProyectoFinalBIOS

------------------------------------------------------------------------------------------------------------------
----------- TABLAS -----------------  
------------------------------------------------------------------------------------------------------------------


CREATE TABLE EMPLEADOS
(	
	Usuario varchar(20) PRIMARY KEY NOT NULL,
	ContraseñaEmpleado varchar(20) NOT NULL,
	NombreEmpleado varchar(20) NOT NULL,
	Labor varchar(20) NOT NULL
)

CREATE TABLE CLIENTES
(
	Pasaporte varchar(9) PRIMARY KEY NOT NULL,
	NombreCliente varchar(20) NOT NULL,
	NroTarjeta int NOT NULL,
	ContraseñaCliente varchar(20) NOT NULL
)

CREATE TABLE CIUDAD
(
	CodigoCiudad varchar(6) PRIMARY KEY NOT NULL,
	NombreCiudad varchar(20) NOT NULL,
	Pais varchar (20) NOT NULL
)


CREATE TABLE AEROPUERTOS
(
	CodigoAeropuerto varchar(3)PRIMARY KEY NOT NULL,
	NombreAeropuerto varchar(40) NOT NULL,
	DireccionAeropuerto  varchar(40) NOT NULL,
	ImpuestosPartida int NOT NULL,
	ImpuestosLlegada int NOT NULL,
	CodigoCiudad varchar(6) NOT NULL FOREIGN KEY REFERENCES CIUDAD(CodigoCiudad)
)

CREATE TABLE VUELOS
(
	CodigoVuelo varchar(15) PRIMARY KEY NOT NULL,
	FechaHoraSalida date NOT NULL,
	FechaHoraLlegada date NOT NULL,
	Precio int NOT NULL,
	CantidadAsientos int NOT NULL,
	AeropuertoLlegada varchar(3) NOT NULL FOREIGN KEY REFERENCES AEROPUERTOS(CodigoAeropuerto),
	AeropuertoSalida varchar(3) NOT NULL FOREIGN KEY REFERENCES AEROPUERTOS(CodigoAeropuerto)
	
)

CREATE TABLE PASAJES
(
	NroVenta int IDENTITY PRIMARY KEY NOT NULL,
	PrecioTotal int NOT NULL,
	FechaCompra datetime  NOT NULL,
	CodigoVuelo varchar(15) NOT NULL FOREIGN KEY REFERENCES VUELOS(CodigoVuelo),
	Pasaporte varchar(9) NOT NULL FOREIGN KEY REFERENCES CLIENTES(Pasaporte)
		
)


----------------------------------------------------------------------------------------------------------------------
 ----------- DATOS DE PRUEBA -----------------
----------------------------------------------------------------------------------------------------------------------

INSERT INTO CLIENTES(Pasaporte, NombreCliente, NroTarjeta, ContraseñaCliente) VALUES('A00033123', 'Alejandra', 123456789, 'ContraA')
INSERT INTO CLIENTES(Pasaporte, NombreCliente, NroTarjeta, ContraseñaCliente) VALUES('D00044545', 'Esteban', 987654321, 'ContraB')
INSERT INTO CLIENTES(Pasaporte, NombreCliente, NroTarjeta, ContraseñaCliente) VALUES('G00055678', 'Nicolas', 135798642, 'ContraC' )

INSERT INTO EMPLEADOS(Usuario, ContraseñaEmpleado, NombreEmpleado, Labor) VALUES('LuisM', 'ContraD', 'Luis Miguel', 'Gerente')
INSERT INTO EMPLEADOS(Usuario, ContraseñaEmpleado, NombreEmpleado, Labor) VALUES('CarlaV','ContraE', 'Carla Veras', 'Vendedor')
INSERT INTO EMPLEADOS(Usuario, ContraseñaEmpleado, NombreEmpleado, Labor) VALUES('AlexB', 'ContraF', 'Alex Bequielle', 'Admin')

INSERT INTO CIUDAD(CodigoCiudad, NombreCiudad, Pais) VALUES('MVDURU', 'Montevideo', 'Uruguay')
INSERT INTO CIUDAD(CodigoCiudad, NombreCiudad, Pais) VALUES('BSASAR', 'Buenos Aires', 'Argentina')
INSERT INTO CIUDAD(CodigoCiudad, NombreCiudad, Pais) VALUES('RDJBRA', 'Rio de Janeiro', 'Brasil')


INSERT INTO AEROPUERTOS(CodigoAeropuerto, NombreAeropuerto, DireccionAeropuerto, ImpuestosLlegada, ImpuestosPartida, CodigoCiudad) VALUES('MVD', 'Aeropuerto de Carrasco', 'Avenida de las Américas', 100, 0, 'MVDURU')
INSERT INTO AEROPUERTOS(CodigoAeropuerto, NombreAeropuerto, DireccionAeropuerto, ImpuestosLlegada, ImpuestosPartida, CodigoCiudad) VALUES('EZE', 'Aeropuerto Internacional Ezeiza', 'Gral. Pablo Riccheri',500, 0, 'BSASAR')

INSERT INTO VUELOS(CodigoVuelo, Precio, CantidadAsientos, FechaHoraSalida, FechaHoraLlegada, AeropuertoLlegada, AeropuertoSalida) VALUES('202701202050MVD', 1000,  200, '20/01/2027 2:50:00', '20/06/2028 12:50:00', 'MVD', 'EZE')
INSERT INTO VUELOS(CodigoVuelo, Precio, CantidadAsientos, FechaHoraSalida, FechaHoraLlegada, AeropuertoLlegada, AeropuertoSalida) VALUES('202502051130EZE', 800 ,  180, '06/05/2024 1:30:00', '05/04/2028 13:50:00', 'EZE', 'MVD')
INSERT INTO VUELOS(CodigoVuelo, Precio, CantidadAsientos, FechaHoraSalida, FechaHoraLlegada, AeropuertoLlegada, AeropuertoSalida) VALUES('202601202050MVD', 1000,  200, '20/01/2026 2:50:00', '20/03/2027 12:50:00', 'MVD', 'EZE')
INSERT INTO VUELOS(CodigoVuelo, Precio, CantidadAsientos, FechaHoraSalida, FechaHoraLlegada, AeropuertoLlegada, AeropuertoSalida) VALUES('202505061130EZE', 800 ,  180, '05/06/2024 1:30:00', '05/03/2028 13:50:00', 'EZE', 'MVD')

INSERT INTO PASAJES(PrecioTotal, FechaCompra, CodigoVuelo, Pasaporte) VALUES(1100, '10/03/2024', '202701202050MVD', 'A00033123')
INSERT INTO PASAJES(PrecioTotal, FechaCompra, CodigoVuelo, Pasaporte) VALUES(1300, '20/01/2026', '202502051130EZE', 'D00044545')


----------------------------------------------------------------------------------------------------------------------
 ----------- PROCEDIMIENTOS ALMACENADOS -----------------
----------------------------------------------------------------------------------------------------------------------


------------------------ P U B L I C O ---------------------------------------------------------------------------------------

CREATE PROCEDURE LogueoCliente 
@Pasaporte varchar(9), @ContraseñaCli varchar(20) 
AS
Begin
	Select *
	From CLIENTES C
	Where C.Pasaporte = @Pasaporte AND C.ContraseñaCliente = @ContraseñaCli
End
go 

CREATE PROCEDURE LogueoEmpleado
@Usuario varchar(15), @ContraseñaEmp varchar(20) 
AS
Begin
	Select *
	From EMPLEADOS E
	Where E.Usuario = @Usuario AND E.ContraseñaEmpleado = @ContraseñaEmp
End
go 

create PROCEDURE ListarVuelosporAeropuertos
@aero varchar(3)
AS
Begin
	Select AeropuertoLlegada, CodigoVuelo, FechaHoraLlegada, FechaHoraSalida, AeropuertoSalida
	From VUELOS V
	Where V.AeropuertoLlegada = @aero OR V.AeropuertoSalida = @aero
End
Go

--exec ListarVuelosporAeropuertos 'EZE'

create PROCEDURE ListarVuelosSinPartir
@aero varchar(3)
AS
Begin
	Select *
	From VUELOS V
	Where GETDATE() < FechaHoraSalida AND V.AeropuertoSalida = @aero
	ORDER BY FechaHoraSalida asc
End
Go

--exec ListarVuelosSinPartir 'MVD'

create PROCEDURE ListarVuelosSinLlegar
 @aero varchar(3)
AS
Begin
	Select *
	From VUELOS V
	Where GETDATE() < FechaHoraLlegada AND V.AeropuertoLlegada = @aero
	ORDER BY FechaHoraLlegada asc
End
Go



CREATE PROCEDURE ListarAeropuertos
AS
Begin
	Select *
	From AEROPUERTOS
End
Go



------------------------ C L I E N T E ---------------------------------------------------------------------------------------

CREATE PROCEDURE Compras
@Pasaporte varchar (9)
AS
BEGIN
    SELECT NroVenta, PrecioTotal, FechaCompra, CodigoVuelo, Pasaporte
    FROM PASAJES
    WHERE Pasaporte = @Pasaporte
    ORDER BY FechaCompra desc;
END
go

exec Compras 'A00033123'


------------------------ E M P L E A D O ---------------------------------------------------------------------------------------

------------------------ C I U D A D ---------------------------------------------------------------------------------------


CREATE PROCEDURE AltaCiudad
@CodigoCiudad varchar(6),@NombreCiudad varchar(20), @Pais varchar (20)
AS
Begin
	if (EXISTS(Select * From CIUDAD Where CodigoCiudad = @CodigoCiudad))
		return -1
		
	--si llego aca puedo agregar
	INSERT CIUDAD VALUES(@CodigoCiudad, @NombreCiudad, @Pais) 
	
	IF(@@Error=0)
		RETURN 1
	else
		RETURN -2
End
go

CREATE PROCEDURE ModificarCiudad
@CodigoCiudad varchar(6),@NombreCiudad varchar(20), @Pais varchar (20)
AS
Begin
	if Not(EXISTS(Select * From CIUDAD Where CodigoCiudad = @CodigoCiudad))
		return -1
		
	--si llego aca puedo modificar
	UPDATE CIUDAD 
	SET NombreCiudad = @NombreCiudad, Pais=@Pais
	WHERE CodigoCiudad = @CodigoCiudad
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -2
End
go

CREATE PROCEDURE EliminarCiudad
@CodigoCiudad varchar(6)
AS
Begin
	if Not(EXISTS(Select * From CIUDAD Where CodigoCiudad = @CodigoCiudad))
		return -1
	
	if (EXISTS(Select * From AEROPUERTOS Where CodigoCiudad=@CodigoCiudad))
		return -2 --Existe un aeropuerto en esa Ciudad
		
	Delete CIUDAD Where CodigoCiudad=@CodigoCiudad
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -3
End
go

CREATE PROCEDURE BuscarCiudad 
@codigoCiudad varchar (6)
AS
Begin
	Select CodigoCiudad, NombreCiudad, Pais 
	From CIUDAD
	Where CodigoCiudad = @codigoCiudad
End
go

--exec BuscarCiudad 'RDJBRA'

------------------------ A E R O P U E R T O S ---------------------------------------------------------------------------------------


CREATE PROCEDURE AltaAeropuerto
@CodigoAeropuerto varchar(3), @NombreAeropuerto varchar(40),@DireccionAeropuerto varchar(40),@ImpuestosPartida int, @ImpuestosLlegada int, @CodigoCiudad varchar(6)
AS
Begin
	if (EXISTS(Select * From AEROPUERTOS Where CodigoAeropuerto = @CodigoAeropuerto))
		return -1
	if (NOT EXISTS(Select * From CIUDAD Where CodigoCiudad = @CodigoCiudad))
		return -2
		
	--si llego aca puedo agregar
	INSERT AEROPUERTOS VALUES(@CodigoAeropuerto, @NombreAeropuerto, @DireccionAeropuerto, @ImpuestosPartida, @ImpuestosLlegada, @CodigoCiudad) 
	
	IF(@@Error=0)
		RETURN 1
	else
		RETURN -3
End
go

CREATE PROCEDURE ModificarAeropuerto
@CodigoAeropuerto varchar(3), @NombreAeropuerto varchar(40),@DireccionAeropuerto varchar(40),@ImpuestosPartida int, @ImpuestosLlegada int, @CodigoCiudad varchar(6)
AS
Begin
	if Not(EXISTS(Select * From AEROPUERTOS Where CodigoAeropuerto=@CodigoAeropuerto))
		return -1
	if (NOT EXISTS(Select * From CIUDAD Where CodigoCiudad = @CodigoCiudad))
		return -2
		
	--si llego aca puedo modificar
	UPDATE AEROPUERTOS 
	SET NombreAeropuerto = @NombreAeropuerto, DireccionAeropuerto= @DireccionAeropuerto, ImpuestosPartida = @ImpuestosPartida, ImpuestosLlegada = @ImpuestosLlegada, CodigoCiudad = @CodigoCiudad
	WHERE CodigoAeropuerto = @CodigoAeropuerto
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -3
End
go

CREATE PROCEDURE EliminarAeropuerto
@CodigoAeropuerto varchar(3)
AS
Begin
	if Not(EXISTS(Select * From AEROPUERTOS Where CodigoAeropuerto = @CodigoAeropuerto))
		return -1
	
	if (EXISTS(Select * From VUELOS Where AeropuertoLlegada=@CodigoAeropuerto OR AeropuertoSalida = @CodigoAeropuerto))
		return -2 --Existen Viajes en ese Aeropuerto
		
	Delete AEROPUERTOS Where CodigoAeropuerto = @CodigoAeropuerto
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -3
End
go

create PROCEDURE BuscarAeropuerto 
@CodigoAeropuerto varchar(3)
AS
Begin
	Select CodigoAeropuerto, NombreAeropuerto, DireccionAeropuerto, ImpuestosLlegada, ImpuestosPartida, CodigoCiudad 
	From AEROPUERTOS 
	Where CodigoAeropuerto = @CodigoAeropuerto
End
go

--exec BuscarAeropuerto 'MVD'

------------------------ C L I E N T E S ---------------------------------------------------------------------------------------

CREATE PROCEDURE AltaCliente
@Pasaporte varchar(9), @NombreCliente varchar(20), @NroTarjeta int, @ContraseñaCliente varchar(20)
AS
Begin
	if (EXISTS(Select * From CLIENTES Where Pasaporte = @Pasaporte))
		return -1
		
	--si llego aca puedo agregar
	INSERT CLIENTES VALUES(@Pasaporte, @NombreCliente, @NroTarjeta, @ContraseñaCliente) 
	
	IF(@@Error=0)
		RETURN 1
	else
		RETURN -2
End
go

CREATE PROCEDURE ModificarCliente
@Pasaporte varchar(9), @NombreCliente varchar(20), @NroTarjeta int, @ContraseñaCliente varchar(20)
AS
Begin
	if Not(EXISTS(Select * From CLIENTES Where Pasaporte = @Pasaporte))
		return -1
		
	--si llego aca puedo modificar
	UPDATE CLIENTES 
	SET NombreCliente = @NombreCliente, NroTarjeta = @NroTarjeta, ContraseñaCliente = @ContraseñaCliente

	WHERE Pasaporte = @Pasaporte
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -2
End
go

CREATE PROCEDURE EliminarCliente
@Pasaporte varchar(9)
AS
Begin
	if Not(EXISTS(Select * From CLIENTES Where Pasaporte = @Pasaporte))
		return -1
	
	if (EXISTS(Select * From PASAJES Where Pasaporte = @Pasaporte))
		return -2 --Existe un Pasaje con el Pasaporte del Cliente
		
	Delete CLIENTES Where Pasaporte = @Pasaporte
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -3
End
go

CREATE PROCEDURE BuscarCliente 
@Pasaporte varchar(9) 
AS
Begin
	Select * From CLIENTES Where Pasaporte = @Pasaporte
End
go


CREATE PROCEDURE ListarClientes
AS
Begin
	Select * From CLIENTES
End
go


------------------------ V U E L O S ---------------------------------------------------------------------------------------

CREATE PROCEDURE AltaVuelo
@codigoVuelo varchar(15), @FechaHoraSalida date, @FechaHoraLlegada date, @Precio int, @CantidadAsientos int, @CodigoAeropuertoSalida varchar(3), @CodigoAeropuertoLlegada varchar(3)

AS
Begin
 --Existe un Pasaje con el Pasaporte del Cliente
	if (NOT EXISTS(Select * From AEROPUERTOS Where CodigoAeropuerto = @CodigoAeropuertoSalida))
		return -1
	if (NOT EXISTS(Select * From AEROPUERTOS Where CodigoAeropuerto = @CodigoAeropuertoLlegada))
		return -2
	if (EXISTS(Select * From VUELOS Where CodigoVuelo = @codigoVuelo))
		return -3
		
	--si llego aca puedo agregar
	INSERT VUELOS VALUES(@codigoVuelo,@FechaHoraSalida, @FechaHoraLlegada, @Precio, @CantidadAsientos, @CodigoAeropuertoSalida, @CodigoAeropuertoLlegada) 
	
	IF(@@Error!=0)
		RETURN -4
End
go

CREATE PROCEDURE ListarVuelos
AS
Begin
	Select *
	From VUELOS 
End
Go

create PROCEDURE BuscarVuelos
@codigoV varchar(15)
AS
Begin
	Select *
	From VUELOS where CodigoVuelo = @codigoV
End
Go

--exec BuscarVuelos '202701202050MVD'

------------------------ P A S A J E S ---------------------------------------------------------------------------------------

CREATE PROCEDURE VentaPasajes
@PrecioTotal int, @CodigoVuelo varchar(15), @Pasaporte varchar(9)
AS
Begin
	if ( NOT EXISTS(Select * From VUELOS Where CodigoVuelo = @CodigoVuelo))
		return -1
		
	if ( NOT EXISTS(Select * From CLIENTES Where Pasaporte = @Pasaporte))
		return -2
	
	Declare @cantAsientos int 
	Select @cantAsientos = CantidadAsientos 
	from Vuelos 
	where CodigoVuelo = @codigovuelo

	Declare @AsientosVendidos int 
	Select @AsientosVendidos = COUNT(*)
	from Pasajes 
	where codigovuelo = @codigovuelo

	if (@AsientosVendidos >= @cantAsientos)
		return -3 

    
	--si llego aca puedo agregar
	INSERT INTO PASAJES (PrecioTotal, FechaCompra, CodigoVuelo, Pasaporte)
    VALUES (@PrecioTotal, GETDATE(), @CodigoVuelo, @Pasaporte);
	
	IF(@@Error=0)
		RETURN 1
	else
		RETURN -4
End
go


EXEC VentaPasajes 500, '202701202050MVD', 'A00033123';


