<?php

$json = '{"id": 1,"title": "東海コンチネンタル旅の湯", "title_e": "Tabi Ryokan Tokai", "address": "愛知県海部郡飛島村", "price": 175.300,"latitude": 35.0068663,"longitude": 136.8020497}';

header("Content-Type:application/json; charset=utf-8", true);

echo($json);

?>