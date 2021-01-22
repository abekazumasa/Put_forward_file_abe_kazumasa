-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- ホスト: 127.0.0.1
-- 生成日時: 
-- サーバのバージョン： 10.4.8-MariaDB
-- PHP のバージョン: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- データベース: `web2020`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `seminars`
--

CREATE TABLE `seminars` (
  `id` int(11) NOT NULL,
  `title` varchar(255) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- テーブルのデータのダンプ `seminars`
--

INSERT INTO `seminars` (`id`, `title`, `description`, `created_at`) VALUES
(1, 'おいしいカレーです', 'セシウム入りでちょっぴり熱々。', '2020-06-10 07:11:27'),
(2, '真夏向きの鍋物は', 'キムチなべに決まり。', '2020-06-18 07:14:40'),
(3, '夏とはいっても', 'カレーにあきたらおせちもね。', '2020-06-18 08:36:14'),
(4, '元ソーリ大臣にまかせなさい', 'いっぱつで水蒸気爆発。', '2020-06-19 07:16:07'),
(5, '山田教授ですがなにか', '文句ある？', '2020-07-10 17:16:07');

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `seminars`
--
ALTER TABLE `seminars`
  ADD PRIMARY KEY (`id`);

--
-- ダンプしたテーブルのAUTO_INCREMENT
--

--
-- テーブルのAUTO_INCREMENT `seminars`
--
ALTER TABLE `seminars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
