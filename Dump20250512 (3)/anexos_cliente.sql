-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: anexos
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `id_cliente` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `profissao` varchar(50) NOT NULL,
  `data_nasc` date NOT NULL,
  `rg` varchar(20) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `endereco` varchar(100) NOT NULL,
  `numero_casa` varchar(14) NOT NULL,
  `complemento` varchar(100) NOT NULL,
  `bairro` varchar(50) NOT NULL,
  `cidade` varchar(50) NOT NULL,
  `estado` char(2) NOT NULL,
  `cep` varchar(20) NOT NULL,
  `telefone` varchar(20) NOT NULL,
  `celular` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  PRIMARY KEY (`id_cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (3,'jefferson','gerente de barman','2025-05-10','123456789','123.456.789-00','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(6,'jefferson','gerente de barman','2025-05-10','123456789','123.456.789-00','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(7,'jefferson','gerente de barman','2025-05-10','123456789','123.456.789-00','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(9,'jefferson','barman','2025-05-06','43969447801','43969447801','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(10,'jefferson','barman','2025-05-06','43969447801','43969447801','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(11,'jefferson','barman','2025-05-06','43969447801','43969447801','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(12,'jefferson','barman','2025-05-06','38973228','4396944801','camarupim','333','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(13,'jefferson','barman','2025-05-06','43969447801','43969447801','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(14,'jefferson','barman','2025-05-06','43969447801','43969447801','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(15,'jefferson','barman','2025-05-06','1111111111','22222222222','carapeba','111','casa 6','piraporinha','DIadema','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(16,'jefferson','barman','2025-05-06','1111111111','22222222222','carapeba','111','casa 6','piraporinha','DIadema','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(17,'jefferson','barman','2025-05-06','43969447801','43969447801','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(18,'jefferson','barman','2025-05-06','389732280','439669407','prata','121','casa 3','lapada','congo','RJ','441060','1133445566','1199887766','joaosilva@email.com'),(19,'jefferson','barman','2025-05-06','43969447801','43969447801','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(20,'jefferson','barman','2025-05-06','43969447801','43969447801','Rua das Flores','123','Apto 502','Centro','São Paulo','SP','12345678','1133445566','1199887766','joaosilva@email.com'),(21,'Vitor Lima','Arquiteto de Software','2025-05-06','1234567','123456789','Rua senac jabaquara','123','escola','jabaquara','são paulo','SP','06140450','12345678','123456789','vitor@gmail.com.com'),(22,'DBNAHNODN','DJSKNAKNFKLN','2025-05-07','FGVSGNANF','NFDANFLAN','NDFKLANF','nfkanfka ','fnlfnand','dnanfan','aknfakndan','SP','sngsnvgn','nfjasnfkan','kngkxn','kgnxkgnkn'),(23,'DBNAHNODN','DJSKNAKNFKLN','2025-05-07','FGVSGNANF','NFDANFLAN','NDFKLANF','nfkanfka ','fnlfnand','dnanfan','aknfakndan','SP','sngsnvgn','nfjasnfkan','kngkxn','kgnxkgnkn'),(24,'Agda Bittencourt','Dona da Empresa','1999-05-09','1234567','777777777','rua da alegria','10','apto na cobertura','jardins','são paulo','SP','01234560','116070607','1160606060','agdamagalhaes@live.com');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-12 21:40:22
