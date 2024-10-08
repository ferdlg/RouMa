-- Limpieza y creación de la base de datos
DROP DATABASE IF EXISTS RouteManagement_db;
CREATE DATABASE RouteManagement_db;
USE RouteManagement_db;

-- Crear tablas
CREATE TABLE ROLES (
    RolId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(50) NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE
);

CREATE TABLE PERMISSIONS (
    PermissionId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(50) NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE
);

CREATE TABLE ROLES_PERMISSIONS (
    RolPermissionId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    PermissionId INT NOT NULL,
    RolId INT NOT NULL,
    FOREIGN KEY (PermissionId) REFERENCES PERMISSIONS(PermissionId),
    FOREIGN KEY (RolId) REFERENCES ROLES(RolId)
);

CREATE TABLE DOCUMENT_TYPES (
    DocumentTypeId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(200),
    IsDelete BOOLEAN DEFAULT FALSE
);

CREATE TABLE STREET_TYPES (
    StreetTypeId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(50) NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE
);

CREATE TABLE ADDRESSES (
    AddressId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    StreetName VARCHAR(50),
    StreetNumber INT,
    Quadrant VARCHAR(50),
    Plate INT,
    Prefix VARCHAR(50),
    StreetTypeId INT NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (StreetTypeId) REFERENCES STREET_TYPES(StreetTypeId)
);

CREATE TABLE COMPANIES (
    CompanyId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Logo VARCHAR(255),
    Name VARCHAR(50) NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE
);

CREATE TABLE HEADQUARTERS(
    HeadQuarterId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    AddressId INT NOT NULL,
    CompanyId INT NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (AddressId) REFERENCES ADDRESSES(AddressId),
    FOREIGN KEY (CompanyId) REFERENCES COMPANIES(CompanyId)
);

CREATE TABLE TRANSPORT_TYPES (
    TransportTypeId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(50),
    Description VARCHAR(200),
    IsDelete BOOLEAN DEFAULT FALSE
);

CREATE TABLE ROUTES (
    RouteId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    AddressOriginId INT,
    AddressHeadQuarterId INT,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (AddressOriginId) REFERENCES ADDRESSES(AddressId),
    FOREIGN KEY (AddressHeadQuarterId) REFERENCES HEADQUARTERS(AddressId)
);

CREATE TABLE STOPS (
    StopId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    AddressId INT NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY(AddressId) REFERENCES ADDRESSES(AddressId)
);

CREATE TABLE ROUTES_STOPS (
    RouteStopId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    RouteId INT NOT NULL,
    StopId INT NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (RouteId) REFERENCES ROUTES(RouteId),
    FOREIGN KEY (StopId) REFERENCES STOPS(StopId)
);

CREATE TABLE TRANSPORT_STATES (
    StateId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    State VARCHAR(50) NOT NULL
);

CREATE TABLE TRANSPORTS (
    Plate VARCHAR(50) PRIMARY KEY NOT NULL,
    Capacity INT NOT NULL,
    Picture VARCHAR(255),
    StateId INT NOT NULL,
    RouteId INT,
    TransportTypeId INT, 
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (StateId) REFERENCES TRANSPORT_STATES(StateId),
    FOREIGN KEY (RouteId) REFERENCES ROUTES(RouteId),
    FOREIGN KEY (TransportTypeId) REFERENCES TRANSPORT_TYPES(TransportTypeId)
);

CREATE TABLE PEOPLE (
    DocumentNumber INT PRIMARY KEY NOT NULL,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Phone INT NOT NULL, 
    ProfilePicture VARCHAR(255),
    AddressId INT,
    DocumentTypeId INT,
    RolId INT,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (AddressId) REFERENCES ADDRESSES(AddressId),
    FOREIGN KEY (DocumentTypeId) REFERENCES DOCUMENT_TYPES(DocumentTypeId),
    FOREIGN KEY (RolId) REFERENCES ROLES(RolId)
);

CREATE TABLE USERS (
    UserId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(200),
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (Email) REFERENCES PEOPLE(Email)
);

CREATE TABLE DRIVINGLICENSETYPE(
    TypeLicenseId INT PRIMARY KEY NOT NULL,
    Name VARCHAR(50)
);

CREATE TABLE DRIVERS (
    DriverId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    DrivingLicenseNumber INT NOT NULL,
    DocumentNumber INT NOT NULL,
    TypeLicenseId INT NOT NULL,
    PlateTransport VARCHAR(50),
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (DocumentNumber) REFERENCES PEOPLE(DocumentNumber),
    FOREIGN KEY (PlateTransport) REFERENCES TRANSPORTS(Plate),
    FOREIGN KEY (TypeLicenseId) REFERENCES DRIVINGLICENSETYPE(TypeLicenseId)
);

CREATE TABLE COMPANY_ADMINISTRATOR(
    CompanyAdminId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    DocumentNumber INT NOT NULL,
    CompanyId INT NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (DocumentNumber) REFERENCES PEOPLE(DocumentNumber),
    FOREIGN KEY (CompanyId) REFERENCES COMPANIES(CompanyId)
);

CREATE TABLE ADMINISTRATORS (
    AdministratorId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    DocumentNumber INT NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (DocumentNumber) REFERENCES PEOPLE(DocumentNumber)
);

