-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Июн 19 2021 г., 20:13
-- Версия сервера: 10.4.18-MariaDB
-- Версия PHP: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `dbi460221`
--

-- --------------------------------------------------------

--
-- Структура таблицы `items`
--

CREATE TABLE `items` (
  `id` int(20) NOT NULL,
  `category` varchar(255) NOT NULL,
  `subcategory` varchar(255) NOT NULL,
  `brand` varchar(255) NOT NULL,
  `model` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `stock_price` varchar(255) NOT NULL,
  `price` varchar(255) NOT NULL,
  `restock_state` varchar(255) NOT NULL DEFAULT 'manager',
  `roomInShop` int(255) NOT NULL,
  `roomInStorage` int(255) NOT NULL,
  `minimumAmountInStock` int(255) NOT NULL,
  `inShopAmount` int(255) NOT NULL,
  `inStorageAmount` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `items`
--

INSERT INTO `items` (`id`, `category`, `subcategory`, `brand`, `model`, `description`, `stock_price`, `price`, `restock_state`, `roomInShop`, `roomInStorage`, `minimumAmountInStock`, `inShopAmount`, `inStorageAmount`) VALUES
(30, 'Electronics', 'Laptop', 'HP', 'RTL8723DE', 'Gaming laptop', '160', '320', 'stable', 5, 10, 5, 5, 10),
(31, 'Electronics', 'Laptop', 'HP', '245 G7', 'Gaming laptop', '200', '400', 'stable', 20, 40, 20, 20, 40),
(32, 'Electronics', 'Laptop', 'HP', '340S G7', 'Gaming laptop', '300', '600', 'stable', 15, 30, 15, 15, 30),
(33, 'Electronics', 'Laptop', 'HP', 'Spectre x360', 'Gaming laptop', '650', '1300', 'stable', 20, 40, 20, 20, 40),
(34, 'Electronics', 'Laptop', 'HP', 'Elitebook 850 G8', 'Gaming laptop', '800', '1600', 'stable', 5, 10, 5, 5, 10),
(35, 'Electronics', 'Laptop', 'HP', 'Elite Dragonfly G2', 'Gaming laptop', '1000', '2000', 'stable', 7, 14, 7, 7, 14),
(36, 'Electronics', 'Laptop', 'Acer', 'One Silver 14', 'Gaming laptop', '200', '400', 'stable', 20, 40, 20, 20, 40),
(37, 'Electronics', 'Laptop', 'Acer', 'Predator Triton 300 PT315-52-55TU', 'Gaming laptop', '600', '1200', 'stable', 20, 40, 20, 20, 40),
(38, 'Electronics', 'Laptop', 'Acer', 'TravelMate TMP614-51-G2-59XZ', 'Gaming laptop', '500', '1000', 'stable', 5, 10, 5, 5, 10),
(39, 'Electronics', 'Laptop', 'Acer', 'Swift 3 SF314-510G-59DZ', 'Gaming laptop', '425', '850', 'stable', 15, 30, 15, 15, 30),
(40, 'Electronics', 'Laptop', 'Acer', 'Swift 5 SF514-55TA-50EH', 'Gaming laptop', '450', '900', 'stable', 5, 10, 5, 5, 10),
(41, 'Electronics', 'Laptop', 'Lenovo', 'V15-IIL', 'Gaming laptop', '260', '520', 'stable', 7, 14, 7, 7, 14),
(42, 'Electronics', 'Laptop', 'Lenovo', 'IdeaPad 3 17ADA05', 'Gaming laptop', '200', '400', 'stable', 5, 10, 5, 5, 10),
(43, 'Electronics', 'Laptop', 'Apple', 'MacBook Air', 'Business laptop', '400', '800', 'stable', 35, 70, 35, 35, 70),
(44, 'Electronics', 'Laptop', 'Apple', 'MacBook Air MGN93', 'Business laptop', '500', '1000', 'stable', 5, 10, 5, 5, 10),
(45, 'Electronics', 'Laptop', 'Apple', 'MacBook Air MGNE3', 'Business laptop', '550', '1100', 'stable', 10, 20, 10, 10, 20),
(46, 'Electronics', 'PC', 'Acer', 'Predator Orion 3000 620', 'Gaming PC', '525', '1050', 'stable', 5, 10, 5, 5, 10),
(47, 'Electronics', 'PC', 'Medion', 'ERAZER ENGINEER P10 MD35076', 'Gaming PC', '550', '1100', 'stable', 5, 10, 5, 5, 10),
(48, 'Electronics', 'PC', 'Lenovo', 'IdeaCentre AIO 3 24', 'Gaming PC', '400', '800', 'stable', 5, 10, 5, 5, 10),
(49, 'Electronics', 'PC', 'HP', 'Slim Desktop S01-AF1810ND', 'Gaming PC', '225', '450', 'stable', 5, 10, 5, 5, 10),
(50, 'Electronics', 'PC', 'HP', 'OMEN 25L', 'Gaming PC', '800', '1600', 'stable', 5, 10, 5, 5, 10),
(51, 'Electronics', 'Monitor', 'Acer', 'Nitro XV270Pbmiiprx', 'Full HD', '130', '260', 'stable', 5, 10, 5, 5, 10),
(52, 'Electronics', 'Monitor', 'Asus', 'TUF Gaming VG27WQ', 'Gaming monitor, 27 inch', '200', '400', 'stable', 15, 30, 15, 15, 30),
(53, 'Electronics', 'Monitor', 'Samsung', 'LF24T350FHUXEN', 'Full HD, 24 inch', '65', '130', 'stable', 7, 14, 7, 7, 14),
(54, 'Electronics', 'Keyboard', 'Logitech', 'MK335', 'Wireless keyboard', '13', '26', 'stable', 30, 60, 30, 30, 60),
(55, 'Electronics', 'Keyboard', 'Logitech', 'K350', 'Wireless keyboard', '20', '40', 'stable', 50, 100, 50, 50, 100),
(56, 'Electronics', 'Keyboard', 'logitech', 'K845ch', 'Mechanical illuminated keyboard', '8', '16', 'stable', 60, 120, 60, 60, 120),
(57, 'Electronics', 'Mouse', 'Ledsail', 'None', 'Wireless mouse', '5', '10', 'stable', 40, 80, 40, 40, 80),
(58, 'Electronics', 'Mouse', 'Jelly Comb', 'None', 'Wireless mouse', '5', '10', 'stable', 40, 80, 40, 40, 80),
(59, 'Electronics', 'Mouse', 'Logitech', 'B100', 'Wired USB mouse', '5', '10', 'stable', 40, 80, 40, 40, 80),
(60, 'Electronics', 'Headphones', 'Sony', 'MDRZX110 BLK ZX', 'Wired headphones', '10', '20', 'stable', 35, 70, 35, 35, 70),
(61, 'Electronics', 'Headphones', 'Cowin', 'E7 Active Noise Cancelling', 'Wireless headphones', '25', '50', 'stable', 20, 40, 20, 20, 40),
(62, 'Electronics', 'Headphones', 'Apple', 'EarPods', 'In-ear', '10', '20', 'stable', 35, 70, 35, 35, 70),
(63, 'Furniture', 'Chair', 'Ikea', 'Renberget', 'Swivel chair', '20', '40', 'stable', 10, 20, 10, 10, 20),
(64, 'Furniture', 'Chair', 'Ikea', 'Loberget', 'Swivel chair', '13', '26', 'stable', 15, 30, 15, 15, 30),
(65, 'Furniture', 'Chair', 'Respawn', 'RSP-110', 'Gaming chair', '85', '170', 'stable', 5, 10, 5, 5, 10),
(66, 'Furniture', 'Chair', 'Ikea', 'Pello', 'Armchair', '20', '40', 'stable', 10, 20, 10, 10, 20),
(67, 'Furniture', 'Chair', 'Homall', 'None', 'Gaming chair', '100', '200', 'stable', 5, 10, 5, 5, 10),
(68, 'Furniture', 'Desk', 'Coleshome', 'None', '47-inch', '25', '50', 'stable', 50, 100, 50, 50, 100),
(69, 'Furniture', 'Desk', 'Homieasy', 'None', 'L-shaped', '50', '100', 'stable', 16, 32, 16, 16, 32),
(70, 'Furniture', 'Desk', 'Ikea', 'Skarsta', 'Sit/stand', '100', '200', 'stable', 10, 20, 10, 10, 20),
(71, 'Furniture', 'Desk', 'Ikea', 'Micke', 'None', '35', '70', 'stable', 40, 80, 40, 40, 80),
(72, 'Furniture', 'Desk', 'Ikea', 'Linnmon/Adils', 'None', '9', '18', 'stable', 60, 120, 60, 60, 120),
(73, 'Accessories', 'Controller', 'Luna', 'None', 'Wireless controller', '35', '70', 'stable', 30, 60, 30, 30, 60),
(74, 'Accessories', 'Controller', 'Playstation', 'None', 'DualSense Wireless Controller', '35', '70', 'stable', 30, 60, 30, 30, 60),
(75, 'Accessories', 'Controller', 'Xbox', 'None', 'Wireless controller', '25', '50', 'stable', 40, 80, 40, 40, 80),
(76, 'Accessories', 'Flash drive', 'SanDisk', 'Cruzer Glide', '128GB', '8', '16', 'stable', 70, 140, 70, 70, 140),
(77, 'Accessories', 'Flash drive', 'Yuhoves', 'None', '2TB', '25', '50', 'stable', 15, 30, 15, 15, 30),
(78, 'Accessories', 'Flash drive', 'Samsung', 'FIT Plus', '128GB', '12', '24', 'stable', 30, 60, 30, 30, 60),
(79, 'Accessories', 'Microphone', 'Schure', 'SM58-LC', 'Dynamic Vocal Microphone', '50', '100', 'stable', 15, 30, 15, 15, 30),
(80, 'Accessories', 'Microphone', 'Sudotack', 'None', 'None', '10', '20', 'stable', 15, 30, 15, 15, 30),
(81, 'Accessories', 'Microphone', 'Tonor', 'None', 'Dynamic Karaoke Microphone', '10', '20', 'stable', 20, 40, 20, 20, 40),
(82, 'Accessories', 'Microphone', 'Sudotack', 'None', 'Streaming Podcast PC Microphone', '25', '50', 'stable', 15, 30, 15, 15, 30),
(83, 'Furniture', 'Cabinet', 'Ikea', 'Brimnes', 'Cabinet with doors', '35', '70', 'stable', 15, 30, 15, 15, 30),
(84, 'Furniture', 'Cabinet', 'Ikea', 'Besta', 'Storage combination', '80', '160', 'stable', 10, 20, 10, 10, 20),
(85, 'Furniture', 'Cabinet', 'Ikea', 'Brusali', 'Cabinet with doors', '40', '80', 'stable', 10, 20, 10, 10, 20),
(86, 'Furniture', 'Cabinet', 'Ikea', 'Lixhult', 'Cabinet combination', '30', '60', 'stable', 10, 20, 10, 10, 20),
(87, 'Electronics', 'Cell phone', 'Apple', 'Iphone 8 Plus', '64GB', '150', '300', 'stable', 20, 40, 20, 20, 40),
(88, 'Electronics', 'Cell phone', 'Apple', 'Iphone X', '64GB', '200', '400', 'stable', 20, 40, 20, 20, 40),
(89, 'Electronics', 'Cell phone', 'Apple', 'Iphone 11 Pro Max', '64GB', '350', '700', 'stable', 20, 40, 20, 20, 40),
(90, 'Electronics', 'Cell phone', 'Samsung', 'Galaxy S21', '64GB', '400', '800', 'stable', 10, 20, 10, 10, 20),
(91, 'Electronics', 'Cell phone', 'Samsung', 'Galaxy A52', '128GB', '30', '60', 'stable', 10, 20, 10, 10, 20),
(92, 'Electronics', 'Cell phone', 'Xiaomi', 'Redmi Note 10', '64GB', '75', '150', 'stable', 40, 80, 40, 40, 80),
(93, 'Electronics', 'Cell phone', 'Xiaomi', 'Redmi Note 10 Pro', '128GB', '200', '400', 'stable', 10, 20, 10, 10, 20),
(94, 'Furniture', 'Mirror', 'Ikea', 'Nissedal', 'Wall mirror', '15', '30', 'stable', 20, 40, 20, 20, 40),
(95, 'Furniture', 'Mirror', 'Ikea', 'Lyndbin', 'Wall mirror', '20', '40', 'stable', 20, 40, 20, 20, 40),
(96, 'Furniture', 'Mirror', 'Ikea', 'Hovet', 'Wall mirror', '50', '100', 'stable', 5, 10, 5, 5, 10),
(97, 'Furniture', 'Lamp', 'Ikea', 'Ingared', 'None', '4', '8', 'stable', 50, 100, 50, 50, 100),
(98, 'Furniture', 'Lamp', 'Ikea', 'Lakafors', 'None', '8', '16', 'stable', 50, 100, 50, 50, 100),
(99, 'Furniture', 'Lamp', 'Ikea', 'Arstid', 'None', '10', '20', 'stable', 50, 100, 50, 50, 100),
(100, 'Furniture', 'Lamp', 'Ikea', 'Misterhult', 'Table lamp', '15', '30', 'stable', 15, 30, 15, 15, 30),
(101, 'Accessories', 'Cable', 'Amazon basics', 'None', 'USB-A to Lightning Cable', '5', '10', 'stable', 50, 100, 50, 50, 100),
(102, 'Accessories', 'Cable', 'Jsaux', 'None', 'USB-A to USB-C', '5', '10', 'stable', 50, 100, 50, 50, 100),
(103, 'Accessories', 'Cable', 'Okray', 'None', 'USB Extension, Male to female', '5', '10', 'stable', 50, 100, 50, 50, 100),
(104, 'Accessories', 'Cable', 'Freedom house', 'None', 'A10 Headsets Cord Audio Cable for Astro A40TR', '5', '10', 'stable', 50, 100, 50, 50, 100),
(105, 'Accessories', 'Cable', 'Jsaux', 'None', 'USB C to Lightning Cable', '5', '10', 'stable', 50, 100, 50, 50, 100),
(106, 'Accessories', 'Cable', 'DbillionDa', 'None', 'Ethernet Cable', '5', '10', 'stable', 50, 100, 50, 50, 100),
(107, 'Accessories', 'Printer', 'Canon', 'Pixma TS3320', 'None', '35', '70', 'stable', 10, 20, 10, 10, 20),
(108, 'Accessories', 'Printer', 'HP', 'ENVY 6055e', 'None', '40', '80', 'stable', 10, 20, 10, 10, 20),
(109, 'Accessories', 'Printer', 'Canon', 'TS6420', 'Wireless printer', '50', '100', 'stable', 5, 10, 5, 5, 10),
(110, 'Accessories', 'Printer', 'Canon', 'TR8620', 'None', '90', '180', 'stable', 5, 10, 5, 5, 10),
(111, 'Accessories', 'Printer', 'Pantum', 'M6552NW', 'Monochrome Multifunctional', '80', '160', 'stable', 5, 10, 5, 5, 10),
(112, 'Electronics', 'Speaker', 'Doss', 'None', 'Bluetooth Speaker', '20', '40', 'stable', 25, 50, 25, 25, 50),
(113, 'Electronics', 'Speaker', 'Zamkol', 'None', 'Portable Bluetooth Speaker', '20', '40', 'stable', 25, 50, 25, 25, 50),
(114, 'Electronics', 'Speaker', 'Campbridge soundworks', 'None', 'Bluetooth Speakers', '13', '26', 'stable', 25, 50, 25, 25, 50),
(115, 'Electronics', 'Speaker', 'Tamproad', 'None', 'Subwoofer, Rich Bass, Wireless', '20', '40', 'stable', 5, 10, 5, 5, 10),
(116, 'Electronics', 'Speaker', 'MusiBady', 'M88', 'Bluetooth Speaker', '25', '50', 'stable', 25, 50, 25, 25, 50),
(117, 'Electronics', 'Speaker', 'W-King', 'D8', 'Bluetooth Speaker', '40', '80', 'stable', 20, 40, 20, 20, 40),
(118, 'Electronics', 'Speaker', 'W-King', 'None', 'Bluetooth Speaker', '45', '90', 'stable', 20, 40, 20, 20, 40),
(119, 'Furniture', 'Sofa', 'Ikea', 'Uppland', 'None', '200', '400', 'stable', 5, 10, 5, 5, 10),
(120, 'Furniture', 'Sofa', 'Ikea', 'Karlstad', 'None', '200', '400', 'stable', 5, 10, 5, 5, 10),
(121, 'Furniture', 'Sofa', 'Ikea', 'Ektorp', 'None', '200', '400', 'stable', 5, 10, 5, 5, 10),
(122, 'Furniture', 'Sofa', 'Ikea', 'Kivik', 'None', '250', '500', 'stable', 5, 10, 5, 5, 10),
(123, 'Furniture', 'Sofa', 'Ikea', 'Finnala', 'None', '300', '600', 'stable', 5, 10, 5, 5, 10),
(124, 'Accessories', 'eBook', 'Amazon', 'Kindle Paperwhite', 'None', '15', '30', 'stable', 50, 100, 50, 50, 100),
(125, 'Accessories', 'eBook', 'Sutinna', 'None', '7 inch e-Book Reader', '40', '80', 'stable', 50, 100, 50, 50, 100),
(126, 'Accessories', 'eBook', 'Amazon', 'Rustic', 'Paperwhite Premium Leather Cover', '30', '60', 'stable', 20, 40, 20, 20, 40),
(127, 'Accessories', 'eBook', 'Kobo', 'Clara', 'None', '45', '90', 'stable', 20, 40, 20, 20, 40),
(128, 'Accessories', 'eBook', 'Kobo', 'Libra H20', 'None', '80', '160', 'stable', 5, 10, 5, 5, 10),
(129, 'Accessories', 'eBook', 'Amazon', 'Kindle Oasis', '8GB', '135', '270', 'stable', 20, 40, 20, 20, 40);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `items`
--
ALTER TABLE `items`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=130;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
