-- phpMyAdmin SQL Dump
-- version 4.9.3
-- https://www.phpmyadmin.net/
--
-- Host: studmysql01.fhict.local
-- Generation Time: Mar 13, 2021 at 03:19 PM
-- Server version: 5.7.26-log
-- PHP Version: 7.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbi460221`
--

-- --------------------------------------------------------

--
-- Table structure for table `days`
--

CREATE TABLE `days` (
  `id` tinyint(20) NOT NULL,
  `date` date NOT NULL,
  `schedule_id` tinyint(20) NOT NULL,
  `security_needed` tinyint(4) NOT NULL,
  `cashiers_needed` tinyint(4) NOT NULL,
  `stockers_needed` tinyint(4) NOT NULL,
  `sales_assistants_needed` tinyint(4) NOT NULL,
  `warehouse_managers_needed` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `id` tinyint(20) NOT NULL,
  `first_name` varchar(40) NOT NULL,
  `last_name` varchar(40) NOT NULL,
  `email` varchar(320) NOT NULL,
  `password` varchar(40) NOT NULL,
  `job_position` enum('Security','Cashier','Stocker','SalesAssistant','WarehouseManager') NOT NULL,
  `phoneNumber` int(10) DEFAULT NULL,
  `address` varchar(50) NOT NULL,
  `salary` float DEFAULT NULL,
  `gender` enum('MALE','FEMALE','OTHER') NOT NULL,
  `education` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`id`, `first_name`, `last_name`, `email`, `password`, `job_position`, `phoneNumber`, `address`, `salary`, `gender`, `education`) VALUES
(1, 'John', 'McDuffin', 'john.mcduffin@mail.com', 'john1', 'Security', 731234568, 'Flower Street 23A', 1400, 'MALE', 'High School'),
(2, 'Maria', 'Vincenzio', 'maria.vincenzio@mail.com', 'maria1', 'Security', 198767889, 'Stationsweg 16', 1400, 'FEMALE', 'High School'),
(3, 'Lawrence', 'Moschino', 'lawrence.moschino@mail.com', 'lawrence1', 'Security', 965234521, 'Buekeslaan 12A', 1400, 'OTHER', 'University'),
(4, 'Ponton', 'Portofino', 'ponton.portofino@mail.com', 'ponton1', 'Security', 134156123, 'Cebeslaan 213A', 1400, 'MALE', 'University'),
(5, 'Caitlyn', 'Rose', 'caitlyn.rose@mail.com', 'caitlyn1', 'Cashier', 623144155, 'Transformatorstraat 1', 1200, 'FEMALE', 'High School'),
(6, 'Daniel', 'Burton', 'daniel.burton@mail.com', 'daniel1', 'Cashier', 534412415, 'Borneolaan 5', 1200, 'MALE', 'University'),
(7, 'Prince', 'John', 'prince.john', 'prince1', 'Cashier', 333125619, 'Winston Churchilaan 12', 1200, 'MALE', 'High School'),
(8, 'Laquesha', 'Johnson', 'laquesha.johnson@mail.com', 'laquesha1', 'Cashier', 564123667, 'Horneolaan 32', 1200, 'FEMALE', 'University'),
(9, 'Anastasia', 'Krilov', 'anastasio.krilov@mail.com', 'anastasia1', 'Stocker', 567889001, 'John F. Kennedylaan 168', 2500, 'FEMALE', 'University'),
(10, 'Claire', 'Temple', 'claire.temple@mail.com', 'claire1', 'Stocker', 193343600, 'Luciferstraat 32', 2500, 'FEMALE', 'University'),
(11, 'Daniel', 'Meachum', 'daniel.meachum@mail.com', 'daniel1', 'Stocker', 358890065, 'Cederlaan 12D', 2500, 'MALE', 'University'),
(12, 'Cornell', 'Stokes', 'cornell.stokes@mail.com', 'cornell1', 'Stocker', 466781032, 'Franklin D. Rooseveltlaan 12', 2500, 'MALE', 'University'),
(13, 'Maria', 'Antoinette', 'maria.antoinette@mail.com', 'maria1', 'SalesAssistant', 913576787, 'Hemelrijken 215A', 2000, 'FEMALE', 'University'),
(14, 'Lucas', 'Cage', 'lucas.cage@mail.com', 'lucas1', 'SalesAssistant', 919071783, 'Lombokpad 3.42', 2000, 'MALE', 'University'),
(15, 'Janette', 'Stones', 'janette.stones@mail.com', 'janette1', 'SalesAssistant', 675553687, ' Bulevardul Iuliu Maniu 205', 2000, 'FEMALE', 'University'),
(16, 'Alex', 'Spades', 'alex.spades@mail.com', 'alex1', 'SalesAssistant', 727567672, ' Fuutlaan 3', 2000, 'MALE', 'University'),
(17, 'Matthew', 'Murdock', 'matthew.murdock@mail.com', 'matthew1', 'WarehouseManager', 657773686, ' Pagelaan 21', 3500, 'MALE', 'University'),
(18, 'Johnatan', 'Joestar', 'johnatan.joestar@mail.com', 'johnatan1', 'WarehouseManager', 757699888, ' Mathildelaan 32', 3500, 'MALE', 'University'),
(19, 'Colleen', 'Wing', 'colleen.wing@mail.com', 'colleen1', 'WarehouseManager', 723679009, ' Havenstraat 2B', 3500, 'FEMALE', 'University'),
(20, 'Joy', 'Meachum', 'joy.meachum@mail.com', 'joy1', 'WarehouseManager', 165663686, ' Lakerstraat', 3500, 'OTHER', 'University');

-- --------------------------------------------------------

--
-- Table structure for table `employees_preferences`
--

CREATE TABLE `employees_preferences` (
  `day_id` tinyint(20) NOT NULL,
  `employee_id` tinyint(20) NOT NULL,
  `prefered_first_shift` enum('None','Morning','Midday','Evening') NOT NULL,
  `prefered_second_shift` enum('None','Morning','Midday','Evening') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `employees_workdays`
--

CREATE TABLE `employees_workdays` (
  `day_id` tinyint(20) NOT NULL,
  `employee_id` tinyint(20) NOT NULL,
  `first_shift` enum('None','Morning','Midday','Evening') NOT NULL,
  `second_shift` enum('None','Sick','DayOff') NOT NULL,
  `absence` tinyint(1) NOT NULL DEFAULT '0',
  `absence_reason` enum('None','Sick','DayOff') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `schedule`
--

CREATE TABLE `schedule` (
  `id` tinyint(20) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` int(11) NOT NULL,
  `is_outdated` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `days`
