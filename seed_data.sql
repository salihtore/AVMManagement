-- MASTER SEED DATA SCRIPT FOR AVM MANAGEMENT SYSTEM (VERIFIED SCHEMA)
-- USE WITH CAUTION: TRUNCATES TABLES!

USE [AVMDB]
GO

SET NOCOUNT ON;
PRINT 'Starting Verified Data Seeding...';

-- 1. CLEANUP
DELETE FROM Payments;
DELETE FROM Rents;
DELETE FROM ServiceRequests;
DELETE FROM LeaveRequests;
DELETE FROM Turnovers;
DELETE FROM Tasks;
DELETE FROM Shifts;
DELETE FROM Shifts;
DELETE FROM Employees;
DELETE FROM Contracts;
DELETE FROM Tenants;
DELETE FROM Users;
DELETE FROM Stores;

DBCC CHECKIDENT ('Stores', RESEED, 0);
DBCC CHECKIDENT ('Users', RESEED, 0);
DBCC CHECKIDENT ('Tenants', RESEED, 0);
DBCC CHECKIDENT ('Contracts', RESEED, 0);
DBCC CHECKIDENT ('Employees', RESEED, 0);
DBCC CHECKIDENT ('LeaveRequests', RESEED, 0);
DBCC CHECKIDENT ('ServiceRequests', RESEED, 0);
DBCC CHECKIDENT ('Turnovers', RESEED, 0);

PRINT 'Cleanup Done.';

-- 2. ROLES
IF NOT EXISTS (SELECT * FROM Roles WHERE RoleId = 1) INSERT INTO Roles (RoleId, RoleName) VALUES (1, 'Admin');
IF NOT EXISTS (SELECT * FROM Roles WHERE RoleId = 2) INSERT INTO Roles (RoleId, RoleName) VALUES (2, 'Personnel');
IF NOT EXISTS (SELECT * FROM Roles WHERE RoleId = 3) INSERT INTO Roles (RoleId, RoleName) VALUES (3, 'Store');

-- 3. STORES (Schema: StoreName, FloorNumber, SquareMeter, Category, IsActive, CreatedAt)
PRINT 'Inserting Stores...';
INSERT INTO Stores (StoreName, FloorNumber, SquareMeter, Category, IsActive, CreatedAt) VALUES
('Mavi', 0, 400.0, 'Giyim', 1, GETDATE()),
('LC Waikiki', 1, 800.0, 'Giyim', 1, GETDATE()),
('Zara', 0, 600.0, 'Giyim', 1, GETDATE()),
('Boyner', 2, 1200.0, 'Çok Katlı', 1, GETDATE()),
('Teknosa', 1, 300.0, 'Teknoloji', 1, GETDATE()),
('MediaMarkt', 0, 1000.0, 'Teknoloji', 1, GETDATE()),
('Starbucks', 0, 150.0, 'Yeme-İçme', 1, GETDATE()),
('Mado', 3, 200.0, 'Yeme-İçme', 1, GETDATE()),
('Burger King', 2, 100.0, 'Yeme-İçme', 1, GETDATE()),
('Eczane', 0, 50.0, 'Sağlık', 1, GETDATE());

-- 4. USERS (Schema Check: Tenant users link to Stores)
PRINT 'Inserting Users...';
INSERT INTO Users (RoleId, StoreId, FullName, Username, PasswordHash, Email, Phone, IsActive, CreatedAt) VALUES
(1, NULL, 'Sistem Yöneticisi', 'admin', '123456', 'admin@avm.com', '5551112233', 1, GETDATE()),
(3, 1, 'Ahmet Yılmaz (Mavi)', 'mavi_mudur', '123456', 'ahmet.y@mavi.com', '5559990001', 1, GETDATE()),
(3, 2, 'Zeynep Kaya (LCW)', 'lcw_mudur', '123456', 'zeynep.k@lcw.com', '5559990002', 1, GETDATE()),
(3, 3, 'Mustafa Çelik (Zara)', 'zara_mudur', '123456', 'mustafa.c@zara.com', '5559990003', 1, GETDATE()),
(3, 4, 'Ayşe Demir (Boyner)', 'boyner_mudur', '123456', 'ayse.d@boyner.com', '5559990004', 1, GETDATE()),
(3, 5, 'Mehmet Öz (Teknosa)', 'teknosa_mudur', '123456', 'mehmet.o@teknosa.com', '5559990005', 1, GETDATE()),
(3, 6, 'Fatma Şahin (Media)', 'media_mudur', '123456', 'fatma.s@media.com', '5559990006', 1, GETDATE()),
(3, 7, 'Canan Dağ (Starbucks)', 'starbucks_mudur', '123456', 'canan.d@sbux.com', '5559990007', 1, GETDATE()),
(3, 8, 'Murat Boz (Mado)', 'mado_mudur', '123456', 'murat.b@mado.com', '5559990008', 1, GETDATE()),
(3, 9, 'Selin Yurt (BK)', 'burger_mudur', '123456', 'selin.y@bk.com', '5559990009', 1, GETDATE()),
(3, 10, 'Kemal Sunal (Eczane)', 'eczane_mudur', '123456', 'kemal.s@eczane.com', '5559990010', 1, GETDATE()),
(2, NULL, 'Hakan Çelik (Güvenlik)', 'guvenlik_sef', '123456', 'hakan.c@avm.com', '5558887777', 1, GETDATE()),
(2, NULL, 'Elif Polat (Temizlik)', 'temizlik_sef', '123456', 'elif.p@avm.com', '5558886666', 1, GETDATE());

