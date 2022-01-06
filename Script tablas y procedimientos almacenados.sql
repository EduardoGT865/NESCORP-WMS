USE [sage500_app_recetas]
GO
/****** Object:  Table [dbo].[timwmsAlmacenArt]    Script Date: 9/10/2021 4:36:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Tablas configuracion WMS*/

CREATE TABLE [dbo].[timwmsAlmacenArt](
	[PkeywmsAlmArt] [int] IDENTITY(1,1) NOT NULL,
	[FkitemKey] [int] NOT NULL,
	[FKeywmscf] [int] NULL,
	[ItemId] [varchar](30) NOT NULL,
	[ItemDesc] [varchar](255) NULL,
	[Sku] [varchar](30) NOT NULL,
	[FkUbicacionOpcional] [int] NULL,
	[Usuario] [varchar](30) NOT NULL,
	[Fecha_Creacion] [datetime2](7) NOT NULL,
	[Fecha_Modificacion] [datetime2](7) NULL,
	[blogica] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PkeywmsAlmArt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[timwmsAlmacenPallet]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timwmsAlmacenPallet](
	[PkeywmsAlmPall] [int] IDENTITY(1,1) NOT NULL,
	[Fkeywmscf] [int] NULL,
	[PalletId] [varchar](100) NOT NULL,
	[Tamaño] [float] NOT NULL,
	[PalletDefault] [varchar](40) NULL,
	[Usuario] [varchar](30) NOT NULL,
	[Fecha_Creacion] [datetime2](7) NOT NULL,
	[Fecha_Modificacion] [datetime2](7) NULL,
	[blogica] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PkeywmsAlmPall] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[timwmsConfAlmacen]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timwmsConfAlmacen](
	[Pkeywmscf] [int] IDENTITY(1,1) NOT NULL,
	[FKAlmacen_Id] [int] NULL,
	[FkUbicacion_Default_PP] [int] NULL,
	[FkUbicacion_Sec_PP] [int] NULL,
	[FkUbicacion_Default_Res] [int] NULL,
	[FkUbicacion_Sec_Res] [int] NULL,
	[FkUbicacion_EntDef] [int] NULL,
	[Dias_Estadia] [smallint] NULL,
	[Dias_Devolucion] [smallint] NULL,
	[FkCompany_Id] [varchar](3) NULL,
	[Usuario] [varchar](30) NULL,
	[Fecha_Creacion] [datetime2](7) NULL,
	[Fecha_Modificacion] [datetime2](7) NULL,
	[blogica] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Pkeywmscf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[timwmsDetallePuertas]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Tablas configuracion frescura*/
CREATE TABLE [dbo].[twmInventaries](
	[ItemKey] [int] NOT NULL,
	[WhseKey] [int] NOT NULL,
	[MinQty] [decimal](18, 5) NOT NULL,
	[MaxQty] [decimal](18, 5) NOT NULL,
	[StrgPatternKey] [int] NOT NULL,
 CONSTRAINT [PK_twmInventaries] PRIMARY KEY CLUSTERED 
(
	[ItemKey] ASC,
	[WhseKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[twmParameters]    Script Date: 9/10/2021 5:01:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[twmParameters](
	[WMSParameterKey] [int] IDENTITY(1,1) NOT NULL,
	[CommodityCodeKey] [int] NOT NULL,
	[ProdCategoryKey] [int] NULL,
	[ItemKey] [int] NULL,
	[SavageMonth] [int] NOT NULL,
	[FreshTime] [int] NOT NULL,
	[CompanyID] [varchar](3) NOT NULL,
 CONSTRAINT [PK_twmParameters] PRIMARY KEY CLUSTERED 
(
	[WMSParameterKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[twmParameters] ADD  DEFAULT ((0)) FOR [FreshTime]
GO

/*Tablas mantenimiento a puertas*/


CREATE TABLE [dbo].[timwmsDetallePuertas](
	[PkeyDetPuerta] [int] IDENTITY(1,1) NOT NULL,
	[FkPuerta] [int] NULL,
	[Puerta] [varchar](100) NULL,
	[Tipo] [varchar](10) NULL,
	[Blogica] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[PkeyDetPuerta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[timwmsPuertas]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timwmsPuertas](
	[PkeyPuerta] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Cantidad] [int] NULL,
	[Company_Id] [varchar](5) NULL,
	[Almacen_Id] [int] NULL,
	[Usuario] [varchar](40) NULL,
	[Fecha_Creacion] [datetime2](7) NULL,
	[Fecha_Modificacion] [datetime2](7) NULL,
	[Blogica] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[PkeyPuerta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[timwmsAlmacenArt]  WITH CHECK ADD  CONSTRAINT [fk_Item] FOREIGN KEY([FkitemKey])
REFERENCES [dbo].[timItem] ([ItemKey])
GO
ALTER TABLE [dbo].[timwmsAlmacenArt] CHECK CONSTRAINT [fk_Item]
GO
ALTER TABLE [dbo].[timwmsAlmacenArt]  WITH CHECK ADD  CONSTRAINT [fk_timwmsConfAlm] FOREIGN KEY([FKeywmscf])
REFERENCES [dbo].[timwmsConfAlmacen] ([Pkeywmscf])
GO
ALTER TABLE [dbo].[timwmsAlmacenArt] CHECK CONSTRAINT [fk_timwmsConfAlm]
GO
ALTER TABLE [dbo].[timwmsConfAlmacen]  WITH CHECK ADD  CONSTRAINT [fk_Almacen] FOREIGN KEY([FKAlmacen_Id])
REFERENCES [dbo].[timWarehouse] ([WhseKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[timwmsConfAlmacen] CHECK CONSTRAINT [fk_Almacen]
GO
ALTER TABLE [dbo].[timwmsConfAlmacen]  WITH CHECK ADD  CONSTRAINT [fk_Compania] FOREIGN KEY([FkCompany_Id])
REFERENCES [dbo].[tciCompany] ([CompanyID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[timwmsConfAlmacen] CHECK CONSTRAINT [fk_Compania]
GO
ALTER TABLE [dbo].[timwmsDetallePuertas]  WITH CHECK ADD  CONSTRAINT [fk_Puerta] FOREIGN KEY([FkPuerta])
REFERENCES [dbo].[timwmsPuertas] ([PkeyPuerta])
GO
ALTER TABLE [dbo].[timwmsDetallePuertas] CHECK CONSTRAINT [fk_Puerta]
GO
ALTER TABLE [dbo].[timwmsPuertas]  WITH CHECK ADD  CONSTRAINT [fk_AlmacenPuerta] FOREIGN KEY([Almacen_Id])
REFERENCES [dbo].[timWarehouse] ([WhseKey])
GO
ALTER TABLE [dbo].[timwmsPuertas] CHECK CONSTRAINT [fk_AlmacenPuerta]
GO


/****** Object:  StoredProcedure [dbo].[EliminarConfig]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EliminarConfig]
@CONFID int
as
UPDATE timwmsAlmacenPallet set blogica = '0' where Fkeywmscf = @CONFID
UPDATE timwmsAlmacenArt set blogica ='0' where Fkeywmscf = @CONFID
UPDATE timwmsConfAlmacen set blogica ='0' where Pkeywmscf = @CONFID
GO
/****** Object:  StoredProcedure [dbo].[ExistAlmPallet]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ExistAlmPallet]
@PkeyAlmpall int
as
select PkeywmsAlmPall 
from timwmsAlmacenPallet
where PkeywmsAlmPall = @PkeyAlmpall
GO
/****** Object:  StoredProcedure [dbo].[ExistArtAlm]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ExistArtAlm]
@ItemKey int,
@FkConf int
as
select FkitemKey 
from timwmsAlmacenArt
where FkitemKey = @ItemKey and FKeywmscf = @FkConf and blogica = 1
GO
/****** Object:  StoredProcedure [dbo].[ListarAlmArtWMS]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarAlmArtWMS]
@Whse int
as
select taa.PkeywmsAlmArt, taa.ItemId as "ITEM ID", taa.ItemDesc as "DESCRIPCION",taa.Sku as "SKU", taa.Usuario as "USUARIO",taa.Fecha_Creacion as "FECHA CREACION", taa.FKeywmscf 
from timwmsAlmacenArt as taa,timwmsConfAlmacen as tcf, timWarehouse as twh
where taa.FKeywmscf= tcf.PKeywmscf and tcf.FKAlmacen_Id = twh.WhseKey and taa.blogica = 1 and twh.WhseKey = @Whse


GO
/****** Object:  StoredProcedure [dbo].[ListarPallets]    Script Date: 9/10/2021 4:36:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarPallets]
@Whse int
as
select tap.PkeywmsAlmPall, tap.PalletId as "ID PALLET", tap.Tamaño as "TAMAÑO", tap.PalletDefault as"PALLET DEFAULT"
from timwmsAlmacenPallet as tap,timwmsConfAlmacen as tcf, timWarehouse as twh
where tap.FKeywmscf= tcf.PKeywmscf and tcf.FKAlmacen_Id = twh.WhseKey and tap.blogica = 1 and twh.WhseKey = @Whse
GO


insert twmWarehouseUbications(
Whsekey,UbicationTypeKey,WhseUbicationID,CompanyID,Rotation,Weight,Active)values(1,1,1,'NCR',1,1,'1')

USE [sage500_app_recetas]
GO
GRANT EXEC ON dbo.ListarPallets TO PUBLIC

USE [sage500_app_recetas]
GO
GRANT EXEC ON dbo.ListarAlmArtWMS TO PUBLIC

USE [sage500_app_recetas]
GO
GRANT EXEC ON dbo.ExistArtAlm TO PUBLIC

USE [sage500_app_recetas]
GO
GRANT EXEC ON dbo.ExistAlmPallet TO PUBLIC