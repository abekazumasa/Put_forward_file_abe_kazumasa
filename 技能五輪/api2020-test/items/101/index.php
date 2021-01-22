<?php
$json = '{
	"id": 101,
	"photo": "https://photo-pot.com/wp/wp-content/uploads/2011/07/pan7.jpg",
	"name": "クロワッサン",
	"description": "出来立てほやほやのクロワッサン",
	"price": 230
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>