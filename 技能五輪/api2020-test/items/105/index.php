<?php
$json = '{
	"id": 105,
	"photo": "https://rimage.gnst.jp/rest/img/3j3uc9rc0000/s_0n6e.jpg?t=1575264323",
	"name": "おまかせ寿司コース",
	"description": "大将のおすすめコース",
	"price": 5500
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>