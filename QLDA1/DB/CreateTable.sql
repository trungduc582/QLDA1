--tạo bảng
create table ChiNhanh(
MaCN Varchar (20),
TenCN Nvarchar (100),
DiaChi Nvarchar(100),
SDT Varchar(10),
MaNH Varchar(20));

insert into ChiNhanh(MaCN,TenCN, DiaChi, SDT, MaNH)
values('CN1','Chi Nhanh 1','Ha Noi VN','0375522656','NH1');
insert into ChiNhanh(MaCN,TenCN, DiaChi, SDT, MaNH)
values('CN2','Chi Nhanh 2','Ha Noi VN','0375522656','NH1');

select 'All' MaCN, 'All' TenCN
union all
select MaCN, TenCN from ChiNhanh



create table PhongBan(
MaPB Varchar (20),
TenPB Nvarchar (100));
insert into PhongBan (MaPB,TenPB)
values ('PB1','phong marketing')


create table ChucVu(
MaCV Varchar (20),
TenCV Nvarchar (100));

insert into ChucVu (MaCV,TenCV)
values ('CV1','Trưởng phòng')
--


create table NhanVien(
MaNV varchar(20),
MaCN Varchar (20),
MaPB Varchar(20),
TenNV Varchar(50),
SoCCCD Varchar(12),
GioiTinh Varchar (10),
NgaySinh Nvarchar (100),
DiaChi Nvarchar(100),
SDT Varchar(10));

insert into NhanVien( MaNV,MaCN,MaPB ,TenNV ,SoCCCD ,GioiTinh ,NgaySinh ,DiaChi ,SDT )
values ('NV1','CN1','PB1','Nguyễn Trung Đức','026200001012','Nam','05/08/2000','Vĩnh phúc' , '0373200741');

create table Ket(
MaKet varchar(20),
MaCN Varchar (20),
HanMuc int);
insert into Ket(MaKet,MaCN,HanMuc)
values( 'Ket1','CN1','70000000000');


create table ChiTietKet(
MaChiTietKet varchar(20),
MaMenhGia varchar(20),
SoLuong int,
MaKet varchar(20));
insert into ChiTietKet(MaChiTietKet,MaMenhGia,SoLuong,MaKet)
values ('CTKet1','500000','100000','Ket1')


create table GiaoDich(
MaGiaoDich varchar(20),
MaCN varchar(20),
LoaiGiaoDich varchar(20),
SoTien money,
NgayGiaoDich varchar(20),
MaNhanVien varchar(20),
MaLoaiTien varchar(20));

insert into GiaoDich(MaGiaoDich,MaCN,LoaiGiaoDich,SoTien,NgayGiaoDich,MaNhanVien,MaLoaiTien)
values ('1101','CN1','Nop Tien','160000000','11/01/2022','NV1','LT1');

create table LoaiTien(
MaLoaiTien varchar(20),
LoaiTien varchar(50),
DonViTienTe varchar(20));

insert into LoaiTien (MaLoaiTien,LoaiTien,DonViTienTe)
values ('LT1','Tien VND','VND')

create table MenhGia(
MaMenhGia varchar(20),
MenhGia int,
MaLoaiTien varchar(20));
insert into MenhGia (MaMenhGia,MenhGia,MaLoaiTien)
values ('MG1','500000','LT1')

create table TrangThai(
MaTrangThai varchar(20),
TenTrangThai varchar(20));

insert into TrangThai (MaTrangThai,TenTrangThai)
values ('TT1','Thanh cong')

create table NganHang(
MaNH  varchar(20),
TenNH varchar(100),
DiaChi varchar(100),
SDT varchar(10));
insert into NganHang(MaNH,TenNH,DiaChi,SDT)
values('NH1','TCB','Ha noi' , '0645698746')


create table LuongTienTiepQuyLCN(
MaLTTQLCN varchar(50),
MaCNT varchar(20),
MaCNN varchar(20),
TongTien int,
HanMuc float ,
NgayYeuCau varchar(20),
NgayKetThuc varchar(20),
TrangThai varchar (20));

insert into LuongTienTiepQuyLCN( MaLTTQLCN,MaCNT,MaCNN,TongTien,HanMuc,NgayYeuCau,NgayKetThuc,TrangThai)
values('LTTQLCN1','CN1','CN2','50000000','10000000000','10-mar-2022','11-mar-2022','thanh cong')

insert into LuongTienTiepQuyLCN( MaLTTQLCN,MaCNT,MaCNN,TongTien,HanMuc,NgayYeuCau,NgayKetThuc,TrangThai)
values('LTTQLCN2','CN2','CN1','40000000','90000000000','12-mar-2022','13-mar-2022','thanh cong')

