<?php
$json = '{
	"id": 103,
	"photo": "https://housefoods.jp/_sys/catimages/recipe/hfrecipe/items/00018280/0.jpeg",
	"name": "カツカレー",
	"description": "サクサク触感のカツカレー",
	"price": 1200
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>