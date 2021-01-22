<?php
$json = '{
	"id": 108,
	"photo": "https://img.cpcdn.com/recipes/5819603/1200x630c/5a9830c039641e08437666260a64dd37?u=10939408&p=1568081194",
	"name": "鮭缶ときのこの炊き込みご飯",
	"description": "秋の味覚の炊き込みご飯",
	"price": 800
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>