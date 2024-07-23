USE Dab_clinic;
GO

-- Insert fake entries into Account table
INSERT INTO Account (username, email, password_hash, creation_time, fullname, birthdate, gender, phone, role, active, removed)
SELECT 
    CONCAT('user', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))),
    CONCAT('user', ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), '@example.com'),
    HASHBYTES('SHA2_256', CONCAT('password', ROW_NUMBER() OVER (ORDER BY (SELECT NULL)))),
    GETDATE(),
    CONCAT('Full Name ', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))),
    DATEADD(YEAR, -30, GETDATE()),
    CASE WHEN ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) % 2 = 0 THEN 'Male' ELSE 'Female' END,
    CONCAT('123-456-78', RIGHT('00' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR), 2)),
    0,
    1,
    0
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);

-- Insert fake entries into Clinic table
INSERT INTO Clinic (name, address, description, phone, email, open_hour, close_hour, working, clinic_status)
SELECT 
    CONCAT('Clinic ', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))),
    CONCAT('Address ', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))),
    'Description of clinic ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR),
    CONCAT('123-456-78', RIGHT('00' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR), 2)),
    CONCAT('clinic', ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), '@example.com'),
    '09:00:00',
    '18:00:00',
    1,
    1
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);

-- Insert fake entries into ServiceCategory table
INSERT INTO ServiceCategory (name)
SELECT CONCAT('Category ', ROW_NUMBER() OVER (ORDER BY (SELECT NULL)))
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);

-- Insert fake entries into ClinicService table
INSERT INTO ClinicService (service_name, description, price, available, category_id, removed, weekday, in_slot_treatment)
SELECT 
    CONCAT('Service ', ROW_NUMBER() OVER (ORDER BY (SELECT NULL))),
    'Description of service ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR),
    100 + ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
    1,
    1,
    0,
    1,
    1
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);

-- Insert fake entries into ClinicSlot table
INSERT INTO ClinicSlot (max_checkup, max_treatment, weekday, time_id, status, start, [end])
SELECT 
    5,
    5,
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) % 7,
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
    1,
    '09:00:00',
    '10:00:00'
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);

-- Insert fake entries into Appointment table
INSERT INTO Appointment (appointment_type, number, date, slot_id, customer_id, dentist_id, cycle_count, dentist_note, appointment_status, price_final)
SELECT 
    0,
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
    DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), GETDATE()),
    1,
    1,
    2,
    1,
    'Dentist note for appointment ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR),
    3,
    200
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);

-- Insert fake entries into BookedService table
INSERT INTO BookedService (appointment_id, service_id, price)
SELECT 
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
    1,
    100 + ROW_NUMBER() OVER (ORDER BY (SELECT NULL))
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);

-- Create more realistic relationships for Appointment and BookedService tables
DECLARE @MaxAccountID INT = (SELECT MAX(id) FROM Account);
DECLARE @MaxClinicSlotID INT = (SELECT MAX(slot_id) FROM ClinicSlot);
DECLARE @MaxClinicServiceID INT = (SELECT MAX(id) FROM ClinicService);

-- Re-populate Appointment with realistic customer_id and dentist_id
DELETE FROM Appointment;
INSERT INTO Appointment (appointment_type, number, date, slot_id, customer_id, dentist_id, cycle_count, dentist_note, appointment_status, price_final)
SELECT 
    0,
    ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
    DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), GETDATE()),
    ABS(CHECKSUM(NEWID())) % @MaxClinicSlotID + 1,
    ABS(CHECKSUM(NEWID())) % @MaxAccountID + 1,
    ABS(CHECKSUM(NEWID())) % @MaxAccountID + 1,
    1,
    'Dentist note for appointment ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR),
    3,
    200
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);

-- Re-populate BookedService with realistic appointment_id and service_id
DELETE FROM BookedService;
INSERT INTO BookedService (appointment_id, service_id, price)
SELECT 
    ABS(CHECKSUM(NEWID())) % 50 + 1,
    ABS(CHECKSUM(NEWID())) % @MaxClinicServiceID + 1,
    100 + ROW_NUMBER() OVER (ORDER BY (SELECT NULL))
FROM (SELECT 1 AS n FROM (VALUES (1), (1), (1), (1), (1), (1), (1), (1), (1), (1)) AS a(n) CROSS JOIN (VALUES (1), (1), (1), (1), (1)) AS b(n)) AS T(n);
