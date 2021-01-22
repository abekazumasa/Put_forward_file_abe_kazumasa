<?php
$json_arr = array();
$json_arr[0] = '{"id": 1,"name": "東海パン", "address": "愛知県常滑市セントレア5丁目10番１号", "price": 300,"latitude": 34.856793,"longitude": 136.8192515},';

$json_arr[1] = '{"id": 2,"name": "セントラルカレー", "address": "〒450-0002 愛知県名古屋市中村区名駅3丁目14-1号", "price": 500,"latitude": 136.8824129,"longitude": 136.8192515},';

$json_arr[2] = '{"id": 3,"name": "セントレア寿司", "address": "〒451-0034 愛知県名古屋市西区樋の口町3丁目-19", "price": 20000,"latitude": 35.1825504,"longitude": 136.8956348},';

$json_arr[3] = '{"id": 4,"name": "旅の湯の缶詰販", "address": "愛知県海部郡飛島村", "price": 200,"latitude": 35.0068663,"longitude": 136.8020497}';

header("Content-Type:application/json; charset=utf-8", true);
echo("[");
foreach($json_arr as $data){
	echo($data);
}
echo("]");
?>