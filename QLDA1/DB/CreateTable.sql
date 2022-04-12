--tạo bảng

drop table ChiNhanh
create table ChiNhanh(
MaCN Varchar (20),
TenCN Nvarchar (100),
DiaChi Nvarchar(100),
SDT Varchar(10),
MaNH Varchar(20));

select MaCN, TenCN from ChiNhanh

insert into ChiNhanh(MaCN,TenCN, DiaChi, SDT, MaNH)
values('CN1','Chi Nhanh 1','Ha Noi VN','0375522656','NH1');
insert into ChiNhanh(MaCN,TenCN, DiaChi, SDT, MaNH)
values('CN2','Chi Nhanh 2','Ha Noi VN','0375522656','NH1');

----------------------------------------------------------------------

drop table userlogin
create table userlogin(
username Varchar (100),
pwd Nvarchar (50),
MaNV varchar(20));

insert into userlogin values ('duc','123','vault04')

select count(1) c from  userlogin where username = 'a' and pwd = 'a'


----------------------------------------------------------------------------



create table PhongBan(
MaPB Varchar (20),
TenPB Nvarchar (100));
insert into PhongBan (MaPB,TenPB)
values ('PB1','phong marketing')



------------------------------------------------------------


create table ChucVu(
MaCV Varchar (20),
TenCV Nvarchar (100));

insert into ChucVu (MaCV,TenCV)
values ('CV1','Trưởng phòng')



----------------------------------------------------------------------------


create table NhanVien(
MaNV varchar(20),
MaCN Varchar (20),
MaPB Varchar(20),
TenNV Varchar(50),
SoCCCD Varchar(12),
GioiTinh Varchar (10),
NgaySinh date,
DiaChi Nvarchar(100),
SDT Varchar(10));

insert into NhanVien(MaNV,MaCN,MaPB,TenNV,SoCCCD,GioiTinh,NgaySinh,DiaChi,SDT)
values ('vault04','CN1','PB1','Duc NT','09802998','Nam','05-aug-2000','HN','0123659874');
insert into NhanVien(MaNV,MaCN,MaPB,TenNV,SoCCCD,GioiTinh,NgaySinh,DiaChi,SDT)
values ('vault01','CN2','PB2','an','09684168418','Nam','03-aug-2000','HN','0128859879');
insert into NhanVien(MaNV,MaCN,MaPB,TenNV,SoCCCD,GioiTinh,NgaySinh,DiaChi,SDT)
values ('vault02','CN3','PB3','ming','0884998418','Nam','01-aug-2000','HN','0123659836');
insert into NhanVien(MaNV,MaCN,MaPB,TenNV,SoCCCD,GioiTinh,NgaySinh,DiaChi,SDT)
values ('Safe01','CN3','PB3','hang','0884998418','Nam','01-aug-2000','HN','0123659836');
insert into NhanVien(MaNV,MaCN,MaPB,TenNV,SoCCCD,GioiTinh,NgaySinh,DiaChi,SDT)
values ('Safe03','CN3','PB3','thuy','0884998418','Nam','01-aug-2000','HN','0123659836');
insert into NhanVien(MaNV,MaCN,MaPB,TenNV,SoCCCD,GioiTinh,NgaySinh,DiaChi,SDT)
values ('Safe04','CN3','PB3','duc duc','0884998418','Nam','01-aug-2000','HN','0123659836');
insert into NhanVien( MaNV,MaCN,MaPB ,TenNV ,SoCCCD ,GioiTinh ,NgaySinh ,DiaChi ,SDT )
values ('vault03','CN1','PB1','Nguyễn Trung Đức','026200001012','Nam','05/08/2000','Vĩnh phúc' , '0373200741');


----------------------------------------------------------------------------

drop table Ket
create table Ket(
MaKet varchar(20),
MaCN Varchar (20),
SoTien float,
HanMuc float );

