-- phpMyAdmin SQL Dump
-- version 4.9.3
-- https://www.phpmyadmin.net/
--
-- Host: studmysql01.fhict.local
-- Generation Time: Apr 01, 2021 at 07:45 PM
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
-- Table structure for table `dayoff_requests`
--

CREATE TABLE `dayoff_requests` (
  `day_id` int(20) NOT NULL,
  `employee_id` int(20) NOT NULL,
  `denied` tinyint(1) NOT NULL,
  `objection` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `days`
--

CREATE TABLE `days` (
  `id` int(20) NOT NULL,
  `date` date NOT NULL,
  `schedule_id` int(20) NOT NULL,
  `security_needed` int(4) NOT NULL DEFAULT '2',
  `cashiers_needed` int(4) NOT NULL DEFAULT '5',
  `stockers_needed` int(4) NOT NULL DEFAULT '5',
  `sales_assistants_needed` int(4) NOT NULL DEFAULT '4',
  `warehouse_managers_needed` int(4) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `days`
--

INSERT INTO `days` (`id`, `date`, `schedule_id`, `security_needed`, `cashiers_needed`, `stockers_needed`, `sales_assistants_needed`, `warehouse_managers_needed`) VALUES
(1, '2021-01-04', 1, 2, 4, 9, 4, 1),
(2, '2021-01-05', 1, 2, 5, 5, 4, 1),
(3, '2021-01-06', 1, 2, 5, 5, 4, 1),
(4, '2021-01-07', 1, 2, 5, 5, 4, 1),
(5, '2021-01-08', 1, 2, 5, 5, 4, 1),
(6, '2021-01-09', 1, 2, 5, 5, 4, 1),
(7, '2021-01-10', 1, 2, 5, 5, 4, 1),
(8, '2021-01-11', 1, 2, 5, 5, 4, 1),
(9, '2021-01-12', 1, 2, 5, 5, 4, 1),
(10, '2021-01-13', 1, 2, 5, 5, 4, 1),
(11, '2021-01-14', 1, 2, 5, 5, 4, 1),
(12, '2021-01-15', 1, 2, 5, 5, 4, 1),
(13, '2021-01-16', 1, 2, 5, 5, 4, 1),
(14, '2021-01-17', 1, 2, 5, 5, 4, 1),
(15, '2021-01-18', 2, 2, 5, 5, 4, 1),
(16, '2021-01-19', 2, 2, 5, 5, 4, 1),
(17, '2021-01-20', 2, 2, 5, 5, 4, 1),
(18, '2021-01-21', 2, 2, 5, 5, 4, 1),
(19, '2021-01-22', 2, 2, 5, 5, 4, 1),
(20, '2021-01-23', 2, 2, 5, 5, 4, 1),
(21, '2021-01-24', 2, 2, 5, 5, 4, 1),
(22, '2021-01-25', 2, 2, 5, 5, 4, 1),
(23, '2021-01-26', 2, 2, 5, 5, 4, 1),
(24, '2021-01-27', 2, 2, 5, 5, 4, 1),
(25, '2021-01-28', 2, 2, 5, 5, 4, 1),
(26, '2021-01-29', 2, 2, 5, 5, 4, 1),
(27, '2021-01-30', 2, 2, 5, 5, 4, 1),
(28, '2021-01-31', 2, 2, 5, 5, 4, 1),
(29, '2021-02-01', 3, 2, 5, 5, 4, 1),
(30, '2021-02-02', 3, 2, 5, 5, 4, 1),
(31, '2021-02-03', 3, 2, 5, 5, 4, 1),
(32, '2021-02-04', 3, 2, 5, 5, 4, 1),
(33, '2021-02-05', 3, 2, 5, 5, 4, 1),
(34, '2021-02-06', 3, 2, 5, 5, 4, 1),
(35, '2021-02-07', 3, 2, 5, 5, 4, 1),
(36, '2021-02-08', 3, 2, 5, 5, 4, 1),
(37, '2021-02-09', 3, 2, 5, 5, 4, 1),
(38, '2021-02-10', 3, 2, 5, 5, 4, 1),
(39, '2021-02-11', 3, 2, 5, 5, 4, 1),
(40, '2021-02-12', 3, 2, 5, 5, 4, 1),
(41, '2021-02-13', 3, 2, 5, 5, 4, 1),
(42, '2021-02-14', 3, 2, 5, 5, 4, 1),
(43, '2021-02-15', 4, 2, 5, 5, 4, 1),
(44, '2021-02-16', 4, 2, 5, 5, 4, 1),
(45, '2021-02-17', 4, 2, 5, 5, 4, 1),
(46, '2021-02-18', 4, 2, 5, 5, 4, 1),
(47, '2021-02-19', 4, 2, 5, 5, 4, 1),
(48, '2021-02-20', 4, 2, 5, 5, 4, 1),
(49, '2021-02-21', 4, 2, 5, 5, 4, 1),
(50, '2021-02-22', 4, 2, 5, 5, 4, 1),
(51, '2021-02-23', 4, 2, 5, 5, 4, 1),
(52, '2021-02-24', 4, 2, 5, 5, 4, 1),
(53, '2021-02-25', 4, 2, 5, 5, 4, 1),
(54, '2021-02-26', 4, 2, 5, 5, 4, 1),
(55, '2021-02-27', 4, 2, 5, 5, 4, 1),
(56, '2021-02-28', 4, 2, 5, 5, 4, 1),
(57, '2021-03-01', 5, 2, 5, 5, 4, 1),
(58, '2021-03-02', 5, 2, 5, 5, 4, 1),
(59, '2021-03-03', 5, 2, 5, 5, 4, 1),
(60, '2021-03-04', 5, 2, 5, 5, 4, 1),
(61, '2021-03-05', 5, 2, 5, 5, 4, 1),
(62, '2021-03-06', 5, 2, 5, 5, 4, 1),
(63, '2021-03-07', 5, 2, 5, 5, 4, 1),
(64, '2021-03-08', 5, 2, 5, 5, 4, 1),
(65, '2021-03-09', 5, 2, 5, 5, 4, 1),
(66, '2021-03-10', 5, 2, 5, 5, 4, 1),
(67, '2021-03-11', 5, 2, 5, 5, 4, 1),
(68, '2021-03-12', 5, 2, 5, 5, 4, 1),
(69, '2021-03-13', 5, 2, 5, 5, 4, 1),
(70, '2021-03-14', 5, 2, 5, 5, 4, 1),
(71, '2021-03-15', 6, 2, 5, 5, 4, 1),
(72, '2021-03-16', 6, 2, 5, 5, 4, 1),
(73, '2021-03-17', 6, 2, 5, 5, 4, 1),
(74, '2021-03-18', 6, 2, 5, 5, 4, 1),
(75, '2021-03-19', 6, 2, 5, 5, 4, 1),
(76, '2021-03-20', 6, 2, 5, 5, 4, 1),
(77, '2021-03-21', 6, 2, 5, 5, 4, 1),
(78, '2021-03-22', 6, 2, 5, 5, 4, 1),
(79, '2021-03-23', 6, 2, 5, 5, 4, 1),
(80, '2021-03-24', 6, 2, 5, 5, 4, 1),
(81, '2021-03-25', 6, 2, 5, 5, 4, 1),
(82, '2021-03-26', 6, 2, 5, 5, 4, 1),
(83, '2021-03-27', 6, 2, 5, 5, 4, 1),
(84, '2021-03-28', 6, 2, 5, 5, 4, 1),
(85, '2021-03-29', 7, 2, 5, 5, 4, 1),
(86, '2021-03-30', 7, 2, 5, 5, 4, 1),
(87, '2021-03-31', 7, 2, 5, 5, 4, 1),
(88, '2021-04-01', 7, 2, 5, 5, 4, 1),
(89, '2021-04-02', 7, 2, 5, 5, 4, 1),
(90, '2021-04-03', 7, 2, 5, 5, 4, 1),
(91, '2021-04-04', 7, 2, 5, 5, 4, 1),
(92, '2021-04-05', 7, 2, 5, 5, 4, 1),
(93, '2021-04-06', 7, 2, 5, 5, 4, 1),
(94, '2021-04-07', 7, 2, 5, 5, 4, 1),
(95, '2021-04-08', 7, 2, 5, 5, 4, 1),
(96, '2021-04-09', 7, 2, 5, 5, 4, 1),
(97, '2021-04-10', 7, 2, 5, 5, 4, 1),
(98, '2021-04-11', 7, 2, 5, 5, 4, 1),
(99, '2021-04-12', 8, 2, 5, 5, 4, 1),
(100, '2021-04-13', 8, 2, 5, 5, 4, 1),
(101, '2021-04-14', 8, 2, 5, 5, 4, 1),
(102, '2021-04-15', 8, 2, 5, 5, 4, 1),
(103, '2021-04-16', 8, 2, 5, 5, 4, 1),
(104, '2021-04-17', 8, 2, 5, 5, 4, 1),
(105, '2021-04-18', 8, 2, 5, 5, 4, 1),
(106, '2021-04-19', 8, 2, 5, 5, 4, 1),
(107, '2021-04-20', 8, 2, 5, 5, 4, 1),
(108, '2021-04-21', 8, 2, 5, 5, 4, 1),
(109, '2021-04-22', 8, 2, 5, 5, 4, 1),
(110, '2021-04-23', 8, 2, 5, 5, 4, 1),
(111, '2021-04-24', 8, 2, 5, 5, 4, 1),
(112, '2021-04-25', 8, 2, 5, 5, 4, 1),
(113, '2021-04-26', 9, 2, 5, 5, 4, 1),
(114, '2021-04-27', 9, 2, 5, 5, 4, 1),
(115, '2021-04-28', 9, 2, 5, 5, 4, 1),
(116, '2021-04-29', 9, 2, 5, 5, 4, 1),
(117, '2021-04-30', 9, 2, 5, 5, 4, 1),
(118, '2021-05-01', 9, 2, 5, 5, 4, 1),
(119, '2021-05-02', 9, 2, 5, 5, 4, 1),
(120, '2021-05-03', 9, 2, 5, 5, 4, 1),
(121, '2021-05-04', 9, 2, 5, 5, 4, 1),
(122, '2021-05-05', 9, 2, 5, 5, 4, 1),
(123, '2021-05-06', 9, 2, 5, 5, 4, 1),
(124, '2021-05-07', 9, 2, 5, 5, 4, 1),
(125, '2021-05-08', 9, 2, 5, 5, 4, 1),
(126, '2021-05-09', 9, 2, 5, 5, 4, 1),
(127, '2021-05-10', 10, 2, 5, 5, 4, 1),
(128, '2021-05-11', 10, 2, 5, 5, 4, 1),
(129, '2021-05-12', 10, 2, 5, 5, 4, 1),
(130, '2021-05-13', 10, 2, 5, 5, 4, 1),
(131, '2021-05-14', 10, 2, 5, 5, 4, 1),
(132, '2021-05-15', 10, 2, 5, 5, 4, 1),
(133, '2021-05-16', 10, 2, 5, 5, 4, 1),
(134, '2021-05-17', 10, 2, 5, 5, 4, 1),
(135, '2021-05-18', 10, 2, 5, 5, 4, 1),
(136, '2021-05-19', 10, 2, 5, 5, 4, 1),
(137, '2021-05-20', 10, 2, 5, 5, 4, 1),
(138, '2021-05-21', 10, 2, 5, 5, 4, 1),
(139, '2021-05-22', 10, 2, 5, 5, 4, 1),
(140, '2021-05-23', 10, 2, 5, 5, 4, 1),
(141, '2021-05-24', 11, 2, 5, 5, 4, 1),
(142, '2021-05-25', 11, 2, 5, 5, 4, 1),
(143, '2021-05-26', 11, 2, 5, 5, 4, 1),
(144, '2021-05-27', 11, 2, 5, 5, 4, 1),
(145, '2021-05-28', 11, 2, 5, 5, 4, 1),
(146, '2021-05-29', 11, 2, 5, 5, 4, 1),
(147, '2021-05-30', 11, 2, 5, 5, 4, 1),
(148, '2021-05-31', 11, 2, 5, 5, 4, 1),
(149, '2021-06-01', 11, 2, 5, 5, 4, 1),
(150, '2021-06-02', 11, 2, 5, 5, 4, 1),
(151, '2021-06-03', 11, 2, 5, 5, 4, 1),
(152, '2021-06-04', 11, 2, 5, 5, 4, 1),
(153, '2021-06-05', 11, 2, 5, 5, 4, 1),
(154, '2021-06-06', 11, 2, 5, 5, 4, 1),
(155, '2021-06-07', 12, 2, 5, 5, 4, 1),
(156, '2021-06-08', 12, 2, 5, 5, 4, 1),
(157, '2021-06-09', 12, 2, 5, 5, 4, 1),
(158, '2021-06-10', 12, 2, 5, 5, 4, 1),
(159, '2021-06-11', 12, 2, 5, 5, 4, 1),
(160, '2021-06-12', 12, 2, 5, 5, 4, 1),
(161, '2021-06-13', 12, 2, 5, 5, 4, 1),
(162, '2021-06-14', 12, 2, 5, 5, 4, 1),
(163, '2021-06-15', 12, 2, 5, 5, 4, 1),
(164, '2021-06-16', 12, 2, 5, 5, 4, 1),
(165, '2021-06-17', 12, 2, 5, 5, 4, 1),
(166, '2021-06-18', 12, 2, 5, 5, 4, 1),
(167, '2021-06-19', 12, 2, 5, 5, 4, 1),
(168, '2021-06-20', 12, 2, 5, 5, 4, 1),
(169, '2021-06-21', 13, 2, 5, 5, 4, 1),
(170, '2021-06-22', 13, 2, 5, 5, 4, 1),
(171, '2021-06-23', 13, 2, 5, 5, 4, 1),
(172, '2021-06-24', 13, 2, 5, 5, 4, 1),
(173, '2021-06-25', 13, 2, 5, 5, 4, 1),
(174, '2021-06-26', 13, 2, 5, 5, 4, 1),
(175, '2021-06-27', 13, 2, 5, 5, 4, 1),
(176, '2021-06-28', 13, 2, 5, 5, 4, 1),
(177, '2021-06-29', 13, 2, 5, 5, 4, 1),
(178, '2021-06-30', 13, 2, 5, 5, 4, 1),
(179, '2021-07-01', 13, 2, 5, 5, 4, 1),
(180, '2021-07-02', 13, 2, 5, 5, 4, 1),
(181, '2021-07-03', 13, 2, 5, 5, 4, 1),
(182, '2021-07-04', 13, 2, 5, 5, 4, 1),
(183, '2021-07-05', 14, 2, 5, 5, 4, 1),
(184, '2021-07-06', 14, 2, 5, 5, 4, 1),
(185, '2021-07-07', 14, 2, 5, 5, 4, 1),
(186, '2021-07-08', 14, 2, 5, 5, 4, 1),
(187, '2021-07-09', 14, 2, 5, 5, 4, 1),
(188, '2021-07-10', 14, 2, 5, 5, 4, 1),
(189, '2021-07-11', 14, 2, 5, 5, 4, 1),
(190, '2021-07-12', 14, 2, 5, 5, 4, 1),
(191, '2021-07-13', 14, 2, 5, 5, 4, 1),
(192, '2021-07-14', 14, 2, 5, 5, 4, 1),
(193, '2021-07-15', 14, 2, 5, 5, 4, 1),
(194, '2021-07-16', 14, 2, 5, 5, 4, 1),
(195, '2021-07-17', 14, 2, 5, 5, 4, 1),
(196, '2021-07-18', 14, 2, 5, 5, 4, 1),
(197, '2021-07-19', 15, 2, 5, 5, 4, 1),
(198, '2021-07-20', 15, 2, 5, 5, 4, 1),
(199, '2021-07-21', 15, 2, 5, 5, 4, 1),
(200, '2021-07-22', 15, 2, 5, 5, 4, 1),
(201, '2021-07-23', 15, 2, 5, 5, 4, 1),
(202, '2021-07-24', 15, 2, 5, 5, 4, 1),
(203, '2021-07-25', 15, 2, 5, 5, 4, 1),
(204, '2021-07-26', 15, 2, 5, 5, 4, 1),
(205, '2021-07-27', 15, 2, 5, 5, 4, 1),
(206, '2021-07-28', 15, 2, 5, 5, 4, 1),
(207, '2021-07-29', 15, 2, 5, 5, 4, 1),
(208, '2021-07-30', 15, 2, 5, 5, 4, 1),
(209, '2021-07-31', 15, 2, 5, 5, 4, 1),
(210, '2021-08-01', 15, 2, 5, 5, 4, 1),
(211, '2021-08-02', 16, 2, 5, 5, 4, 1),
(212, '2021-08-03', 16, 2, 5, 5, 4, 1),
(213, '2021-08-04', 16, 2, 5, 5, 4, 1),
(214, '2021-08-05', 16, 2, 5, 5, 4, 1),
(215, '2021-08-06', 16, 2, 5, 5, 4, 1),
(216, '2021-08-07', 16, 2, 5, 5, 4, 1),
(217, '2021-08-08', 16, 2, 5, 5, 4, 1),
(218, '2021-08-09', 16, 2, 5, 5, 4, 1),
(219, '2021-08-10', 16, 2, 5, 5, 4, 1),
(220, '2021-08-11', 16, 2, 5, 5, 4, 1),
(221, '2021-08-12', 16, 2, 5, 5, 4, 1),
(222, '2021-08-13', 16, 2, 5, 5, 4, 1),
(223, '2021-08-14', 16, 2, 5, 5, 4, 1),
(224, '2021-08-15', 16, 2, 5, 5, 4, 1),
(225, '2021-08-16', 17, 2, 5, 5, 4, 1),
(226, '2021-08-17', 17, 2, 5, 5, 4, 1),
(227, '2021-08-18', 17, 2, 5, 5, 4, 1),
(228, '2021-08-19', 17, 2, 5, 5, 4, 1),
(229, '2021-08-20', 17, 2, 5, 5, 4, 1),
(230, '2021-08-21', 17, 2, 5, 5, 4, 1),
(231, '2021-08-22', 17, 2, 5, 5, 4, 1),
(232, '2021-08-23', 17, 2, 5, 5, 4, 1),
(233, '2021-08-24', 17, 2, 5, 5, 4, 1),
(234, '2021-08-25', 17, 2, 5, 5, 4, 1),
(235, '2021-08-26', 17, 2, 5, 5, 4, 1),
(236, '2021-08-27', 17, 2, 5, 5, 4, 1),
(237, '2021-08-28', 17, 2, 5, 5, 4, 1),
(238, '2021-08-29', 17, 2, 5, 5, 4, 1),
(239, '2021-08-30', 18, 2, 5, 5, 4, 1),
(240, '2021-08-31', 18, 2, 5, 5, 4, 1),
(241, '2021-09-01', 18, 2, 5, 5, 4, 1),
(242, '2021-09-02', 18, 2, 5, 5, 4, 1),
(243, '2021-09-03', 18, 2, 5, 5, 4, 1),
(244, '2021-09-04', 18, 2, 5, 5, 4, 1),
(245, '2021-09-05', 18, 2, 5, 5, 4, 1),
(246, '2021-09-06', 18, 2, 5, 5, 4, 1),
(247, '2021-09-07', 18, 2, 5, 5, 4, 1),
(248, '2021-09-08', 18, 2, 5, 5, 4, 1),
(249, '2021-09-09', 18, 2, 5, 5, 4, 1),
(250, '2021-09-10', 18, 2, 5, 5, 4, 1),
(251, '2021-09-11', 18, 2, 5, 5, 4, 1),
(252, '2021-09-12', 18, 2, 5, 5, 4, 1),
(253, '2021-09-13', 19, 2, 5, 5, 4, 1),
(254, '2021-09-14', 19, 2, 5, 5, 4, 1),
(255, '2021-09-15', 19, 2, 5, 5, 4, 1),
(256, '2021-09-16', 19, 2, 5, 5, 4, 1),
(257, '2021-09-17', 19, 2, 5, 5, 4, 1),
(258, '2021-09-18', 19, 2, 5, 5, 4, 1),
(259, '2021-09-19', 19, 2, 5, 5, 4, 1),
(260, '2021-09-20', 19, 2, 5, 5, 4, 1),
(261, '2021-09-21', 19, 2, 5, 5, 4, 1),
(262, '2021-09-22', 19, 2, 5, 5, 4, 1),
(263, '2021-09-23', 19, 2, 5, 5, 4, 1),
(264, '2021-09-24', 19, 2, 5, 5, 4, 1),
(265, '2021-09-25', 19, 2, 5, 5, 4, 1),
(266, '2021-09-26', 19, 2, 5, 5, 4, 1),
(267, '2021-09-27', 20, 2, 5, 5, 4, 1),
(268, '2021-09-28', 20, 2, 5, 5, 4, 1),
(269, '2021-09-29', 20, 2, 5, 5, 4, 1),
(270, '2021-09-30', 20, 2, 5, 5, 4, 1),
(271, '2021-10-01', 20, 2, 5, 5, 4, 1),
(272, '2021-10-02', 20, 2, 5, 5, 4, 1),
(273, '2021-10-03', 20, 2, 5, 5, 4, 1),
(274, '2021-10-04', 20, 2, 5, 5, 4, 1),
(275, '2021-10-05', 20, 2, 5, 5, 4, 1),
(276, '2021-10-06', 20, 2, 5, 5, 4, 1),
(277, '2021-10-07', 20, 2, 5, 5, 4, 1),
(278, '2021-10-08', 20, 2, 5, 5, 4, 1),
(279, '2021-10-09', 20, 2, 5, 5, 4, 1),
(280, '2021-10-10', 20, 2, 5, 5, 4, 1),
(281, '2021-10-11', 21, 2, 5, 5, 4, 1),
(282, '2021-10-12', 21, 2, 5, 5, 4, 1),
(283, '2021-10-13', 21, 2, 5, 5, 4, 1),
(284, '2021-10-14', 21, 2, 5, 5, 4, 1),
(285, '2021-10-15', 21, 2, 5, 5, 4, 1),
(286, '2021-10-16', 21, 2, 5, 5, 4, 1),
(287, '2021-10-17', 21, 2, 5, 5, 4, 1),
(288, '2021-10-18', 21, 2, 5, 5, 4, 1),
(289, '2021-10-19', 21, 2, 5, 5, 4, 1),
(290, '2021-10-20', 21, 2, 5, 5, 4, 1),
(291, '2021-10-21', 21, 2, 5, 5, 4, 1),
(292, '2021-10-22', 21, 2, 5, 5, 4, 1),
(293, '2021-10-23', 21, 2, 5, 5, 4, 1),
(294, '2021-10-24', 21, 2, 5, 5, 4, 1),
(295, '2021-10-25', 22, 2, 5, 5, 4, 1),
(296, '2021-10-26', 22, 2, 5, 5, 4, 1),
(297, '2021-10-27', 22, 2, 5, 5, 4, 1),
(298, '2021-10-28', 22, 2, 5, 5, 4, 1),
(299, '2021-10-29', 22, 2, 5, 5, 4, 1),
(300, '2021-10-30', 22, 2, 5, 5, 4, 1),
(301, '2021-10-31', 22, 2, 5, 5, 4, 1),
(302, '2021-11-01', 22, 2, 5, 5, 4, 1),
(303, '2021-11-02', 22, 2, 5, 5, 4, 1),
(304, '2021-11-03', 22, 2, 5, 5, 4, 1),
(305, '2021-11-04', 22, 2, 5, 5, 4, 1),
(306, '2021-11-05', 22, 2, 5, 5, 4, 1),
(307, '2021-11-06', 22, 2, 5, 5, 4, 1),
(308, '2021-11-07', 22, 2, 5, 5, 4, 1),
(309, '2021-11-08', 23, 2, 5, 5, 4, 1),
(310, '2021-11-09', 23, 2, 5, 5, 4, 1),
(311, '2021-11-10', 23, 2, 5, 5, 4, 1),
(312, '2021-11-11', 23, 2, 5, 5, 4, 1),
(313, '2021-11-12', 23, 2, 5, 5, 4, 1),
(314, '2021-11-13', 23, 2, 5, 5, 4, 1),
(315, '2021-11-14', 23, 2, 5, 5, 4, 1),
(316, '2021-11-15', 23, 2, 5, 5, 4, 1),
(317, '2021-11-16', 23, 2, 5, 5, 4, 1),
(318, '2021-11-17', 23, 2, 5, 5, 4, 1),
(319, '2021-11-18', 23, 2, 5, 5, 4, 1),
(320, '2021-11-19', 23, 2, 5, 5, 4, 1),
(321, '2021-11-20', 23, 2, 5, 5, 4, 1),
(322, '2021-11-21', 23, 2, 5, 5, 4, 1),
(323, '2021-11-22', 24, 2, 5, 5, 4, 1),
(324, '2021-11-23', 24, 2, 5, 5, 4, 1),
(325, '2021-11-24', 24, 2, 5, 5, 4, 1),
(326, '2021-11-25', 24, 2, 5, 5, 4, 1),
(327, '2021-11-26', 24, 2, 5, 5, 4, 1),
(328, '2021-11-27', 24, 2, 5, 5, 4, 1),
(329, '2021-11-28', 24, 2, 5, 5, 4, 1),
(330, '2021-11-29', 24, 2, 5, 5, 4, 1),
(331, '2021-11-30', 24, 2, 5, 5, 4, 1),
(332, '2021-12-01', 24, 2, 5, 5, 4, 1),
(333, '2021-12-02', 24, 2, 5, 5, 4, 1),
(334, '2021-12-03', 24, 2, 5, 5, 4, 1),
(335, '2021-12-04', 24, 2, 5, 5, 4, 1),
(336, '2021-12-05', 24, 2, 5, 5, 4, 1),
(337, '2021-12-06', 25, 2, 5, 5, 4, 1),
(338, '2021-12-07', 25, 2, 5, 5, 4, 1),
(339, '2021-12-08', 25, 2, 5, 5, 4, 1),
(340, '2021-12-09', 25, 2, 5, 5, 4, 1),
(341, '2021-12-10', 25, 2, 5, 5, 4, 1),
(342, '2021-12-11', 25, 2, 5, 5, 4, 1),
(343, '2021-12-12', 25, 2, 5, 5, 4, 1),
(344, '2021-12-13', 25, 2, 5, 5, 4, 1),
(345, '2021-12-14', 25, 2, 5, 5, 4, 1),
(346, '2021-12-15', 25, 2, 5, 5, 4, 1),
(347, '2021-12-16', 25, 2, 5, 5, 4, 1),
(348, '2021-12-17', 25, 2, 5, 5, 4, 1),
(349, '2021-12-18', 25, 2, 5, 5, 4, 1),
(350, '2021-12-19', 25, 2, 5, 5, 4, 1),
(351, '2021-12-20', 26, 2, 5, 5, 4, 1),
(352, '2021-12-21', 26, 2, 5, 5, 4, 1),
(353, '2021-12-22', 26, 2, 5, 5, 4, 1),
(354, '2021-12-23', 26, 2, 5, 5, 4, 1),
(355, '2021-12-24', 26, 2, 5, 5, 4, 1),
(356, '2021-12-25', 26, 2, 5, 5, 4, 1),
(357, '2021-12-26', 26, 2, 5, 5, 4, 1),
(358, '2021-12-27', 26, 2, 5, 5, 4, 1),
(359, '2021-12-28', 26, 2, 5, 5, 4, 1),
(360, '2021-12-29', 26, 2, 5, 5, 4, 1),
(361, '2021-12-30', 26, 2, 5, 5, 4, 1),
(362, '2021-12-31', 26, 2, 5, 5, 4, 1),
(363, '2022-01-01', 26, 2, 5, 5, 4, 1),
(364, '2022-01-02', 26, 2, 5, 5, 4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `id` int(255) NOT NULL,
  `first_name` varchar(40) NOT NULL,
  `last_name` varchar(40) NOT NULL,
  `birthDate` date NOT NULL,
  `email` varchar(320) NOT NULL,
  `password` varchar(40) NOT NULL,
  `job_position` varchar(100) NOT NULL,
  `phoneNumber` int(10) DEFAULT NULL,
  `address` varchar(50) NOT NULL,
  `salary` int(11) DEFAULT NULL,
  `gender` varchar(10) NOT NULL,
  `education` varchar(20) DEFAULT NULL,
  `Contract` varchar(255) NOT NULL,
  `DaysOff` int(255) NOT NULL,
  `ContractHours` int(255) NOT NULL,
  `Notes` varchar(255) NOT NULL DEFAULT '"Nothing"'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`id`, `first_name`, `last_name`, `birthDate`, `email`, `password`, `job_position`, `phoneNumber`, `address`, `salary`, `gender`, `education`, `Contract`, `DaysOff`, `ContractHours`, `Notes`) VALUES
(1, 'John', 'McDuffin', '1999-01-12', 'john.mcduffin@mail.com', 'john1', 'Security', 731234568, 'Flower Street 23A', 1400, 'MALE', 'High School', 'Fulltime', 30, 40, 'test3'),
(2, 'Maria', 'Vincenzio', '1995-04-15', 'maria.vincenzio@mail.com', 'maria1', 'Security', 198767889, 'Stationsweg 16', 1400, 'FEMALE', 'High School', 'Fulltime', 30, 40, 'test1'),
(3, 'Lawrence', 'Moschino', '1997-12-03', 'lawrence.moschino@mail.com', 'lawrence1', 'Security', 965234521, 'Buekeslaan 12A', 1400, 'OTHER', 'University', 'Parttime', 30, 0, ''),
(4, 'Ponton', 'Portofino', '1999-11-01', 'ponton.portofino@mail.com', 'ponton1', 'Security', 134156123, 'Cebeslaan 213A', 1400, 'MALE', 'University', 'Parttime', 30, 0, ''),
(5, 'Caitlyn', 'Rose', '1997-10-09', 'caitlyn.rose@mail.com', 'caitlyn1', 'Cashier', 623144155, 'Transformatorstraat 1', 1200, 'FEMALE', 'High School', 'Fulltime', 30, 40, ''),
(6, 'Daniel', 'Burton', '2000-06-06', 'daniel.burton@mail.com', 'daniel1', 'Cashier', 534412415, 'Borneolaan 5', 1200, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(7, 'Prince', 'John', '2001-07-08', 'prince.john@mail.com', 'prince1', 'Cashier', 333125619, 'Winston Churchilaan 12', 1200, 'MALE', 'High School', 'Parttime', 30, 0, ''),
(8, 'Laquesha', 'Johnson', '2002-05-14', 'laquesha.johnson@mail.com', 'laquesha1', 'Cashier', 564123667, 'Horneolaan 32', 1200, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(9, 'Anastasia', 'Krilov', '2000-12-12', 'anastasio.krilov@mail.com', 'anastasia1', 'Stocker', 567889001, 'John F. Kennedylaan 168', 2500, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(10, 'Claire', 'Temple', '1995-10-12', 'claire.temple@mail.com', 'claire1', 'Stocker', 193343600, 'Luciferstraat 32', 2500, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(11, 'Daniel', 'Meachum', '1966-12-01', 'daniel.meachum@mail.com', 'daniel1', 'Stocker', 358890065, 'Cederlaan 12D', 2500, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(12, 'Cornell', 'Stokes', '1998-05-15', 'cornell.stokes@mail.com', 'cornell1', 'Stocker', 466781032, 'Franklin D. Rooseveltlaan 12', 2500, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(13, 'Maria', 'Antoinette', '1996-06-23', 'maria.antoinette@mail.com', 'maria1', 'SalesAssistant', 913576787, 'Hemelrijken 215A', 2000, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(14, 'Lucas', 'Cage', '1997-03-21', 'lucas.cage@mail.com', 'lucas1', 'SalesAssistant', 919071783, 'Lombokpad 3.42', 2000, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(15, 'Janette', 'Stones', '2000-10-12', 'janette.stones@mail.com', 'janette1', 'SalesAssistant', 675553687, ' Bulevardul Iuliu Maniu 205', 2000, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(16, 'Alex', 'Spades', '1990-04-19', 'alex.spades@mail.com', 'alex1', 'SalesAssistant', 727567672, ' Fuutlaan 3', 2000, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(17, 'Matthew', 'Murdock', '1993-08-15', 'matthew.murdock@mail.com', 'matthew1', 'WarehouseManager', 657773686, ' Pagelaan 21', 3500, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(18, 'Johnatan', 'Joestar', '1960-12-01', 'johnatan.joestar@mail.com', 'johnatan1', 'WarehouseManager', 757699888, ' Mathildelaan 32', 3500, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(19, 'Colleen', 'Wing', '2002-01-05', 'colleen.wing@mail.com', 'colleen1', 'WarehouseManager', 723679009, ' Havenstraat 2B', 3500, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(20, 'Joy', 'Meachum', '1989-08-08', 'joy.meachum@mail.com', 'joy1', 'WarehouseManager', 165663686, ' Lakerstraat', 3500, 'OTHER', 'University', 'Fulltime', 30, 40, ''),
(21, 'Matthew', 'Lolly', '1996-09-25', 'matthew.buston@mail.com', 'Lolly1', 'Security', 231234555, 'Lombokpad 12', 2500, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(22, 'Daniel', 'Daniels', '1996-02-25', 'daniel.daniels@mail.com', 'daniels1', 'Security', 239240555, 'Fuutlaan 2', 2500, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(23, 'Rachel', 'Summers', '2000-05-05', 'rachel.summers@mail.com', 'summers1', 'Cashier', 123456789, 'Boschdijk 42L', 1400, 'OTHER', 'None', 'Fulltime', 30, 40, ''),
(24, 'Manuel', 'Aquino', '1982-02-14', 'ManuelAAquino@rhyta.com', 'aquino1', 'Security', 622379835, 'Kwikstaarthoek 27', 1400, 'MALE', 'None', 'Fulltime', 30, 40, ''),
(25, 'Gregory', 'Hess', '1978-03-15', '\r\nGregoryJHess@jourrapide.com', 'GregoryJHess@jourrapide.com', 'Security', 695396673, 'Wittenburgergracht 91', 1400, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(26, 'Eric', 'Smith', '1950-12-25', 'EricASmith@dayrep.com', 'smith1', 'Security', 663865634, 'Boerestreek 156', 1400, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(27, 'Martin', 'Weaver', '1952-05-07', 'MartinKWeaver@jourrapide.com', 'weaver1', 'Security', 689616906, 'Swemmerlaan 86', 1400, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(28, 'Jesus', 'Goldstein', '1996-03-24', '\r\nJesusNGoldstein@rhyta.com', 'goldstein1', 'WarehouseManager', 634771911, 'Van Foreeststraat 146', 2500, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(29, 'Amber', 'Eastin', '1977-03-17', 'AmberAEastin@armyspy.com', 'eastin1', 'Cashier', 687531086, 'Ocarinalaan 193', 1200, 'FEMALE', 'High School', '', 30, 0, ''),
(30, 'Edward', 'Lott', '1990-03-10', 'EdwardVLott@armyspy.com', 'lott1', 'Cashier', 633109844, 'Ringweg 47', 1200, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(31, 'Robyn', 'Pointer', '1983-03-17', 'robyn.pointer@armyspy.com', 'pointer1', 'Cashier', 687531086, 'Nederheidseweg 90', 1200, 'FEMALE', 'High School', 'Fulltime', 30, 40, ''),
(34, 'Elsie', 'Boyette', '1977-03-11', 'ElsieNBoyette@armyspy.com', 'boyette1', 'Cashier', 685644403, 'Borgersstede 129', 1200, 'FEMALE', 'High School', 'Fulltime', 30, 40, ''),
(35, 'Anthony', 'Wilson', '1999-03-17', 'anthony.wilson@armyspy.com', 'wilson1', 'Cashier', 636694615, 'Djambistraat 177', 1200, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(42, 'Charles', 'Horner', '1996-03-19', 'charles.horner@armyspy.com', 'horner1', 'Cashier', 631668932, 'Vossegatselaan 174', 1200, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(43, 'James ', 'Kinch', '1981-07-01', 'james.kinch@armyspy.com', 'kinch1', 'Cashier', 687531086, 'Zwanenkamp 196', 1200, 'MALE', 'High School', 'Fulltime', 30, 40, ''),
(44, 'Derek', 'Garcia', '1987-06-25', 'derek.garcia@armyspy.com', 'garcia1', 'Cashier', 690713583, 'Musketruwe 73', 1200, 'OTHER', 'High School', 'Fulltime', 30, 40, ''),
(45, 'Dolores', 'McCarty', '1990-07-30', 'dolores.mccarty@armyspy.com', 'mccarty1', 'Cashier', 664045265, 'Veluwsedijk 19', 1200, 'FEMALE', 'High School', 'Fulltime', 30, 40, ''),
(46, 'Diana', 'Crabtree', '1987-03-27', 'diana.crabtree@armyspy.com', 'crabtree1', 'Cashier', 619984012, 'Sterrenlaan 103', 1200, 'FEMALE', 'High School', 'Fulltime', 30, 40, ''),
(47, 'Michael', 'Kemp', '2000-01-14', 'MichaelAKemp@armyspy.com', 'kemp1', 'Stocker', 646967570, 'Jurriaan Kokstraat 77', 2000, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(49, 'Page', 'Bedell', '2001-09-24', 'page.bedell@armyspy.com', 'bedell1', 'Stocker', 665499417, 'Korhoenlaan 21', 2000, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(50, 'Tara ', 'Smith', '1988-02-09', 'tara.smith@armyspy.com', 'smith1', 'Stocker', 626564858, 'Vrouwenakker 94', 2000, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(51, 'Patricia ', 'Petty', '1981-04-03', 'patricia.petty@armyspy.com', 'petty', 'Stocker', 689826337, 'Justus van Effenstraat 154', 2000, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(52, 'Katy ', 'Newman', '1987-01-19', 'katy.newman@armyspy.com', 'newman1', 'Stocker', 646456206, 'Grootblok 94', 2000, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(53, 'Stuart ', 'Daniel', '1978-04-14', 'stuart.daniel@armyspy.com', 'daniel1', 'Stocker', 620481490, 'Binderserf 160', 2000, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(54, 'Cynthia', 'Robbins', '1995-05-10', 'cynthia.robbins@armyspy.com', 'robbins', 'Stocker', 665292422, 'Tuinstraat 47', 2000, 'FEMALE', 'University', 'Fulltime', 30, 40, ''),
(61, 'Michael', 'Faris', '1987-07-19', 'michael.faris@armyspy.com', 'faris1', 'Stocker', 624967691, 'Amsteldijk 75', 2000, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(62, 'Barry ', 'Tregre', '1983-08-14', 'barry.tregre@armyspy.com', 'tregre', 'Stocker', 666819849, 'Willem Alexanderplein 197', 2000, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(63, 'Ronald', 'Carmean', '1992-03-03', 'ronald.carmean@armyspy.com', 'carmean1', 'Stocker', 694023509, 'Bernissestraat 114', 2000, 'MALE', 'University', 'Fulltime', 30, 40, ''),
(64, 'Gregory ', 'Atwell', '1990-08-15', 'gregoy.atwell@armyspy.com', 'atwell1', 'Stocker', 669719447, 'Schimmelstraat 135', 2000, 'MALE', 'University', 'Parttime', 30, 0, ''),
(65, 'Patrick', 'Armstrong', '1988-03-23', 'patrickarmstrong@mail.com', 'armstrong1', 'SalesAssistant', 638404573, 'Hendrikstraat', 2500, 'MALE', 'University', 'Parttime', 30, 0, ''),
(66, 'David ', 'Ruffin', '2000-05-31', 'david.ruffin@mail.com', 'ruffin1', 'SalesAssistant', 623498076, 'Aldenhof 80', 2500, 'MALE', 'University', '', 30, 0, ''),
(67, 'Carol ', 'Jenkins', '1994-03-08', 'carol.jenkins@mail.com', 'jenkins1', 'SalesAssistant', 658101141, 'Havenstraat 8', 2500, 'FEMALE', 'University', '', 30, 0, ''),
(68, 'Billy ', 'Decarlo', '1998-05-18', 'billy.decarlo@mail.com', 'decarlo1', 'SalesAssistant', 691513042, 'Nijboerstrjitte 192', 2500, 'MALE', 'University', '', 30, 0, ''),
(69, 'Jerome ', 'Hearn', '1981-01-18', 'jerome.hearn@mail.com', 'hearn1', 'SalesAssistant', 688110113, 'Reigerdreef 70', 2500, 'MALE', 'University', '', 30, 0, ''),
(70, 'Ada ', 'Tillmon', '1993-08-18', 'ada.tillmon@mail.com', 'tillmon1', 'SalesAssistant', 697949031, 'Groteweg 23', 2500, 'FEMALE', 'University', '', 30, 0, ''),
(71, 'Sandy ', 'Blaisdell', '1981-01-13', 'sandy.blaisdell@mail.com', 'blaisdell', 'SalesAssistant', 624445180, 'Staalstraat 147', 2500, 'FEMALE', 'University', '', 30, 0, ''),
(72, 'Dorothy ', 'Sims', '1983-05-13', 'dorothy.sims@mail.com', 'sims1', 'SalesAssistant', 659167920, 'Kwietheuvel 53', 2500, 'MALE', 'University', '', 30, 0, ''),
(73, 'Danilo ', 'Huerta', '1978-07-23', 'danilo.huerta@mail.com', 'huerta1', 'SalesAssistant', 629410719, 'Kerklaan 118', 2500, 'MALE', 'University', '', 30, 0, ''),
(74, 'Lawrence ', 'Jones', '1992-02-23', 'lawrence.jones@mail.com', 'jones1', 'SalesAssistant', 676080931, 'Pompstraat 21', 2500, 'MALE', 'University', '', 30, 0, ''),
(84, 'William ', 'Jackson', '1980-12-24', 'william.jackson@mail.com', 'jackson1', 'SalesAssistant', 67087774, 'Vossendaal 180', 2500, 'MALE', 'University', '', 30, 0, '');

-- --------------------------------------------------------

--
-- Table structure for table `employees_preferences`
--

CREATE TABLE `employees_preferences` (
  `day_id` int(20) NOT NULL,
  `employee_id` int(20) NOT NULL,
  `prefered_first_shift` enum('None','Morning','Midday','Evening') NOT NULL,
  `prefered_second_shift` enum('None','Morning','Midday','Evening') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `employees_workdays`
--

CREATE TABLE `employees_workdays` (
  `day_id` int(20) NOT NULL,
  `employee_id` int(20) NOT NULL,
  `first_shift` varchar(10) NOT NULL,
  `second_shift` varchar(10) NOT NULL DEFAULT 'None',
  `absence` int(1) NOT NULL DEFAULT '0',
  `absence_reason` varchar(10) NOT NULL DEFAULT 'None'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employees_workdays`
--

INSERT INTO `employees_workdays` (`day_id`, `employee_id`, `first_shift`, `second_shift`, `absence`, `absence_reason`) VALUES
(1, 3, 'Morning', 'None', 0, 'None'),
(1, 5, 'Morning', 'Midday', 0, 'None'),
(1, 7, 'Morning', 'None', 0, 'None'),
(1, 9, 'Morning', 'None', 0, 'None'),
(1, 11, 'Evening', 'Midday', 0, 'None'),
(1, 16, 'None', 'Midday', 0, 'None'),
(1, 26, 'Evening', 'None', 0, 'None'),
(1, 44, 'Evening', 'None', 0, 'None'),
(1, 46, 'Evening', 'None', 0, 'None'),
(360, 13, 'Morning', 'None', 0, 'None'),
(364, 5, 'Morning', 'Midday', 0, 'None'),
(364, 6, 'Morning', 'None', 0, 'None');

-- --------------------------------------------------------

--
-- Table structure for table `schedules`
--

CREATE TABLE `schedules` (
  `id` int(20) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `is_outdated` int(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `schedules`
--

INSERT INTO `schedules` (`id`, `start_date`, `end_date`, `is_outdated`) VALUES
(1, '2021-01-04', '2021-01-17', 0),
(2, '2021-01-18', '2021-01-31', 0),
(3, '2021-02-01', '2021-02-14', 0),
(4, '2021-02-15', '2021-02-28', 0),
(5, '2021-03-01', '2021-03-14', 0),
(6, '2021-03-15', '2021-03-28', 0),
(7, '2021-03-29', '2021-04-11', 0),
(8, '2021-04-12', '2021-04-25', 0),
(9, '2021-04-26', '2021-05-09', 0),
(10, '2021-05-10', '2021-05-23', 0),
(11, '2021-05-24', '2021-06-06', 0),
(12, '2021-06-07', '2021-06-20', 0),
(13, '2021-06-21', '2021-07-04', 0),
(14, '2021-07-05', '2021-07-18', 0),
(15, '2021-07-19', '2021-08-01', 0),
(16, '2021-08-02', '2021-08-15', 0),
(17, '2021-08-16', '2021-08-29', 0),
(18, '2021-08-30', '2021-09-12', 0),
(19, '2021-09-13', '2021-09-26', 0),
(20, '2021-09-27', '2021-10-10', 0),
(21, '2021-10-11', '2021-10-24', 0),
(22, '2021-10-25', '2021-11-07', 0),
(23, '2021-11-08', '2021-11-21', 0),
(24, '2021-11-22', '2021-12-05', 0),
(25, '2021-12-06', '2021-12-19', 0),
(26, '2021-12-20', '2022-01-02', 0);

-- --------------------------------------------------------

--
-- Table structure for table `sick_reports`
--

CREATE TABLE `sick_reports` (
  `day_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `description` varchar(300) NOT NULL,
  `seen` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dayoff_requests`
--
ALTER TABLE `dayoff_requests`
  ADD PRIMARY KEY (`day_id`,`employee_id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indexes for table `days`
--
ALTER TABLE `days`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UNIQUE` (`date`) USING BTREE,
  ADD KEY `FOREIGN KEY` (`schedule_id`) USING BTREE;

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
-- Indexes for table `schedules`
--
ALTER TABLE `schedules`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UNIQUE` (`start_date`,`end_date`) USING BTREE;

--
-- Indexes for table `sick_reports`
--
ALTER TABLE `sick_reports`
  ADD PRIMARY KEY (`day_id`,`employee_id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `days`
--
ALTER TABLE `days`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=365;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=114;

--
-- AUTO_INCREMENT for table `schedules`
--
ALTER TABLE `schedules`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `dayoff_requests`
--
ALTER TABLE `dayoff_requests`
  ADD CONSTRAINT `dayoff_requests_ibfk_1` FOREIGN KEY (`day_id`) REFERENCES `days` (`id`),
  ADD CONSTRAINT `dayoff_requests_ibfk_2` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`);

--
-- Constraints for table `days`
--
ALTER TABLE `days`
  ADD CONSTRAINT `days_ibfk_1` FOREIGN KEY (`schedule_id`) REFERENCES `schedules` (`id`);

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

--
-- Constraints for table `sick_reports`
--
ALTER TABLE `sick_reports`
  ADD CONSTRAINT `sick_reports_ibfk_1` FOREIGN KEY (`day_id`) REFERENCES `days` (`id`),
  ADD CONSTRAINT `sick_reports_ibfk_2` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
