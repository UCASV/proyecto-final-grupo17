CREATE DATABASE Vaccination;

GO

USE Vaccination;

GO

-- Tabla Usuario
CREATE TABLE [User](
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(50) NOT NULL,
	[Password] VARCHAR(30) NOT NULL
);

-- Tabla Tipo Empleado
CREATE TABLE EmployeeType(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(50) NOT NULL
);

-- Tabla Cabina
CREATE TABLE Cabin(
	Id INT PRIMARY KEY IDENTITY,
	PhoneNumber VARCHAR(9) NOT NULL,
	[Address] VARCHAR(100) NOT NULL
);

-- Tabla Empleado
CREATE TABLE Employee(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[Mail] VARCHAR(30) NOT NULL,
	Id_User INT NULL, -- Si es gestor tendra un usuario
	Id_Cabin INT NULL, -- Si es en cargado de la cabina entonces este dira de que cabina
	Id_EmployeeType INT, -- Tipo de empleado
);

-- Este bloque de codigo es para que las llaves foraneas id cabina y id usuario puedan ser nulas o puedan tener un id de usuario y cabina para hacerlo unico de ellos
CREATE UNIQUE NONCLUSTERED INDEX idx_Id_User_notnull
ON Employee(Id_User)
Where Id_User IS NOT NULL;

CREATE UNIQUE NONCLUSTERED INDEX idx_Id_Cabin_notnull
ON Employee(Id_Cabin)
Where Id_Cabin IS NOT NULL;

-- Relacion de empleado con usuario
ALTER TABLE Employee
ADD FOREIGN KEY (Id_User) REFERENCES [User](Id);

-- Relacion de empleado con cabina
ALTER TABLE Employee
ADD FOREIGN KEY (Id_Cabin) REFERENCES Cabin(Id);

-- Relacion de empleado con tipo usuario
ALTER TABLE Employee
ADD FOREIGN KEY (Id_EmployeeType) REFERENCES EmployeeType(Id);

-- Tabla Registro de sesion
CREATE TABLE [Login](
	Id INT PRIMARY KEY IDENTITY,
	LoginDate DATETIME NOT NULL, -- Id del inicio de sesion
	Id_Employee INT, -- Id del empleado
	Id_Cabin INT -- Id de cabina
);

-- Realcion de Login con Empleado
ALTER TABLE [Login]
ADD FOREIGN KEY (Id_Employee) REFERENCES Employee(Id);

-- Relacion de Login con cabina
ALTER TABLE [Login]
ADD FOREIGN KEY (Id_Cabin) REFERENCES Cabin(Id);

-- Tabla institucion
CREATE TABLE Institution(
	Id INT PRIMARY KEY IDENTITY,
	InstitutionName VARCHAR(30)
);

-- Tabla ciudadano
CREATE TABLE Citizen(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Dui VARCHAR(10) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(9) NOT NULL,
	Mail VARCHAR(30),
	[Address] VARCHAR(100) NOT NULL,
	Age INT NOT NULL,
	Id_Institution INT
);

-- Relacion de tabla ciudadano con institucion
ALTER TABLE Citizen
ADD FOREIGN KEY (Id_Institution) REFERENCES Institution(Id);

-- Tabla enfermedad
CREATE TABLE Disease(
	Id INT PRIMARY KEY IDENTITY,
	Illness VARCHAR(50) NOT NULL,
	Id_Citizen INT FOREIGN KEY REFERENCES Citizen(Id) -- Relacion de enfermedad y ciudadano
);

-- Tabla lugar
CREATE TABLE Place(
	Id INT PRIMARY KEY IDENTITY,
	PlaceName VARCHAR(75) NOT NULL -- Nombre del lugar
);

