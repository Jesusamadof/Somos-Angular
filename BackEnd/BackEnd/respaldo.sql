-- MySqlBackup.NET 2.3.8.0
-- Dump Time: 2024-03-16 17:49:11
-- --------------------------------------
-- Server version 8.2.0 MySQL Community Server - GPL


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of tbl_departamento
-- 

DROP TABLE IF EXISTS `tbl_departamento`;
CREATE TABLE IF NOT EXISTS `tbl_departamento` (
  `id_departamento` int NOT NULL AUTO_INCREMENT,
  `nombre_departamento` varchar(20) DEFAULT NULL,
  `codigo_departamento` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`id_departamento`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_departamento
-- 

/*!40000 ALTER TABLE `tbl_departamento` DISABLE KEYS */;
INSERT INTO `tbl_departamento`(`id_departamento`,`nombre_departamento`,`codigo_departamento`) VALUES(1,'Atlántida','01'),(2,'Colón','02'),(3,'Comayagua','03'),(4,'Copán','04'),(5,'Cortés','05'),(6,'Choluteca','06'),(7,'El Paraiso','07'),(8,'Francisco Morazán','08'),(9,'Gracias a Dios','09'),(10,'Intibucá','10'),(11,'Islas de la Bahia','11'),(12,'La Paz','12'),(13,'Lempira','13'),(14,'Ocotepeque','14'),(15,'Olancho','15'),(16,'Santa Barbara','16'),(17,'Valle','17'),(18,'Yoro','18');
/*!40000 ALTER TABLE `tbl_departamento` ENABLE KEYS */;

-- 
-- Definition of tbl_municipio
-- 

DROP TABLE IF EXISTS `tbl_municipio`;
CREATE TABLE IF NOT EXISTS `tbl_municipio` (
  `id_municipio` int NOT NULL AUTO_INCREMENT,
  `nombre_municipio` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `codigo_municipio` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `id_departamento` int DEFAULT NULL,
  PRIMARY KEY (`id_municipio`),
  KEY `fk_munic_depart` (`id_departamento`),
  CONSTRAINT `fk_munic_depart` FOREIGN KEY (`id_departamento`) REFERENCES `tbl_departamento` (`id_departamento`)
) ENGINE=InnoDB AUTO_INCREMENT=299 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_municipio
-- 

/*!40000 ALTER TABLE `tbl_municipio` DISABLE KEYS */;
INSERT INTO `tbl_municipio`(`id_municipio`,`nombre_municipio`,`codigo_municipio`,`id_departamento`) VALUES(1,'La Ceiba','0101',1),(2,'El Provenir','0102',1),(3,'Esparta','0103',1),(4,'Jutiapa','0104',1),(5,'La Masica','0105',1),(6,'San Francisco','0106',1),(7,'Tela','0107',1),(8,'Arizona','0108',1),(9,'Trujillo','0201',2),(10,'Balfate','0202',2),(11,'Iriona','0203',2),(12,'Limón','0204',2),(13,'Sabá','0205',2),(14,'Santa Fe','0206',2),(15,'Santa Rosa de Aguán','0207',2),(16,'Sonaguera','0208',2),(17,'Tocoa','0209',2),(18,'Bonito Oriental','0210',2),(19,'Comayagua','0301',3),(20,'Ajuterique','0302',3),(21,'El Rosario','0303',3),(22,'Esquías','0304',3),(23,'Humuya','0305',3),(24,'La Libertad','0306',3),(25,'Lamaní','0307',3),(26,'La Trinidad','0308',3),(27,'Lejamaní','0309',3),(28,'Meámbar','0310',3),(29,'Minas de Oro','0311',3),(30,'Ojo de Agua','0312',3),(31,'San Jerónimo','0313',3),(32,'San José de Comayagua','0314',3),(33,'San José del Potrero','0315',3),(34,'San Luis','0316',3),(35,'San Sebastián','0317',3),(36,'Siguatepeque','0318',3),(37,'Villa de San Antonio','0319',3),(38,'Lajas','0320',3),(39,'Taulabe','0321',3),(40,'Santa Rosa de Copán','0401',4),(41,'Cabañas','0402',4),(42,'Concepción','0403',4),(43,'Copán Ruinas','0404',4),(44,'Corquín','0405',4),(45,'Cucuyagua','0406',4),(46,'Dolores','0407',4),(47,'Dulce Nombre','0408',4),(48,'El Paraíso','0409',4),(49,'Florida','0410',4),(50,'La jigua','0411',4),(51,'La Unión','0412',4),(52,'Nueva Arcadia','0413',4),(53,'San Agustín','0414',4),(54,'San Antonio','0415',4),(55,'San Jerónimo','0416',4),(56,'San José','0417',4),(57,'San Juan de Opoa','0418',4),(58,'San Nicolás','0419',4),(59,'San Pedro','0420',4),(60,'Santa Rita','0421',4),(61,'Trinidad de Copán','0422',4),(62,'Veracruz','0423',4),(63,'San Pedro Sula','0501',5),(64,'Choloma','0502',5),(65,'Omoa','0503',5),(66,'Pimienta','0504',5),(67,'Potrerillos','0505',5),(68,'Puerto Cortés','0506',5),(69,'San Antonio de Cortés','0507',5),(70,'San Francisco de Yojoa','0508',5),(71,'San Manuel','0509',5),(72,'San Cruz de Yojoa','0510',5),(73,'Villanueva','0511',5),(74,'La Lima','0512',5),(75,'Choluteca','0601',6),(76,'Apacilagua','0602',6),(77,'Concepción de María','0603',6),(78,'Duyure','0604',6),(79,'El Corpus','0605',6),(80,'El Triunfo','0606',6),(81,'Marcovia','0607',6),(82,'Morolica','0608',6),(83,'Namasigue','0609',6),(84,'Orocuina','0610',6),(85,'Pespire','0611',6),(86,'San Antonio de Flores','0612',6),(87,'San Isidro','0613',6),(88,'San José','0614',6),(89,'San Marcos de Colón','0615',6),(90,'San Ana de Yusguare','0616',6),(91,'Yuscarán','0701',7),(92,'Alauca','0702',7),(93,'Danlí','0703',7),(94,'El Paraiso','0704',7),(95,'Guinope','0705',7),(96,'Jacaleapa','0706',7),(97,'Liure','0707',7),(98,'Morocelí','0708',7),(99,'Oropolí','0709',7),(100,'Potrerillos','0710',7),(101,'San Antonio de Flores','0711',7),(102,'San Lucas','0712',7),(103,'San Matías','0713',7),(104,'Soledad','0714',7),(105,'Teupasenti','0715',7),(106,'Texiguat','0716',7),(107,'Vado Ancho','0717',7),(108,'Yauyupe','0718',7),(109,'Trojes','0719',7),(110,'Tegucigalpa D.C.','0801',8),(111,'Alubarén','0802',8),(112,'Cedros','0803',8),(113,'Curarén','0804',8),(114,'El Porvenir','0805',8),(115,'Guaimaca','0806',8),(116,'La Libertad','0807',8),(117,'La Venta','0808',8),(118,'Lepaterique','0809',8),(119,'Maraita','0810',8),(120,'Marale','0811',8),(121,'Nueva Armenia','0812',8),(122,'Ojojons','0813',8),(123,'Orica','0814',8),(124,'Reitoca','0815',8),(125,'Sabanagrande','0816',8),(126,'San Antonio de Oriente','0817',8),(127,'San Buenaventura','0818',8),(128,'San Ignacio','0819',8),(129,'San Juan de Flores','0820',8),(130,'San Miguelito','0821',8),(131,'Santa Ana','0822',8),(132,'Santa Lucia','0823',8),(133,'Talanga','0824',8),(134,'Tatumbla','0825',8),(135,'Valle de Angeles','0826',8),(136,'Villa de San Fracisco','0827',8),(137,'Vallecillo','0828',8),(138,'Puerto Lempira','0901',9),(139,'Brus Laguna','0902',9),(140,'Ahuas','0903',9),(141,'Juan Francisco Bulnes','0904',9),(142,'Villeda Morales','0905',9),(143,'Wampusirpe','0906',9),(144,'La Esperanza','1001',10),(145,'Camasca','1002',10),(146,'Colomoncagua','1003',10),(147,'Concepción','1004',10),(148,'Dolores','1005',10),(149,'Intibucá','1006',10),(150,'Jesús de Otoro','1007',10),(151,'Magdalena','1008',10),(152,'Masaguara','1009',10),(153,'San Antonio','1010',10),(154,'San isidro','1011',10),(155,'San Juan de Flores','1012',10),(156,'San Marcos de la Sierra','1013',10),(157,'San Miguel Guancapla','1014',10),(158,'Santa Lucía','1015',10),(159,'Yamaranguila','1016',10),(160,'San Francisco de Opalaca','1017',10),(161,'Roatán','1101',11),(162,'Guanaja','1102',11),(163,'José Santos Guardiola','1103',11),(164,'Utila','1104',11),(165,'La Paz','1201',12),(166,'Aguanqueterique','1202',12),(167,'Cabañas','1203',12),(168,'Cane','1204',12),(169,'Chinacla','1205',12),(170,'Guajiquiro','1206',12),(171,'Lauterique','1207',12),(172,'Marcala','1208',12),(173,'Mecedes de Oriente','1209',12),(174,'Opatoro','1210',12),(175,'San Antonio del Norte','1211',12),(176,'San José','1212',12),(177,'San Juan','1213',12),(178,'San Pedro de Tutule','1214',12),(179,'Santa Ana','1215',12),(180,'Santa Elena','1216',12),(181,'Santa María','1217',12),(182,'Santiago de Puringla','1218',12),(183,'Yarula','1219',12),(184,'Gracias','1301',13),(185,'Belén','1302',13),(186,'Candelaria','1303',13),(187,'Cololaca','1304',13),(188,'Erandique','1305',13),(189,'Gualcinse','1306',13),(190,'Guarita','1307',13),(191,'La Campa','1308',13),(192,'La Iguala','1309',13),(193,'Las Flores','1310',13),(194,'La Unión','1311',13),(195,'La Virtud','1312',13),(196,'Lepaera','1313',13),(197,'Mapulaca','1314',13),(198,'Piraera','1315',13),(199,'San Andrés','1316',13),(200,'San Francisco','1317',13),(201,'San Juan Guarita','1318',13),(202,'San Manuel Colohete','1319',13),(203,'San Rafael','1320',13),(204,'San Sebastian','1321',13),(205,'Santa Cruz','1322',13),(206,'Algua','1323',13),(207,'Tambla','1324',13),(208,'Tomalá','1325',13),(209,'Valladolid','1326',13),(210,'Virginia','1327',13),(211,'San Marcos de Caiquín','1328',13),(212,'Nueva Ocotepeque','1401',14),(213,'Belén Gualcho','1402',14),(214,'Concepción','1403',14),(215,'Dolores Merendón','1404',14),(216,'Fraterninda','1405',14),(217,'La Encarnación','1406',14),(218,'La Labor','1407',14),(219,'Lucerna','1408',14),(220,'Mercedes','1409',14),(221,'San Fernando','1410',14),(222,'San Francisco del Valle','1411',14),(223,'San Jorge','1412',14),(224,'San Marcos','1413',14),(225,'Sante Fé','1414',14),(226,'Sensenti','1415',14),(227,'Sinuapa','1416',14),(228,'Juticalpa','1501',15),(229,'Campamento','1502',15),(230,'Catacamas','1503',15),(231,'Concordia','1504',15),(232,'Dulce nombre de Culmí','1505',15),(233,'El Rosario','1506',15),(234,'Esquipulas del Norte','1507',15),(235,'Gualaco','1508',15),(236,'Guarizama','1509',15),(237,'Guata','1510',15),(238,'Guayape','1511',15),(239,'Jano','1512',15),(240,'La Unión','1513',15),(241,'Manguile','1514',15),(242,'Manto','1515',15),(243,'Salamá','1516',15),(244,'San Esteban','1517',15),(245,'San Francisco de Becera','1518',15),(246,'San Francisco de la Paz','1519',15),(247,'Santa María del Real','1520',15),(248,'Silca','1521',15),(249,'Yocón','1522',15),(250,'Froylán Turcios','1523',15),(251,'Santa Bárbara','1601',16),(252,'Arada','1602',16),(253,'Atima','1603',16),(254,'Azacual','1604',16),(255,'Ceguaca','1605',16),(256,'Colinas','1606',16),(257,'Concepción del Norte','1607',16),(258,'Concepción del Sur','1608',16),(259,'Chinda','1609',16),(260,'El Níspero','1610',16),(261,'Gualala','1611',16),(262,'Ilama','1612',16),(263,'Macuelizo','1613',16),(264,'Naranjito','1614',16),(265,'Nueva Celilac','1615',16),(266,'Petoa','1616',16),(267,'Protección','1617',16),(268,'Quimistán','1618',16),(269,'San Francisco de Ojuera','1619',16),(270,'San Luis','1620',16),(271,'San Marcos','1621',16),(272,'San Nicolás','1622',16),(273,'San Pedro Zacapa','1623',16),(274,'Santa Rita','1624',16),(275,'San Vicente Centenario','1625',16),(276,'Trinidad','1626',16),(277,'Las Vegas','1627',16),(278,'Nueva Frontera','1628',16),(279,'Nacaome','1701',17),(280,'Alianza','1702',17),(281,'Amapala','1703',17),(282,'Aramecina','1704',17),(283,'Caridad','1705',17),(284,'Guascorán','1706',17),(285,'Langue','1707',17),(286,'San Francisco de Coray','1708',17),(287,'San Lorenzo','1709',17),(288,'Yoro','1801',18),(289,'Arenal','1802',18),(290,'El Negrito','1803',18),(291,'EL Progreso','1804',18),(292,'Jocón','1805',18),(293,'Morazán','1806',18),(294,'Olanchito','1807',18),(295,'Santa Rita','1808',18),(296,'Sulaco','1809',18),(297,'Victoria','1810',18),(298,'Yorito','1811',18);
/*!40000 ALTER TABLE `tbl_municipio` ENABLE KEYS */;

-- 
-- Definition of tbl_nivel_educacion
-- 

DROP TABLE IF EXISTS `tbl_nivel_educacion`;
CREATE TABLE IF NOT EXISTS `tbl_nivel_educacion` (
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

-- 
-- Dumping data for table tbl_nivel_educacion
-- 

/*!40000 ALTER TABLE `tbl_nivel_educacion` DISABLE KEYS */;
INSERT INTO `tbl_nivel_educacion`(`id_nivel_educ`,`nombre_nivel`,`fecha_creacion`,`fecha_modificacion`,`id_usuario_creo`,`id_usuario_modifico`,`estado`,`estado_eliminacion`) VALUES(1,'Universida Completa','2024-03-10 18:25:02','2024-03-10 18:25:02',0,0,0,0),(2,'Universida incompleta','2024-03-10 18:25:02','2024-03-10 18:25:02',0,0,0,0);
/*!40000 ALTER TABLE `tbl_nivel_educacion` ENABLE KEYS */;

-- 
-- Definition of tbl_objeto
-- 

DROP TABLE IF EXISTS `tbl_objeto`;
CREATE TABLE IF NOT EXISTS `tbl_objeto` (
  `id_objeto` int NOT NULL AUTO_INCREMENT,
  `id_objeto_padre` int DEFAULT NULL,
  `nombre_objeto` varchar(300) DEFAULT NULL,
  `ruta` varchar(50) DEFAULT NULL,
  `icono` varchar(30) DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_objeto`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_objeto
-- 

/*!40000 ALTER TABLE `tbl_objeto` DISABLE KEYS */;
INSERT INTO `tbl_objeto`(`id_objeto`,`id_objeto_padre`,`nombre_objeto`,`ruta`,`icono`,`estado`,`estado_eliminacion`) VALUES(1,1,'Seleccionar Objeto Como Padre','padre',NULL,1,0),(2,3,'Usuarios','seguridad/usuarios','group_add',1,0),(3,1,'Seguridad','segurida','security',1,0),(4,3,'Roles','seguridad/roles','group',1,0),(5,3,'Objetos','seguridad/objetos','data_object',1,0),(6,1,'Mantenimientos','mantenimientos','list_alt',1,0),(7,6,'Estados','mantenimientos/estados','status',1,0),(8,3,'Parametros','seguridad/parametros','display_settings',1,0),(9,3,'Preguntas','seguridad/preguntas','question_mark',1,0),(10,3,'prueba','seguridad/prueba','prueba',1,0),(11,3,'Permisos','seguridad/permisos','admin_panel_settings',1,0),(12,1,'Home','home','home',1,0),(13,12,'Dashboard','home/dashboard','dashboard',1,0),(14,1,'Gestión de Victimas','victimas','group',1,0),(15,14,'Agregar Victima','gestionPersonas/addEditVictima','groups',1,0);
/*!40000 ALTER TABLE `tbl_objeto` ENABLE KEYS */;

-- 
-- Definition of tbl_orientacion_sexual
-- 

DROP TABLE IF EXISTS `tbl_orientacion_sexual`;
CREATE TABLE IF NOT EXISTS `tbl_orientacion_sexual` (
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_orientacion_sexual
-- 

/*!40000 ALTER TABLE `tbl_orientacion_sexual` DISABLE KEYS */;

/*!40000 ALTER TABLE `tbl_orientacion_sexual` ENABLE KEYS */;

-- 
-- Definition of tbl_caso
-- 

DROP TABLE IF EXISTS `tbl_caso`;
CREATE TABLE IF NOT EXISTS `tbl_caso` (
  `id_caso` int NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `hora` time DEFAULT NULL,
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
  PRIMARY KEY (`id_caso`),
  KEY `fk_caso_orientacion` (`id_orientacion`),
  CONSTRAINT `fk_caso_orientacion` FOREIGN KEY (`id_orientacion`) REFERENCES `tbl_orientacion_sexual` (`id_orientacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_caso
-- 

/*!40000 ALTER TABLE `tbl_caso` DISABLE KEYS */;

/*!40000 ALTER TABLE `tbl_caso` ENABLE KEYS */;

-- 
-- Definition of tbl_persona
-- 

DROP TABLE IF EXISTS `tbl_persona`;
CREATE TABLE IF NOT EXISTS `tbl_persona` (
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

-- 
-- Dumping data for table tbl_persona
-- 

/*!40000 ALTER TABLE `tbl_persona` DISABLE KEYS */;
INSERT INTO `tbl_persona`(`id_persona`,`dni`,`nombre_legal`,`fecha_nacimiento`,`estado_civil`,`agravantes`,`nacionalidad`,`telefono`,`id_nivel_educ`,`fecha_creacion`,`fecha_modificacion`,`id_usuario_creo`,`id_usuario_modifico`,`estado`,`estado_eliminacion`) VALUES(8,'0801199922323','Jorge Andres Gamez Palacios','2000-02-05 00:00:00','Soltero/a','Choche enfrente de tigo','Hondurena','98372878',2,'2024-03-12 20:15:46','2024-03-13 17:42:02',1,1,1,0);
/*!40000 ALTER TABLE `tbl_persona` ENABLE KEYS */;

-- 
-- Definition of tbl_lugar_domicilio
-- 

DROP TABLE IF EXISTS `tbl_lugar_domicilio`;
CREATE TABLE IF NOT EXISTS `tbl_lugar_domicilio` (
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

-- 
-- Dumping data for table tbl_lugar_domicilio
-- 

/*!40000 ALTER TABLE `tbl_lugar_domicilio` DISABLE KEYS */;
INSERT INTO `tbl_lugar_domicilio`(`id_lugar_domicilio`,`id_departamento`,`id_municipio`,`ciudad`,`aldea`,`fecha_creacion`,`fecha_modificacion`,`id_usuario_creo`,`id_usuario_modifico`,`estado`,`estado_eliminacion`,`id_persona`) VALUES(5,13,202,'h','u','2024-03-12 20:15:46','2024-03-13 17:42:23',1,1,1,0,8),(6,11,162,'nnn','hh',NULL,'2024-03-13 17:13:05',1,1,NULL,NULL,NULL),(7,11,162,'nnn','hh',NULL,'2024-03-13 17:14:28',1,1,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_lugar_domicilio` ENABLE KEYS */;

-- 
-- Definition of tbl_lugar_nacimiento
-- 

DROP TABLE IF EXISTS `tbl_lugar_nacimiento`;
CREATE TABLE IF NOT EXISTS `tbl_lugar_nacimiento` (
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

-- 
-- Dumping data for table tbl_lugar_nacimiento
-- 

/*!40000 ALTER TABLE `tbl_lugar_nacimiento` DISABLE KEYS */;
INSERT INTO `tbl_lugar_nacimiento`(`id_lugar_nacimiento`,`id_departamento`,`id_municipio`,`ciudad`,`aldea`,`fecha_creacion`,`fecha_modificacion`,`id_usuario_creo`,`id_usuario_modifico`,`estado`,`estado_eliminacion`,`id_persona`) VALUES(5,12,174,'mp','mp','2024-03-12 20:15:46','2024-03-13 17:42:13',1,1,1,0,8),(6,4,41,'mjj','mjj',NULL,'2024-03-13 17:13:05',1,1,NULL,NULL,NULL),(7,15,241,'mjj','mjj',NULL,'2024-03-13 17:14:20',1,1,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tbl_lugar_nacimiento` ENABLE KEYS */;

-- 
-- Definition of tbl_pregunta
-- 

DROP TABLE IF EXISTS `tbl_pregunta`;
CREATE TABLE IF NOT EXISTS `tbl_pregunta` (
  `id_pregunta` int NOT NULL AUTO_INCREMENT,
  `pregunta` varchar(50) DEFAULT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_pregunta`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_pregunta
-- 

/*!40000 ALTER TABLE `tbl_pregunta` DISABLE KEYS */;
INSERT INTO `tbl_pregunta`(`id_pregunta`,`pregunta`,`descripcion`,`estado`,`estado_eliminacion`) VALUES(1,'Color Favorito','Color favorito del usuario para recuperar contraseña',1,0),(2,'Nombre de Mascota Favorita','Nombre de mascota favorita del usuario para recuperar contraseña',1,0),(3,'Apodo de niño','Apodo del niño del usuario n',1,0);
/*!40000 ALTER TABLE `tbl_pregunta` ENABLE KEYS */;

-- 
-- Definition of tbl_reporte_actual
-- 

DROP TABLE IF EXISTS `tbl_reporte_actual`;
CREATE TABLE IF NOT EXISTS `tbl_reporte_actual` (
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

-- 
-- Dumping data for table tbl_reporte_actual
-- 

/*!40000 ALTER TABLE `tbl_reporte_actual` DISABLE KEYS */;

/*!40000 ALTER TABLE `tbl_reporte_actual` ENABLE KEYS */;

-- 
-- Definition of tbl_rol
-- 

DROP TABLE IF EXISTS `tbl_rol`;
CREATE TABLE IF NOT EXISTS `tbl_rol` (
  `id_rol` int NOT NULL AUTO_INCREMENT,
  `nombre_rol` varchar(30) DEFAULT NULL,
  `descripcion` varchar(300) DEFAULT NULL,
  `estado` int DEFAULT NULL,
  `estado_eliminacion` int DEFAULT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_rol
-- 

/*!40000 ALTER TABLE `tbl_rol` DISABLE KEYS */;
INSERT INTO `tbl_rol`(`id_rol`,`nombre_rol`,`descripcion`,`estado`,`estado_eliminacion`) VALUES(1,'Administrador','Administrar',1,NULL),(2,'string','string',1,NULL),(3,'Auxiliar','Usuario del sistema',1,NULL),(4,'Auxiliar1','Encargada de llevar documentos',1,0),(5,'Super Administrador','Administrar todo el sistema',1,0),(6,'ndjndjsnd','jdjsndjsd',1,NULL);
/*!40000 ALTER TABLE `tbl_rol` ENABLE KEYS */;

-- 
-- Definition of tbl_permiso
-- 

DROP TABLE IF EXISTS `tbl_permiso`;
CREATE TABLE IF NOT EXISTS `tbl_permiso` (
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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_permiso
-- 

/*!40000 ALTER TABLE `tbl_permiso` DISABLE KEYS */;
INSERT INTO `tbl_permiso`(`id_permiso`,`id_objeto`,`id_rol`,`ver`,`agregar`,`editar`,`eliminar`,`reporte`,`estado`,`estado_eliminacion`) VALUES(1,2,4,1,1,1,1,1,1,0),(2,4,4,1,1,1,1,1,1,0),(3,2,5,1,1,1,1,1,1,0),(4,4,5,1,1,1,1,1,1,0),(5,5,5,1,1,1,1,1,1,0),(6,8,5,1,1,1,1,1,1,0),(7,9,5,1,1,1,1,1,1,0),(8,10,5,1,1,1,1,1,1,0),(9,7,5,1,1,1,1,1,1,0),(10,11,5,1,1,1,1,1,1,0),(11,13,5,1,1,1,1,1,1,0),(12,4,4,1,1,1,1,1,1,0),(13,2,4,1,1,1,1,1,1,0),(14,8,4,1,1,1,1,1,1,0),(15,9,4,1,1,1,1,1,1,0),(16,13,4,1,1,1,1,1,1,0),(17,15,5,1,1,1,1,1,1,0);
/*!40000 ALTER TABLE `tbl_permiso` ENABLE KEYS */;

-- 
-- Definition of tbl_tipo_reporte
-- 

DROP TABLE IF EXISTS `tbl_tipo_reporte`;
CREATE TABLE IF NOT EXISTS `tbl_tipo_reporte` (
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

-- 
-- Dumping data for table tbl_tipo_reporte
-- 

/*!40000 ALTER TABLE `tbl_tipo_reporte` DISABLE KEYS */;

/*!40000 ALTER TABLE `tbl_tipo_reporte` ENABLE KEYS */;

-- 
-- Definition of tbl_usuario
-- 

DROP TABLE IF EXISTS `tbl_usuario`;
CREATE TABLE IF NOT EXISTS `tbl_usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(30) DEFAULT NULL,
  `contrasena` varchar(300) DEFAULT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_usuario
-- 

/*!40000 ALTER TABLE `tbl_usuario` DISABLE KEYS */;
INSERT INTO `tbl_usuario`(`id_usuario`,`usuario`,`contrasena`,`nombre`,`correo`,`contrasena_segura`,`cambio_contrasena`,`estado`,`estado_eliminacion`,`id_rol`) VALUES(1,'jose.perez','$2a$12$KCga/fVw9wainf2JqmssBOuJ1KloW.rPQj3FYnhmdp/6vbOrhZ3EC','Jose Perez','pere22@gmail.com',1,0,1,0,5),(2,'angel.gomez','$2a$12$bAzMFgxo/CdNdQeHbj0lRuQazTlDgaMubAnWmgCnDZl14XZ1VppDq','Angel Gomez','perez@gamil.com',0,1,1,0,5),(3,'arnol','$2a$12$YhA4FwD8lzcRzsiMSYde2ORAwc/7/9gMoJMEq8kaFeN35zbAcHsby','Arnol','perez@gamil.com',0,1,1,1,5);
/*!40000 ALTER TABLE `tbl_usuario` ENABLE KEYS */;

-- 
-- Definition of tbl_bitacora
-- 

DROP TABLE IF EXISTS `tbl_bitacora`;
CREATE TABLE IF NOT EXISTS `tbl_bitacora` (
  `id_bitacora` int NOT NULL AUTO_INCREMENT,
  `fecha` timestamp NULL DEFAULT NULL,
  `evento` varchar(100) DEFAULT NULL,
  `valor` varchar(500) DEFAULT NULL,
  `id_usuario` int DEFAULT NULL,
  PRIMARY KEY (`id_bitacora`),
  KEY `fk_usuario_bitacora` (`id_usuario`),
  CONSTRAINT `fk_usuario_bitacora` FOREIGN KEY (`id_usuario`) REFERENCES `tbl_usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_bitacora
-- 

/*!40000 ALTER TABLE `tbl_bitacora` DISABLE KEYS */;

/*!40000 ALTER TABLE `tbl_bitacora` ENABLE KEYS */;

-- 
-- Definition of tbl_pregunta_usuario
-- 

DROP TABLE IF EXISTS `tbl_pregunta_usuario`;
CREATE TABLE IF NOT EXISTS `tbl_pregunta_usuario` (
  `id_pregunta_usuario` int NOT NULL AUTO_INCREMENT,
  `id_usuario` int DEFAULT NULL,
  `id_pregunta` int DEFAULT NULL,
  `fecha_creacion` timestamp NULL DEFAULT NULL,
  `fecha_modificacion` timestamp NULL DEFAULT NULL,
  `id_usuario_creo` int DEFAULT NULL,
  `id_usuario_modifico` int DEFAULT NULL,
  PRIMARY KEY (`id_pregunta_usuario`),
  KEY `fk_tbl_usuario_prg_usu` (`id_usuario`),
  KEY `fk_tbl_pregunta_prg_usu` (`id_pregunta`),
  CONSTRAINT `fk_tbl_pregunta_prg_usu` FOREIGN KEY (`id_pregunta`) REFERENCES `tbl_pregunta` (`id_pregunta`),
  CONSTRAINT `fk_tbl_usuario_prg_usu` FOREIGN KEY (`id_usuario`) REFERENCES `tbl_usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table tbl_pregunta_usuario
-- 

/*!40000 ALTER TABLE `tbl_pregunta_usuario` DISABLE KEYS */;

/*!40000 ALTER TABLE `tbl_pregunta_usuario` ENABLE KEYS */;

-- 
-- Dumping views
-- 

DROP TABLE IF EXISTS `v_permisos`;
DROP VIEW IF EXISTS `v_permisos`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `v_permisos` AS select `tp`.`id_permiso` AS `id_permiso`,`tp`.`id_objeto` AS `id_objeto`,`tp`.`id_rol` AS `id_rol`,`tp`.`ver` AS `ver`,`tp`.`agregar` AS `agregar`,`tp`.`editar` AS `editar`,`tp`.`eliminar` AS `eliminar`,`tp`.`reporte` AS `reporte`,`tp`.`estado` AS `estado`,`tp`.`estado_eliminacion` AS `estado_eliminacion`,`tob`.`id_objeto_padre` AS `id_objeto_padre`,`tob`.`nombre_objeto` AS `nombre_objeto`,`tob`.`icono` AS `icono_hijo`,`to2`.`nombre_objeto` AS `nombre_objeto_padre`,`to2`.`icono` AS `icono_padre`,`tob`.`ruta` AS `ruta`,`tob`.`icono` AS `icono`,`tr`.`nombre_rol` AS `nombre_rol`,`tp`.`estado` AS `estado_permiso`,`tp`.`estado_eliminacion` AS `estado_eliminacion_permiso`,`tob`.`estado` AS `estado_objeto`,`tob`.`estado_eliminacion` AS `estado_eliminacion_objeto`,`tr`.`estado` AS `estado_rol`,`tr`.`estado_eliminacion` AS `estado_eliminacion_rol` from (((`tbl_permiso` `tp` join `tbl_objeto` `tob` on((`tp`.`id_objeto` = `tob`.`id_objeto`))) join `tbl_rol` `tr` on((`tp`.`id_rol` = `tr`.`id_rol`))) join `tbl_objeto` `to2` on((`tob`.`id_objeto_padre` = `to2`.`id_objeto`)));

DROP TABLE IF EXISTS `v_personas`;
DROP VIEW IF EXISTS `v_personas`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `v_personas` AS select `tp`.`id_persona` AS `id_persona`,`tp`.`dni` AS `dni`,`tp`.`nombre_legal` AS `nombre_legal`,timestampdiff(YEAR,`tp`.`fecha_nacimiento`,curdate()) AS `edad`,`tp`.`fecha_nacimiento` AS `fecha_nacimiento`,`tp`.`estado_civil` AS `estado_civil`,`tp`.`agravantes` AS `agravantes`,`tp`.`nacionalidad` AS `nacionalidad`,`tp`.`telefono` AS `telefono`,`tp`.`estado` AS `estado`,`tp`.`estado_eliminacion` AS `estado_eliminacion`,`tp`.`id_nivel_educ` AS `id_nivel_educ`,`tne`.`nombre_nivel` AS `nombre_nivel`,`tln`.`id_lugar_nacimiento` AS `id_lugar_nacimiento`,`td`.`nombre_departamento` AS `nombre_departamento_nac`,`tln`.`id_departamento` AS `id_departamento_nac`,`tln`.`id_municipio` AS `id_municipio_nac`,`tm`.`nombre_municipio` AS `nombre_municipio_nac`,`tln`.`ciudad` AS `ciudad_nac`,`tln`.`aldea` AS `aldea_nac`,`tld`.`id_lugar_domicilio` AS `id_lugar_domicilio`,`td1`.`nombre_departamento` AS `nombre_departamento_dom`,`tld`.`id_departamento` AS `id_departamento_dom`,`tld`.`id_municipio` AS `id_municipio_dom`,`tm1`.`nombre_municipio` AS `nombre_municipio_dom`,`tld`.`ciudad` AS `ciudad_dom`,`tld`.`aldea` AS `aldea_dom` from (((((((`tbl_persona` `tp` join `tbl_nivel_educacion` `tne` on((`tp`.`id_nivel_educ` = `tne`.`id_nivel_educ`))) join `tbl_lugar_nacimiento` `tln` on((`tp`.`id_persona` = `tln`.`id_persona`))) join `tbl_lugar_domicilio` `tld` on((`tld`.`id_persona` = `tp`.`id_persona`))) join `tbl_departamento` `td` on((`tln`.`id_departamento` = `td`.`id_departamento`))) join `tbl_departamento` `td1` on((`tld`.`id_departamento` = `td1`.`id_departamento`))) join `tbl_municipio` `tm` on((`tm`.`id_municipio` = `tln`.`id_municipio`))) join `tbl_municipio` `tm1` on((`tm1`.`id_municipio` = `tld`.`id_municipio`)));

DROP TABLE IF EXISTS `v_usuario_rol`;
DROP VIEW IF EXISTS `v_usuario_rol`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `v_usuario_rol` AS select `tu`.`id_usuario` AS `id_usuario`,`tu`.`usuario` AS `usuario`,`tu`.`contrasena` AS `contrasena`,`tu`.`nombre` AS `nombre`,`tu`.`correo` AS `correo`,`tu`.`contrasena_segura` AS `contrasena_segura`,`tu`.`cambio_contrasena` AS `cambio_contrasena`,`tu`.`estado` AS `estado`,`tu`.`estado_eliminacion` AS `estado_eliminacion`,`tr`.`id_rol` AS `id_rol`,`tr`.`nombre_rol` AS `nombre_rol`,`tr`.`estado` AS `estado_rol`,`tr`.`estado_eliminacion` AS `estado_eliminacion_rol` from (`tbl_usuario` `tu` join `tbl_rol` `tr` on((`tu`.`id_rol` = `tr`.`id_rol`)));



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2024-03-16 17:49:12
-- Total time: 0:0:0:0:519 (d:h:m:s:ms)