CREATE TABLE PASSENGERS (
    PassengerId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    DocumentNumber INT NOT NULL,
    CompanyId INT NOT NULL,
    RouteId INT NOT NULL,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (DocumentNumber) REFERENCES PEOPLE(DocumentNumber),
    FOREIGN KEY (CompanyId) REFERENCES COMPANIES(CompanyId),
    FOREIGN KEY (RouteId) REFERENCES ROUTES(RouteId)
);

CREATE TABLE TRANSPORT_REQUEST_STATES(
    StateId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    State VARCHAR(50) NOT NULL
);

CREATE TABLE TRANSPORT_REQUESTS (
    RequestId INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Date DATETIME NOT NULL,
    Description VARCHAR(200),
    TransportTypeId INT NOT NULL,
    CompanyId INT NULL,
    StateId INT NULL,
    IsDelete BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (TransportTypeId) REFERENCES TRANSPORT_TYPES(TransportTypeId),
    FOREIGN KEY (CompanyId) REFERENCES COMPANIES(CompanyId),
    FOREIGN KEY (StateId) REFERENCES TRANSPORT_REQUEST_STATES(StateId)
);

-- Insertar datos ficticios

-- Roles
INSERT INTO ROLES (Name) VALUES ('Administrator'), ('Driver'), ('Passenger'), ('Company Admin');

-- Permisos
INSERT INTO PERMISSIONS (Name) VALUES 
('Manage Routes'), 
('Manage Transport Requests'), 
('View Routes'), 
('View Transport Requests');

-- Asignar permisos a roles
INSERT INTO ROLES_PERMISSIONS (PermissionId, RolId) VALUES 
(1, 1), (2, 1), 
(3, 2), (4, 2), 
(3, 3), (4, 3);

-- Tipos de documento
INSERT INTO DOCUMENT_TYPES (Name, Description) VALUES 
('Passport', 'International travel document'), 
('ID Card', 'National identity document');

-- Tipos de calle
INSERT INTO STREET_TYPES (Name) VALUES 
('Street'), 
('Avenue');

-- Direcciones
INSERT INTO ADDRESSES (StreetName, StreetNumber, Quadrant, Plate, Prefix, StreetTypeId) VALUES 
('Main St', 101, 'NW', 1234, 'A', 1), 
('Broadway', 200, 'SW', 5678, 'B', 2);

-- Empresas
INSERT INTO COMPANIES (Name) VALUES 
('Company A'), 
('Company B');

-- Sedes
INSERT INTO HEADQUARTERS (AddressId, CompanyId) VALUES 
(1, 1), 
(2, 2);

-- Tipos de transporte
INSERT INTO TRANSPORT_TYPES (Name, Description) VALUES 
('Bus', 'Large vehicle for public transport'), 
('Taxi', 'Small vehicle for private transport');

-- Rutas
INSERT INTO ROUTES (AddressOriginId, AddressHeadQuarterId) VALUES 
(1, 1), 
(2, 2);

-- Paradas
INSERT INTO STOPS (AddressId) VALUES 
(1), 
(2);

-- Asignar paradas a rutas
INSERT INTO ROUTES_STOPS (RouteId, StopId) VALUES 
(1, 1), (1, 2), 
(2, 1);

-- Estados de transporte
INSERT INTO TRANSPORT_STATES (State) VALUES 
('Operational'), 
('Under Maintenance');

-- Transportes
INSERT INTO TRANSPORTS (Plate, Capacity, StateId, RouteId, TransportTypeId) VALUES 
('ABC123', 50, 1, 1, 1), 
('XYZ789', 4, 2, 2, 2);

-- Tipos de licencia de conducir
INSERT INTO DRIVINGLICENSETYPE (TypeLicenseId, Name) VALUES 
(1, 'Class A'), 
(2, 'Class B');

-- Personas
INSERT INTO PEOPLE (DocumentNumber, FirstName, LastName, Email, Phone, AddressId, DocumentTypeId, RolId) VALUES 
(123456789, 'John', 'Doe', 'john.doe@example.com', 1234567890, 1, 1, 1), 
(987654321, 'Jane', 'Smith', 'jane.smith@example.com', 9876543210, 2, 2, 2);

-- Usuarios
INSERT INTO USERS (Email, Password) VALUES 
('john.doe@example.com', 'password123'),
('jane.smith@example.com', 'password456');
-- Conductores
INSERT INTO DRIVERS (DrivingLicenseNumber, DocumentNumber, TypeLicenseId, PlateTransport) VALUES 
(111223, 123456789, 1, 'ABC123'), 
(444556, 987654321, 2, 'XYZ789');

-- Administradores
INSERT INTO ADMINISTRATORS (DocumentNumber) VALUES 
(123456789);

-- Pasajeros
INSERT INTO PASSENGERS (DocumentNumber, CompanyId, RouteId) VALUES 
(987654321, 1, 1), 
(123456789, 2, 2);

-- Estados de solicitud de transporte
INSERT INTO TRANSPORT_REQUEST_STATES (State) VALUES 
('Pending'), 
('Approved'), 
('Rejected');

-- Solicitudes de transporte
INSERT INTO TRANSPORT_REQUESTS (Date, Description, TransportTypeId, CompanyId, StateId) VALUES 
('2024-08-16 10:00:00', 'Request for new bus route', 1, 1, 1), 
('2024-08-16 14:00:00', 'Request for taxi service', 2, 2, 2);