insert into LuongTienTiepQuyLCN( MaLTTQLCN,MaCNT,MaCNN,TongTien,HanMuc,NgayYeuCau,NgayKetThuc,TrangThai)
values ('LTTQLCN_20Mar22_160932','CN2','CN1','5','6','15-Mar-22','15-Mar-22','TT1')

update LuongTienTiepQuyLCN 
set MaCNT='cn1',MaCNN='cn2',TongTien=1000,HanMuc=2000,NgayYeuCau='16-Mar-22',NgayKetThuc='15-Mar-22',TrangThai='Thanh cong' WHERE MaLTTQLCN='LTTQLCN_20Mar22_160932'

update LuongTienTiepQuyLCN set MaCNT = 'CN2',MaCNN='CN2',TongTien='40000000',HanMuc='90000000',NgayYeuCau='15-Mar-22',NgayKetThuc='15-Mar-22',TrangThai='TT1' where MaLTTQLCN='LTTQLCN2'

delete LuongTienTiepQuyLCN
select * from LuongTienTiepQuyLCN where MaCNT like '%' and MaCNN like '%' and MaLTTQLCN like '%' and TrangThai like '%' and NgayTiep = convert(date,'11-mar-22',100) ;
select * from LuongTienTiepQuyLCN where convert(date,NgayTiep,103) between convert(date,'11-mar-22',103) and convert(date,'12-mar-22',103)
select MaLTTQLCN from LuongTienTiepQuyLCN where MaCNT like '%' and MaCNN like '%' and MaLTTQLCN like '%' and TrangThai like '%' and convert(date,NgayTiep,103) between convert(date,'10-Mar-22 22:22:30',103) and convert(date,'15-Mar-22 22:22:30',103)


select right(MaLTTQLCN,1) from LuongTienTiepQuyLCN

create table ChiTietLuongTienLCN(
MaCTLTTQLCN varchar(20),
MaLTTQLCN varchar(20),
MaMenhGia varchar(20),
SoLuong int);
----------------------------------------------
create table LuongTienDieuChuyenVT(
MaLTDCVT varchar(20),
MaNVV varchar(20),
MaNVT varchar(20), 
TongTien int,
HanMuc int,
NgayDieuChuyen varchar(20))



create table ChiTietLuongTienDieuChuyenVT(
MaCTLTDCVT varchar(20),
MaLTDCVT varchar(20),
MaMenhGia int,
SoLuong int);


-----------------------------------------------------------------------
create table LuongTienDieuChuyenTT(
MaLTDCTT varchar(20),
MaNVTC varchar(20),
MaNVTN varchar(20), 
TongTien int,
HanMuc int,
NgayDieuChuyen varchar(20))



create table ChiTietLuongTienDieuChuyenTT(
MaCTLTDCTT varchar(20),
MaLTDCTT varchar(20),
MaMenhGia int,
SoLuong int)

---------------------------------------------------------------

create table DieuChuyenKho(
TranID varchar(20),
FUser varchar(20),
TUser varchar(20),
TranType varchar(20),
Amount int,
CYY varchar(15),
TranStatus varchar(20),
Supervisor varchar(100),
ValueDate date)

insert into DieuChuyenKho( TranID, FUser,TUser,TranType,Amount,CYY, TranStatus,Supervisor,ValueDate)
values ( 'vs001', 'Safe01','vault02','out',9000000,'VND', 'New', 'safe03','21-mar-22');
insert into DieuChuyenKho( TranID, FUser,TUser,TranType,Amount,CYY, TranStatus,Supervisor,ValueDate)
values ( 'vs003', 'Safe03','vault01','out',87000000,'VND', 'New', 'safe03','20-mar-22')
select * from DieuChuyenKho; 

select 'ALL' TranID
union all
select TranType from DieuChuyenKho;


create table ChiTietDieuChuyenKho(
TranID varchar(20),
VSTranID varchar(20),
MaMenhGia int,
SoLuong int);


------------------------------------------------


create table LuongTienTiepQuyLNH(
MaLTTQLNH varchar(20),
MaNHT varchar(20),
MaNHN varchar(20),
TongTien int,
HanMuc int,
NgayYeuCau varchar(20),
NgayTiep varchar(20),
NgayKetThuc varchar(20));

create table ChiTietLuongTienLNH(
MaCTLTTQLNH varchar(20),
MaLTTQLNH varchar(20),
MaMenhGia varchar(20),
SoLuong int);


------------------------------------------------


