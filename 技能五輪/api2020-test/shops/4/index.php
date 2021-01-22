<?php
$json = '
	{"id": 4,
	"photo": "https://image.enuchi.jp/upload/20190314/images/iwashi_1.jpg",
	"name": "旅の湯の缶詰販売",
	"opening_time": "9:00",
	"closing_time": "24:00",
	"price_range": 1100,
	"items": [
		{
      "id": 107,
      "photo": "https://kumiko-jp.com/wp-content/uploads/2018/06/3P9A7568.jpg",
      "name": "いわしの缶詰丼",
      "description": "卵でとじたいわし丼",
      "price": 1300
		},
		{
      "id": 108,
      "photo": "https://img.cpcdn.com/recipes/5819603/1200x630c/5a9830c039641e08437666260a64dd37?u=10939408&p=1568081194",
      "name": "鮭缶ときのこの炊き込みご飯",
      "description": "秋の味覚の炊き込みご飯",
      "price": 800
    }
	]
}';



header("Content-Type:application/json; charset=utf-8", true);

echo($json);

?>