insert into Ket(MaKet,MaCN,SoTien,HanMuc)
values( 'Ket01','CN1',20000000,'70000000000');
insert into Ket(MaKet,MaCN,SoTien,HanMuc)
values( 'Ket02','CN1',60000000,'90000000000');
insert into Ket(MaKet,MaCN,SoTien,HanMuc)
values( 'Ket03','CN2',223000000,'110000000000');
insert into Ket(MaKet,MaCN,SoTien,HanMuc)
values( 'Ket04','CN3',1111100000,'130000000000');
insert into Ket(MaKet,MaCN,SoTien,HanMuc)
values( 'Ket05','CN4',90000000,'50000000000');

SELECT MaKet, SoTien,HanMuc FROM Ket WHERE MaKet = 'ket01'

/*
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





create table MenhGia(
MaMenhGia varchar(20),
MenhGia int,
MaLoaiTien varchar(20));
insert into MenhGia (MaMenhGia,MenhGia,MaLoaiTien)
values ('MG1','500000','LT1')


create table NganHang(
MaNH  varchar(20),
TenNH varchar(100),
DiaChi varchar(100),
SDT varchar(10));
insert into NganHang(MaNH,TenNH,DiaChi,SDT)
values('NH1','TCB','Ha noi' , '0645698746')
*/



----------------------------------------------------------------------------


create table LuongTienTiepQuyLCN(
MaLTTQLCN varchar(50),
MaCNT varchar(20),
MaCNN varchar(20),
TongTien int,
HanMuc float ,
NgayYeuCau varchar(20),
NgayKetThuc varchar(20),
TrangThai varchar (20));

select * from LuongTienTiepQuyLCN

delete LuongTienTiepQuyLCN

insert into LuongTienTiepQuyLCN( MaLTTQLCN,MaCNT,MaCNN,TongTien,HanMuc,NgayYeuCau,NgayKetThuc,TrangThai)
values('LTTQLCN1','CN1','CN2','50000000','10000000000','10-mar-22','11-mar-2022','New')

insert into LuongTienTiepQuyLCN( MaLTTQLCN,MaCNT,MaCNN,TongTien,HanMuc,NgayYeuCau,NgayKetThuc,TrangThai)
values('LTTQLCN2','CN2','CN1','40000000','90000000000','12-mar-22','13-mar-2022','New')

insert into LuongTienTiepQuyLCN( MaLTTQLCN,MaCNT,MaCNN,TongTien,HanMuc,NgayYeuCau,NgayKetThuc,TrangThai)
values ('LTTQLCN_20Mar22_160932','CN2','CN1','5900000','60000000','15-Mar-22','15-Mar-22','Pending')

update LuongTienTiepQuyLCN 
set MaCNT='cn1',MaCNN='cn2',TongTien=1000,HanMuc=2000,NgayYeuCau='16-Mar-22',NgayKetThuc='15-Mar-22',TrangThai='Thanh cong' WHERE MaLTTQLCN='LTTQLCN_20Mar22_160932'

update LuongTienTiepQuyLCN set MaCNT = 'CN2',MaCNN='CN2',TongTien='40000000',HanMuc='90000000',NgayYeuCau='15-Mar-22',NgayKetThuc='15-Mar-22',TrangThai='TT1' where MaLTTQLCN='LTTQLCN2'

delete LuongTienTiepQuyLCN
select * from LuongTienTiepQuyLCN where MaCNT like '%' and MaCNN like '%' and MaLTTQLCN like '%' and TrangThai like '%' and NgayTiep = convert(date,'11-mar-22',100) ;
select * from LuongTienTiepQuyLCN where convert(date,NgayTiep,103) between convert(date,'11-mar-22',103) and convert(date,'12-mar-22',103)
select MaLTTQLCN from LuongTienTiepQuyLCN where MaCNT like '%' and MaCNN like '%' and MaLTTQLCN like '%' and TrangThai like '%' and convert(date,NgayTiep,103) between convert(date,'10-Mar-22 22:22:30',103) and convert(date,'15-Mar-22 22:22:30',103)

