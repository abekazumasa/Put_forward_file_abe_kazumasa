<?php

$json = '{"id": 1,"title": "東海セントラルパレス", "title_e": "Tokai Central Palace", "address": "愛知県常滑市セントレア5丁目10番１号", "price": 34.800,"latitude": 34.856793,"longitude": 136.8192515}';

header("Content-Type:application/json; charset=utf-8", true);

echo($json);

?>