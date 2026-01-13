-- SCHEMA UPDATE FOR AVM MANAGEMENT FUTURE FEATURES
-- Run this script to create/update the necessary tables for Store and Personnel modules.

-- 0. EMPLOYEES UPDATE (Existing Table)
IF EXISTS (SELECT * FROM sysobjects WHERE name='Employees' AND xtype='U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'StoreId' AND Object_ID = Object_ID('Employees'))
    BEGIN
        ALTER TABLE Employees ADD StoreId INT NULL;
        ALTER TABLE Employees ADD CONSTRAINT FK_Employees_Stores FOREIGN KEY (StoreId) REFERENCES Stores(StoreId);
        PRINT 'Added StoreId column to Employees table.';
    END
END

-- 0.1 USERS UPDATE (For Login)
-- Link Users to Stores for Dynamic Login
IF EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'StoreId' AND Object_ID = Object_ID('Users'))
    BEGIN
        ALTER TABLE Users ADD StoreId INT NULL;
        ALTER TABLE Users ADD CONSTRAINT FK_Users_Stores_User FOREIGN KEY (StoreId) REFERENCES Stores(StoreId);
        PRINT 'Added StoreId column to Users table.';
    END
END

-- 1. TURNOVERS (Ciro Bildirimleri)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Turnovers' AND xtype='U')
CREATE TABLE Turnovers (
    TurnoverId INT PRIMARY KEY IDENTITY(1,1),
    StoreId INT NOT NULL,
    Date DATE NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
);

-- 2. SERVICE REQUESTS (Teknik/Destek Talepleri)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ServiceRequests' AND xtype='U')
CREATE TABLE ServiceRequests (
    RequestId INT PRIMARY KEY IDENTITY(1,1),
    StoreId INT NOT NULL,
    RequestType NVARCHAR(50) NOT NULL, -- 'Elektrik', 'Mekanik', 'Temizlik', 'Diğer'
    Description NVARCHAR(500) NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Pending', -- 'Pending', 'In Progress', 'Resolved', 'Cancelled'
    CreatedAt DATETIME DEFAULT GETDATE(),
    ResolvedAt DATETIME NULL,
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
);

-- 3. STORE EMPLOYEES (Legacy - We use Employees now)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='StoreEmployees' AND xtype='U')
CREATE TABLE StoreEmployees (
    StoreEmployeeId INT PRIMARY KEY IDENTITY(1,1),
    StoreId INT NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Position NVARCHAR(50),
    Phone NVARCHAR(20),
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
);

-- 4. SHIFTS (Personel Vardiyaları)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Shifts' AND xtype='U')
CREATE TABLE Shifts (
    ShiftId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    Location NVARCHAR(100), -- 'Gate A', 'Floor 2', etc.
    Note NVARCHAR(200),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- 5. TASKS (Personel Görevleri)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Tasks' AND xtype='U')
CREATE TABLE Tasks (
    TaskId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    IsCompleted BIT DEFAULT 0,
    AssignedAt DATETIME DEFAULT GETDATE(),
    CompletedAt DATETIME NULL,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- 6. LEAVE REQUESTS (İzin Talepleri)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='LeaveRequests' AND xtype='U')
CREATE TABLE LeaveRequests (
    LeaveId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    LeaveType NVARCHAR(50) NOT NULL, -- 'Annual', 'Sick', 'Casual'
    Reason NVARCHAR(200),
    Status NVARCHAR(20) DEFAULT 'Pending', -- 'Pending', 'Approved', 'Rejected'
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- 6.1 UPDATE LEAVE REQUESTS (Add RejectionReason)
IF EXISTS (SELECT * FROM sysobjects WHERE name='LeaveRequests' AND xtype='U')
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE Name = 'RejectionReason' AND Object_ID = Object_ID('LeaveRequests'))
    BEGIN
        ALTER TABLE LeaveRequests ADD RejectionReason NVARCHAR(200) NULL;
        PRINT 'Added RejectionReason to LeaveRequests.';
    END
END

PRINT 'Schema Update Completed Successfully.';