----------------------------------
----------------------------------------------------------------------------------------
drop table DieuChuyenQuy;

create table DieuChuyenQuy(
TranID varchar(20),
FUser varchar(20),
TUser varchar(20),
Amount float,
CCY varchar(15),
TranStatus varchar(20),
Supervisor varchar(100),
ValueDate date)

insert into DieuChuyenQuy 
values ('1','Safe01','Safe02',1000000,'0001','N','','26-mar-22')


select * from ket

----------------------------------------
---------------------------------------------------------------------------------------------------
drop table DieuChuyenKho;
create table DieuChuyenKho(
TranID varchar(20),
MaKet varchar(20),
FUser varchar(20),
TUser varchar(20),
TranType varchar(20),
Amount float,
CCY varchar(15),
TranStatus varchar(20),
Supervisor varchar(100),
ValueDate date)

select * from DieuChuyenKho

select distinct( a0.CDName), a0.CDVal TranStatus from DieuChuyenKho dck, allcode a0 where dck.TranStatus = a0.CDVal and a0.CDType='TranStatus' 

select distinct( a0.CDName) CCY from DieuChuyenKho dck, allcode a0 where dck.CCY = a0.CDVal and a0.CDType='CCY' 
select 'ALL' CDName, '' TranStatus union all select distinct( a0.CDName), a0.CDVal TranStatus from DieuChuyenKho dck, allcode a0 where dck.TranStatus = a0.CDVal and a0.CDType='TranStatus' 
select * from DieuChuyenKho
select 'ALL' TranStatus union all select TranStatus from DieuChuyenKho

select TranID, nv0.TenNV FUser, nv1.TenNV TUser,(a0.CDName) TranType,Amount,a1.CDName CCY, a2.CDName TranStatus,Supervisor,ValueDate  
from DieuChuyenKho dck, Allcode a0, Allcode a1, Allcode a2, NhanVien nv0, NhanVien nv1
where dck.TranType=a0.CDVal and a0.CDType = 'TranType'
and dck.CCY = a1.CDVal and a1.CDType='CCY'
and dck.TranStatus = a2.CDVal and a2.CDType='TranStatus'
and dck.FUser = nv0.MaNV
and dck.TUser = nv1.MaNV

select 'ALL' CDName, '%' TranID union all select TranID CDName, TranID TranID from DieuChuyenKho

select * from DieuChuyenKho 
select a0.CDName from DieuChuyenKho dck, allcode a0 where dck.CCY = a0.CDVal and a0.CDType='CCY' and dck.TranID='DCK_22Mar22_235204'
-------------------------------------
---------------------------------------------------------------------------------------


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


-------------------------------
---------------------------------------------------------------------------------------------
DROP TABLE ALLCODE
create table Allcode(
CDID int identity(1,1),
CDType varchar(20),
CDName varchar(100),
CDVal varchar(20));
SET IDENTITY_INSERT Allcode ON;

insert into Allcode (CDID,CDType,CDName,CDVal)
values ('1','TranType','out','0001');
insert into Allcode (CDID,CDType,CDName,CDVal)
values ('2','TranType','in','0002');
insert into Allcode (CDID,CDType,CDName,CDVal)
values ('3','CCY','VND','0001');
insert into Allcode (CDID,CDType,CDName,CDVal)
values ('4','CCY','USD','0002');
insert into Allcode (CDID,CDType,CDName,CDVal)
values ('5','TranStatus','NEW','N');
insert into Allcode (CDID,CDType,CDName,CDVal)
values ('6','TranStatus','Pending','P');
insert into Allcode (CDID,CDType,CDName,CDVal)
values ('7','TranStatus','Cancel','C');
insert into Allcode (CDID,CDType,CDName,CDVal)
values ('8','TranStatus','Approve','A');
insert into Allcode (CDID,CDType,CDName,CDVal)
values ('9','TranStatus','Reject','R');


select * from Allcode where CDType='TranType'



----------------------------------------------------------------------------