-- 5. TENANTS (Schema: StoreId, CompanyName, TaxNumber, ContactName, ContactPhone, Email, Status)
PRINT 'Inserting Tenants...';
INSERT INTO Tenants (StoreId, CompanyName, TaxNumber, ContactName, ContactPhone, Email, Status) VALUES
(1, 'Mavi Giyim A.Ş.', '1234567890', 'Ahmet Yılmaz', '5559990001', 'info@mavi.com', 1),
(2, 'LC Waikiki Mağazacılık', '2234567890', 'Zeynep Kaya', '5559990002', 'info@lcw.com', 1),
(3, 'Inditex Giyim', '3234567890', 'Mustafa Çelik', '5559990003', 'info@zara.com', 1),
(4, 'Boyner Büyük Mağazacılık', '4234567890', 'Ayşe Demir', '5559990004', 'info@boyner.com', 1),
(5, 'Teknosa A.Ş.', '5234567890', 'Mehmet Öz', '5559990005', 'info@teknosa.com', 1),
(6, 'MediaMarkt Turkey', '6234567890', 'Fatma Şahin', '5559990006', 'info@media.com', 1),
(7, 'Shaya Kahve', '7234567890', 'Canan Dağ', '5559990007', 'info@sbux.com', 1),
(8, 'Mado Dondurma', '8234567890', 'Murat Boz', '5559990008', 'info@mado.com', 1),
(9, 'TAB Gıda', '9234567890', 'Selin Yurt', '5559990009', 'info@bk.com', 1),
(10, 'Şifa Eczanesi', '0234567890', 'Kemal Sunal', '5559990010', 'info@eczane.com', 1);

-- 6. CONTRACTS (Schema: TenantId, StartDate, EndDate, MonthlyRent, DepositAmount, PaymentDay)
PRINT 'Inserting Contracts...';
INSERT INTO Contracts (TenantId, StartDate, EndDate, MonthlyRent, DepositAmount, PaymentDay) VALUES
(1, '2024-01-01', '2029-01-01', 50000, 100000, 1),
(2, '2024-01-01', '2029-01-01', 90000, 180000, 1),
(3, '2024-01-01', '2029-01-01', 75000, 150000, 1),
(4, '2023-06-01', '2028-06-01', 120000, 240000, 5),
(5, '2024-03-01', '2027-03-01', 40000, 80000, 1),
(6, '2024-01-01', '2029-01-01', 110000, 220000, 5),
(7, '2024-01-01', '2026-01-01', 30000, 60000, 1),
(8, '2024-01-01', '2026-01-01', 25000, 50000, 5),
(9, '2024-01-01', '2026-01-01', 20000, 40000, 1),
(10, '2023-01-01', '2030-01-01', 10000, 20000, 1);

-- 7. EMPLOYEES (Schema: StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd)
PRINT 'Inserting Employees...';
-- Mavi
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(1, 'Burak Aslan', 'Satış Danışmanı', 22000, '5321000001', 'Active', '2024-05-01', '09:00', '18:00'),
(1, 'Seda Yalçın', 'Kasa Sorumlusu', 24000, '5321000002', 'Active', '2024-06-01', '10:00', '19:00');

-- LC Waikiki
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(2, 'Caner Erkin', 'Reyon Görevlisi', 20000, '5321000011', 'Active', '2024-02-01', '09:00', '18:00'),
(2, 'Gökhan Gönül', 'Depo Sorumlusu', 21000, '5321000012', 'Active', '2024-03-01', '08:00', '17:00'),
(2, 'Volkan Demirel', 'Mağaza Şefi', 30000, '5321000013', 'Active', '2023-01-01', '09:00', '18:00');

-- Zara
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(3, 'Hadise Açıkgöz', 'Satış Temsilcisi', 25000, '5321000021', 'Active', '2024-01-10', '12:00', '21:00'),
(3, 'Murat Boz', 'Kasiyer', 24000, '5321000022', 'Active', '2024-02-15', '10:00', '19:00');

