<?php
$json = '{
	"id": 107,
	"photo": "https://kumiko-jp.com/wp-content/uploads/2018/06/3P9A7568.jpg",
	"name": "いわしの缶詰丼",
	"description": "卵でとじたいわし丼",
	"price": 1300
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>