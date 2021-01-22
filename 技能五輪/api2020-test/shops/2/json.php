<?php

$json = '{"id": 1,"title": "東海セントラルイン", "title_e": "Tokai Central Inn", "address": "愛知県名古屋市中村区名駅3丁目14-1号", "price": 5.500,"latitude": 34.856793,"longitude": 136.8192515}';

header("Content-Type:application/json; charset=utf-8", true);

echo($json);

?>