-- Tabla cita
CREATE TABLE Appointment(
	Id_Appointment INT PRIMARY KEY IDENTITY,
	AppointmentDate DATETIME NOT NULL, -- Fecha y hora cita
	Id_Vaccination INT, -- Id de vacunacion
	WaitingDateTime TIME, -- Hora de espera
	VaccineDateTime DATETIME, -- Fecha de vacunacion
	Id_Citizen INT NOT NULL FOREIGN KEY REFERENCES Citizen(Id), -- Relacion de cita con ciudadano
	Id_Employee INT FOREIGN KEY REFERENCES Employee(Id), -- Relacion de cita con el Gestor(empleado) 
	Id_Place INT NOT NULL FOREIGN KEY REFERENCES Place(Id) -- Relacion de cita con el lugar de vacunacion
);


-- Tabla efecto secundario
CREATE TABLE SideEffect(
	Id INT PRIMARY KEY IDENTITY,
	Effect VARCHAR(50) -- Efecto secundario
);

-- Tabla cruz de efecto secundario y cita
CREATE TABLE SideEffectXAppointment(
	Id_Appointment INT,
	Id_SideEffect INT,
	Lapse INT, -- Lapso de tiempo desde vacunacion al efecto secundario
	CONSTRAINT PK_SideEffectXAppointment PRIMARY KEY(Id_Appointment, Id_SideEffect)
);

-- Relaciones de la tabla cruz
ALTER TABLE SideEffectXAppointment
ADD FOREIGN KEY (Id_Appointment) REFERENCES Appointment(Id_Appointment);

ALTER TABLE SideEffectXAppointment
ADD FOREIGN KEY (Id_SideEffect) REFERENCES SideEffect(Id);

GO 

-- Stored procedure que se usara para obtener la eficiencia de vacunacion
CREATE OR ALTER PROCEDURE GetVaccineStatistics
	@FirstRange INT OUTPUT,
	@SecondRange INT OUTPUT,
	@ThirdRange INT OUTPUT,
	@LastRange INT OUTPUT
	AS
		BEGIN
			SELECT @FirstRange = COUNT(*)
			FROM Appointment
			WHERE DATEDIFF(MINUTE, WaitingDateTime, CAST(VaccineDateTime AS TIME)) < 15;

			SELECT @SecondRange = COUNT(*)
			FROM Appointment
			WHERE DATEDIFF(MINUTE, WaitingDateTime, CAST(VaccineDateTime AS TIME)) BETWEEN 15 AND 30;

			SELECT @ThirdRange = COUNT(*)
			FROM Appointment
			WHERE DATEDIFF(MINUTE, WaitingDateTime, CAST(VaccineDateTime AS TIME)) BETWEEN 30 AND 60;

			SELECT @LastRange = COUNT(*)
			FROM Appointment
			WHERE DATEDIFF(MINUTE, WaitingDateTime, CAST(VaccineDateTime AS TIME)) > 60;

		END;

GO
--*************************INSERTANDO ALGUNOS DATOS***************************
--****************************************************************************

--DATOS PARA CABINA
INSERT INTO Cabin VALUES ('7453-2132','Boulevar orden de malta #12')
INSERT INTO Cabin VALUES ('7250-2342','Final Colonia Escalon Pj2')
INSERT INTO Cabin VALUES ('7743-3987','29 Cl Pte y 11 Av Nte Bo San Miguelito')
INSERT INTO Cabin VALUES ('7789-3454','Alam Roosevelt 37 Av S 114')
INSERT INTO Cabin VALUES ('6432-4512','Calle Gerardo Barrios, 17 AV. Sur #412')

--DATOS PARA TIPOS DE EMPLEADOS
INSERT INTO EmployeeType VALUES ('Encargado')
INSERT INTO EmployeeType VALUES ('Gestor')
INSERT INTO EmployeeType VALUES ('Conserje')
INSERT INTO EmployeeType VALUES ('Director')
INSERT INTO EmployeeType VALUES ('Supervisor')

