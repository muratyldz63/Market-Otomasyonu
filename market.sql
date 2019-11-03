-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 22 Eyl 2018, 19:36:31
-- Sunucu sürümü: 10.1.34-MariaDB
-- PHP Sürümü: 7.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `market`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `username` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `password` varchar(20) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`id`, `username`, `password`) VALUES
(1, 'murat', '123456');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `gecmis`
--

CREATE TABLE `gecmis` (
  `id` int(11) NOT NULL,
  `urun_adi` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `barkod_no` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `fiyat` varchar(10) COLLATE utf8_turkish_ci NOT NULL,
  `tarih` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `saat` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `personel_ad` varchar(30) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `gecmis`
--

INSERT INTO `gecmis` (`id`, `urun_adi`, `barkod_no`, `fiyat`, `tarih`, `saat`, `personel_ad`) VALUES
(20, 'kola', '1', '1,50', '24 Agustos 2018 Cuma', '19:28:04', 'murat'),
(21, 'kola', '1', '1,50', '30 Agustos 2018 Cuma', '19:28:22', 'murat'),
(23, 'gazo-nuri alço', '2', '2,85', '25 Agustos 2018 Cuma', '19:29:00', 'murat'),
(24, 'kola', '1', '1,51', '6 Eylül 2018 Persemb', '14:46:23', 'murat'),
(25, 'kola', '1', '1,51', '6 Eylül 2018 Persemb', '14:46:28', 'murat');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `personel`
--

CREATE TABLE `personel` (
  `id` int(11) NOT NULL,
  `username` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `password` varchar(20) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `personel`
--

INSERT INTO `personel` (`id`, `username`, `password`) VALUES
(10, 'murat', '123456');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun`
--

CREATE TABLE `urun` (
  `urun_id` int(11) NOT NULL,
  `urun_adi` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `kat_ad` varchar(30) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `urun`
--

INSERT INTO `urun` (`urun_id`, `urun_adi`, `kat_ad`) VALUES
(3, 'KOLA 2.5 TL', 'ICECEKLER'),
(4, 'karpuz', 'MERVE-SEBZE'),
(5, 'yumurta', 'ET-BALIK-KUMES'),
(6, 'süt', 'SUT-KAHVALTILIK'),
(7, 'kabak', 'EV-PET'),
(8, 'dido', 'GIDA-SEKERLEME'),
(9, 'kasar', 'DETERJAN-TEMIZLIK'),
(10, 'a4', 'KAGIT-KOZMETIK'),
(11, 'bebiş', 'BEBEK-OYUNCAK');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

CREATE TABLE `urunler` (
  `id` int(11) NOT NULL,
  `urun_adi` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `barkod_no` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `fiyat` varchar(10) COLLATE utf8_turkish_ci NOT NULL,
  `stok` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `urunler`
--

INSERT INTO `urunler` (`id`, `urun_adi`, `barkod_no`, `fiyat`, `stok`) VALUES
(59, 'kola', '1', '1,51', 96),
(60, 'gazo-nuri alço', '2', '2,85', 100),
(61, 'karpuz', '3', '3.15', 70);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `gecmis`
--
ALTER TABLE `gecmis`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `personel`
--
ALTER TABLE `personel`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `urun`
--
ALTER TABLE `urun`
  ADD PRIMARY KEY (`urun_id`);

--
-- Tablo için indeksler `urunler`
--
ALTER TABLE `urunler`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `gecmis`
--
ALTER TABLE `gecmis`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Tablo için AUTO_INCREMENT değeri `personel`
--
ALTER TABLE `personel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tablo için AUTO_INCREMENT değeri `urun`
--
ALTER TABLE `urun`
  MODIFY `urun_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Tablo için AUTO_INCREMENT değeri `urunler`
--
ALTER TABLE `urunler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
