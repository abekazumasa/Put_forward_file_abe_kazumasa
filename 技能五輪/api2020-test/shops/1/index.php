<?php
$json = '
	{"id": 1,
	"photo": "https://static.wixstatic.com/media/ee0c43_33c188b0f7544992a5bb2730b7951d35~mv2.jpg",
	"name": "東海パン",
	"opening_time": "7:00",
	"closing_time": "19:00",
	"price_range": 1000,
	"items": [
			{
				"id": 101,
				"photo": "https://photo-pot.com/wp/wp-content/uploads/2011/07/pan7.jpg",
				"name": "クロワッサン",
				"description": "出来立てほやほやのクロワッサン",
				"price": 230
			},
			{
				"id": 102,
				"photo": "http://kanmae.com/wp-content/uploads/2017/04/%E3%83%A1%E3%83%AD%E3%83%B3%E3%83%87%E3%83%A1%E3%83%AD%E3%83%B3.jpg",
				"name": "メロンパン",
				"description": "甘くておいしいメロンパン",
				"price": 190
			}
		]
}';



header("Content-Type:application/json; charset=utf-8", true);

echo($json);

?>