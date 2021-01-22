<?php

$json = '{"id": 1,"title": "東海セントラルプレミアム", "title_e": "Tokai Central Premiun", "address": "愛知県名古屋市西区樋の口町3丁目-19号", "price": 78.800,"latitude": 35.1825504,"longitude": 136.8956348}';

header("Content-Type:application/json; charset=utf-8", true);

echo($json);

?>