-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Май 07 2026 г., 19:44
-- Версия сервера: 5.7.24
-- Версия PHP: 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `netflix`
--

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `ClientID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `RegistrationDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Структура таблицы `films`
--

CREATE TABLE `films` (
  `FilmID` int(11) NOT NULL,
  `Title` varchar(200) NOT NULL,
  `Director` varchar(100) DEFAULT NULL,
  `Genre` varchar(50) DEFAULT NULL,
  `ReleaseYear` int(11) DEFAULT NULL,
  `Duration` int(11) DEFAULT NULL,
  `Rating` decimal(3,1) DEFAULT NULL,
  `TotalCopies` int(11) DEFAULT '1',
  `AvailableCopies` int(11) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Структура таблицы `librarians`
--

CREATE TABLE `librarians` (
  `LibrarianID` int(11) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Login` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `HireDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Структура таблицы `rentaljournal`
--

CREATE TABLE `rentaljournal` (
  `RentalID` int(11) NOT NULL,
  `FilmID` int(11) NOT NULL,
  `ClientID` int(11) NOT NULL,
  `LibrarianID` int(11) NOT NULL,
  `RentalDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `ReturnDate` datetime DEFAULT NULL,
  `DueDate` datetime NOT NULL,
  `Status` varchar(20) DEFAULT 'Выдано'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`ClientID`);

--
-- Индексы таблицы `films`
--
ALTER TABLE `films`
  ADD PRIMARY KEY (`FilmID`);

--
-- Индексы таблицы `librarians`
--
ALTER TABLE `librarians`
  ADD PRIMARY KEY (`LibrarianID`),
  ADD UNIQUE KEY `Login` (`Login`);

--
-- Индексы таблицы `rentaljournal`
--
ALTER TABLE `rentaljournal`
  ADD PRIMARY KEY (`RentalID`),
  ADD KEY `FilmID` (`FilmID`),
  ADD KEY `ClientID` (`ClientID`),
  ADD KEY `LibrarianID` (`LibrarianID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `clients`
--
ALTER TABLE `clients`
  MODIFY `ClientID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `films`
--
ALTER TABLE `films`
  MODIFY `FilmID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `librarians`
--
ALTER TABLE `librarians`
  MODIFY `LibrarianID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `rentaljournal`
--
ALTER TABLE `rentaljournal`
  MODIFY `RentalID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `rentaljournal`
--
ALTER TABLE `rentaljournal`
  ADD CONSTRAINT `rentaljournal_ibfk_1` FOREIGN KEY (`FilmID`) REFERENCES `films` (`FilmID`) ON DELETE CASCADE,
  ADD CONSTRAINT `rentaljournal_ibfk_2` FOREIGN KEY (`ClientID`) REFERENCES `clients` (`ClientID`) ON DELETE CASCADE,
  ADD CONSTRAINT `rentaljournal_ibfk_3` FOREIGN KEY (`LibrarianID`) REFERENCES `librarians` (`LibrarianID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
