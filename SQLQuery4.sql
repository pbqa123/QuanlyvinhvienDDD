create database ppppp;
go
use ppppp;

-- Tạo bảng Tác giả
CREATE TABLE TacGia (
    MaTacGia INT PRIMARY KEY,
    TenTacGia VARCHAR(255)
);

-- Tạo bảng Sách
CREATE TABLE Sach (
    MaSach INT PRIMARY KEY,
    TenSach VARCHAR(255),
    MaTacGia INT,
    MaTheLoai INT,
    MaNXB INT,
    NamXuatBan INT,
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia),
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai),
    FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB)
);


-- Tạo bảng Thể loại
CREATE TABLE TheLoai (
    MaTheLoai INT PRIMARY KEY,
    TenTheLoai VARCHAR(255)
);
select * from TheLoai;
-- Tạo bảng Nhà xuất bản
CREATE TABLE NhaXuatBan (
    MaNXB INT PRIMARY KEY,
    TenNXB VARCHAR(255)
);

-- Tạo bảng Độc giả
CREATE TABLE DocGia (
    MaDocGia INT PRIMARY KEY,
    TenDocGia VARCHAR(255),
    DiaChi VARCHAR(255),
    SoDienThoai VARCHAR(15),
    SoThe VARCHAR(15),
    Username VARCHAR(50),
    Password VARCHAR(50)
);

-- Tạo bảng Thẻ thư viện
CREATE TABLE TheThuVien (
    SoThe VARCHAR(15) PRIMARY KEY,
    NgayBatDau DATE,
    NgayHetHan DATE,
    GhiChu TEXT
);

-- Tạo bảng Nhân viên
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    HoTen VARCHAR(255),
    NgaySinh DATE,
    SoDienThoai VARCHAR(15),
    Username VARCHAR(50),
    Password VARCHAR(50)
);

-- Tạo bảng Mượn trả
CREATE TABLE MuonTra (
    MaMuonTra INT PRIMARY KEY,
    SoThe VARCHAR(15),
    MaNhanVien INT,
    NgayMuon DATE,
    FOREIGN KEY (SoThe) REFERENCES TheThuVien(SoThe),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChiTietMuonTra (
    MaMuonTra INT,
    MaSach INT,
    GhiChu TEXT,
    DaTra INT,
    NgayTra DATE,
    PRIMARY KEY (MaMuonTra, MaSach),
    FOREIGN KEY (MaMuonTra) REFERENCES MuonTra(MaMuonTra),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach),
    CHECK (DaTra IN (0, 1)) -- Đảm bảo giá trị của cột DaTra là 0 hoặc 1
);
select * from MuonTra;
select * from ChiTietMuonTra;

-- Thêm dữ liệu vào bảng TacGia
INSERT INTO TacGia (MaTacGia, TenTacGia)
VALUES (1, 'Nguyen Van A');

INSERT INTO TacGia (MaTacGia, TenTacGia)
VALUES (2, 'Tran Thi B');

-- Thêm dữ liệu vào bảng TheLoai
INSERT INTO TheLoai (MaTheLoai, TenTheLoai)
VALUES (1, 'Khoa Hoc');

INSERT INTO TheLoai (MaTheLoai, TenTheLoai)
VALUES (2, 'Van Hoc');

insert into TheLoai (MaTheLoai,TenTheLoai)
Values (3, 'Lap Trinh');

-- Thêm dữ liệu vào bảng NhaXuatBan
INSERT INTO NhaXuatBan (MaNXB, TenNXB)
VALUES (1, 'to huu');

INSERT INTO NhaXuatBan (MaNXB, TenNXB)
VALUES (2, 'tran van anh');

-- Thêm dữ liệu vào bảng Sach

INSERT INTO Sach (MaSach, TenSach, MaTacGia, MaTheLoai, MaNXB, NamXuatBan)
VALUES (1, 'ngu van 12', 1, 1, 1, 2000);

INSERT INTO Sach (MaSach, TenSach, MaTacGia, MaTheLoai, MaNXB, NamXuatBan)
VALUES (2, 'toan 12', 2, 2, 2, 2005);

-- Thêm dữ liệu vào bảng DocGia
INSERT INTO DocGia (MaDocGia, TenDocGia, DiaChi, SoDienThoai, SoThe, Username, Password)
VALUES (1, 'Nguyen Van An', '123 Duong ABC', '0123456789', 'DG123', 'user1', 'pass1');

INSERT INTO DocGia (MaDocGia, TenDocGia, DiaChi, SoDienThoai, SoThe, Username, Password)
VALUES (2, 'tran Van Anh', 'ha noi', '0123456789', 'DG002', 'user2', 'pass2');