--DATOS PARA USUARIOS (Con estos usuarios y contraseñas se puede acceder al sistema)
INSERT INTO [User] VALUES ('ADMIN01','ROOT01')
INSERT INTO [User] VALUES ('ADMIN02','ROOT02')
INSERT INTO [User] VALUES ('ADMIN03','ROOT03')
INSERT INTO [User] VALUES ('ADMIN04','ROOT04')
INSERT INTO [User] VALUES ('ADMIN05','ROOT05')

--DATOS PARA EMPLEADOS

-- Gestores
INSERT INTO Employee VALUES ('Kevin Alexander','Final colonia escalon pasaje Ambrogi','kevin@gmail.com',1, NULL ,2)
INSERT INTO Employee VALUES ('Fernando Jose','Urbanizacion la esperanza','fernando@gmail.com',2, NULL ,2)
INSERT INTO Employee VALUES ('Samuel Adonay','Quintas de San Francisco','samuel@gmail.com',3,NULL ,2)
INSERT INTO Employee VALUES ('Erick Rickelmy','Pasaje Flor Blanca','erick@gmail.com',4,NULL,2)
INSERT INTO Employee VALUES ('Antony Jose','Antiguo Cuscatlan, La Libertad','antony@gmail.com',5, NULL ,2)

-- Encargados de cabina
INSERT INTO Employee VALUES ('Alexander Martinez','Ciudad Arce','amartz@gmail.com', NULL, 1,1)
INSERT INTO Employee VALUES ('Erick Hernandez','Residencial Nuevo Lourdes','erHnandez@hotmail.com', NULL, 2, 1)
INSERT INTO Employee VALUES ('Marcela Fernandez','Residencial Las Arboledas','marcef289@yahoo.com', NULL, 3, 1)
INSERT INTO Employee VALUES ('Cristhoper Rosales','Colonia El Conacaste','cr2001@gmail.com', NULL, 4, 1)
INSERT INTO Employee VALUES ('Marta Quiñonez','Colonia Escalon','qmarta2021@gmail.com', NULL, 5, 1)

-- Otros
INSERT INTO Employee VALUES ('Donnie Lubowitz','Cañada Lorem, 209 1ºB','moshe.mcdermott@gmail.com', NULL, NULL,3)
INSERT INTO Employee VALUES ('Bruno Barreto Hijo','Travesía Lorem, 77 1ºB','montes.javier@mendoza.org.ve', NULL, NULL, 4)
INSERT INTO Employee VALUES ('Emma Carrasquillo','Paseo Lorem ipsum dolor, 241 9ºD','nperea@palacios.com.ve', NULL, NULL,5)

--DATOS PARA INSTITUCION
INSERT INTO Institution VALUES ('Educacion')
INSERT INTO Institution VALUES ('Salud')
INSERT INTO Institution VALUES ('Policia nacional civil')
INSERT INTO Institution VALUES ('Gobierno')
INSERT INTO Institution VALUES ('Fuerza armada')
INSERT INTO Institution VALUES ('Periodismo')
INSERT INTO Institution VALUES ('Cuerpos de socorro')
INSERT INTO Institution VALUES ('Personal de frontera')
INSERT INTO Institution VALUES ('Centros penales')
INSERT INTO Institution VALUES ('Ninguna')

--DATOS PARA LOGIN
INSERT INTO [Login] VALUES ('2021-08-25',2,3)

--DATOS PARA CIUDADANO
INSERT INTO Citizen VALUES ('06362398-0','Kevin Mejia','7216-6942','juanPerz@gmail.com','Colonia Albert Einstein #2',19,5)
INSERT INTO Citizen VALUES ('08282923-4','Fernando Melendez','7727-0535','ErnestoG@gmail.com','Paseo El Carmen, Santa tecla',34,1)
INSERT INTO Citizen VALUES ('05895474-0','Erick Vasquez','7484-5842','ErickVasquez@gmail.com','Colonia maquilishuat',25,5)
INSERT INTO Citizen VALUES ('02151657-8','Samuel Ortiz','7917-6985','SamuelO@gmail.com','Calle al volvan',48,3)
INSERT INTO Citizen VALUES ('01188451-7','Juan Hernandez','7287-6975','JuanH@gmail.com','Av Jerusalen',60,2)
INSERT INTO Citizen VALUES ('04165487-5','Javier Mejia','7747-0254','Javiermejia@gmail.com','Pasaje domingo santos',24,1)
INSERT INTO Citizen VALUES('12345678-9', 'Juan Perez','7374-2732','kvn@hotmail.com','La libertad',24,1);

