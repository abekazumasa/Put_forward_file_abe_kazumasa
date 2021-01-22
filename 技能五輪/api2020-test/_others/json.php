<?php
$json_arr = array();
$json_arr[0] = '{"id": 1,"title": "東海セントラルパレス", "title_e": "Tokai Central Palace", "address": "愛知県常滑市セントレア5丁目10番１号", "price": 34.800,"latitude": 34.856793,"longitude": 136.8192515},';

$json_arr[1] = '{"id": 1,"title": "東海セントラルイン", "title_e": "Tokai Central Inn", "address": "〒450-0002 愛知県名古屋市中村区名駅3丁目14-1号", "price": 5.500,"latitude": 136.8824129,"longitude": 136.8192515},';

$json_arr[2] = '{"id": 1,"title": "東海セントラルプレミアム", "title_e": "Tokai Central Premiun", "address": "〒451-0034 愛知県名古屋市西区樋の口町3丁目-19", "price": 78.800,"latitude": 35.1825504,"longitude": 136.8956348},';

$json_arr[3] = '{"id": 1,"title": "東海コンチネンタル旅の湯", "title_e": "Tokai Central Palace", "address": "愛知県海部郡飛島村", "price": 175.300,"latitude": 35.0068663,"longitude": 136.8020497}';

header("Content-Type:application/json; charset=utf-8", true);
echo("[");
foreach($json_arr as $data){
	echo($data);
}
echo("]");
?>