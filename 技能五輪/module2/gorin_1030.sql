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
-- データベース: `gorin_1030`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `items`
--

CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `price` int(11) NOT NULL,
  `photo` varchar(255) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `items`
--

INSERT INTO `items` (`id`, `name`, `description`, `price`, `photo`, `created_at`, `updated_at`) VALUES
(4, '商品4', 'afafaf', 122, 'http://localhost:8000/images/shop.png', '2020-10-24 08:21:41', '2020-11-08 06:50:05'),
(5, '商品5', 'asfsdfafaf', 123, 'http://localhost:8000/images/shop.png', '2020-10-24 08:22:10', '2020-10-24 08:22:10'),
(6, '商品6', 'afafaf', 122, 'http://localhost:8000/images/shop.png', '2020-10-24 08:35:20', '2020-11-08 06:50:23'),
(7, '商品7', 'afafaf', 122, 'http://localhost:8000/images/shop.png', '2020-10-31 07:12:36', '2020-11-08 06:50:31'),
(9, '商品9', 'afafaf', 122, 'http://localhost:8000/images/shop.png', '2020-10-31 07:16:17', '2020-11-08 06:50:44'),
(10, '商品10', 'afafaf', 122, 'http://localhost:8000/images/shop.png', '2020-11-07 08:52:33', '2020-11-08 06:50:52'),
(11, '商品11', '商品説明だよ', 122, 'http://localhost:8000/images/shop.png', '2020-11-07 08:54:03', '2020-11-08 06:51:51');

-- --------------------------------------------------------

--
-- テーブルの構造 `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `item_quantity` int(11) NOT NULL,
  `shop_id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `number` varchar(255) NOT NULL,
  `zip_code` varchar(10) NOT NULL,
  `address` varchar(255) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `orders`
--

INSERT INTO `orders` (`id`, `item_quantity`, `shop_id`, `item_id`, `name`, `number`, `zip_code`, `address`, `created_at`, `updated_at`) VALUES
(1, 1, 1, 1, 'abc', '1234', '245', 'sffa', '2020-10-24 05:10:03', '2020-10-24 05:10:03'),
(2, 1, 1, 1, 'abc', '1234', '245', 'sffa', '2020-10-24 05:10:20', '2020-10-24 05:10:20'),
(3, 1, 1, 2, 'abc', '1234', '245', 'sffa', '2020-10-24 05:33:10', '2020-10-24 05:33:10'),
(4, 1, 1, 2, 'abc', '1234', '2440000', 'sffa', '2020-10-24 05:36:47', '2020-10-24 05:36:47'),
(5, 1, 1, 1, 'abc', '1234', '245', 'sffa', '2020-10-24 09:01:17', '2020-10-24 09:01:17');

-- --------------------------------------------------------

--
-- テーブルの構造 `shops`
--

CREATE TABLE `shops` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `photo` varchar(255) DEFAULT NULL,
  `opening_time` time NOT NULL,
  `closing_time` time NOT NULL,
  `price_range` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `shops`
--

INSERT INTO `shops` (`id`, `name`, `photo`, `opening_time`, `closing_time`, `price_range`, `created_at`, `updated_at`) VALUES
(1, '店舗456', 'http://localhost:8000/images/shop.png', '09:00:00', '11:00:00', 1100, NULL, '2020-11-13 08:05:46'),
(2, '店舗123', 'http://localhost:8000/images/shop.png', '09:00:00', '11:00:00', 1200, '2020-10-17 07:44:13', '2020-11-13 08:04:57'),
(3, '店舗678', 'http://localhost:8000/images/shop.png', '09:00:00', '15:00:00', 1300, '2020-10-24 07:06:09', '2020-11-13 08:06:32'),
(4, '店舗789', 'http://localhost:8000/images/shop.png', '09:00:00', '16:00:00', 1400, '2020-10-24 07:46:31', '2020-11-13 08:06:52'),
(5, '店舗890', 'http://localhost:8000/images/shop.png', '09:00:00', '17:00:00', 1500, '2020-10-24 07:47:21', '2020-11-13 08:07:16'),
(6, '店舗112', 'http://localhost:8000/images/shop.png', '09:00:00', '18:00:00', 1600, '2020-10-31 05:44:48', '2020-11-13 08:07:47'),
(7, '店舗24', 'http://localhost:8000/images/shop.png', '04:00:00', '21:00:00', 0, '2020-10-31 06:53:13', '2020-10-31 06:53:13'),
(8, '店舗11', 'http://localhost:8000/images/shop.png', '09:00:00', '21:00:00', 10000, '2020-11-07 06:21:11', '2020-11-07 06:21:11'),
(9, '店舗13', 'http://localhost:8000/images/shop.png', '09:00:00', '21:00:00', 20300, '2020-11-07 06:23:33', '2020-11-07 07:05:08');