--
ALTER TABLE `days`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `date` (`date`) USING BTREE,
  ADD KEY `schedule_id` (`schedule_id`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `employees_preferences`
--
ALTER TABLE `employees_preferences`
  ADD PRIMARY KEY (`day_id`,`employee_id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indexes for table `employees_workdays`
--
ALTER TABLE `employees_workdays`
  ADD PRIMARY KEY (`day_id`,`employee_id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indexes for table `schedule`
--
ALTER TABLE `schedule`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `days`
--
ALTER TABLE `days`
  MODIFY `id` tinyint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `id` tinyint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `schedule`
--
ALTER TABLE `schedule`
  MODIFY `id` tinyint(20) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `days`
--
ALTER TABLE `days`
  ADD CONSTRAINT `days_ibfk_1` FOREIGN KEY (`schedule_id`) REFERENCES `schedule` (`id`);

--
-- Constraints for table `employees_preferences`
--
ALTER TABLE `employees_preferences`
  ADD CONSTRAINT `employees_preferences_ibfk_1` FOREIGN KEY (`day_id`) REFERENCES `days` (`id`),
  ADD CONSTRAINT `employees_preferences_ibfk_2` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`);

--
-- Constraints for table `employees_workdays`
--
ALTER TABLE `employees_workdays`
  ADD CONSTRAINT `employees_workdays_ibfk_1` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`),
  ADD CONSTRAINT `employees_workdays_ibfk_2` FOREIGN KEY (`day_id`) REFERENCES `days` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