-- Boyner
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(4, 'Beyazıt Öztürk', 'Departman Müdürü', 35000, '5321000031', 'Active', '2023-05-20', '09:00', '18:00'),
(4, 'Seda Sayan', 'Satış Danışmanı', 23000, '5321000032', 'Active', '2024-04-01', '10:00', '19:00'),
(4, 'Acun Ilıcalı', 'Müşteri Hizmetleri', 22000, '5321000033', 'Active', '2024-05-01', '09:00', '18:00');

-- Teknosa
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(5, 'Cem Yılmaz', 'Teknik Servis', 28000, '5321000041', 'Active', '2023-08-01', '09:00', '18:00'),
(5, 'Şahan Gökbakar', 'Satış Danışmanı', 23000, '5321000042', 'Active', '2024-01-01', '10:00', '19:00');

-- MediaMarkt
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(6, 'Ata Demirer', 'Reyon Sorumlusu', 22000, '5321000051', 'Active', '2024-03-10', '11:00', '20:00'),
(6, 'Demet Akbağ', 'Kasiyer', 23000, '5321000052', 'Active', '2024-04-15', '12:00', '21:00');

-- Starbucks
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(7, 'Mert Demir', 'Barista', 21000, '5321000003', 'Active', '2024-08-01', '08:00', '16:00'),
(7, 'Aylin Koç', 'Barista', 21000, '5321000004', 'Active', '2024-08-15', '14:00', '22:00');

-- Mado
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(8, 'Gülse Birsel', 'Garson', 20000, '5321000071', 'Active', '2024-05-01', '08:00', '17:00'),
(8, 'Engin Günaydın', 'Mutfak Şefi', 30000, '5321000072', 'Active', '2023-10-01', '07:00', '16:00');

-- Burger King
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(9, 'Binnur Kaya', 'Kasiyer', 19000, '5321000081', 'Active', '2024-06-01', '11:00', '20:00'),
(9, 'Olgun Şimşek', 'Mutfak Personeli', 19000, '5321000082', 'Active', '2024-06-15', '10:00', '19:00');

-- Eczane
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(10, 'Haluk Bilginer', 'Eczacı Kalfası', 25000, '5321000091', 'Active', '2023-01-01', '09:00', '18:00');

-- AVM Staff
INSERT INTO Employees (StoreId, FullName, Position, Salary, Phone, Status, StartDate, ShiftStart, ShiftEnd) VALUES
(NULL, 'Cemal Süreya', 'Güvenlik Görevlisi', 25000, '5329990001', 'Active', '2023-01-01', '08:00', '20:00'),
(NULL, 'Orhan Veli', 'Temizlik Personeli', 19000, '5329990003', 'Active', '2023-02-01', '07:00', '19:00'),
(NULL, 'Attila İlhan', 'Teknik Personel', 28000, '5329990005', 'Active', '2023-03-01', '08:00', '17:00'),
(NULL, 'Turgut Uyar', 'Danışma', 22000, '5329990006', 'Active', '2024-01-01', '10:00', '19:00');

-- 8. OPERATIONS
PRINT 'Inserting Operations...';

-- Leaves (EmployeeId 1,3,5)
-- Warning: Check IDs. Mavi IDs ~1,2. Starbucks ~3,4. AVM ~5,6.
INSERT INTO LeaveRequests (EmployeeId, StartDate, EndDate, LeaveType, Reason, Status, CreatedAt, RejectionReason) VALUES
(1, DATEADD(day, -10, GETDATE()), DATEADD(day, -5, GETDATE()), 'Yıllık', 'Tatil', 'Approved', DATEADD(day, -20, GETDATE()), NULL),
(3, DATEADD(day, 5, GETDATE()), DATEADD(day, 7, GETDATE()), 'Hastalık', 'Doktor kontrolü', 'Rejected', DATEADD(day, -1, GETDATE()), 'Yoğun dönem.'),
(5, DATEADD(day, 10, GETDATE()), DATEADD(day, 12, GETDATE()), 'Mazeret', 'Şehir dışı', 'Pending', GETDATE(), NULL);

-- Service Requests (StoreId, RequestType, Description, Status, CreatedAt)
INSERT INTO ServiceRequests (StoreId, RequestType, Description, Status, CreatedAt) VALUES
(1, 'Elektrik', 'Vitrin spot ışıkları yanmıyor', 'Pending', GETDATE()),
(7, 'Mekanik', 'Klimadan su damlıyor', 'Resolved', DATEADD(day, -5, GETDATE())),
(9, 'Temizlik', 'Food court masaları kirli', 'Pending', DATEADD(hour, -2, GETDATE()));

-- Turnovers
INSERT INTO Turnovers (StoreId, Date, Amount, CreatedAt) VALUES
(1, DATEADD(day, -1, GETDATE()), 45000, GETDATE()),
(7, DATEADD(day, -1, GETDATE()), 15000, GETDATE());

PRINT 'Completed Successfully!';
