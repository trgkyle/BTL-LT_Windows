/*
Created		5/18/2021
Modified		5/18/2021
Project		
Model		
Company		
Author		
Version		
Database		MS SQL 7 
*/

USE master;
GO

DROP DATABASE QLThuVien;
GO

CREATE DATABASE QLThuVien;
GO
USE QLThuVien;
GO


Create table [TheLoai] (
	[MaTheLoai] Char(10) NOT NULL,
	[TenTheLoai] Varchar(20) NULL,
Primary Key  ([MaTheLoai])
) 
go

Create table [TaiLieu] (
	[MaTaiLieu] Char(10) NOT NULL,
	[MaTheLoai] Char(10) NOT NULL,
	[TenTaiLieu] Char(10) NULL,
	[SoLuong] Char(10) NULL,
	[NhaXuatBan] Char(10) NULL,
	[NamXuatBan] Char(10) NULL,
	[TacGia] Char(10) NULL,
Primary Key  ([MaTaiLieu])
) 
go

Create table [PhieuMuonChiTiet] (
	[MaPhieuMuon] Char(10) NOT NULL,
	[MaTaiLieu] Char(10) NOT NULL,
	[MaSach] Char(10) NOT NULL,
	[SoLuongMuon] Char(10) NULL,
	[NgayTra] Char(10) NULL,
Primary Key  ([MaPhieuMuon],[MaTaiLieu])
) 
go

Create table [PhieuMuon] (
	[MaPhieuMuon] Char(10) NOT NULL,
	[MaNhanVien] Char(10) NOT NULL,
	[MaDocGia] Char(10) NOT NULL,
	[NgayMuon] Char(10) NULL,
Primary Key  ([MaPhieuMuon])
) 
go

Create table [NhanVien] (
	[MaNhanVien] Char(10) NOT NULL,
	[MaChucVu] Char(10) NOT NULL,
	[HoTen] Char(10) NULL,
	[TaiKhoan] Char(10) NULL,
	[MatKhau] Char(10) NULL,
	[Quyen] Char(10) NULL,
Primary Key  ([MaNhanVien])
) 
go

Create table [DocGia] (
	[MaDocGia] Char(10) NOT NULL,
	[MaDoiTuong] Char(10) NOT NULL,
	[HoTen] Char(10) NULL,
	[GioiTinh] Char(10) NULL,
	[NgaySinh] Char(10) NULL,
	[NgayCap] Char(10) NULL,
	[NgayHetHan] Char(10) NULL,
Primary Key  ([MaDocGia])
) 
go

Create table [ChucVu] (
	[MaChucVu] Char(10) NOT NULL,
	[TenChucVu] Char(10) NULL,
Primary Key  ([MaChucVu])
) 
go

Create table [DoiTuong] (
	[MaDoiTuong] Char(10) NOT NULL,
	[TenDoiTuong] Varchar(20) NULL,
Primary Key  ([MaDoiTuong])
) 
go


Alter table [TaiLieu] add  foreign key([MaTheLoai]) references [TheLoai] ([MaTheLoai]) 
go
Alter table [PhieuMuonChiTiet] add  foreign key([MaTaiLieu]) references [TaiLieu] ([MaTaiLieu]) 
go
Alter table [PhieuMuonChiTiet] add  foreign key([MaPhieuMuon]) references [PhieuMuon] ([MaPhieuMuon]) 
go
Alter table [PhieuMuon] add  foreign key([MaNhanVien]) references [NhanVien] ([MaNhanVien]) 
go
Alter table [PhieuMuon] add  foreign key([MaDocGia]) references [DocGia] ([MaDocGia]) 
go
Alter table [NhanVien] add  foreign key([MaChucVu]) references [ChucVu] ([MaChucVu]) 
go
Alter table [DocGia] add  foreign key([MaDoiTuong]) references [DoiTuong] ([MaDoiTuong]) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


/* Roles permissions */


/* Users permissions */


