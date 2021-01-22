<?php
$json = '{
	"id": 102,
	"photo": "http://kanmae.com/wp-content/uploads/2017/04/%E3%83%A1%E3%83%AD%E3%83%B3%E3%83%87%E3%83%A1%E3%83%AD%E3%83%B3.jpg",
	"name": "メロンパン",
	"description": "甘くておいしいメロンパン",
	"price": 190
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>