--DATO PARA ENFERMEDAD
INSERT INTO Disease VALUES('Diabetes',1)

--DATOS PARA LUGAR
INSERT INTO Place VALUES ('Hospital El Salvador')
INSERT INTO Place VALUES ('ISSS')
INSERT INTO Place VALUES ('Hospital de la mujer')
INSERT INTO Place VALUES ('Hospital de San Miguel')
INSERT INTO Place VALUES ('Hospital Benjamin Bloom')
INSERT INTO Place VALUES ('Hospital centro Diagnostico')
INSERT INTO Place VALUES ('Hospital Para Vida')
INSERT INTO Place VALUES ('Centro Medico Escalon')
INSERT INTO Place VALUES ('Hospital Nacional Rosales')
INSERT INTO Place VALUES ('Hospital Bautista')
INSERT INTO Place VALUES ('Hospital Central')
INSERT INTO Place VALUES ('Hospital Pro-Familia')

--DATOS PARA CITA
INSERT INTO Appointment	VALUES('2021-08-25',1,'12:15:59','2021-08-25 12:24:59',1,2,1)
INSERT INTO Appointment VALUES('2021-08-26',2,'17:32:47','2021-08-26 17:33:47',2,1,2)
INSERT INTO Appointment VALUES('2021-08-30',3,'09:14:02','2021-08-30 09:16:02',2,1,2)

INSERT INTO Appointment	VALUES('2021-08-25',4,'12:40:59','2021-08-25 12:50:59',3,2,1)
INSERT INTO Appointment VALUES('2021-08-26',5,'17:12:47','2021-08-26 17:50:47',3,3,2)
INSERT INTO Appointment VALUES('2021-08-30',6,'09:30:02','2021-08-30 09:33:02',4,5,2)
INSERT INTO Appointment VALUES('2021-08-30',7,'09:30:02','2021-08-30 10:10:02',5,1,2)
INSERT INTO Appointment VALUES('2021-08-30',8,'09:30:02','2021-08-30 10:32:02',6,2,2)
INSERT INTO Appointment VALUES('2021-08-30 09:30:02',9,'09:30:02','2021-08-30 09:31:03',7,2,2)

--DATOS PARA EFECTO SECUNDARIOS
INSERT INTO SideEffect VALUES('Fiebre')
INSERT INTO SideEffect VALUES('Gripe y tos')
INSERT INTO SideEffect VALUES('Dolor de cabeza')
--Agregando mas efectos secundarios
INSERT INTO SideEffect VALUES('Dolor o sensibilidad en el sitio de la inyeccion')
INSERT INTO SideEffect VALUES('Enrojecimiento en el sitio de la inyeccion')
INSERT INTO SideEffect VALUES('Fatiga')
INSERT INTO SideEffect VALUES('Mialgia')
INSERT INTO SideEffect VALUES('Artralgia')
INSERT INTO SideEffect VALUES('Anafilaxia')
INSERT INTO SideEffect VALUES('Mialgia')

--DATOS PARA EFECTOS SECUNDARIOS X CITA
INSERT INTO SideEffectXAppointment VALUES(1,3,20)
INSERT INTO SideEffectXAppointment VALUES(2,1,40)
INSERT INTO SideEffectXAppointment VALUES(3,2,90)
INSERT INTO SideEffectXAppointment VALUES(4,2,80)
INSERT INTO SideEffectXAppointment VALUES(5,3,10)
