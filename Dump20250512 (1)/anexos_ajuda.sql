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
-- Table structure for table `ajuda`
--

DROP TABLE IF EXISTS `ajuda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ajuda` (
  `id_ajuda` int NOT NULL AUTO_INCREMENT,
  `pergunta` varchar(255) NOT NULL,
  `resposta` text NOT NULL,
  PRIMARY KEY (`id_ajuda`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ajuda`
--

LOCK TABLES `ajuda` WRITE;
/*!40000 ALTER TABLE `ajuda` DISABLE KEYS */;
INSERT INTO `ajuda` VALUES (1,'Como Enviar um Arquivo','1. Acesse o sistema com seu login e senha.\n2. Vá até o módulo onde deseja enviar o arquivo.\n3. Clique em upload.\n4. Selecione o arquivo desejado no seu computador.\n5. Clique em upload para concluir.'),(2,'Como Baixar um Arquivo','1. Localize o arquivo desejado na listagem.\n2. Clique no ícone de download.\n3. O arquivo será baixado para seu computador no local padrão de downloads.'),(3,'Como Cadastrar um Novo Cliente','1. Acesse o sistema com seu login e senha.\n2. Vá até o menu \"novo cliente\".\n3. Preencher formulário de cadastro novo cliente.\n4. Preencha os campos obrigatórios: nome, e-mail, CPF/CNPJ etc.\n5. Clique em cadastrar para concluir o cadastro.'),(4,'Como Editar as Informações do Cliente','1. Acesse o sistema com seu login e senha.\n2. Acesse o menu consulta cliente.\n3. Pesquise o cliente que deseja editar pelo CPF/CNPJ.\n4. Clique no ícone de pesquisar.\n5. Faça as alterações desejadas.\n6. Clique em editar.'),(5,'Como Deletar um Cliente','1. Acesse o sistema com seu login e senha.\n2. Acesse o menu consultar cliente.\n3. Pesquise o cliente que deseja excluir.\n4. Clique no ícone de excluir.\n5. Confirme a exclusão quando solicitado.'),(6,'Como Realizar o Primeiro Acesso','1. Acesse o link enviado por e-mail pelo administrador master.\n2. Digite seu e-mail e senha temporária.\n3. Altere a senha conforme solicitado.\n4. Após isso, você terá acesso ao sistema normalmente.'),(7,'Como Gerar Relatório','1. Acesse o sistema com seu login e senha.\n2. Vá ao menu consulta de cliente para gerar relatório.\n3. Escolha o tipo de relatório desejado e defina filtros.\n4. Clique em gerar.\n5. O sistema exibirá o relatório na tela e disponibilizará para download (PDF ou Excel).');
/*!40000 ALTER TABLE `ajuda` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-12 21:36:37
