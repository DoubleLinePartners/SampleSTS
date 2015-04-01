USE [master]
GO

/****** Object:  Database [SampleSTSAuthentication]    Script Date: 5/9/2014 12:32:04 PM ******/
CREATE DATABASE [SampleSTSAuthentication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SampleSTSAuthentication', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SampleSTSAuthentication.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SampleSTSAuthentication_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SampleSTSAuthentication_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [SampleSTSAuthentication] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SampleSTSAuthentication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SampleSTSAuthentication] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET ARITHABORT OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [SampleSTSAuthentication] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SampleSTSAuthentication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SampleSTSAuthentication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SampleSTSAuthentication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SampleSTSAuthentication] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET RECOVERY FULL 
GO

ALTER DATABASE [SampleSTSAuthentication] SET  MULTI_USER 
GO

ALTER DATABASE [SampleSTSAuthentication] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SampleSTSAuthentication] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SampleSTSAuthentication] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SampleSTSAuthentication] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [SampleSTSAuthentication] SET  READ_WRITE 
GO

