<?php
$json = '
	{"id": 2,
	"photo": "http://livedoor.blogimg.jp/woowoo777-kuikui/imgs/8/c/8c2403c8.jpg",
	"name": "セントラルカレー",
	"opening_time": "11:00",
	"closing_time": "22:00",
	"price_range": 1200,
	"items": [
			{
				"id": 103,
				"photo": "https://housefoods.jp/_sys/catimages/recipe/hfrecipe/items/00018280/0.jpeg",
				"name": "カツカレー",
				"description": "サクサク触感のカツカレー",
				"price": 1200
			},
			{
				"id": 104,
				"photo": "https://th.bing.com/th/id/OIP.Z572sgxo32yuSDxfxxUDggHaE8?pid=Api&rs=1",
				"name": "ハンバーグカレー",
				"description": "みんな大好きハンバーグカレー",
				"price": 1100
			}
		]
}';


header("Content-Type:application/json; charset=utf-8", true);

echo($json);

?>