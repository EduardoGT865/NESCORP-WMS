USE [sage500_app_recetas]
GO
/** Object:  Table [dbo].[timwmsPasillos]    Script Date: 9/14/2021 4:03:31 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timwmsPasillos](
	[Pkey_Pasillo] [int] IDENTITY(1,1) NOT NULL,
	[Pasillo] [varchar](200) NULL,
	[Nombre] [varchar](200) NULL,
	[Usuario] [varchar](25) NULL,
	[Compania] [varchar](200) NULL,
	[Fecha_Creacion] [datetime2](7) NULL,
	[Fecha_Modificacion] [datetime2](7) NULL,
	[Blogica] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Pkey_Pasillo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO