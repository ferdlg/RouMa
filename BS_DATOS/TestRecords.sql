-- Insertar datos ficticios
-- Roles
INSERT INTO ROLES (Name) VALUES ('Administrator'), ('Driver'), ('Passenger');

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
INSERT INTO ROUTES (AdrressOriginId, AddressHeadQuarterId) VALUES 
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
INSERT INTO TRANSPORT_STATUSES (Status) VALUES 
('Operational'), 
('Under Maintenance');

-- Transportes
INSERT INTO TRANSPORTS (Plate, Capacity, StatusId, RouteId, TransportTypeId) VALUES 
('ABC123', 50, 1, 1, 1), 
('XYZ789', 4, 2, 2, 2);

-- Tipos de licencia de conducir
INSERT INTO DRIVINGLICENSETYPE (TypeLicenseId, Name) VALUES 
(1, 'Class A'), 
(2, 'Class B');

-- Usuarios
INSERT INTO USERS (DocumentNumber, FirstName, LastName, Email, Phone, AddressId, DocumentTypeId, RolId, CompanyId) VALUES 
(123456789, 'John', 'Doe', 'john.doe@example.com', 1234567890, 1, 1, 1, 1), 
(987654321, 'Jane', 'Smith', 'jane.smith@example.com', 9876543210, 2, 2, 2, 2);

-- Conductores
INSERT INTO DRIVERS (DocumentNumber, DrivingLicenseNumber, TypeLicenseId, PlateTransport) VALUES 
(123456789, 111223, 1, 'ABC123'), 
(987654321, 444556, 2, 'XYZ789');

-- Administradores
INSERT INTO ADMINISTRATORS (DocumentNumber) VALUES 
(123456789);

-- Pasajeros
INSERT INTO PASSENGERS (DocumentNumber, CompanyId, RouteId) VALUES 
(987654321, 1, 1), 
(123456789, 2, 2);

-- Estados de solicitud de transporte
INSERT INTO TRANSPORT_REQUEST_STATUSES (Status) VALUES 
('Pending'), 
('Approved'), 
('Rejected');

-- Solicitudes de transporte
INSERT INTO TRANSPORT_REQUESTS (Date, Description, TransportTypeId, CompanyId, StatusId) VALUES 
('2024-08-16 10:00:00', 'Request for new bus route', 1, 1, 1), 
('2024-08-16 14:00:00', 'Request for taxi service', 2, 2, 2);
