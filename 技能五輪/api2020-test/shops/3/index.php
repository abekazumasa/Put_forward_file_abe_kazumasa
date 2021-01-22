<?php
$json = '
	{"id": 3,
	"photo": "http://www.jc-km.net/wp-content/uploads/2016/04/sushi02.jpg",
	"name": "セントレア寿司",
	"opening_time": "11:00",
	"closing_time": "21:00",
	"price_range": 5000,
	"items": [
			{
				"id": 105,
				"photo": "https://rimage.gnst.jp/rest/img/3j3uc9rc0000/s_0n6e.jpg?t=1575264323",
				"name": "おまかせ寿司コース",
				"description": "大将のおすすめコース",
				"price": 5500
			},
			{
				"id": 106,
				"photo": "https://cdn.r-corona.jp/prd.rb.r-corona.jp/assets/site_files/7viv5ipn/654413/b9mj.jpg",
				"name": "創作炙り寿司コース",
				"description": "炙りの好きな方に絶品のコース",
				"price": 5000
			}
		]
}';


header("Content-Type:application/json; charset=utf-8", true);

echo($json);

?>