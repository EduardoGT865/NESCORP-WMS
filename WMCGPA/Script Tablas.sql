/*Tablas mantenimiento a puertas*/

drop table timwmsPuertas
drop table timwmsDetallePuertas

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