-- Thêm dữ liệu vào bảng TheThuVien
INSERT INTO TheThuVien (SoThe, NgayBatDau, NgayHetHan, GhiChu)
VALUES ('DG123', '2023-01-01', '2024-01-01', 'The thu vien cua Nguyen Van An');

-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (MaNhanVien, HoTen, NgaySinh, SoDienThoai, Username, Password)
VALUES (1, 'Tran Thi Nhan', '1990-01-01', '0987654321', 'admin', 'adminpass');

INSERT INTO NhanVien (MaNhanVien, HoTen, NgaySinh, SoDienThoai, Username, Password)
VALUES (2, 'Phung Ba Quoc Anh', '10-11-2004', '0358378692', 'admin2', '123');

-- Thêm dữ liệu vào bảng MuonTra
INSERT INTO MuonTra (MaMuonTra, SoThe, MaNhanVien, NgayMuon)
VALUES (1, 'DG123', 1, '2023-02-01');

-- Thêm dữ liệu vào bảng ChiTietMuonTra
INSERT INTO ChiTietMuonTra (MaMuonTra, MaSach, GhiChu, DaTra, NgayTra)
VALUES (1, 1, 'Ghi chu 1', 0, NULL);

INSERT INTO ChiTietMuonTra (MaMuonTra, MaSach, GhiChu, DaTra, NgayTra)
VALUES (1, 2, 'Ghi chu 2', 1, '2023-02-10');

select * from TacGia;
select * from DocGia;
select * from Sach;
select * from NhanVien;
select * from MuonTra;
select * from ChiTietMuonTra;
select * from TheThuVien;
select * from TheLoai;



UPDATE TheLoai
SET TenTheLoai = 'Tên sách đã sửa'
WHERE MaTheLoai = 1;

UPDATE Sach
SET TenSach = 'Tên sách đã sửa', NamXuatBan = 2020
WHERE MaSach = 1;

-- Cập nhật thông tin sách có mã sách là 1
UPDATE Sach
SET TenSach = 'ngu van 12',
    MaTacGia = 1,
    MaTheLoai = 1,
    MaNXB = 1,
    NamXuatBan = 2021
WHERE MaSach = 1;

UPDATE DocGia
set SoDienThoai = 121212121;
DELETE FROM DocGia WHERE MaDocGia = 15;

-- Thay đổi kiểu dữ liệu của cột MaDocGia từ INT sang VARCHAR

-- Thêm dữ liệu vào bảng TheLoai
INSERT INTO TheLoai (MaTheLoai, TenTheLoai) VALUES (4, 'Van Hoc');
INSERT INTO TheLoai (MaTheLoai, TenTheLoai) VALUES (5, 'Lap Trinh');
INSERT INTO TheLoai (MaTheLoai, TenTheLoai) VALUES (6, 'Khoa Hoc');
INSERT INTO TheLoai (MaTheLoai, TenTheLoai) VALUES (7, 'Lich Su');

-- Thêm dữ liệu vào bảng NhaXuatBan
INSERT INTO NhaXuatBan (MaNXB, TenNXB) VALUES (4, 'NXB ABC');
INSERT INTO NhaXuatBan (MaNXB, TenNXB) VALUES (5, 'NXB XYZ');
INSERT INTO NhaXuatBan (MaNXB, TenNXB) VALUES (6, 'NXB 123');

-- Thêm dữ liệu vào bảng Sach
INSERT INTO Sach (MaSach, TenSach, MaTacGia, MaTheLoai, MaNXB, NamXuatBan) VALUES (2, 'Tieu thuyet A', 1, 2, 3, 2008);
INSERT INTO Sach (MaSach, TenSach, MaTacGia, MaTheLoai, MaNXB, NamXuatBan) VALUES (3, 'Lap trinh C#', 2, 3, 4, 2020);
INSERT INTO Sach (MaSach, TenSach, MaTacGia, MaTheLoai, MaNXB, NamXuatBan) VALUES (4, 'Sach Khoa Hoc', 1, 4, 5, 2015);
INSERT INTO Sach (MaSach, TenSach, MaTacGia, MaTheLoai, MaNXB, NamXuatBan) VALUES (5, 'Lich Su Viet Nam', 3, 5, 3, 2012);

DELETE FROM DocGia
WHERE MaDocGia = 7;


select * from DocGia;

select * from TheLoai;
select * from Sach;


DELETE FROM DocGia WHERE MaDocGia = 14;




