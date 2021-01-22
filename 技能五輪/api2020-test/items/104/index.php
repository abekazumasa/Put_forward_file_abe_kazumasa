<?php
$json = '{
	"id": 104,
	"photo": "https://th.bing.com/th/id/OIP.Z572sgxo32yuSDxfxxUDggHaE8?pid=Api&rs=1",
	"name": "ハンバーグカレー",
	"description": "みんな大好きハンバーグカレー",
	"price": 1100
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>