-- --------------------------------------------------------

--
-- テーブルの構造 `shop_items`
--

CREATE TABLE `shop_items` (
  `shop_id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `shop_items`
--

INSERT INTO `shop_items` (`shop_id`, `item_id`) VALUES
(1, 1),
(1, 2),
(1, 2),
(1, 2),
(1, 2),
(2, 1),
(1, 3),
(6, 3),
(1, 4);

-- --------------------------------------------------------

--
-- テーブルの構造 `shop_users`
--

CREATE TABLE `shop_users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `api_token` varchar(255) DEFAULT NULL,
  `shop_id` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `shop_users`
--

INSERT INTO `shop_users` (`id`, `username`, `email`, `password`, `api_token`, `shop_id`, `created_at`, `updated_at`) VALUES
(1, 'sfgsf', 'test01@example.com', '$2y$10$4mYfqruIU95fizDNZF9yQOE8zmE0qrfVgkuM9UfKoZhsj6qhdumV2', NULL, 1, '2020-10-17 05:29:09', '2020-10-17 05:29:09'),
(2, 'sfafa', 'test02@example.com', '$2y$10$2FQPlqXfIl3/VY4t0IrYjOAFVF72/sxkamtmEJVbhVfKB1MztUKrS', 'LPZwC2yOjWsUTmsn9A9UdQ8g68jai9uTN4qe9IQUlRXP7WvdbphBeKujvdl9', 1, '2020-10-17 05:49:10', '2020-10-17 05:51:27'),
(3, 'abc', 'sdfsf', '$2y$10$4tb11TZTK/6mJXYNA2yk6euCGahlhDyKhCxMrDmx6zlfucwrDO3ha', 'u40CeeIev2fqzbF9m5Hdbd7oJGUhxOQSZXXnUwqmkEjCnrda55Z52loodMgl', 1, '2020-10-24 06:14:52', '2020-10-24 06:38:53'),
(4, 'defg', 'sdfeddv@fsf.com', '$2y$10$qztkbBnkgo5UXYeMmZajG.YSmurFecuCQFTPB3guN2sHLUHy.Y/Ii', 'sJKVLKnr3Db1HDHwieZQVN4wpHxViwFYb6Tbvu8quP250IQr2yaSpadKe3qj', 1, '2020-10-24 06:25:32', '2020-10-24 06:38:21'),
(5, '田中太郎', 'abcd@example.com', '$2y$10$2vaFAt1qwemB1rqUEnsn.Ou2KSRV2HtZ7CWmDJOP2RP3SFhAkYIYu', NULL, 1, '2020-10-30 01:40:35', '2020-10-30 01:40:35'),
(6, '太郎太郎', 'test3@example.com', '$2y$10$MEhOxr0NTX88ZLJfbAbRe.4qvwBoFsWkZXeI12T.J6I8KIPE43Gma', 'YI3j7vxkjvqRSvhVV9zN9m4KtkDZa4XIiJs0OpalFqP3CbwSs64ygpxrqgwN', 1, '2020-10-30 01:53:58', '2020-10-31 04:07:45'),
(7, '鼻先太郎', 'test4@example.com', '$2y$10$0Kyq/QDarr6IdJE8loQKHOHiiXPY65MhfbHAnUg1ByGSkFiLGowgG', '6E4AYrXNtg3kUJgi6vPMs2IknvyDpJICEr5P4jvMznvEnin6jFAKpDufjHr3', 1, '2020-10-31 04:49:38', '2020-10-31 05:08:13'),
(8, 'username1', 'test05@example.com', '$2y$10$ISrO8aigN73LYMYwO8UKKOuluSOiBeGMT9Zp2sB82/X9tFbiAkIVm', 'T8InyBROZ5KWI5XQ8rsHrIWFM6DArY7TqKfoUF4GgTSS6CSIoMSDBmBM1TZ7', 1, '2020-11-07 05:14:43', '2020-11-07 05:33:22');

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- テーブルのインデックス `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`);

--
-- テーブルのインデックス `shops`
--
ALTER TABLE `shops`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- テーブルのインデックス `shop_users`
--
ALTER TABLE `shop_users`
  ADD PRIMARY KEY (`id`);

--
-- ダンプしたテーブルのAUTO_INCREMENT
--

--
-- テーブルのAUTO_INCREMENT `items`
--
ALTER TABLE `items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- テーブルのAUTO_INCREMENT `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- テーブルのAUTO_INCREMENT `shops`
--
ALTER TABLE `shops`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- テーブルのAUTO_INCREMENT `shop_users`
--
ALTER TABLE `shop_users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
