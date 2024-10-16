USE [master]
GO
/****** Object:  Database [Tema3]    Script Date: 5/21/2023 4:31:44 PM ******/
CREATE DATABASE [Tema3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Tema3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\Tema3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Tema3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\Tema3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Tema3] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tema3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tema3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tema3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tema3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tema3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tema3] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tema3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tema3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tema3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tema3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tema3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tema3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tema3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tema3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tema3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tema3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Tema3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tema3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tema3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tema3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tema3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tema3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tema3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tema3] SET RECOVERY FULL 
GO
ALTER DATABASE [Tema3] SET  MULTI_USER 
GO
ALTER DATABASE [Tema3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tema3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Tema3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Tema3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Tema3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Tema3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Tema3] SET QUERY_STORE = OFF
GO
USE [Tema3]
GO
/****** Object:  Table [dbo].[Absenta]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absenta](
	[id_absenta] [int] IDENTITY(1,1) NOT NULL,
	[tip] [varchar](50) NOT NULL,
	[data] [date] NOT NULL,
	[id_stud_mat] [int] NOT NULL,
 CONSTRAINT [PK_Absenta] PRIMARY KEY CLUSTERED 
(
	[id_absenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clasa]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasa](
	[id_clasa] [int] IDENTITY(1,1) NOT NULL,
	[id_diriginte] [int] NULL,
	[nume_clasa] [varchar](50) NOT NULL,
	[id_specializare] [int] NULL,
 CONSTRAINT [PK_Clasa] PRIMARY KEY CLUSTERED 
(
	[id_clasa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clasa_Materie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasa_Materie](
	[id_clasa] [int] NOT NULL,
	[id_materie] [int] NOT NULL,
	[teza] [bit] NOT NULL,
	[id_clasa_materie] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Clasa_Materie] PRIMARY KEY CLUSTERED 
(
	[id_clasa_materie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Elev]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elev](
	[id_elev] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](50) NOT NULL,
	[prenume] [varchar](50) NOT NULL,
	[Id_clasa] [int] NULL,
 CONSTRAINT [PK_Elev] PRIMARY KEY CLUSTERED 
(
	[id_elev] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[id_material] [int] IDENTITY(1,1) NOT NULL,
	[material] [text] NOT NULL,
	[id_materie] [int] NOT NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[id_material] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materie](
	[id_materie] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Materie] PRIMARY KEY CLUSTERED 
(
	[id_materie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nota]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nota](
	[id_nota] [int] IDENTITY(1,1) NOT NULL,
	[tip] [varchar](50) NOT NULL,
	[nota] [float] NOT NULL,
	[data] [date] NOT NULL,
	[id_stud_mat] [int] NULL,
 CONSTRAINT [PK_Nota] PRIMARY KEY CLUSTERED 
(
	[id_nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[id_profesor] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](50) NOT NULL,
	[prenume] [varchar](50) NOT NULL,
	[id_clasa] [int] NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[id_profesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor_Materie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor_Materie](
	[id_prof_mat] [int] IDENTITY(1,1) NOT NULL,
	[id_prof] [int] NOT NULL,
	[id_mat] [int] NOT NULL,
 CONSTRAINT [PK_Profesor_Materie] PRIMARY KEY CLUSTERED 
(
	[id_prof_mat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semestru]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semestru](
	[id_sem] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semestru] PRIMARY KEY CLUSTERED 
(
	[id_sem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specializare]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specializare](
	[id_specializare] [int] IDENTITY(1,1) NOT NULL,
	[nume] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Specializare] PRIMARY KEY CLUSTERED 
(
	[id_specializare] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Materie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Materie](
	[id_stud_mat] [int] IDENTITY(1,1) NOT NULL,
	[id_materie] [int] NOT NULL,
	[id_elev] [int] NOT NULL,
	[id_sem] [int] NOT NULL,
	[medie] [float] NULL,
 CONSTRAINT [PK_Student_Materie] PRIMARY KEY CLUSTERED 
(
	[id_stud_mat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Absenta]  WITH CHECK ADD  CONSTRAINT [FK_Absenta_Student_Materie] FOREIGN KEY([id_stud_mat])
REFERENCES [dbo].[Student_Materie] ([id_stud_mat])
GO
ALTER TABLE [dbo].[Absenta] CHECK CONSTRAINT [FK_Absenta_Student_Materie]
GO
ALTER TABLE [dbo].[Clasa]  WITH CHECK ADD  CONSTRAINT [FK_Clasa_Profesor] FOREIGN KEY([id_diriginte])
REFERENCES [dbo].[Profesor] ([id_profesor])
GO
ALTER TABLE [dbo].[Clasa] CHECK CONSTRAINT [FK_Clasa_Profesor]
GO
ALTER TABLE [dbo].[Clasa]  WITH CHECK ADD  CONSTRAINT [FK_Clasa_Specializare] FOREIGN KEY([id_specializare])
REFERENCES [dbo].[Specializare] ([id_specializare])
GO
ALTER TABLE [dbo].[Clasa] CHECK CONSTRAINT [FK_Clasa_Specializare]
GO
ALTER TABLE [dbo].[Clasa_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Clasa_Materie_Clasa] FOREIGN KEY([id_clasa])
REFERENCES [dbo].[Clasa] ([id_clasa])
GO
ALTER TABLE [dbo].[Clasa_Materie] CHECK CONSTRAINT [FK_Clasa_Materie_Clasa]
GO
ALTER TABLE [dbo].[Clasa_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Clasa_Materie_Materie] FOREIGN KEY([id_materie])
REFERENCES [dbo].[Materie] ([id_materie])
GO
ALTER TABLE [dbo].[Clasa_Materie] CHECK CONSTRAINT [FK_Clasa_Materie_Materie]
GO
ALTER TABLE [dbo].[Elev]  WITH CHECK ADD  CONSTRAINT [FK_Elev_Clasa] FOREIGN KEY([Id_clasa])
REFERENCES [dbo].[Clasa] ([id_clasa])
GO
ALTER TABLE [dbo].[Elev] CHECK CONSTRAINT [FK_Elev_Clasa]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_Material_Material] FOREIGN KEY([id_materie])
REFERENCES [dbo].[Materie] ([id_materie])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_Material_Material]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Student_Materie] FOREIGN KEY([id_stud_mat])
REFERENCES [dbo].[Student_Materie] ([id_stud_mat])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Student_Materie]
GO
ALTER TABLE [dbo].[Profesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Clasa] FOREIGN KEY([id_clasa])
REFERENCES [dbo].[Clasa] ([id_clasa])
GO
ALTER TABLE [dbo].[Profesor] CHECK CONSTRAINT [FK_Profesor_Clasa]
GO
ALTER TABLE [dbo].[Profesor_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Materie_Materie] FOREIGN KEY([id_mat])
REFERENCES [dbo].[Materie] ([id_materie])
GO
ALTER TABLE [dbo].[Profesor_Materie] CHECK CONSTRAINT [FK_Profesor_Materie_Materie]
GO
ALTER TABLE [dbo].[Profesor_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Materie_Profesor] FOREIGN KEY([id_prof])
REFERENCES [dbo].[Profesor] ([id_profesor])
GO
ALTER TABLE [dbo].[Profesor_Materie] CHECK CONSTRAINT [FK_Profesor_Materie_Profesor]
GO
ALTER TABLE [dbo].[Student_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Student_Materie_Materie] FOREIGN KEY([id_materie])
REFERENCES [dbo].[Materie] ([id_materie])
GO
ALTER TABLE [dbo].[Student_Materie] CHECK CONSTRAINT [FK_Student_Materie_Materie]
GO
ALTER TABLE [dbo].[Student_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Student_Materie_Semestru] FOREIGN KEY([id_sem])
REFERENCES [dbo].[Semestru] ([id_sem])
GO
ALTER TABLE [dbo].[Student_Materie] CHECK CONSTRAINT [FK_Student_Materie_Semestru]
GO
ALTER TABLE [dbo].[Student_Materie]  WITH CHECK ADD  CONSTRAINT [FK_Student_Materie_Student_Materie] FOREIGN KEY([id_elev])
REFERENCES [dbo].[Elev] ([id_elev])
GO
ALTER TABLE [dbo].[Student_Materie] CHECK CONSTRAINT [FK_Student_Materie_Student_Materie]
GO
/****** Object:  StoredProcedure [dbo].[AddAbsenta]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAbsenta]
	@Tip varchar(50),
	@Date Date,
	@ElevID int,
	@MaterieID int,
	@SemestruID int
AS
BEGIN
	
	insert into Absenta([tip],[data],[id_stud_mat]) values(@Tip,@Date,(select Student_Materie.id_stud_mat from Student_Materie where Student_Materie.id_elev = @ElevID and Student_Materie.id_materie = @MaterieID and Student_Materie.id_sem = @SemestruID))
END
GO
/****** Object:  StoredProcedure [dbo].[AddClasa]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddClasa] 
	@Nume_Clasa varchar(50)
AS
BEGIN
	insert into Clasa([nume_clasa]) values(@Nume_Clasa)
END
GO
/****** Object:  StoredProcedure [dbo].[AddClasaMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddClasaMaterie] 
	@ClasaID int,
	@MaterieID int,
	@Teza bit
AS
BEGIN
	insert into Clasa_Materie([id_clasa], [id_materie], [teza]) values(@ClasaID, @MaterieID, @Teza)
END
GO
/****** Object:  StoredProcedure [dbo].[AddElev]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddElev] 
	@Nume varchar(50),
	@Prenume varchar(50)
AS
BEGIN
	insert into Elev([nume], [prenume]) values(@Nume, @Prenume)
END
GO
/****** Object:  StoredProcedure [dbo].[AddMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddMaterie] 
	@Nume varchar(50)
AS
BEGIN
	insert into Materie([nume]) values(@Nume)
END
GO
/****** Object:  StoredProcedure [dbo].[AddNota]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddNota]
	@Tip varchar(50),
	@ValoareNota float,
	@Date Date,
	@ElevID int,
	@MaterieID int,
	@SemestruID int
AS
BEGIN
	
	insert into Nota([tip],[nota],[data],[id_stud_mat]) values(@Tip, @ValoareNota,@Date,(select Student_Materie.id_stud_mat from Student_Materie where Student_Materie.id_elev = @ElevID and Student_Materie.id_materie = @MaterieID and Student_Materie.id_sem = @SemestruID))
END
GO
/****** Object:  StoredProcedure [dbo].[AddProfesor]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddProfesor] 
	@Nume varchar(50),
	@Prenume varchar(50)
AS
BEGIN
	insert into Profesor([nume], [prenume]) values(@Nume, @Prenume)
END
GO
/****** Object:  StoredProcedure [dbo].[AddProfesorMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddProfesorMaterie] 
	@ProfesorID int,
	@MaterieID int
AS
BEGIN
	insert into Profesor_Materie([id_prof], [id_mat]) values(@ProfesorID, @MaterieID)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSemestru]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddSemestru] 
	@Nume varchar(50)
AS
BEGIN
	insert into Semestru([nume]) values(@Nume)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSpecializare]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddSpecializare] 
	@Nume varchar(50)
AS
BEGIN
	insert into Specializare([nume]) values(@Nume)
END
GO
/****** Object:  StoredProcedure [dbo].[AddStudentMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddStudentMaterie] 
	@ElevID int,
	@MaterieID int,
	@SemestruID int
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Student_Materie WHERE id_elev = @ElevID AND id_materie = @MaterieID AND id_sem = @SemestruID)
	BEGIN
		INSERT INTO Student_Materie ([id_elev], [id_materie], [id_sem]) VALUES (@ElevID, @MaterieID, @SemestruID)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CancelNota]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CancelNota]
	@NotaID int
AS
BEGIN
update	Nota
	set		[tip] = 'ANULATA'
	where	id_nota = @NotaID
END
GO
/****** Object:  StoredProcedure [dbo].[ConectNota]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConectNota]
	@id_elev int,
	@id_materie int
AS
BEGIN
	insert into Nota([id_stud_mat]) select Student_Materie.id_stud_mat from Student_Materie where Student_Materie.id_elev = @id_elev and Student_Materie.id_materie = @id_materie
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteClasa]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteClasa]
	@id int
AS
BEGIN
	delete from Clasa
	where id_clasa = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteClasaMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteClasaMaterie]
	@id int
AS
BEGIN
	delete from Clasa_Materie
	where id_clasa_materie = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteElev]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteElev]
	@id int
AS
BEGIN
	delete from Elev
	where id_elev = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteMaterie]
	@id int
AS
BEGIN
	delete from Materie
	where id_materie = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProfesor]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProfesor]
	@id int
AS
BEGIN
	delete from Profesor
	where id_profesor = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProfesorMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProfesorMaterie]
	@id int
AS
BEGIN
	delete from Profesor_Materie
	where id_prof_mat = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSemestru]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSemestru]
	@id int
AS
BEGIN
	delete from Semestru
	where id_sem = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSpecializare]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSpecializare]
	@id int
AS
BEGIN
	delete from Specializare
	where id_specializare = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAbsentaForMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAbsentaForMaterie] 
	@MaterieID int,
	@ElevID int,
	@SemestruID int
AS
BEGIN
	select * from Absenta inner join Student_Materie on Absenta.id_stud_mat = Student_Materie.id_stud_mat 
    where Student_Materie.id_materie = @MaterieID and Student_Materie.id_elev = @ElevID and Student_Materie.id_sem = @SemestruID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAbsenteForElev]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAbsenteForElev]
	@ElevID int,
	@SemestruID int
AS
BEGIN
	SELECT* from Absenta inner join Student_Materie on Absenta.id_stud_mat = Student_Materie.id_stud_mat 
	where Student_Materie.id_elev = @ElevID and Student_Materie.id_sem = @SemestruID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllEleviForMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllEleviForMaterie]
	@Id_materie int
AS
BEGIN
	SELECT* from Elev inner join Student_Materie on Student_Materie.id_elev = Elev.id_elev where 
	Student_Materie.id_materie = @Id_materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetClasa]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetClasa]
     @ProfesorID int
AS
BEGIN
	SELECT * from Clasa where Clasa.id_diriginte = @ProfesorID
END
GO
/****** Object:  StoredProcedure [dbo].[GetClasaMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClasaMaterie] 
	@MaterieID int,
	@ClasaID int
AS
BEGIN
	SELECT * from Clasa_Materie
	WHERE id_materie = @MaterieID and id_clasa = @ClasaID
END
GO
/****** Object:  StoredProcedure [dbo].[GetClase]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetClase] 

AS
BEGIN
	SELECT * from Clasa
END
GO
/****** Object:  StoredProcedure [dbo].[GetClaseForProfesor]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetClaseForProfesor] 
	@ProfesorID int
AS
BEGIN
	SELECT DISTINCT Clasa.*
	FROM Profesor
	INNER JOIN Profesor_Materie ON Profesor.id_profesor = Profesor_Materie.id_prof
	INNER JOIN Clasa_Materie ON Profesor_Materie.id_mat = Clasa_Materie.id_materie
	INNER JOIN Clasa ON Clasa_Materie.id_clasa = Clasa.id_clasa
	WHERE Profesor.id_profesor = @ProfesorID
END
GO
/****** Object:  StoredProcedure [dbo].[GetClaseMaterii]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClaseMaterii] 

AS
BEGIN
	SELECT * from Clasa_Materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetElev]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetElev] 
	@Id_elev int
AS
BEGIN
	select * from Elev where id_elev = @Id_elev
END
GO
/****** Object:  StoredProcedure [dbo].[GetElevi]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetElevi] 

AS
BEGIN
	SELECT * from Elev
END
GO
/****** Object:  StoredProcedure [dbo].[GetEleviForClase]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEleviForClase]
	 
	@Id_clasa int
AS
BEGIN
	SELECT * from Elev where Id_clasa = @Id_clasa
END
GO
/****** Object:  StoredProcedure [dbo].[GetElevMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetElevMaterie] 
	@MaterieID int,
	@ElevID int,
	@SemestruID int
AS
BEGIN
	SELECT * from Student_Materie
	WHERE id_materie = @MaterieID and id_elev = @ElevID and id_sem = @SemestruID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMaterii]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaterii] 

AS
BEGIN
	SELECT * from Materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetMateriiForClasa]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMateriiForClasa] 
	@ClasaID int
AS
BEGIN
	SELECT Materie.*
	FROM Clasa
	INNER JOIN Clasa_Materie ON Clasa.id_clasa = Clasa_Materie.id_clasa
	INNER JOIN Materie ON Clasa_Materie.id_materie = Materie.id_materie
	WHERE Clasa.id_clasa = @ClasaID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMateriiForClasaAndProfesor]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMateriiForClasaAndProfesor] 
	@ClasaID int,
	@ProfesorID int
AS
BEGIN
	SELECT Materie.*
	FROM Clasa
	INNER JOIN Clasa_Materie ON Clasa.id_clasa = Clasa_Materie.id_clasa
	INNER JOIN Materie ON Clasa_Materie.id_materie = Materie.id_materie
	INNER JOIN Profesor_Materie ON Materie.id_materie = Profesor_Materie.id_mat
	INNER JOIN Profesor ON Profesor_Materie.id_prof = Profesor.id_profesor
	WHERE Clasa.id_clasa = @ClasaID
		AND Profesor.id_profesor = @ProfesorID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMateriiForElev]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMateriiForElev] 
	@elevID int
AS
BEGIN
	select * from ((Materie inner join Student_Materie on Materie.id_materie = Student_Materie.id_materie) inner join Elev on 
	Elev.id_elev = Student_Materie.id_elev) where Elev.id_elev = @elevID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMateriiForProfesor]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMateriiForProfesor] 
	@ProfesorID int
AS
BEGIN
	SELECT* from Materie inner join Profesor_Materie on Profesor_Materie.id_mat = Materie.id_materie where
	Profesor_Materie.id_prof = @ProfesorID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMedie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMedie] 
	@MaterieID int,
	@ElevID int,
	@SemestruID int
AS
BEGIN
	SELECT Student_Materie.medie from Student_Materie
	where Student_Materie.id_materie = @MaterieID and Student_Materie.id_elev = @ElevID and Student_Materie.id_sem = @SemestruID
END
GO
/****** Object:  StoredProcedure [dbo].[GetNoteForMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetNoteForMaterie] 
	@materieID int,
	@elevID int
AS
BEGIN
	select * from Nota inner join Student_Materie on nota.id_stud_mat = Student_Materie.id_stud_mat 
    where Student_Materie.id_materie = @materieID and Student_Materie.id_elev = @elevID
END
GO
/****** Object:  StoredProcedure [dbo].[GetNoteForMaterieAndElev]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetNoteForMaterieAndElev] 
	@MaterieID int,
	@ElevID int,
	@SemestruID int
AS
BEGIN
	select * from Nota inner join Student_Materie on Nota.id_stud_mat = Student_Materie.id_stud_mat 
    where Student_Materie.id_materie = @MaterieID and Student_Materie.id_elev = @ElevID and Student_Materie.id_sem = @SemestruID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProfesor]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProfesor] 
	@Id_Profesor int
AS
BEGIN
	SELECT * from Profesor where Profesor.id_profesor = @Id_Profesor
END
GO
/****** Object:  StoredProcedure [dbo].[GetProfesorForClase]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProfesorForClase] 
	@Id_clasa int
AS
BEGIN
	SELECT * from Profesor inner join Clasa on Clasa.id_diriginte = Profesor.id_profesor 
	where Clasa.id_clasa = @Id_clasa
END
GO
/****** Object:  StoredProcedure [dbo].[GetProfesori]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProfesori] 

AS
BEGIN
	SELECT * from Profesor
END
GO
/****** Object:  StoredProcedure [dbo].[GetProfesorMaterii]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProfesorMaterii] 

AS
BEGIN
	SELECT * from Profesor_Materie
END
GO
/****** Object:  StoredProcedure [dbo].[GetSemestre]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSemestre] 

AS
BEGIN
	SELECT * from Semestru
END
GO
/****** Object:  StoredProcedure [dbo].[GetSpecializari]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSpecializari] 

AS
BEGIN
	SELECT * from Specializare
END
GO
/****** Object:  StoredProcedure [dbo].[MotiveazaAbsenta]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MotiveazaAbsenta]
	@AbsentaID int
AS
BEGIN
update	Absenta
	set		[tip] = 'Motivata'
	where	id_absenta = @AbsentaID
END
GO
/****** Object:  StoredProcedure [dbo].[SetMedie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SetMedie] 
	@MaterieID int,
	@ElevID int,
	@SemestruID int,
	@Medie float
AS
BEGIN
	update Student_Materie
	set medie = @Medie
	where Student_Materie.id_materie = @MaterieID and Student_Materie.id_elev = @ElevID and Student_Materie.id_sem = @SemestruID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateClasa]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateClasa]
	@ClasaID int,
	@DiriginteID int,
	@Nume_Clasa  varchar(50),
	@SpecializareID int
AS
BEGIN
update	Clasa
	set		[nume_clasa] = @Nume_Clasa, 
			[id_diriginte] = @DiriginteID,
			[id_specializare] = @SpecializareID
	where	id_clasa = @ClasaID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateElev]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateElev]
	@ElevID int,
	@Nume  varchar(50),
	@Prenume  varchar(50),
	@ClasaID int
AS
BEGIN
update	Elev
	set		[nume] = @Nume, 
			[prenume] = @Prenume,
			[Id_clasa] = @ClasaID
	where	id_elev = @ElevID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateMaterie]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateMaterie]
	@MaterieID int,
	@Nume  varchar(50)
AS
BEGIN
update	Materie
	set		[nume] = @Nume
	where	id_materie = @MaterieID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProfesor]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateProfesor]
	@ProfesorID int,
	@Nume  varchar(50),
	@Prenume  varchar(50),
	@ClasaID int
AS
BEGIN
IF NOT EXISTS (SELECT * FROM Profesor WHERE Id_clasa = @ClasaID)
	BEGIN
		UPDATE Profesor
		SET [nume] = @Nume,
			[prenume] = @Prenume,
			[Id_clasa] = @ClasaID
		WHERE id_profesor = @ProfesorID
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSpecializare]    Script Date: 5/21/2023 4:31:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateSpecializare]
	@SpecializareID int,
	@Nume  varchar(50)
AS
BEGIN
update	Specializare
	set		[nume] = @Nume
	where	id_specializare = @SpecializareID
END
GO
USE [master]
GO
ALTER DATABASE [Tema3] SET  READ_WRITE 
GO
