-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Aug 27, 2021 at 02:02 PM
-- Server version: 10.3.24-MariaDB-cll-lve
-- PHP Version: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `u30186p23947_waddoo`
--
CREATE DATABASE IF NOT EXISTS `u30186p23947_waddoo` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `u30186p23947_waddoo`;

-- --------------------------------------------------------

--
-- Table structure for table `game`
--

CREATE TABLE `game` (
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `game`
--

INSERT INTO `game` (`id`) VALUES
(0);

-- --------------------------------------------------------

--
-- Table structure for table `score`
--

CREATE TABLE `score` (
  `id` int(11) NOT NULL,
  `game_id` int(11) NOT NULL DEFAULT 0,
  `player_id` int(11) NOT NULL,
  `score` int(11) NOT NULL,
  `extraversion` int(11) NOT NULL DEFAULT 0,
  `stability` int(11) NOT NULL DEFAULT 0,
  `conscientiousness` int(11) NOT NULL,
  `openness` int(11) NOT NULL,
  `agreeableness` int(11) NOT NULL,
  `score_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `score`
--

INSERT INTO `score` (`id`, `game_id`, `player_id`, `score`, `extraversion`, `stability`, `conscientiousness`, `openness`, `agreeableness`, `score_date`) VALUES
(1, 0, 0, 12, 3, 4, 2, -4, 3, '2021-03-03'),
(13, 0, 0, 32, 0, 0, 0, 0, 0, '2021-04-21'),
(14, 0, 0, 3, 0, 0, 0, 0, 0, '2021-04-21'),
(15, 0, 0, 1337, 0, 0, 0, 0, 0, '2021-04-21'),
(16, 0, 0, 123, 0, 0, 0, 0, 0, '2021-05-14'),
(17, 0, 0, 23, 0, 0, 0, 0, 0, '2021-05-14'),
(18, 0, 0, 3, 0, 0, 0, 0, 0, '2021-06-08'),
(19, 0, 0, 23, 0, 0, 0, 0, 0, '2021-06-08'),
(26, 0, 10, 123, 0, 0, 0, 0, 0, '2021-06-08'),
(27, 0, 10, 0, 0, 0, 0, 0, 0, '2021-06-08'),
(28, 0, 10, 1, 0, 0, 0, 0, 0, '2021-07-13'),
(86, 0, 0, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(87, 0, 0, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(88, 0, 0, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(89, 0, 11, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(90, 0, 11, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(91, 0, 13, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(92, 0, 13, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(93, 0, 11, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(94, 0, 11, 0, 0, 0, 0, 0, 0, '2021-08-27'),
(95, 0, 11, 1, 0, 0, 0, 0, 0, '2021-08-27'),
(96, 0, 14, 2, 0, 0, 0, 0, 0, '2021-08-27');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `email` varchar(254) CHARACTER SET utf8 NOT NULL,
  `password` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `password`) VALUES
(0, 'Ultragamer123', '', '$2y$10$vn6gHZ1KjL0gt6sTk5mgCuwJu9RUJXq/Y6gDRMllU8I0v63wgy2a.'),
(10, 'Dream', '', '$2y$10$sO88Rwmr1WD2rza5a6GFWO9So7AZqxOA1fMX8R6r9zUm9MUjlo5Ve'),
(11, 'TheDoctor', '', '$2y$10$SzHRHvqKkg6GXhZAwfB/2uguYQ5UT1eBXDy5qV3xftP22fkqdO8ea'),
(12, 'TomDeBeste', '', '$2y$10$BuIl6pDT4h7/W/SZjIYvm.PlqdkxFlsW8hOw4d7YFHb211PzI6aCW'),
(13, 'Karel15', '', '$2y$10$P.97QlX5y7qEtmDeVntgI.noa8hmf6L.Dip1XBAl4CE3Zv/td2VeG'),
(14, 'BanaanSmoothie23', '', '$2y$10$znrRUsTeFxaTg7f3UzbngOQpChxSBzr8jatibBKJrxh5MfZx34gii');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `game`
--
ALTER TABLE `game`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `score`
--
ALTER TABLE `score`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD KEY `player_id` (`player_id`),
  ADD KEY `game_id` (`game_id`) USING BTREE;

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `score`
--
ALTER TABLE `score`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=97;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `score`
--
ALTER TABLE `score`
  ADD CONSTRAINT `game_id` FOREIGN KEY (`game_id`) REFERENCES `game` (`id`),
  ADD CONSTRAINT `player_id` FOREIGN KEY (`player_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
