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

/*
Created		5/18/2021
Modified		5/29/2021
Project		
Model		
Company		
Author		
Version		
Database		MS SQL 7 
*/

Create table [TheLoai] (
	[MaTheLoai] Char(10) NOT NULL,
	[TenTheLoai] Nvarchar(20) NULL,
	[GhiChu] Nvarchar(20) NULL,
Primary Key  ([MaTheLoai])
) 
go

Create table [TaiLieu] (
	[MaTaiLieu] Char(10) NOT NULL,
	[MaTheLoai] Char(10) NOT NULL,
	[TenTaiLieu] Nvarchar(20) NULL,
	[SoLuong] Smallint NULL,
	[NhaXuatBan] Nvarchar(20) NULL,
	[NamXuatBan] Smallint NULL,
	[TacGia] Nvarchar(20) NULL,
Primary Key  ([MaTaiLieu])
) 
go

Create table [PhieuMuonChiTiet] (
	[MaPhieuMuon] Char(10) NOT NULL,
	[MaTaiLieu] Char(10) NOT NULL,
	[SoLuongMuon] Smallint NULL,
	[NgayTra] Datetime NULL,
Primary Key  ([MaPhieuMuon],[MaTaiLieu])
) 
go

Create table [PhieuMuon] (
	[MaPhieuMuon] Char(10) NOT NULL,
	[MaNhanVien] Char(10) NOT NULL,
	[MaDocGia] Char(10) NOT NULL,
	[NgayMuon] Datetime NULL,
Primary Key  ([MaPhieuMuon])
) 
go

Create table [NhanVien] (
	[MaNhanVien] Char(10) NOT NULL,
	[MaChucVu] Char(10) NOT NULL,
	[HoTen] Nvarchar(20) NULL,
	[TaiKhoan] Char(20) NULL,
	[MatKhau] Char(20) NULL,
	[Quyen] Char(10) NULL,
Primary Key  ([MaNhanVien])
) 
go

Create table [DocGia] (
	[MaDocGia] Char(10) NOT NULL,
	[MaDoiTuong] Char(10) NOT NULL,
	[HoTen] Nvarchar(20) NULL,
	[GioiTinh] Nvarchar(20) NULL,
	[NgaySinh] Datetime NULL,
	[NgayCap] Datetime NULL,
	[NgayHetHan] Datetime NULL,
Primary Key  ([MaDocGia])
) 
go

Create table [ChucVu] (
	[MaChucVu] Char(10) NOT NULL,
	[TenChucVu] Nvarchar(20) NULL,
Primary Key  ([MaChucVu])
) 
go

Create table [DoiTuong] (
	[MaDoiTuong] Char(10) NOT NULL,
	[TenDoiTuong] Nvarchar(20) NULL,
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







INSERT INTO TheLoai(MaTheLoai,TenTheLoai, GhiChu) VALUES ('TL01',N'Lập Trình',N'Tets');
GO
INSERT INTO TaiLieu(MaTaiLieu,TenTaiLieu,MaTheLoai,SoLuong,NhaXuatBan, NamXuatBan, TacGia) VALUES ('TL01',N'Lập trình C#','TL01',3,N'Giác Dục',2021,N'Vũ Minh Hoàng');
INSERT INTO TaiLieu(MaTaiLieu,TenTaiLieu,MaTheLoai,SoLuong,NhaXuatBan, NamXuatBan, TacGia) VALUES ('TL02',N'Lập trình Java','TL01',3,N'Giác Dục',2021,N'Nguyễn Hoàng Thạch');
INSERT INTO TaiLieu(MaTaiLieu,TenTaiLieu,MaTheLoai,SoLuong,NhaXuatBan, NamXuatBan, TacGia) VALUES ('TL03',N'Mạng máy tính','TL01',3,N'Giác Dục',2021,N'Trành Duy Nhất');
GO

INSERT INTO ChucVu(MaChucVu,TenChucVu) VALUES('CV01',N'Thủ Thư');
INSERT INTO ChucVu(MaChucVu,TenChucVu) VALUES('CV02',N'Giảng Viên');
GO

INSERT INTO NhanVien(MaNhanVien, HoTen, MaChucVu, TaiKhoan, MatKhau, Quyen) VALUES ('NV01',N'Nguyễn Xuân Trường', 'CV02', 'admin','admin','ADMIN');
INSERT INTO NhanVien(MaNhanVien, HoTen, MaChucVu, TaiKhoan, MatKhau, Quyen) VALUES ('NV03',N'Trần Chí Công', 'CV01', 'truonghdpk','123','THUTHU');
GO

INSERT INTO DoiTuong(MaDoiTuong,TenDoiTuong) VALUES('DT01',N'Sinh viên');
GO
INSERT INTO DocGia(MaDocGia,HoTen,GioiTinh,NgaySinh,MaDoiTuong,NgayCap,NgayHetHan) VALUES('DG01',N'Hoàng Chí Thanh',N'Nam','07-15-2000','DT01','3-23-2017','3-24-2025');
GO