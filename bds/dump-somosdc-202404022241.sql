-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: somosdc
-- ------------------------------------------------------
-- Server version	8.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbl_bitacora`
--

DROP TABLE IF EXISTS `tbl_bitacora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_bitacora` (
  `id_bitacora` int NOT NULL AUTO_INCREMENT,
  `fecha` timestamp NULL DEFAULT NULL,
  `evento` varchar(100) DEFAULT NULL,
  `valor` varchar(500) DEFAULT NULL,
  `id_usuario` int DEFAULT NULL,
  PRIMARY KEY (`id_bitacora`),
  KEY `fk_usuario_bitacora` (`id_usuario`),
  CONSTRAINT `fk_usuario_bitacora` FOREIGN KEY (`id_usuario`) REFERENCES `tbl_usuario` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_bitacora`
--

LOCK TABLES `tbl_bitacora` WRITE;
/*!40000 ALTER TABLE `tbl_bitacora` DISABLE KEYS */;
INSERT INTO `tbl_bitacora` VALUES (1,'2024-04-02 03:03:12','Inserción','inicio de sessión de: BackEnd.Models.Login',4),(2,'2024-04-02 03:04:25','Inserción','inicio de sessión de: BackEnd.Models.Login',4),(3,'2024-04-02 03:06:43','Inicio de Sesión','Inicio de sesión de: cristian',4),(4,'2024-04-02 13:56:41','Inicio de Sesión','Inicio de sesión de: cristian',4),(5,'2024-04-03 02:51:36','Inicio de Sesión','Inicio de sesión de: cristian',4),(6,'2024-04-03 02:52:00','Inicio de Sesión','Inicio de sesión de: hola',7),(7,'2024-04-03 02:52:24','Inicio de Sesión','Inicio de sesión de: hola',7);
/*!40000 ALTER TABLE `tbl_bitacora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_caso`
--

DROP TABLE IF EXISTS `tbl_caso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_caso` (
  `id_caso` int NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `hora` varchar(10) DEFAULT NULL,
  `lugar` varchar(100) DEFAULT NULL,
  `nombre_genero` varchar(50) DEFAULT NULL,
  `alias` varchar(50) DEFAULT NULL,
  `dni` varchar(20) DEFAULT NULL,
  `id_orientacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `otro_nombre` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_caso`),
  KEY `fk_caso_orientacion` (`id_orientacion`),
  CONSTRAINT `fk_caso_orientacion` FOREIGN KEY (`id_orientacion`) REFERENCES `tbl_orientacion_sexual` (`id_orientacion`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_caso`
--

LOCK TABLES `tbl_caso` WRITE;
/*!40000 ALTER TABLE `tbl_caso` DISABLE KEYS */;
INSERT INTO `tbl_caso` VALUES (1,NULL,'09:45:00',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(2,'2024-03-08','08:47:00','colonia nueva','Gay','Culay','238978374832',2,'2024-03-30 14:44:17','2024-03-30 15:17:48',1,1,1,0,NULL),(3,'2024-03-08','09:19','lais','lasi','jsajs','8732837',1,'2024-03-30 15:18:13','2024-03-30 15:18:19',1,NULL,1,0,NULL),(4,'2024-03-24','11:03','lugar','sub lugar','lugares','7348973984',2,'2024-03-30 15:48:01','2024-03-30 15:48:07',1,1,1,0,'gaytores');
/*!40000 ALTER TABLE `tbl_caso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_condicion_migratoria`
--

DROP TABLE IF EXISTS `tbl_condicion_migratoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_condicion_migratoria` (
  `id_condicion_migratoria` int NOT NULL AUTO_INCREMENT,
  `nombre_condicion` varchar(40) DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_condicion_migratoria`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_condicion_migratoria`
--

LOCK TABLES `tbl_condicion_migratoria` WRITE;
/*!40000 ALTER TABLE `tbl_condicion_migratoria` DISABLE KEYS */;
INSERT INTO `tbl_condicion_migratoria` VALUES (1,'Turista','2024-03-25 03:10:58',NULL,NULL,1,0,'2024-03-25 02:57:43'),(2,'Residente','2024-03-25 03:08:55',NULL,NULL,1,0,'2024-03-25 03:03:56');
/*!40000 ALTER TABLE `tbl_condicion_migratoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_departamento`
--

DROP TABLE IF EXISTS `tbl_departamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_departamento` (
  `id_departamento` int NOT NULL AUTO_INCREMENT,
  `nombre_departamento` varchar(20) DEFAULT NULL,
  `codigo_departamento` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`id_departamento`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_departamento`
--

LOCK TABLES `tbl_departamento` WRITE;
/*!40000 ALTER TABLE `tbl_departamento` DISABLE KEYS */;
INSERT INTO `tbl_departamento` VALUES (1,'Atlántida','01'),(2,'Colón','02'),(3,'Comayagua','03'),(4,'Copán','04'),(5,'Cortés','05'),(6,'Choluteca','06'),(7,'El Paraiso','07'),(8,'Francisco Morazán','08'),(9,'Gracias a Dios','09'),(10,'Intibucá','10'),(11,'Islas de la Bahia','11'),(12,'La Paz','12'),(13,'Lempira','13'),(14,'Ocotepeque','14'),(15,'Olancho','15'),(16,'Santa Barbara','16'),(17,'Valle','17'),(18,'Yoro','18');
/*!40000 ALTER TABLE `tbl_departamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_dependiente`
--

DROP TABLE IF EXISTS `tbl_dependiente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_dependiente` (
  `id_dependiente` int NOT NULL AUTO_INCREMENT,
  `tipo_dependiente` varchar(40) DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_dependiente`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_dependiente`
--

LOCK TABLES `tbl_dependiente` WRITE;
/*!40000 ALTER TABLE `tbl_dependiente` DISABLE KEYS */;
INSERT INTO `tbl_dependiente` VALUES (1,'Padre',NULL,1,NULL,1,0,NULL),(2,'Madre',NULL,1,NULL,1,0,NULL);
/*!40000 ALTER TABLE `tbl_dependiente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_det_depen_victima`
--

DROP TABLE IF EXISTS `tbl_det_depen_victima`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_det_depen_victima` (
  `id_det_dep_victima` int NOT NULL AUTO_INCREMENT,
  `id_dependiente` int DEFAULT NULL,
  `id_victima` int DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_det_dep_victima`),
  KEY `fk_det_depd_victima` (`id_dependiente`),
  KEY `fk_det_victima` (`id_victima`),
  CONSTRAINT `fk_det_depd_victima` FOREIGN KEY (`id_dependiente`) REFERENCES `tbl_dependiente` (`id_dependiente`),
  CONSTRAINT `fk_det_victima` FOREIGN KEY (`id_victima`) REFERENCES `tbl_victima` (`id_victima`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_det_depen_victima`
--

LOCK TABLES `tbl_det_depen_victima` WRITE;
/*!40000 ALTER TABLE `tbl_det_depen_victima` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_det_depen_victima` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_det_organ_victima`
--

DROP TABLE IF EXISTS `tbl_det_organ_victima`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_det_organ_victima` (
  `id_det_organ_victima` int NOT NULL AUTO_INCREMENT,
  `id_organizacion` int DEFAULT NULL,
  `id_victima` int DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_det_organ_victima`),
  KEY `fk_det_organiz` (`id_organizacion`),
  KEY `fk_det_org_victima` (`id_victima`),
  CONSTRAINT `fk_det_org_victima` FOREIGN KEY (`id_victima`) REFERENCES `tbl_victima` (`id_victima`),
  CONSTRAINT `fk_det_organiz` FOREIGN KEY (`id_organizacion`) REFERENCES `tbl_organizacion` (`id_organizacion`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_det_organ_victima`
--

LOCK TABLES `tbl_det_organ_victima` WRITE;
/*!40000 ALTER TABLE `tbl_det_organ_victima` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_det_organ_victima` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_detalles_sobre_relacion`
--

DROP TABLE IF EXISTS `tbl_detalles_sobre_relacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_detalles_sobre_relacion` (
  `id_detalles_sobre_relacion` int NOT NULL AUTO_INCREMENT,
  `descripcion_detalles_relacion` varchar(100) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_detalles_sobre_relacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_detalles_sobre_relacion`
--

LOCK TABLES `tbl_detalles_sobre_relacion` WRITE;
/*!40000 ALTER TABLE `tbl_detalles_sobre_relacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_detalles_sobre_relacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_enlace_recop_dato`
--

DROP TABLE IF EXISTS `tbl_enlace_recop_dato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_enlace_recop_dato` (
  `id_enlace_recop_dato` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `tipo_archivo` varchar(50) DEFAULT NULL,
  `archivo` longblob,
  `id_generador_hecho` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_enlace_recop_dato`),
  KEY `fk_tbl_generador_h_enlace_rep_dt` (`id_generador_hecho`),
  CONSTRAINT `fk_tbl_generador_h_enlace_rep_dt` FOREIGN KEY (`id_generador_hecho`) REFERENCES `tbl_generador_hecho` (`id_generador_hecho`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_enlace_recop_dato`
--

LOCK TABLES `tbl_enlace_recop_dato` WRITE;
/*!40000 ALTER TABLE `tbl_enlace_recop_dato` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_enlace_recop_dato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_etnia`
--

DROP TABLE IF EXISTS `tbl_etnia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_etnia` (
  `id_etnia` int NOT NULL AUTO_INCREMENT,
  `nombre_etnia` varchar(40) DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_etnia`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_etnia`
--

LOCK TABLES `tbl_etnia` WRITE;
/*!40000 ALTER TABLE `tbl_etnia` DISABLE KEYS */;
INSERT INTO `tbl_etnia` VALUES (1,'Misquito','2024-03-26 01:25:52',NULL,NULL,1,0,'2024-03-26 01:16:32'),(2,'Lenca','2024-03-26 01:25:55',NULL,NULL,1,0,'2024-03-26 01:25:01');
/*!40000 ALTER TABLE `tbl_etnia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_expresion_genero`
--

DROP TABLE IF EXISTS `tbl_expresion_genero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_expresion_genero` (
  `id_expresion_genero` int NOT NULL AUTO_INCREMENT,
  `nombre_expresion` varchar(40) DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_expresion_genero`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_expresion_genero`
--

LOCK TABLES `tbl_expresion_genero` WRITE;
/*!40000 ALTER TABLE `tbl_expresion_genero` DISABLE KEYS */;
INSERT INTO `tbl_expresion_genero` VALUES (1,'Andrógino',NULL,1,NULL,1,0,NULL),(2,'Andrógina',NULL,1,NULL,1,0,NULL),(3,'Femenino',NULL,1,NULL,1,0,NULL),(4,'Masculino',NULL,1,NULL,1,0,NULL);
/*!40000 ALTER TABLE `tbl_expresion_genero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_fuente_dato`
--

DROP TABLE IF EXISTS `tbl_fuente_dato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_fuente_dato` (
  `id_fuente_dato` int NOT NULL AUTO_INCREMENT,
  `descripcion_fuente` varchar(100) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_fuente_dato`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_fuente_dato`
--

LOCK TABLES `tbl_fuente_dato` WRITE;
/*!40000 ALTER TABLE `tbl_fuente_dato` DISABLE KEYS */;
INSERT INTO `tbl_fuente_dato` VALUES (1,'Libros',NULL,NULL,1,NULL,1,0);
/*!40000 ALTER TABLE `tbl_fuente_dato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_generador_hecho`
--

DROP TABLE IF EXISTS `tbl_generador_hecho`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_generador_hecho` (
  `id_generador_hecho` int NOT NULL AUTO_INCREMENT,
  `id_fuente_dato` int DEFAULT NULL,
  `nomb_llenador_dato` varchar(50) DEFAULT NULL,
  `fecha_llenado_dato` date DEFAULT NULL,
  `intitucion_reco_dato` varchar(100) DEFAULT NULL,
  `cargo_dentro_organizacion` varchar(100) DEFAULT NULL,
  `nomb_supervisor` varchar(500) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_generador_hecho`),
  KEY `fk_tbl_gen_h_fue_dt` (`id_fuente_dato`),
  CONSTRAINT `fk_tbl_gen_h_fue_dt` FOREIGN KEY (`id_fuente_dato`) REFERENCES `tbl_fuente_dato` (`id_fuente_dato`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_generador_hecho`
--

LOCK TABLES `tbl_generador_hecho` WRITE;
/*!40000 ALTER TABLE `tbl_generador_hecho` DISABLE KEYS */;
INSERT INTO `tbl_generador_hecho` VALUES (1,1,'Juan Lucas',NULL,'Ong','Auxiliar de datos','Ernesto Jose',NULL,NULL,1,NULL,1,0);
/*!40000 ALTER TABLE `tbl_generador_hecho` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_genero_victima`
--

DROP TABLE IF EXISTS `tbl_genero_victima`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_genero_victima` (
  `id_genero_victima` int NOT NULL AUTO_INCREMENT,
  `tipo_genero_victima` varchar(100) DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_genero_victima`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_genero_victima`
--

LOCK TABLES `tbl_genero_victima` WRITE;
/*!40000 ALTER TABLE `tbl_genero_victima` DISABLE KEYS */;
INSERT INTO `tbl_genero_victima` VALUES (1,'Femenino','2024-03-27 03:35:17',1,1,1,0,'2024-03-27 03:35:17'),(2,'Masculino','2024-03-27 03:35:17',1,1,1,0,'2024-03-27 03:35:17'),(3,'Bixesual','2024-03-27 03:35:17',1,1,1,0,'2024-03-27 03:35:17'),(4,'Transexual','2024-03-27 03:35:17',1,1,1,0,'2024-03-27 03:35:17');
/*!40000 ALTER TABLE `tbl_genero_victima` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_hecho`
--

DROP TABLE IF EXISTS `tbl_hecho`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_hecho` (
  `id_hecho` int NOT NULL AUTO_INCREMENT,
  `id_caso` int DEFAULT NULL,
  `id_generador_hecho` int DEFAULT NULL,
  `fecha_hecho` date DEFAULT NULL,
  `hora_hecho` time DEFAULT NULL,
  `lugar_hecho` varchar(100) DEFAULT NULL,
  `id_genero_victima` int DEFAULT NULL,
  `id_tipo_victima` int DEFAULT NULL,
  `id_tipo_relacion` int DEFAULT NULL,
  `id_modalidad` int DEFAULT NULL,
  `id_detalles_sobre_relacion` int DEFAULT NULL,
  `agresion_sexual` int DEFAULT NULL,
  `denuncia_previa` int DEFAULT NULL,
  `proceso_judicial` int DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_hecho`),
  KEY `fk_caso_hecho` (`id_caso`),
  KEY `fk_generador_hecho` (`id_generador_hecho`),
  KEY `fk_genero_victima_hecho` (`id_genero_victima`),
  KEY `fk_tipo_victima_hecho` (`id_tipo_victima`),
  KEY `fk_tipo_relacion_hecho` (`id_tipo_relacion`),
  KEY `fk_modalidad_hecho` (`id_modalidad`),
  KEY `fk_det_sob_relacion` (`id_detalles_sobre_relacion`),
  CONSTRAINT `fk_caso_hecho` FOREIGN KEY (`id_caso`) REFERENCES `tbl_caso` (`id_caso`),
  CONSTRAINT `fk_det_sob_relacion` FOREIGN KEY (`id_detalles_sobre_relacion`) REFERENCES `tbl_detalles_sobre_relacion` (`id_detalles_sobre_relacion`),
  CONSTRAINT `fk_generador_hecho` FOREIGN KEY (`id_generador_hecho`) REFERENCES `tbl_generador_hecho` (`id_generador_hecho`),
  CONSTRAINT `fk_genero_victima_hecho` FOREIGN KEY (`id_genero_victima`) REFERENCES `tbl_genero_victima` (`id_genero_victima`),
  CONSTRAINT `fk_modalidad_hecho` FOREIGN KEY (`id_modalidad`) REFERENCES `tbl_modalidad` (`id_modalidad`),
  CONSTRAINT `fk_tipo_relacion_hecho` FOREIGN KEY (`id_tipo_relacion`) REFERENCES `tbl_tipo_relacion` (`id_tipo_relacion`),
  CONSTRAINT `fk_tipo_victima_hecho` FOREIGN KEY (`id_tipo_victima`) REFERENCES `tbl_tipo_victima` (`id_tipo_victima`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_hecho`
--

LOCK TABLES `tbl_hecho` WRITE;
/*!40000 ALTER TABLE `tbl_hecho` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_hecho` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_lugar_domicilio`
--

DROP TABLE IF EXISTS `tbl_lugar_domicilio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_lugar_domicilio` (
  `id_lugar_domicilio` int NOT NULL AUTO_INCREMENT,
  `id_departamento` int DEFAULT NULL,
  `id_municipio` int DEFAULT NULL,
  `ciudad` varchar(20) DEFAULT NULL,
  `aldea` varchar(20) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `id_persona` int DEFAULT NULL,
  PRIMARY KEY (`id_lugar_domicilio`),
  KEY `fk_lug_dom_depart` (`id_departamento`),
  KEY `fk_lug_dom_muni` (`id_municipio`),
  KEY `fk_lug_domi_persona` (`id_persona`),
  CONSTRAINT `fk_lug_dom_depart` FOREIGN KEY (`id_departamento`) REFERENCES `tbl_departamento` (`id_departamento`),
  CONSTRAINT `fk_lug_dom_muni` FOREIGN KEY (`id_municipio`) REFERENCES `tbl_municipio` (`id_municipio`),
  CONSTRAINT `fk_lug_domi_persona` FOREIGN KEY (`id_persona`) REFERENCES `tbl_persona` (`id_persona`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_lugar_domicilio`
--

LOCK TABLES `tbl_lugar_domicilio` WRITE;
/*!40000 ALTER TABLE `tbl_lugar_domicilio` DISABLE KEYS */;
INSERT INTO `tbl_lugar_domicilio` VALUES (5,13,202,'h','u','2024-03-13 02:15:46','2024-03-13 23:42:23',1,1,1,0,8),(6,11,162,'nnn','hh',NULL,'2024-03-13 23:13:05',1,1,NULL,NULL,NULL),(7,11,162,'nnn','hh',NULL,'2024-03-13 23:14:28',1,1,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_lugar_domicilio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_lugar_nacimiento`
--

DROP TABLE IF EXISTS `tbl_lugar_nacimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_lugar_nacimiento` (
  `id_lugar_nacimiento` int NOT NULL AUTO_INCREMENT,
  `id_departamento` int DEFAULT NULL,
  `id_municipio` int DEFAULT NULL,
  `ciudad` varchar(20) DEFAULT NULL,
  `aldea` varchar(20) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `id_persona` int DEFAULT NULL,
  PRIMARY KEY (`id_lugar_nacimiento`),
  KEY `fk_lug_nac_depart` (`id_departamento`),
  KEY `fk_lug_nac_muni` (`id_municipio`),
  KEY `fk_lug_nac_persona` (`id_persona`),
  CONSTRAINT `fk_lug_nac_depart` FOREIGN KEY (`id_departamento`) REFERENCES `tbl_departamento` (`id_departamento`),
  CONSTRAINT `fk_lug_nac_muni` FOREIGN KEY (`id_municipio`) REFERENCES `tbl_municipio` (`id_municipio`),
  CONSTRAINT `fk_lug_nac_persona` FOREIGN KEY (`id_persona`) REFERENCES `tbl_persona` (`id_persona`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_lugar_nacimiento`
--

LOCK TABLES `tbl_lugar_nacimiento` WRITE;
/*!40000 ALTER TABLE `tbl_lugar_nacimiento` DISABLE KEYS */;
INSERT INTO `tbl_lugar_nacimiento` VALUES (5,12,174,'mp','mp','2024-03-13 02:15:46','2024-03-13 23:42:13',1,1,1,0,8),(6,4,41,'mjj','mjj',NULL,'2024-03-13 23:13:05',1,1,NULL,NULL,NULL),(7,15,241,'mjj','mjj',NULL,'2024-03-13 23:14:20',1,1,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_lugar_nacimiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_modalidad`
--

DROP TABLE IF EXISTS `tbl_modalidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_modalidad` (
  `id_modalidad` int NOT NULL AUTO_INCREMENT,
  `modalidad` varchar(100) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_modalidad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_modalidad`
--

LOCK TABLES `tbl_modalidad` WRITE;
/*!40000 ALTER TABLE `tbl_modalidad` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_modalidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_municipio`
--

DROP TABLE IF EXISTS `tbl_municipio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_municipio` (
  `id_municipio` int NOT NULL AUTO_INCREMENT,
  `nombre_municipio` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `codigo_municipio` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `id_departamento` int DEFAULT NULL,
  PRIMARY KEY (`id_municipio`),
  KEY `fk_munic_depart` (`id_departamento`),
  CONSTRAINT `fk_munic_depart` FOREIGN KEY (`id_departamento`) REFERENCES `tbl_departamento` (`id_departamento`)
) ENGINE=InnoDB AUTO_INCREMENT=299 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_municipio`
--

LOCK TABLES `tbl_municipio` WRITE;
/*!40000 ALTER TABLE `tbl_municipio` DISABLE KEYS */;
INSERT INTO `tbl_municipio` VALUES (1,'La Ceiba','0101',1),(2,'El Provenir','0102',1),(3,'Esparta','0103',1),(4,'Jutiapa','0104',1),(5,'La Masica','0105',1),(6,'San Francisco','0106',1),(7,'Tela','0107',1),(8,'Arizona','0108',1),(9,'Trujillo','0201',2),(10,'Balfate','0202',2),(11,'Iriona','0203',2),(12,'Limón','0204',2),(13,'Sabá','0205',2),(14,'Santa Fe','0206',2),(15,'Santa Rosa de Aguán','0207',2),(16,'Sonaguera','0208',2),(17,'Tocoa','0209',2),(18,'Bonito Oriental','0210',2),(19,'Comayagua','0301',3),(20,'Ajuterique','0302',3),(21,'El Rosario','0303',3),(22,'Esquías','0304',3),(23,'Humuya','0305',3),(24,'La Libertad','0306',3),(25,'Lamaní','0307',3),(26,'La Trinidad','0308',3),(27,'Lejamaní','0309',3),(28,'Meámbar','0310',3),(29,'Minas de Oro','0311',3),(30,'Ojo de Agua','0312',3),(31,'San Jerónimo','0313',3),(32,'San José de Comayagua','0314',3),(33,'San José del Potrero','0315',3),(34,'San Luis','0316',3),(35,'San Sebastián','0317',3),(36,'Siguatepeque','0318',3),(37,'Villa de San Antonio','0319',3),(38,'Lajas','0320',3),(39,'Taulabe','0321',3),(40,'Santa Rosa de Copán','0401',4),(41,'Cabañas','0402',4),(42,'Concepción','0403',4),(43,'Copán Ruinas','0404',4),(44,'Corquín','0405',4),(45,'Cucuyagua','0406',4),(46,'Dolores','0407',4),(47,'Dulce Nombre','0408',4),(48,'El Paraíso','0409',4),(49,'Florida','0410',4),(50,'La jigua','0411',4),(51,'La Unión','0412',4),(52,'Nueva Arcadia','0413',4),(53,'San Agustín','0414',4),(54,'San Antonio','0415',4),(55,'San Jerónimo','0416',4),(56,'San José','0417',4),(57,'San Juan de Opoa','0418',4),(58,'San Nicolás','0419',4),(59,'San Pedro','0420',4),(60,'Santa Rita','0421',4),(61,'Trinidad de Copán','0422',4),(62,'Veracruz','0423',4),(63,'San Pedro Sula','0501',5),(64,'Choloma','0502',5),(65,'Omoa','0503',5),(66,'Pimienta','0504',5),(67,'Potrerillos','0505',5),(68,'Puerto Cortés','0506',5),(69,'San Antonio de Cortés','0507',5),(70,'San Francisco de Yojoa','0508',5),(71,'San Manuel','0509',5),(72,'San Cruz de Yojoa','0510',5),(73,'Villanueva','0511',5),(74,'La Lima','0512',5),(75,'Choluteca','0601',6),(76,'Apacilagua','0602',6),(77,'Concepción de María','0603',6),(78,'Duyure','0604',6),(79,'El Corpus','0605',6),(80,'El Triunfo','0606',6),(81,'Marcovia','0607',6),(82,'Morolica','0608',6),(83,'Namasigue','0609',6),(84,'Orocuina','0610',6),(85,'Pespire','0611',6),(86,'San Antonio de Flores','0612',6),(87,'San Isidro','0613',6),(88,'San José','0614',6),(89,'San Marcos de Colón','0615',6),(90,'San Ana de Yusguare','0616',6),(91,'Yuscarán','0701',7),(92,'Alauca','0702',7),(93,'Danlí','0703',7),(94,'El Paraiso','0704',7),(95,'Guinope','0705',7),(96,'Jacaleapa','0706',7),(97,'Liure','0707',7),(98,'Morocelí','0708',7),(99,'Oropolí','0709',7),(100,'Potrerillos','0710',7),(101,'San Antonio de Flores','0711',7),(102,'San Lucas','0712',7),(103,'San Matías','0713',7),(104,'Soledad','0714',7),(105,'Teupasenti','0715',7),(106,'Texiguat','0716',7),(107,'Vado Ancho','0717',7),(108,'Yauyupe','0718',7),(109,'Trojes','0719',7),(110,'Tegucigalpa D.C.','0801',8),(111,'Alubarén','0802',8),(112,'Cedros','0803',8),(113,'Curarén','0804',8),(114,'El Porvenir','0805',8),(115,'Guaimaca','0806',8),(116,'La Libertad','0807',8),(117,'La Venta','0808',8),(118,'Lepaterique','0809',8),(119,'Maraita','0810',8),(120,'Marale','0811',8),(121,'Nueva Armenia','0812',8),(122,'Ojojons','0813',8),(123,'Orica','0814',8),(124,'Reitoca','0815',8),(125,'Sabanagrande','0816',8),(126,'San Antonio de Oriente','0817',8),(127,'San Buenaventura','0818',8),(128,'San Ignacio','0819',8),(129,'San Juan de Flores','0820',8),(130,'San Miguelito','0821',8),(131,'Santa Ana','0822',8),(132,'Santa Lucia','0823',8),(133,'Talanga','0824',8),(134,'Tatumbla','0825',8),(135,'Valle de Angeles','0826',8),(136,'Villa de San Fracisco','0827',8),(137,'Vallecillo','0828',8),(138,'Puerto Lempira','0901',9),(139,'Brus Laguna','0902',9),(140,'Ahuas','0903',9),(141,'Juan Francisco Bulnes','0904',9),(142,'Villeda Morales','0905',9),(143,'Wampusirpe','0906',9),(144,'La Esperanza','1001',10),(145,'Camasca','1002',10),(146,'Colomoncagua','1003',10),(147,'Concepción','1004',10),(148,'Dolores','1005',10),(149,'Intibucá','1006',10),(150,'Jesús de Otoro','1007',10),(151,'Magdalena','1008',10),(152,'Masaguara','1009',10),(153,'San Antonio','1010',10),(154,'San isidro','1011',10),(155,'San Juan de Flores','1012',10),(156,'San Marcos de la Sierra','1013',10),(157,'San Miguel Guancapla','1014',10),(158,'Santa Lucía','1015',10),(159,'Yamaranguila','1016',10),(160,'San Francisco de Opalaca','1017',10),(161,'Roatán','1101',11),(162,'Guanaja','1102',11),(163,'José Santos Guardiola','1103',11),(164,'Utila','1104',11),(165,'La Paz','1201',12),(166,'Aguanqueterique','1202',12),(167,'Cabañas','1203',12),(168,'Cane','1204',12),(169,'Chinacla','1205',12),(170,'Guajiquiro','1206',12),(171,'Lauterique','1207',12),(172,'Marcala','1208',12),(173,'Mecedes de Oriente','1209',12),(174,'Opatoro','1210',12),(175,'San Antonio del Norte','1211',12),(176,'San José','1212',12),(177,'San Juan','1213',12),(178,'San Pedro de Tutule','1214',12),(179,'Santa Ana','1215',12),(180,'Santa Elena','1216',12),(181,'Santa María','1217',12),(182,'Santiago de Puringla','1218',12),(183,'Yarula','1219',12),(184,'Gracias','1301',13),(185,'Belén','1302',13),(186,'Candelaria','1303',13),(187,'Cololaca','1304',13),(188,'Erandique','1305',13),(189,'Gualcinse','1306',13),(190,'Guarita','1307',13),(191,'La Campa','1308',13),(192,'La Iguala','1309',13),(193,'Las Flores','1310',13),(194,'La Unión','1311',13),(195,'La Virtud','1312',13),(196,'Lepaera','1313',13),(197,'Mapulaca','1314',13),(198,'Piraera','1315',13),(199,'San Andrés','1316',13),(200,'San Francisco','1317',13),(201,'San Juan Guarita','1318',13),(202,'San Manuel Colohete','1319',13),(203,'San Rafael','1320',13),(204,'San Sebastian','1321',13),(205,'Santa Cruz','1322',13),(206,'Algua','1323',13),(207,'Tambla','1324',13),(208,'Tomalá','1325',13),(209,'Valladolid','1326',13),(210,'Virginia','1327',13),(211,'San Marcos de Caiquín','1328',13),(212,'Nueva Ocotepeque','1401',14),(213,'Belén Gualcho','1402',14),(214,'Concepción','1403',14),(215,'Dolores Merendón','1404',14),(216,'Fraterninda','1405',14),(217,'La Encarnación','1406',14),(218,'La Labor','1407',14),(219,'Lucerna','1408',14),(220,'Mercedes','1409',14),(221,'San Fernando','1410',14),(222,'San Francisco del Valle','1411',14),(223,'San Jorge','1412',14),(224,'San Marcos','1413',14),(225,'Sante Fé','1414',14),(226,'Sensenti','1415',14),(227,'Sinuapa','1416',14),(228,'Juticalpa','1501',15),(229,'Campamento','1502',15),(230,'Catacamas','1503',15),(231,'Concordia','1504',15),(232,'Dulce nombre de Culmí','1505',15),(233,'El Rosario','1506',15),(234,'Esquipulas del Norte','1507',15),(235,'Gualaco','1508',15),(236,'Guarizama','1509',15),(237,'Guata','1510',15),(238,'Guayape','1511',15),(239,'Jano','1512',15),(240,'La Unión','1513',15),(241,'Manguile','1514',15),(242,'Manto','1515',15),(243,'Salamá','1516',15),(244,'San Esteban','1517',15),(245,'San Francisco de Becera','1518',15),(246,'San Francisco de la Paz','1519',15),(247,'Santa María del Real','1520',15),(248,'Silca','1521',15),(249,'Yocón','1522',15),(250,'Froylán Turcios','1523',15),(251,'Santa Bárbara','1601',16),(252,'Arada','1602',16),(253,'Atima','1603',16),(254,'Azacual','1604',16),(255,'Ceguaca','1605',16),(256,'Colinas','1606',16),(257,'Concepción del Norte','1607',16),(258,'Concepción del Sur','1608',16),(259,'Chinda','1609',16),(260,'El Níspero','1610',16),(261,'Gualala','1611',16),(262,'Ilama','1612',16),(263,'Macuelizo','1613',16),(264,'Naranjito','1614',16),(265,'Nueva Celilac','1615',16),(266,'Petoa','1616',16),(267,'Protección','1617',16),(268,'Quimistán','1618',16),(269,'San Francisco de Ojuera','1619',16),(270,'San Luis','1620',16),(271,'San Marcos','1621',16),(272,'San Nicolás','1622',16),(273,'San Pedro Zacapa','1623',16),(274,'Santa Rita','1624',16),(275,'San Vicente Centenario','1625',16),(276,'Trinidad','1626',16),(277,'Las Vegas','1627',16),(278,'Nueva Frontera','1628',16),(279,'Nacaome','1701',17),(280,'Alianza','1702',17),(281,'Amapala','1703',17),(282,'Aramecina','1704',17),(283,'Caridad','1705',17),(284,'Guascorán','1706',17),(285,'Langue','1707',17),(286,'San Francisco de Coray','1708',17),(287,'San Lorenzo','1709',17),(288,'Yoro','1801',18),(289,'Arenal','1802',18),(290,'El Negrito','1803',18),(291,'EL Progreso','1804',18),(292,'Jocón','1805',18),(293,'Morazán','1806',18),(294,'Olanchito','1807',18),(295,'Santa Rita','1808',18),(296,'Sulaco','1809',18),(297,'Victoria','1810',18),(298,'Yorito','1811',18);
/*!40000 ALTER TABLE `tbl_municipio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_nivel_educacion`
--

DROP TABLE IF EXISTS `tbl_nivel_educacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_nivel_educacion` (
  `id_nivel_educ` int NOT NULL AUTO_INCREMENT,
  `nombre_nivel` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_nivel_educ`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_nivel_educacion`
--

LOCK TABLES `tbl_nivel_educacion` WRITE;
/*!40000 ALTER TABLE `tbl_nivel_educacion` DISABLE KEYS */;
INSERT INTO `tbl_nivel_educacion` VALUES (1,'Universida Completa','2024-03-11 00:25:02','2024-03-11 00:25:02',0,0,0,0),(2,'Universida incompleta','2024-03-11 00:25:02','2024-03-11 00:25:02',0,0,0,0);
/*!40000 ALTER TABLE `tbl_nivel_educacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_objeto`
--

DROP TABLE IF EXISTS `tbl_objeto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_objeto` (
  `id_objeto` int NOT NULL AUTO_INCREMENT,
  `id_objeto_padre` int DEFAULT NULL,
  `nombre_objeto` varchar(300) DEFAULT NULL,
  `ruta` varchar(50) DEFAULT NULL,
  `icono` varchar(30) DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_objeto`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_objeto`
--

LOCK TABLES `tbl_objeto` WRITE;
/*!40000 ALTER TABLE `tbl_objeto` DISABLE KEYS */;
INSERT INTO `tbl_objeto` VALUES (1,1,'Seleccionar Objeto Como Padre','padre',NULL,1,0),(2,3,'Usuarios','seguridad/usuarios','group_add',1,0),(3,1,'Seguridad','segurida','security',1,0),(4,3,'Roles','seguridad/roles','group',1,0),(5,3,'Objetos','seguridad/objetos','data_object',1,0),(6,1,'Mantenimientos','mantenimientos','list_alt',1,0),(7,6,'Estados','mantenimientos/estados','status',1,0),(8,3,'Parametros','seguridad/parametros','display_settings',1,0),(9,3,'Preguntas','seguridad/preguntas','question_mark',1,0),(10,3,'prueba','seguridad/prueba','prueba',1,0),(11,3,'Permisos','seguridad/permisos','admin_panel_settings',1,0),(12,1,'Home','home','home',1,0),(13,12,'Dashboard','home/dashboard','dashboard',1,0),(14,1,'Gestión de Personas','victimas','group',1,0),(15,14,'Agregar Victima','gestionPersonas/addEditVictima','groups',1,0),(16,14,'Persona','gestionPersonas/personas','sports_kabaddi',1,0),(17,6,'Orientaciones Sexuales','mantenimientos/orientacion_sexual','wc',1,0),(18,6,'Condiciones Migratorias','mantenimientos/condicion_migratoria','flights_and_hotels',1,0),(19,6,'Etnias','mantenimientos/etnias','social_distance',1,0),(20,1,'Gestión de Victimas','gestion_persona','group',1,0),(21,20,'Victimas','victimas/lista_victimas','group2',1,0),(22,1,'Gestión de Casos','casos','list',1,0),(23,22,'Lista de caso','casos/lista_casos','list',1,0);
/*!40000 ALTER TABLE `tbl_objeto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_organizacion`
--

DROP TABLE IF EXISTS `tbl_organizacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_organizacion` (
  `id_organizacion` int NOT NULL AUTO_INCREMENT,
  `nombre_organizacion` varchar(40) DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_organizacion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_organizacion`
--

LOCK TABLES `tbl_organizacion` WRITE;
/*!40000 ALTER TABLE `tbl_organizacion` DISABLE KEYS */;
INSERT INTO `tbl_organizacion` VALUES (1,'Organizaión',NULL,1,NULL,1,0,NULL),(2,'USAID',NULL,1,NULL,1,0,NULL);
/*!40000 ALTER TABLE `tbl_organizacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_orientacion_sexual`
--

DROP TABLE IF EXISTS `tbl_orientacion_sexual`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_orientacion_sexual` (
  `id_orientacion` int NOT NULL AUTO_INCREMENT,
  `orientacion` varchar(30) DEFAULT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_orientacion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_orientacion_sexual`
--

LOCK TABLES `tbl_orientacion_sexual` WRITE;
/*!40000 ALTER TABLE `tbl_orientacion_sexual` DISABLE KEYS */;
INSERT INTO `tbl_orientacion_sexual` VALUES (1,'sexual',NULL,NULL,NULL,NULL,NULL,1,0),(2,'gay','mero gay',NULL,NULL,1,NULL,1,0);
/*!40000 ALTER TABLE `tbl_orientacion_sexual` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_permiso`
--

DROP TABLE IF EXISTS `tbl_permiso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_permiso` (
  `id_permiso` int NOT NULL AUTO_INCREMENT,
  `id_objeto` int DEFAULT NULL,
  `id_rol` int DEFAULT NULL,
  `ver` int DEFAULT NULL,
  `agregar` int DEFAULT NULL,
  `editar` int DEFAULT NULL,
  `eliminar` int DEFAULT NULL,
  `reporte` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_permiso`),
  KEY `fk_objeto_permiso` (`id_objeto`),
  KEY `fk_rol_permiso` (`id_rol`),
  CONSTRAINT `fk_objeto_permiso` FOREIGN KEY (`id_objeto`) REFERENCES `tbl_objeto` (`id_objeto`),
  CONSTRAINT `fk_rol_permiso` FOREIGN KEY (`id_rol`) REFERENCES `tbl_rol` (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_permiso`
--

LOCK TABLES `tbl_permiso` WRITE;
/*!40000 ALTER TABLE `tbl_permiso` DISABLE KEYS */;
INSERT INTO `tbl_permiso` VALUES (1,2,4,1,1,1,1,1,1,0),(2,4,4,1,1,1,1,1,1,0),(3,2,5,1,1,1,1,1,1,0),(4,4,5,1,1,1,1,1,1,0),(5,5,5,1,1,1,1,1,1,0),(6,8,5,1,1,1,1,1,1,0),(7,9,5,1,1,1,1,1,1,0),(8,10,5,1,1,1,1,1,1,0),(9,7,5,1,1,1,1,1,1,0),(10,11,5,1,1,1,1,1,1,0),(11,13,5,1,1,1,1,1,1,0),(12,4,4,1,1,1,1,1,1,0),(13,2,4,1,1,1,1,1,1,0),(14,8,4,1,1,1,1,1,1,0),(15,9,4,1,1,1,1,1,1,0),(16,13,4,1,1,1,1,1,1,0),(17,15,5,1,1,1,1,1,1,0),(18,16,5,1,1,1,1,1,1,0),(19,17,5,1,1,1,1,1,1,0),(20,18,5,1,1,1,1,1,1,0),(21,19,5,1,1,1,1,1,1,0),(22,21,5,1,1,1,1,1,1,0),(23,23,5,1,1,1,1,1,1,0);
/*!40000 ALTER TABLE `tbl_permiso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_persona`
--

DROP TABLE IF EXISTS `tbl_persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_persona` (
  `id_persona` int NOT NULL AUTO_INCREMENT,
  `dni` varchar(20) DEFAULT NULL,
  `nombre_legal` varchar(100) DEFAULT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `estado_civil` enum('Soltero/a','Casado/a','Unión libre o unión de hecho','Separado/a','Divorciado/a','Viudo/a.\r\n') DEFAULT NULL,
  `agravantes` varchar(300) DEFAULT NULL,
  `nacionalidad` varchar(50) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `id_nivel_educ` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_persona`),
  KEY `fk_persona_nivel_educ` (`id_nivel_educ`),
  CONSTRAINT `fk_persona_nivel_educ` FOREIGN KEY (`id_nivel_educ`) REFERENCES `tbl_nivel_educacion` (`id_nivel_educ`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_persona`
--

LOCK TABLES `tbl_persona` WRITE;
/*!40000 ALTER TABLE `tbl_persona` DISABLE KEYS */;
INSERT INTO `tbl_persona` VALUES (8,'0801199922323','Jorge Andres Gamez Palacios','2000-02-05','Soltero/a','Choche enfrente de tigo','Hondurena','98372878',2,'2024-03-13 02:15:46','2024-03-13 23:42:02',1,1,1,0);
/*!40000 ALTER TABLE `tbl_persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pregunta`
--

DROP TABLE IF EXISTS `tbl_pregunta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_pregunta` (
  `id_pregunta` int NOT NULL AUTO_INCREMENT,
  `pregunta` varchar(50) DEFAULT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_pregunta`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_pregunta`
--

LOCK TABLES `tbl_pregunta` WRITE;
/*!40000 ALTER TABLE `tbl_pregunta` DISABLE KEYS */;
INSERT INTO `tbl_pregunta` VALUES (1,'Color Favorito','Color favorito del usuario para recuperar contraseña',1,0),(2,'Nombre de Mascota Favorita','Nombre de mascota favorita del usuario para recuperar contraseña',1,0),(3,'Apodo de niño','Apodo del niño del usuario n',1,0);
/*!40000 ALTER TABLE `tbl_pregunta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_pregunta_usuario`
--

DROP TABLE IF EXISTS `tbl_pregunta_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_pregunta_usuario` (
  `id_pregunta_usuario` int NOT NULL AUTO_INCREMENT,
  `id_usuario` int DEFAULT NULL,
  `id_pregunta` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `respuesta` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_pregunta_usuario`),
  KEY `fk_tbl_usuario_prg_usu` (`id_usuario`),
  KEY `fk_tbl_pregunta_prg_usu` (`id_pregunta`),
  CONSTRAINT `fk_tbl_pregunta_prg_usu` FOREIGN KEY (`id_pregunta`) REFERENCES `tbl_pregunta` (`id_pregunta`),
  CONSTRAINT `fk_tbl_usuario_prg_usu` FOREIGN KEY (`id_usuario`) REFERENCES `tbl_usuario` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_pregunta_usuario`
--

LOCK TABLES `tbl_pregunta_usuario` WRITE;
/*!40000 ALTER TABLE `tbl_pregunta_usuario` DISABLE KEYS */;
INSERT INTO `tbl_pregunta_usuario` VALUES (1,4,1,'2024-04-01 20:10:36',NULL,NULL,NULL,'U'),(2,4,2,'2024-04-01 20:10:36',NULL,NULL,NULL,'K'),(3,4,3,'2024-04-01 20:10:36',NULL,NULL,NULL,'K'),(8,7,1,'2024-04-03 03:18:05',NULL,7,NULL,'N'),(9,7,2,'2024-04-03 03:18:07',NULL,7,NULL,'8'),(10,7,3,'2024-04-03 03:18:08',NULL,7,NULL,'7'),(11,7,1,'2024-04-03 03:21:10',NULL,7,NULL,'U'),(12,7,2,'2024-04-03 03:21:10',NULL,7,NULL,'6'),(13,7,3,'2024-04-03 03:21:10',NULL,7,NULL,'N');
/*!40000 ALTER TABLE `tbl_pregunta_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_reporte_actual`
--

DROP TABLE IF EXISTS `tbl_reporte_actual`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_reporte_actual` (
  `id_reporte_actual` int NOT NULL AUTO_INCREMENT,
  `fecha` datetime DEFAULT NULL,
  `lugar` varchar(100) DEFAULT NULL,
  `diligencia_realizada` varchar(70) DEFAULT NULL,
  `institucion_consultada` varchar(100) DEFAULT NULL,
  `nombre_autoridad_consultada` varchar(50) DEFAULT NULL,
  `estado_proceso` enum('Positivo','Negativo') DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_reporte_actual`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_reporte_actual`
--

LOCK TABLES `tbl_reporte_actual` WRITE;
/*!40000 ALTER TABLE `tbl_reporte_actual` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_reporte_actual` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_rol`
--

DROP TABLE IF EXISTS `tbl_rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_rol` (
  `id_rol` int NOT NULL AUTO_INCREMENT,
  `nombre_rol` varchar(30) DEFAULT NULL,
  `descripcion` varchar(300) DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_rol`
--

LOCK TABLES `tbl_rol` WRITE;
/*!40000 ALTER TABLE `tbl_rol` DISABLE KEYS */;
INSERT INTO `tbl_rol` VALUES (1,'Administrador','Administrar',1,NULL),(2,'string','string',1,NULL),(3,'Auxiliar','Usuario del sistema',1,NULL),(4,'Auxiliar1','Encargada de llevar documentos',1,0),(5,'Super Administrador','Administrar todo el sistema',1,0),(6,'ndjndjsnd','jdjsndjsd',1,NULL);
/*!40000 ALTER TABLE `tbl_rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_tipo_relacion`
--

DROP TABLE IF EXISTS `tbl_tipo_relacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_tipo_relacion` (
  `id_tipo_relacion` int NOT NULL AUTO_INCREMENT,
  `tipo_relacion` varchar(100) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_tipo_relacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_tipo_relacion`
--

LOCK TABLES `tbl_tipo_relacion` WRITE;
/*!40000 ALTER TABLE `tbl_tipo_relacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_tipo_relacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_tipo_reporte`
--

DROP TABLE IF EXISTS `tbl_tipo_reporte`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_tipo_reporte` (
  `id_tipo_reporte` int NOT NULL AUTO_INCREMENT,
  `circular` varchar(20) DEFAULT NULL,
  `columnas` varchar(20) DEFAULT NULL,
  `lineal` varchar(20) DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_tipo_reporte`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_tipo_reporte`
--

LOCK TABLES `tbl_tipo_reporte` WRITE;
/*!40000 ALTER TABLE `tbl_tipo_reporte` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_tipo_reporte` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_tipo_victima`
--

DROP TABLE IF EXISTS `tbl_tipo_victima`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_tipo_victima` (
  `id_tipo_victima` int NOT NULL AUTO_INCREMENT,
  `tipo_victima` varchar(100) DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_tipo_victima`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_tipo_victima`
--

LOCK TABLES `tbl_tipo_victima` WRITE;
/*!40000 ALTER TABLE `tbl_tipo_victima` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_tipo_victima` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_usuario`
--

DROP TABLE IF EXISTS `tbl_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(30) DEFAULT NULL,
  `contrasena` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `correo` varchar(30) DEFAULT NULL,
  `contrasena_segura` int DEFAULT NULL,
  `cambio_contrasena` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `id_rol` int DEFAULT NULL,
  PRIMARY KEY (`id_usuario`),
  KEY `fk_rol_usuario` (`id_rol`),
  CONSTRAINT `fk_rol_usuario` FOREIGN KEY (`id_rol`) REFERENCES `tbl_rol` (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_usuario`
--

LOCK TABLES `tbl_usuario` WRITE;
/*!40000 ALTER TABLE `tbl_usuario` DISABLE KEYS */;
INSERT INTO `tbl_usuario` VALUES (1,'jose.perez','$2a$12$KCga/fVw9wainf2JqmssBOuJ1KloW.rPQj3FYnhmdp/6vbOrhZ3EC','Jose Perez','pere22@gmail.com',1,0,1,0,5),(2,'angel.gomez','$2a$12$bAzMFgxo/CdNdQeHbj0lRuQazTlDgaMubAnWmgCnDZl14XZ1VppDq','Angel Gomez','perez@gamil.com',0,1,1,0,5),(3,'arnol','$2a$12$YhA4FwD8lzcRzsiMSYde2ORAwc/7/9gMoJMEq8kaFeN35zbAcHsby','Arnol','perez@gamil.com',0,1,1,1,5),(4,'cristian','$2a$12$3mLFqfIF7BLwSaZ0jVdNhubWXkDH3Y41rZe18HrenxFEsMApyZtoG','cristianm','cris',1,0,1,0,5),(7,'hola','$2a$12$nRUDGxxhDqVcxEW1A.DyDe3MZsVXnpIKVIveIiczolsfyezE.UOJK','hola','pere22@gmail.com',1,0,1,0,5);
/*!40000 ALTER TABLE `tbl_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_victima`
--

DROP TABLE IF EXISTS `tbl_victima`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_victima` (
  `id_victima` int NOT NULL AUTO_INCREMENT,
  `id_persona` int DEFAULT NULL,
  `nombre_legal` varchar(50) DEFAULT NULL,
  `cambio_nom_legal_victima` varchar(50) DEFAULT NULL,
  `nombre_ident_genero` varchar(100) DEFAULT NULL,
  `otro_nombres` varchar(50) DEFAULT NULL,
  `id_genero_victima` int DEFAULT NULL,
  `id_expresion_genero` int DEFAULT NULL,
  `id_orientacion` int DEFAULT NULL,
  `ocupacion` varchar(100) DEFAULT NULL,
  `discapacidad_victima` int DEFAULT NULL,
  `id_condicion_migratoria` int DEFAULT NULL,
  `id_etnia` int DEFAULT NULL,
  `hijos` int DEFAULT NULL,
  `cant_hijos` int DEFAULT NULL,
  `cant_hijos_men` int DEFAULT NULL,
  `cant_hijos_may` int DEFAULT NULL,
  `cant_pers_dependiente` int DEFAULT NULL,
  `perteneciente_organizacion` int DEFAULT NULL,
  `denucia_previa` int DEFAULT NULL,
  `numero_caso` int DEFAULT NULL,
  `tipo_denucia` varchar(300) DEFAULT NULL,
  `nom_insti_denucia` varchar(300) DEFAULT NULL,
  `medidas_proteccion` varchar(300) DEFAULT NULL,
  `tipo_med_proteccion` varchar(100) DEFAULT NULL,
  `id_generador_hecho` int DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_victima`),
  KEY `fk_victima_pers` (`id_persona`),
  KEY `fk_generador_victima` (`id_generador_hecho`),
  KEY `fk_vicitma_genero_vi` (`id_genero_victima`),
  KEY `fk_expresion_gen_victima` (`id_expresion_genero`),
  KEY `fk_vicitma_orient_sexual` (`id_orientacion`),
  KEY `fk_victi_cond_migratoria` (`id_condicion_migratoria`),
  KEY `fk_victi_etnia` (`id_etnia`),
  CONSTRAINT `fk_expresion_gen_victima` FOREIGN KEY (`id_expresion_genero`) REFERENCES `tbl_expresion_genero` (`id_expresion_genero`),
  CONSTRAINT `fk_generador_victima` FOREIGN KEY (`id_generador_hecho`) REFERENCES `tbl_generador_hecho` (`id_generador_hecho`),
  CONSTRAINT `fk_vicitma_genero_vi` FOREIGN KEY (`id_genero_victima`) REFERENCES `tbl_genero_victima` (`id_genero_victima`),
  CONSTRAINT `fk_vicitma_orient_sexual` FOREIGN KEY (`id_orientacion`) REFERENCES `tbl_orientacion_sexual` (`id_orientacion`),
  CONSTRAINT `fk_victi_cond_migratoria` FOREIGN KEY (`id_condicion_migratoria`) REFERENCES `tbl_condicion_migratoria` (`id_condicion_migratoria`),
  CONSTRAINT `fk_victi_etnia` FOREIGN KEY (`id_etnia`) REFERENCES `tbl_etnia` (`id_etnia`),
  CONSTRAINT `fk_victima_pers` FOREIGN KEY (`id_persona`) REFERENCES `tbl_persona` (`id_persona`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_victima`
--

LOCK TABLES `tbl_victima` WRITE;
/*!40000 ALTER TABLE `tbl_victima` DISABLE KEYS */;
INSERT INTO `tbl_victima` VALUES (1,8,'jose jav','jose perezzz','josefina','josefa nena',1,4,1,'sin oficio kk',1,1,1,0,NULL,NULL,NULL,4,0,1,98989,'acoso','salud','aislamiento','curso',1,'2024-03-29 16:13:34',NULL,NULL,1,0,'2024-03-28 00:12:15'),(2,8,'josejjj','jose','josefina','josefa',2,2,1,'sin oficio',0,1,1,1,5,2,5,4,1,1,98989,'acoso','salud','aislamiento','curso',1,NULL,NULL,NULL,1,0,'2024-03-28 04:36:03');
/*!40000 ALTER TABLE `tbl_victima` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `v_casos`
--

DROP TABLE IF EXISTS `v_casos`;
/*!50001 DROP VIEW IF EXISTS `v_casos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_casos` AS SELECT 
 1 AS `id_caso`,
 1 AS `fecha`,
 1 AS `hora`,
 1 AS `lugar`,
 1 AS `nombre_genero`,
 1 AS `alias`,
 1 AS `dni`,
 1 AS `orientacion`,
 1 AS `fecha_creacion`,
 1 AS `fecha_modificacion`,
 1 AS `id_usuario_creo`,
 1 AS `otro_nombre`,
 1 AS `id_usuario_modifico`,
 1 AS `estado`,
 1 AS `estado_eliminacion`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_det_dependientes`
--

DROP TABLE IF EXISTS `v_det_dependientes`;
/*!50001 DROP VIEW IF EXISTS `v_det_dependientes`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_det_dependientes` AS SELECT 
 1 AS `id_det_dep_victima`,
 1 AS `id_dependiente`,
 1 AS `tipo_dependiente`,
 1 AS `id_victima`,
 1 AS `estado`,
 1 AS `estado_eliminacion`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_det_organizaciones`
--

DROP TABLE IF EXISTS `v_det_organizaciones`;
/*!50001 DROP VIEW IF EXISTS `v_det_organizaciones`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_det_organizaciones` AS SELECT 
 1 AS `id_det_organ_victima`,
 1 AS `id_organizacion`,
 1 AS `id_victima`,
 1 AS `estado`,
 1 AS `estado_eliminacion`,
 1 AS `nombre_organizacion`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_permisos`
--

DROP TABLE IF EXISTS `v_permisos`;
/*!50001 DROP VIEW IF EXISTS `v_permisos`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_permisos` AS SELECT 
 1 AS `id_permiso`,
 1 AS `id_objeto`,
 1 AS `id_rol`,
 1 AS `ver`,
 1 AS `agregar`,
 1 AS `editar`,
 1 AS `eliminar`,
 1 AS `reporte`,
 1 AS `estado`,
 1 AS `estado_eliminacion`,
 1 AS `id_objeto_padre`,
 1 AS `nombre_objeto`,
 1 AS `icono_hijo`,
 1 AS `nombre_objeto_padre`,
 1 AS `icono_padre`,
 1 AS `ruta`,
 1 AS `icono`,
 1 AS `nombre_rol`,
 1 AS `estado_permiso`,
 1 AS `estado_eliminacion_permiso`,
 1 AS `estado_objeto`,
 1 AS `estado_eliminacion_objeto`,
 1 AS `estado_rol`,
 1 AS `estado_eliminacion_rol`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_personas`
--

DROP TABLE IF EXISTS `v_personas`;
/*!50001 DROP VIEW IF EXISTS `v_personas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_personas` AS SELECT 
 1 AS `id_persona`,
 1 AS `dni`,
 1 AS `nombre_legal`,
 1 AS `edad`,
 1 AS `fecha_nacimiento`,
 1 AS `estado_civil`,
 1 AS `agravantes`,
 1 AS `nacionalidad`,
 1 AS `telefono`,
 1 AS `estado`,
 1 AS `estado_eliminacion`,
 1 AS `id_nivel_educ`,
 1 AS `nombre_nivel`,
 1 AS `id_lugar_nacimiento`,
 1 AS `nombre_departamento_nac`,
 1 AS `id_departamento_nac`,
 1 AS `id_municipio_nac`,
 1 AS `nombre_municipio_nac`,
 1 AS `ciudad_nac`,
 1 AS `aldea_nac`,
 1 AS `id_lugar_domicilio`,
 1 AS `nombre_departamento_dom`,
 1 AS `id_departamento_dom`,
 1 AS `id_municipio_dom`,
 1 AS `nombre_municipio_dom`,
 1 AS `ciudad_dom`,
 1 AS `aldea_dom`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_preguntas_usuario`
--

DROP TABLE IF EXISTS `v_preguntas_usuario`;
/*!50001 DROP VIEW IF EXISTS `v_preguntas_usuario`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_preguntas_usuario` AS SELECT 
 1 AS `id_pregunta_usuario`,
 1 AS `id_usuario`,
 1 AS `id_pregunta`,
 1 AS `respuesta`,
 1 AS `usuario`,
 1 AS `nombre`,
 1 AS `correo`,
 1 AS `estado`,
 1 AS `id_rol`,
 1 AS `estado_eliminacion`,
 1 AS `pregunta`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_usuario_login`
--

DROP TABLE IF EXISTS `v_usuario_login`;
/*!50001 DROP VIEW IF EXISTS `v_usuario_login`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_usuario_login` AS SELECT 
 1 AS `id_usuario`,
 1 AS `usuario`,
 1 AS `contrasena`,
 1 AS `nombre`,
 1 AS `correo`,
 1 AS `contrasena_segura`,
 1 AS `cambio_contrasena`,
 1 AS `estado`,
 1 AS `estado_eliminacion`,
 1 AS `id_rol`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_usuario_rol`
--

DROP TABLE IF EXISTS `v_usuario_rol`;
/*!50001 DROP VIEW IF EXISTS `v_usuario_rol`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_usuario_rol` AS SELECT 
 1 AS `id_usuario`,
 1 AS `usuario`,
 1 AS `contrasena`,
 1 AS `nombre`,
 1 AS `correo`,
 1 AS `contrasena_segura`,
 1 AS `cambio_contrasena`,
 1 AS `estado`,
 1 AS `estado_eliminacion`,
 1 AS `id_rol`,
 1 AS `nombre_rol`,
 1 AS `estado_rol`,
 1 AS `estado_eliminacion_rol`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_usuarios`
--

DROP TABLE IF EXISTS `v_usuarios`;
/*!50001 DROP VIEW IF EXISTS `v_usuarios`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_usuarios` AS SELECT 
 1 AS `id_usuario`,
 1 AS `usuario`,
 1 AS `nombre`,
 1 AS `correo`,
 1 AS `contrasena_segura`,
 1 AS `cambio_contrasena`,
 1 AS `estado`,
 1 AS `estado_eliminacion`,
 1 AS `id_rol`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_victimas`
--

DROP TABLE IF EXISTS `v_victimas`;
/*!50001 DROP VIEW IF EXISTS `v_victimas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_victimas` AS SELECT 
 1 AS `id_victima`,
 1 AS `id_persona`,
 1 AS `nombre_legal_persona`,
 1 AS `dni`,
 1 AS `nombre_legal_victima`,
 1 AS `cambio_nom_legal_victima`,
 1 AS `nombre_ident_genero`,
 1 AS `otro_nombres`,
 1 AS `nombre_expresion`,
 1 AS `tipo_genero_victima`,
 1 AS `orientacion`,
 1 AS `ocupacion`,
 1 AS `discapacidad_victima`,
 1 AS `nombre_condicion`,
 1 AS `nombre_etnia`,
 1 AS `hijos`,
 1 AS `cant_hijos`,
 1 AS `cant_hijos_men`,
 1 AS `cant_hijos_may`,
 1 AS `cant_pers_dependiente`,
 1 AS `perteneciente_organizacion`,
 1 AS `denucia_previa`,
 1 AS `numero_caso`,
 1 AS `tipo_denucia`,
 1 AS `nom_insti_denucia`,
 1 AS `medidas_proteccion`,
 1 AS `tipo_med_proteccion`,
 1 AS `nomb_llenador_dato`,
 1 AS `id_usuario_creo`,
 1 AS `estado`,
 1 AS `estado_eliminacion`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'somosdc'
--

--
-- Final view structure for view `v_casos`
--

/*!50001 DROP VIEW IF EXISTS `v_casos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_casos` AS select `tc`.`id_caso` AS `id_caso`,`tc`.`fecha` AS `fecha`,`tc`.`hora` AS `hora`,`tc`.`lugar` AS `lugar`,`tc`.`nombre_genero` AS `nombre_genero`,`tc`.`alias` AS `alias`,`tc`.`dni` AS `dni`,`tos`.`orientacion` AS `orientacion`,`tc`.`fecha_creacion` AS `fecha_creacion`,`tc`.`fecha_modificacion` AS `fecha_modificacion`,`tc`.`id_usuario_creo` AS `id_usuario_creo`,`tc`.`otro_nombre` AS `otro_nombre`,`tc`.`id_usuario_modifico` AS `id_usuario_modifico`,`tc`.`estado` AS `estado`,`tc`.`estado_eliminacion` AS `estado_eliminacion` from (`tbl_caso` `tc` join `tbl_orientacion_sexual` `tos` on((`tc`.`id_orientacion` = `tos`.`id_orientacion`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_det_dependientes`
--

/*!50001 DROP VIEW IF EXISTS `v_det_dependientes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_det_dependientes` AS select `tddv`.`id_det_dep_victima` AS `id_det_dep_victima`,`tddv`.`id_dependiente` AS `id_dependiente`,`td`.`tipo_dependiente` AS `tipo_dependiente`,`tddv`.`id_victima` AS `id_victima`,`tddv`.`estado` AS `estado`,`tddv`.`estado_eliminacion` AS `estado_eliminacion` from (`tbl_det_depen_victima` `tddv` join `tbl_dependiente` `td` on((`tddv`.`id_dependiente` = `td`.`id_dependiente`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_det_organizaciones`
--

/*!50001 DROP VIEW IF EXISTS `v_det_organizaciones`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_det_organizaciones` AS select `tdov`.`id_det_organ_victima` AS `id_det_organ_victima`,`tdov`.`id_organizacion` AS `id_organizacion`,`tdov`.`id_victima` AS `id_victima`,`tdov`.`estado` AS `estado`,`tdov`.`estado_eliminacion` AS `estado_eliminacion`,`tbo`.`nombre_organizacion` AS `nombre_organizacion` from (`tbl_det_organ_victima` `tdov` join `tbl_organizacion` `tbo` on((`tdov`.`id_organizacion` = `tbo`.`id_organizacion`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_permisos`
--

/*!50001 DROP VIEW IF EXISTS `v_permisos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_permisos` AS select `tp`.`id_permiso` AS `id_permiso`,`tp`.`id_objeto` AS `id_objeto`,`tp`.`id_rol` AS `id_rol`,`tp`.`ver` AS `ver`,`tp`.`agregar` AS `agregar`,`tp`.`editar` AS `editar`,`tp`.`eliminar` AS `eliminar`,`tp`.`reporte` AS `reporte`,`tp`.`estado` AS `estado`,`tp`.`estado_eliminacion` AS `estado_eliminacion`,`tob`.`id_objeto_padre` AS `id_objeto_padre`,`tob`.`nombre_objeto` AS `nombre_objeto`,`tob`.`icono` AS `icono_hijo`,`to2`.`nombre_objeto` AS `nombre_objeto_padre`,`to2`.`icono` AS `icono_padre`,`tob`.`ruta` AS `ruta`,`tob`.`icono` AS `icono`,`tr`.`nombre_rol` AS `nombre_rol`,`tp`.`estado` AS `estado_permiso`,`tp`.`estado_eliminacion` AS `estado_eliminacion_permiso`,`tob`.`estado` AS `estado_objeto`,`tob`.`estado_eliminacion` AS `estado_eliminacion_objeto`,`tr`.`estado` AS `estado_rol`,`tr`.`estado_eliminacion` AS `estado_eliminacion_rol` from (((`tbl_permiso` `tp` join `tbl_objeto` `tob` on((`tp`.`id_objeto` = `tob`.`id_objeto`))) join `tbl_rol` `tr` on((`tp`.`id_rol` = `tr`.`id_rol`))) join `tbl_objeto` `to2` on((`tob`.`id_objeto_padre` = `to2`.`id_objeto`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_personas`
--

/*!50001 DROP VIEW IF EXISTS `v_personas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_personas` AS select `tp`.`id_persona` AS `id_persona`,`tp`.`dni` AS `dni`,`tp`.`nombre_legal` AS `nombre_legal`,timestampdiff(YEAR,`tp`.`fecha_nacimiento`,curdate()) AS `edad`,`tp`.`fecha_nacimiento` AS `fecha_nacimiento`,`tp`.`estado_civil` AS `estado_civil`,`tp`.`agravantes` AS `agravantes`,`tp`.`nacionalidad` AS `nacionalidad`,`tp`.`telefono` AS `telefono`,`tp`.`estado` AS `estado`,`tp`.`estado_eliminacion` AS `estado_eliminacion`,`tp`.`id_nivel_educ` AS `id_nivel_educ`,`tne`.`nombre_nivel` AS `nombre_nivel`,`tln`.`id_lugar_nacimiento` AS `id_lugar_nacimiento`,`td`.`nombre_departamento` AS `nombre_departamento_nac`,`tln`.`id_departamento` AS `id_departamento_nac`,`tln`.`id_municipio` AS `id_municipio_nac`,`tm`.`nombre_municipio` AS `nombre_municipio_nac`,`tln`.`ciudad` AS `ciudad_nac`,`tln`.`aldea` AS `aldea_nac`,`tld`.`id_lugar_domicilio` AS `id_lugar_domicilio`,`td1`.`nombre_departamento` AS `nombre_departamento_dom`,`tld`.`id_departamento` AS `id_departamento_dom`,`tld`.`id_municipio` AS `id_municipio_dom`,`tm1`.`nombre_municipio` AS `nombre_municipio_dom`,`tld`.`ciudad` AS `ciudad_dom`,`tld`.`aldea` AS `aldea_dom` from (((((((`tbl_persona` `tp` join `tbl_nivel_educacion` `tne` on((`tp`.`id_nivel_educ` = `tne`.`id_nivel_educ`))) join `tbl_lugar_nacimiento` `tln` on((`tp`.`id_persona` = `tln`.`id_persona`))) join `tbl_lugar_domicilio` `tld` on((`tld`.`id_persona` = `tp`.`id_persona`))) join `tbl_departamento` `td` on((`tln`.`id_departamento` = `td`.`id_departamento`))) join `tbl_departamento` `td1` on((`tld`.`id_departamento` = `td1`.`id_departamento`))) join `tbl_municipio` `tm` on((`tm`.`id_municipio` = `tln`.`id_municipio`))) join `tbl_municipio` `tm1` on((`tm1`.`id_municipio` = `tld`.`id_municipio`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_preguntas_usuario`
--

/*!50001 DROP VIEW IF EXISTS `v_preguntas_usuario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_preguntas_usuario` AS select `tpu`.`id_pregunta_usuario` AS `id_pregunta_usuario`,`tpu`.`id_usuario` AS `id_usuario`,`tpu`.`id_pregunta` AS `id_pregunta`,`tpu`.`respuesta` AS `respuesta`,`tu`.`usuario` AS `usuario`,`tu`.`nombre` AS `nombre`,`tu`.`correo` AS `correo`,`tu`.`estado` AS `estado`,`tu`.`id_rol` AS `id_rol`,`tu`.`estado_eliminacion` AS `estado_eliminacion`,`tp`.`pregunta` AS `pregunta` from ((`tbl_pregunta_usuario` `tpu` join `tbl_usuario` `tu` on((`tpu`.`id_usuario` = `tu`.`id_usuario`))) join `tbl_pregunta` `tp` on((`tpu`.`id_pregunta` = `tp`.`id_pregunta`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_usuario_login`
--

/*!50001 DROP VIEW IF EXISTS `v_usuario_login`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_usuario_login` AS select `tbl_usuario`.`id_usuario` AS `id_usuario`,`tbl_usuario`.`usuario` AS `usuario`,`tbl_usuario`.`contrasena` AS `contrasena`,`tbl_usuario`.`nombre` AS `nombre`,`tbl_usuario`.`correo` AS `correo`,`tbl_usuario`.`contrasena_segura` AS `contrasena_segura`,`tbl_usuario`.`cambio_contrasena` AS `cambio_contrasena`,`tbl_usuario`.`estado` AS `estado`,`tbl_usuario`.`estado_eliminacion` AS `estado_eliminacion`,`tbl_usuario`.`id_rol` AS `id_rol` from `tbl_usuario` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_usuario_rol`
--

/*!50001 DROP VIEW IF EXISTS `v_usuario_rol`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_usuario_rol` AS select `tu`.`id_usuario` AS `id_usuario`,`tu`.`usuario` AS `usuario`,`tu`.`contrasena` AS `contrasena`,`tu`.`nombre` AS `nombre`,`tu`.`correo` AS `correo`,`tu`.`contrasena_segura` AS `contrasena_segura`,`tu`.`cambio_contrasena` AS `cambio_contrasena`,`tu`.`estado` AS `estado`,`tu`.`estado_eliminacion` AS `estado_eliminacion`,`tr`.`id_rol` AS `id_rol`,`tr`.`nombre_rol` AS `nombre_rol`,`tr`.`estado` AS `estado_rol`,`tr`.`estado_eliminacion` AS `estado_eliminacion_rol` from (`tbl_usuario` `tu` join `tbl_rol` `tr` on((`tu`.`id_rol` = `tr`.`id_rol`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_usuarios`
--

/*!50001 DROP VIEW IF EXISTS `v_usuarios`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_usuarios` AS select `tbl_usuario`.`id_usuario` AS `id_usuario`,`tbl_usuario`.`usuario` AS `usuario`,`tbl_usuario`.`nombre` AS `nombre`,`tbl_usuario`.`correo` AS `correo`,`tbl_usuario`.`contrasena_segura` AS `contrasena_segura`,`tbl_usuario`.`cambio_contrasena` AS `cambio_contrasena`,`tbl_usuario`.`estado` AS `estado`,`tbl_usuario`.`estado_eliminacion` AS `estado_eliminacion`,`tbl_usuario`.`id_rol` AS `id_rol` from `tbl_usuario` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_victimas`
--

/*!50001 DROP VIEW IF EXISTS `v_victimas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_victimas` AS select `tv`.`id_victima` AS `id_victima`,`tp`.`id_persona` AS `id_persona`,`tp`.`nombre_legal` AS `nombre_legal_persona`,`tp`.`dni` AS `dni`,`tv`.`nombre_legal` AS `nombre_legal_victima`,`tv`.`cambio_nom_legal_victima` AS `cambio_nom_legal_victima`,`tv`.`nombre_ident_genero` AS `nombre_ident_genero`,`tv`.`otro_nombres` AS `otro_nombres`,`teg`.`nombre_expresion` AS `nombre_expresion`,`tgv`.`tipo_genero_victima` AS `tipo_genero_victima`,`tos`.`orientacion` AS `orientacion`,`tv`.`ocupacion` AS `ocupacion`,`tv`.`discapacidad_victima` AS `discapacidad_victima`,`tcm`.`nombre_condicion` AS `nombre_condicion`,`te`.`nombre_etnia` AS `nombre_etnia`,`tv`.`hijos` AS `hijos`,`tv`.`cant_hijos` AS `cant_hijos`,`tv`.`cant_hijos_men` AS `cant_hijos_men`,`tv`.`cant_hijos_may` AS `cant_hijos_may`,`tv`.`cant_pers_dependiente` AS `cant_pers_dependiente`,`tv`.`perteneciente_organizacion` AS `perteneciente_organizacion`,`tv`.`denucia_previa` AS `denucia_previa`,`tv`.`numero_caso` AS `numero_caso`,`tv`.`tipo_denucia` AS `tipo_denucia`,`tv`.`nom_insti_denucia` AS `nom_insti_denucia`,`tv`.`medidas_proteccion` AS `medidas_proteccion`,`tv`.`tipo_med_proteccion` AS `tipo_med_proteccion`,`tgh`.`nomb_llenador_dato` AS `nomb_llenador_dato`,`tv`.`id_usuario_creo` AS `id_usuario_creo`,`tv`.`estado` AS `estado`,`tv`.`estado_eliminacion` AS `estado_eliminacion` from (((((((`tbl_victima` `tv` join `tbl_persona` `tp` on((`tv`.`id_persona` = `tp`.`id_persona`))) join `tbl_genero_victima` `tgv` on((`tv`.`id_genero_victima` = `tgv`.`id_genero_victima`))) join `tbl_expresion_genero` `teg` on((`tv`.`id_expresion_genero` = `teg`.`id_expresion_genero`))) join `tbl_orientacion_sexual` `tos` on((`tv`.`id_orientacion` = `tos`.`id_orientacion`))) join `tbl_condicion_migratoria` `tcm` on((`tv`.`id_condicion_migratoria` = `tcm`.`id_condicion_migratoria`))) join `tbl_etnia` `te` on((`tv`.`id_etnia` = `te`.`id_etnia`))) join `tbl_generador_hecho` `tgh` on((`tv`.`id_generador_hecho` = `tgh`.`id_generador_hecho`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-02 22:41:22
