USE [LaEmpresa];
GO

--  EQUIPOS
INSERT INTO Equipos (Nombre) VALUES
('Contabilidad'),
('Recursos Humanos'),
('Mantenimiento'),
('Ventas'),
('Compras'),
('IT'),
('Producción'),
('Logística'),
('Dirección'),
('Calidad');
GO

--  USUARIOS
INSERT INTO Usuarios (IdEquipo, NombreCompleto_Nombre, NombreCompleto_Apellido, Contrasenia, Email_Email, Rol) VALUES
(1, 'Ana', 'Pérez', '1234', 'ana.perez@laempresa.com', 0),
(2, 'Juan', 'Gómez', 'abcd', 'juan.gomez@laempresa.com', 1),
(3, 'Lucía', 'Rodríguez', 'pass1', 'lucia.rodriguez@laempresa.com', 2),
(4, 'Martín', 'Fernández', 'pass2', 'martin.fernandez@laempresa.com', 0),
(5, 'Sofía', 'Sosa', 'pass3', 'sofia.sosa@laempresa.com', 2),
(6, 'Diego', 'Silva', 'pass4', 'diego.silva@laempresa.com', 1),
(7, 'Laura', 'García', 'pass5', 'laura.garcia@laempresa.com', 0),
(8, 'Pedro', 'López', 'pass6', 'pedro.lopez@laempresa.com', 2),
(9, 'María', 'Torres', 'pass7', 'maria.torres@laempresa.com', 1),
(10, 'Andrés', 'Ramos', 'pass8', 'andres.ramos@laempresa.com', 2);
GO

--  TIPOS DE GASTOS
INSERT INTO TipoDeGastos (Nombre, Descripcion) VALUES
('Luz', 'Gasto por consumo eléctrico'),
('Agua', 'Pago mensual de agua'),
('Internet', 'Servicio de conexión a Internet'),
('Limpieza', 'Gasto en limpieza del local'),
('Mantenimiento', 'Reparaciones varias'),
('Transporte', 'Combustible y movilidad'),
('Papelería', 'Material de oficina'),
('Capacitación', 'Cursos y talleres'),
('Comidas', 'Gastos de alimentación'),
('Publicidad', 'Anuncios y marketing');
GO

--  PAGOS
-- Unico (Discriminator = 'Unico')
INSERT INTO Pagos (MetodoDePago, IdTipoGasto, IdUsuario, Descripcion, Discriminator, FechaDePago, NroRecibo, Monto)
VALUES
(1, 1, 1, 'Pago factura UTE', 'Unico', '2025-01-15', 'REC-1001', 4500),
(2, 2, 2, 'Pago factura OSE', 'Unico', '2025-02-10', 'REC-1002', 2300),
(1, 3, 3, 'Pago servicio de fibra óptica', 'Unico', '2025-03-12', 'REC-1003', 1800),
(3, 4, 4, 'Pago empresa de limpieza', 'Unico', '2025-04-05', 'REC-1004', 3200),
(1, 5, 5, 'Reparación maquinaria', 'Unico', '2025-05-20', 'REC-1005', 6700),
(2, 6, 6, 'Pago combustible camioneta', 'Unico', '2025-06-18', 'REC-1006', 4100),
(1, 7, 7, 'Compra de hojas y carpetas', 'Unico', '2025-07-09', 'REC-1007', 900),
(3, 8, 8, 'Almuerzo con cliente', 'Unico', '2025-08-02', 'REC-1008', 2500),
(1, 9, 9, 'Pago de publicidad en redes', 'Unico', '2025-09-14', 'REC-1009', 3700),
(2, 10, 10, 'Pago de curso de capacitación', 'Unico', '2025-10-01', 'REC-1010', 4200);
GO

--Recurrente (Discriminator = 'Recurrente')
INSERT INTO Pagos (MetodoDePago, IdTipoGasto, IdUsuario, Descripcion, Discriminator, FechaDesde, FechaHasta, Monto)
VALUES
(1, 1, 1, 'Pago mensual de luz', 'Recurrente', '2025-01-01', '2025-12-31', 4000),
(2, 2, 2, 'Pago mensual de agua', 'Recurrente', '2025-01-01', '2025-12-31', 2100),
(3, 3, 3, 'Pago mensual de internet', 'Recurrente', '2025-01-01', '2025-12-31', 1600),
(1, 6, 4, 'Pago mensual de transporte', 'Recurrente', '2025-01-01', '2025-12-31', 3000),
(2, 4, 5, 'Servicio de limpieza', 'Recurrente', '2025-01-01', '2025-12-31', 3100),
(3, 7, 6, 'Suministros de oficina', 'Recurrente', '2025-01-01', '2025-12-31', 1200),
(1, 8, 7, 'Curso de actualización mensual', 'Recurrente', '2025-01-01', '2025-06-30', 2000),
(2, 9, 8, 'Comidas ejecutivas mensuales', 'Recurrente', '2025-01-01', '2025-12-31', 2800),
(3, 10, 9, 'Publicidad mensual', 'Recurrente', '2025-01-01', '2025-12-31', 3500),
(1, 5, 10, 'Mantenimiento preventivo mensual', 'Recurrente', '2025-01-01', '2025-12-31', 5000);
GO

-- AUDITORÍAS
INSERT INTO Auditorias (Email, Fecha, Accion) VALUES
('ana.perez@laempresa.com', '2025-01-15', 'Creó pago de luz'),
('juan.gomez@laempresa.com', '2025-02-10', 'Modificó usuario'),
('lucia.rodriguez@laempresa.com', '2025-03-12', 'Eliminó tipo de gasto'),
('martin.fernandez@laempresa.com', '2025-04-05', 'Agregó nuevo pago'),
('sofia.sosa@laempresa.com', '2025-05-20', 'Actualizó contraseña'),
('diego.silva@laempresa.com', '2025-06-18', 'Inició sesión'),
('laura.garcia@laempresa.com', '2025-07-09', 'Registró gasto único'),
('pedro.lopez@laempresa.com', '2025-08-02', 'Eliminó auditoría antigua'),
('maria.torres@laempresa.com', '2025-09-14', 'Creó usuario nuevo'),
('andres.ramos@laempresa.com', '2025-10-01', 'Realizó respaldo del sistema');
GO
