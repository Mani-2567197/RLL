create database ClinicalDb

use ClinicalDb

create table Roles
(
RoleId int identity(1,1) primary key,
Name nvarchar(50) not null)

create table Users
(
UserId int identity(1,1) Not null,
Name varchar(50)  NOT NULL,
Phone varchar(11)  NOT NULL,
Address varchar(50)  NOT NULL,
DOB datetime  NOT NULL,
Gender varchar(10)  NOT NULL,
Email varchar(50)  NOT NULL,
Password varchar(128)  NOT NULL,
IsActive bit  NOT NULL,
RoleId int  NOT NULL)

create table Appointments
(
AppointmentId int IDENTITY(1,1) NOT NULL,
StartDateTime datetime  NOT NULL,
Status nvarchar(10)  NOT NULL,
Details nvarchar(200)  NOT NULL,
IsApprove bit  NOT NULL,
PatientId int  NOT NULL,
DoctorId int  NOT NULL);

create table Doctors
(
DoctorId int IDENTITY(1,1) NOT NULL,
IsAavailable bit  NOT NULL,
SpecializationId int  NOT NULL,
UserId int  NOT NULL,
Timings nvarchar(50)  NOT NULL);

create table Medicines(
MedicineId int IDENTITY(1,1) NOT NULL,
Name nvarchar(50)  NOT NULL,
Price float  NOT NULL,
Stock int  NOT NULL,
IsAvailable bit  NOT NULL,
Tax float  NOT NULL,
IsActive bit  NOT NULL);

create table Messages
(
MessageId int IDENTITY(1,1) NOT NULL,
MessageTime datetime  NOT NULL,
Message1 nvarchar(200)  NOT NULL,
Status nvarchar(100)  NOT NULL,
RecieverId int  NOT NULL,
SenderId int  NOT NULL);

create table Specializations(
SpecializationId int identity(1,1) not null,
SpecializationName nvarchar(50) not null);

----------------------------------------------------
-- Adding primary keys to existing tables 
----------------------------------------------------
alter table Users add constraint [pk_Users] primary key clustered([UserId] ASC);

alter table Appointments add constraint [pk_Appointments] primary key clustered([AppointmentId] ASC);

alter table Doctors add constraint [pk_Doctors] primary key clustered([DoctorId] ASC);

alter table Medicines add constraint [pk_Medicines] primary key clustered([MedicineId] ASC);

alter table Messages add constraint [pk_Messages] primary key clustered([MessageId] ASC);

alter table Specializations add constraint [pk_Specializations] primary key clustered([SpecializationId] ASC);

---------------------------------------------------------------------------------
--- Adding Foreign Keys to Existing tables
---------------------------------------------------------------------------------
ALTER TABLE Appointments ADD CONSTRAINT [FK_160] FOREIGN KEY ([PatientId]) REFERENCES Users([UserId]);

ALTER TABLE Appointments ADD CONSTRAINT [FK_169] FOREIGN KEY ([DoctorId]) REFERENCES Users ([UserId]);

ALTER TABLE Doctors ADD CONSTRAINT [FK_128] FOREIGN KEY ([UserId])REFERENCES Users ([UserId]);

ALTER TABLE Doctors ADD CONSTRAINT [FK_27]  FOREIGN KEY ([SpecializationId]) REFERENCES Specializations ([SpecializationId]);
  
ALTER TABLE Messages ADD CONSTRAINT [FK_163] FOREIGN KEY ([RecieverId])  REFERENCES  Users([UserId]);
    
ALTER TABLE Messages ADD CONSTRAINT [FK_166] FOREIGN KEY ([SenderId]) REFERENCES Users([UserId]);

ALTER TABLE Users ADD CONSTRAINT [FK_153]  FOREIGN KEY ([RoleId]) REFERENCES Roles([RoleId]);

----------------------------------------------------------------------------
---- Creating Index's
-----------------------------------------------------------------------------
CREATE INDEX [IX_FK_160] ON Appointments (PatientId);

CREATE INDEX [IX_FK_169] ON Appointments (DoctorId);

CREATE INDEX [IX_FK_128] ON Doctors(UserId);

CREATE INDEX [IX_FK_27] ON Doctors(SpecializationId);

CREATE INDEX [IX_FK_163] ON Messages(RecieverId);

CREATE INDEX [IX_FK_166] ON Messages(SenderId);

CREATE INDEX [IX_FK_153] ON Users(RoleId);




