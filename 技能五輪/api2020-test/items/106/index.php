<?php
$json = '{
	"id": 106,
	"photo": "https://cdn.r-corona.jp/prd.rb.r-corona.jp/assets/site_files/7viv5ipn/654413/b9mj.jpg",
	"name": "創作炙り寿司コース",
	"description": "炙りの好きな方に絶品のコース",
	"price": 5000
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>