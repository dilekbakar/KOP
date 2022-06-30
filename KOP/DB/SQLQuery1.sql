use kutuphanedb

create table Uyeler (ID int NOT NULL IDENTITY(1,1) primary key ,TC nvarchar(100), AD nvarchar(100), SOYAD nvarchar(100),EPOSTA nvarchar(100), TELEFON nvarchar(100),ADRES nvarchar(100),DURUM bit)

insert into Uyeler (TC,AD,SOYAD,EPOSTA,TELEFON,ADRES,DURUM) values ('456','sss','aaa','aaa@gmail.com','547825','asddddd',1)

create table Admindb (ID int NOT NULL IDENTITY(1,1) primary key,KULLANICI_AD nvarchar(100),SIFRE nvarchar(100),ADI nvarchar(100),YETKI bit)
insert into Admindb (KULLANICI_AD,SIFRE,ADI,YETKI) values ('Görevli','gorevli','Emre',1)

create table Yazarlar (ID int not null IDENTITY(1,1) primary key ,YAZAR_AD nvarchar(100),YAZAR_SOYAD nvarchar(100))
create table Turler (ID int not null IDENTITY(1,1) primary key,TUR_ADI nvarchar(100))
create table Kitaplar (ID int not null IDENTITY (1,1) primary key ,ISBN nvarchar(100),KITAP_ADI nvarchar(100),TUR nvarchar(100),YAZAR_ID int ,ADET int ,SAYFA_SAYISI int)
create table Islemler (ID int not null IDENTITY(1,1) primary key,UYE_AD nvarchar(100) ,KITAP_ADI nvarchar(100) ,VERILME_TAR datetime Not Null DEFAULT GETDATE(),TESLIM_TAR date)

select * from Islemler;

	
