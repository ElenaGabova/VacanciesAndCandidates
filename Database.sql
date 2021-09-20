USE [master]
GO

/****** Object:  Database [VacanciesCandidates]    Script Date: 20.09.2021 23:46:24 ******/
CREATE DATABASE [VacanciesCandidates]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VacanciesCandidates', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\VacanciesCandidates.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VacanciesCandidates_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\VacanciesCandidates_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VacanciesCandidates].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [VacanciesCandidates] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET ARITHABORT OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [VacanciesCandidates] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [VacanciesCandidates] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET  DISABLE_BROKER 
GO

ALTER DATABASE [VacanciesCandidates] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [VacanciesCandidates] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [VacanciesCandidates] SET  MULTI_USER 
GO

ALTER DATABASE [VacanciesCandidates] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [VacanciesCandidates] SET DB_CHAINING OFF 
GO

ALTER DATABASE [VacanciesCandidates] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [VacanciesCandidates] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [VacanciesCandidates] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [VacanciesCandidates] SET QUERY_STORE = OFF
GO

ALTER DATABASE [VacanciesCandidates] SET  READ_WRITE 
GO


USE [VacanciesCandidates]
GO

/****** Object:  Table [dbo].[Candidates]    Script Date: 20.09.2021 23:46:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Candidates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[last_name] [varchar](250) NOT NULL,
	[first_name] [varchar](250) NOT NULL,
	[middle_name] [varchar](250) NULL,
	[no_middle_name] [bit] NULL,
	[dt_birthday] [date] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[gender] [bit] NULL,
	[Rec_Active] [int] NULL,
	[vacancyID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Candidates]  WITH CHECK ADD  CONSTRAINT [CK_Rec_Active] CHECK  (([Rec_Active]>=(0) AND [Rec_Active]<=(1)))
GO

ALTER TABLE [dbo].[Candidates] CHECK CONSTRAINT [CK_Rec_Active]
GO

USE [VacanciesCandidates]
GO

/****** Object:  Table [dbo].[Vacansies]    Script Date: 20.09.2021 23:47:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vacansies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[staffing_item_parrent_full_ext_id] [varchar](255) NULL,
	[staffing_item_full_ext_id] [varchar](255) NOT NULL,
	[fio_vlad] [varchar](255) NOT NULL,
	[telefon_vlad] [varchar](30) NOT NULL,
	[fio_rec] [varchar](255) NOT NULL,
	[telefon_rec] [varchar](30) NOT NULL,
	[email_rec] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [VacanciesCandidates]
GO

/****** Object:  StoredProcedure [dbo].[AddCandidate]    Script Date: 20.09.2021 23:47:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddCandidate]
      @first_name VARCHAR(250), 
	  @last_name  VARCHAR(250), 
      @middle_name VARCHAR(250), 
	  @email VARCHAR(50),
	  @dt_birthday datetime,  
	  @vacancyID int, 
      @gender bit, 
	  @inputCorrect int OUTPUT,
	  @resultText VARCHAR(250) OUTPUT
AS
BEGIN

-- проверка правильной заполненности входных параметров
	IF (LEN(TRIM(@first_name)) = 0 OR
	    LEN(TRIM(@last_name))  = 0)	  
		SET @resultText = 'Некорректное сочетание имени и фамилии'

	IF (@dt_birthday IS NULL or @dt_birthday = '')	  
		SET @resultText = 'Некорректная дата рождения'

	IF (LEN(TRIM(@email)) = 0) or (CHARINDEX('@', @email) = 0)
		SET @resultText = 'Некорректный Email'

	IF (@vacancyID = 0)
		SET @resultText = 'Некорректная вакансия'

	IF (@resultText IS NOT NULL)
		BEGIN
			SET @inputCorrect = 1
			RETURN @inputCorrect
		END

-- Создание новой записи
	INSERT INTO [dbo].[Candidates]
    VALUES
           (@first_name,
            @last_name,
            @middle_name,
            IIF(@middle_name = '', 1, 0),
            @dt_birthday, 
            @email, 
            @gender,
            1,
			@vacancyID)

	SET @resultText = 'Создан новый кандидат'
	SET @inputCorrect = 0
	RETURN @inputCorrect

END
GO


USE [VacanciesCandidates]
GO

/****** Object:  StoredProcedure [dbo].[AddVacancy]    Script Date: 20.09.2021 23:47:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[AddVacancy]
      @staffing_item_parrent_full_ext_id VARCHAR(255), 
	  @staffing_item_full_ext_id  VARCHAR(255), 
      @Fio_vlad VARCHAR(255), 
	  @Telefon_vlad VARCHAR(30),
      @Fio_rec VARCHAR(255), 
      @Telefon_rec VARCHAR(30), 
	  @Email_rec VARCHAR(30), 
	  @inputCorrect int OUTPUT,
	  @resultText VARCHAR(250) OUTPUT
AS
BEGIN

-- проверка правильной заполненности входных параметров
	IF (LEN(TRIM(@staffing_item_parrent_full_ext_id)) = 0)
		SET @resultText = 'Некорректный отдел штатной структуры из вакансии (справочник SAP)'

	IF (LEN(TRIM(@staffing_item_full_ext_id)) = 0)
		SET @resultText = 'Некорректный № штатной должности из вакансии (справочник SAP)'

	IF (LEN(TRIM(@Fio_vlad)) = 0)
		SET @resultText = 'Некорректное ФИО владельца вакансии'

	IF (LEN(TRIM(@Telefon_vlad)) = 0)
		SET @resultText = 'Некорректный номер телефона владельца вакансии'

	IF (LEN(TRIM(@Fio_rec)) = 0)
		SET @resultText = 'Некорректное ФИО рекрутера, ведущего заявку'

	IF (LEN(TRIM(@Telefon_rec)) = 0)
		SET @resultText = 'Некорректный номер телефона рекрутера'

	IF (LEN(TRIM(@Email_rec)) = 0)
		SET @resultText = 'Некорректный Email рекрутера'

	IF (@resultText IS NOT NULL)
		BEGIN
			SET @inputCorrect = 1
			RETURN @inputCorrect
		END

-- Создание новой записи
	INSERT INTO [dbo].[Vacansies]
    VALUES
		(@staffing_item_parrent_full_ext_id,
		@staffing_item_full_ext_id,
		@Fio_vlad,
		@Telefon_vlad,
		@Fio_rec,
		@Telefon_rec,
		@Email_rec)

	SET @resultText = 'Создана новая вакансия'
	SET @inputCorrect = 0
	RETURN @inputCorrect

END
GO


USE [VacanciesCandidates]
GO

/****** Object:  StoredProcedure [dbo].[DeleteCandidate]    Script Date: 20.09.2021 23:47:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE    PROCEDURE [dbo].[DeleteCandidate]
      @candidateID INT
AS
BEGIN
-- Пометка записи на удаление
	UPDATE dbo.Candidates
	SET Rec_Active = 0
	WHERE id =  @candidateID
END
GO

USE [VacanciesCandidates]
GO

/****** Object:  StoredProcedure [dbo].[UpdateCandidate]    Script Date: 20.09.2021 23:47:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateCandidate]
	  @id int,	
      @first_name VARCHAR(250), 
	  @last_name  VARCHAR(250), 
      @middle_name VARCHAR(250), 
	  @email VARCHAR(50), 
	  @dt_birthday datetime,
	  @vacancyID int,  
      @gender bit, 
	  @inputCorrect int OUTPUT,
	  @resultText VARCHAR(250) OUTPUT
AS
BEGIN

-- проверка правильной заполненности входных параметров
	IF (LEN(TRIM(@first_name)) = 0 OR
	    LEN(TRIM(@last_name))  = 0)	  
		SET @resultText = 'Некорректное сочетание имени и фамилии'

	IF (@dt_birthday IS NULL or @dt_birthday = '')	  
		SET @resultText = 'Некорректная дата рождения'

	IF (LEN(TRIM(@email)) = 0) or (CHARINDEX('@', @email) = 0)
		SET @resultText = 'Некорректный Email'

	IF (@vacancyID = 0)
		SET @resultText = 'Некорректная вакансия'

	IF (@resultText IS NOT NULL)
		BEGIN
			SET @inputCorrect = 1
			RETURN @inputCorrect
		END

-- обновление записи
	UPDATE [dbo].[Candidates]
    SET first_name = @first_name,
        last_name  = @last_name,
        middle_name = @middle_name,
        no_middle_name = IIF(@middle_name = '', 1, 0),
        dt_birthday = @dt_birthday, 
        email = @email, 
        gender = @gender,
		vacancyID = @vacancyID
	WHERE id = @id

	SET @resultText = 'Иинформация о кандидиате обновлена'
	SET @inputCorrect = 0
	RETURN @inputCorrect

END
GO


USE [VacanciesCandidates]
GO

/****** Object:  StoredProcedure [dbo].[UpdateVacancy]    Script Date: 20.09.2021 23:47:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [dbo].[UpdateVacancy]
      @id int,	
      @staffing_item_parrent_full_ext_id VARCHAR(255), 
	  @staffing_item_full_ext_id  VARCHAR(255), 
      @Fio_vlad VARCHAR(255), 
	  @Telefon_vlad VARCHAR(30),
      @Fio_rec VARCHAR(255), 
      @Telefon_rec VARCHAR(30), 
	  @Email_rec VARCHAR(30), 
	  @inputCorrect int OUTPUT,
	  @resultText VARCHAR(250) OUTPUT
AS
BEGIN

-- проверка правильной заполненности входных параметров
	IF (LEN(TRIM(@staffing_item_parrent_full_ext_id)) = 0)
		SET @resultText = 'Некорректный отдел штатной структуры из вакансии (справочник SAP)'

	IF (LEN(TRIM(@staffing_item_full_ext_id)) = 0)
		SET @resultText = 'Некорректный № штатной должности из вакансии (справочник SAP)'

	IF (LEN(TRIM(@Fio_vlad)) = 0)
		SET @resultText = 'Некорректное ФИО владельца вакансии'

	IF (LEN(TRIM(@Telefon_vlad)) = 0)
		SET @resultText = 'Некорректный номер телефона владельца вакансии'

	IF (LEN(TRIM(@Fio_rec)) = 0)
		SET @resultText = 'Некорректное ФИО рекрутера, ведущего заявку'

	IF (LEN(TRIM(@Telefon_rec)) = 0)
		SET @resultText = 'Некорректный номер телефона рекрутера'

	IF (LEN(TRIM(@Email_rec)) = 0)
		SET @resultText = 'Некорректный Email рекрутера'

	IF (@resultText IS NOT NULL)
		BEGIN
			SET @inputCorrect = 1
			RETURN @inputCorrect
		END

-- Создание новой записи
	UPDATE [dbo].[Vacansies]
    SET staffing_item_parrent_full_ext_id = @staffing_item_parrent_full_ext_id,
		staffing_item_full_ext_id = @staffing_item_full_ext_id,
		Fio_vlad = @Fio_vlad,
		Telefon_vlad = @Telefon_vlad,
		Fio_rec = @Fio_rec,
		Telefon_rec = @Telefon_rec,
		Email_rec = @Email_rec
	WHERE id = @id

	SET @resultText = 'Иинформация о вакансии обновлена'
	SET @inputCorrect = 0
	RETURN @inputCorrect

END
GO




