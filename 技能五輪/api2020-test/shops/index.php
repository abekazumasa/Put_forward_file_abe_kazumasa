<?php
$json_arr = array();
$json_arr[0] = '{"id": 1,"photo": "https://static.wixstatic.com/media/ee0c43_33c188b0f7544992a5bb2730b7951d35~mv2.jpg","name": "東海パン", "opening_time": "7:00", "closing_time": "19:00","price_range": 1000},';

$json_arr[1] = '{"id": 2,"photo": "http://livedoor.blogimg.jp/woowoo777-kuikui/imgs/8/c/8c2403c8.jpg","name": "セントラルカレー", "opening_time": "11:00", "closing_time": "22:00","price_range": 1200},';

$json_arr[2] = '{"id": 3,"photo": "http://www.jc-km.net/wp-content/uploads/2016/04/sushi02.jpg","name": "セントレア寿司", "opening_time": "11:00", "closing_time": "21:00","price_range": 5000},';

$json_arr[3] = '{"id": 4,"photo": "https://image.enuchi.jp/upload/20190314/images/iwashi_1.jpg","name": "旅の湯の缶詰販", "opening_time": "9:00", "closing_time": "24:00","price_range": 1100}';


$login    = "user01";
$password = "passwd01";
$token    = "a8414fd8704811e8a360cbcc29616d17";

if($_SERVER['REQUEST_METHOD'] == "POST") {

	//	$_POST['login']    = "user01";
	//	$_POST['password'] = "passwd01";
	//	$_POST['token']    = "a8414fd8704811e8a360cbcc29616d17";

	/*
	if(($token == $_POST['token']) && ($login == $_POST['login]) && ($password == $_POST['password])){
		// ----------------------------------- 
		// ログイン・トークン使用時の処理はここに
		// ----------------------------------- 
	} else {
		// ユーザID、パスワード、トークンの値が不正な場合の処理 -------------------------
		//	header("Content-Type:application/json; charset=utf-8", true);
		//	echo('{"status": "login failed"}');
	};
		// ----------------------------------------------------------------------
	*/

	$name    = $_POST['name'];
	$address  = $_POST['address'];
	$posted_json = '{"id": 10,"name": "' . $name . '","' . "address" . '": "' . $address . '","latitude": "36.0' . mt_rand(0,99) . '","longitude": "136.0' . mt_rand(0,99) . '", "created_at": "2019-07-25 10:00:00"}';
	header("Content-Type:application/json; charset=utf-8", true);
	echo("[");
	echo($posted_json);
	echo("]");
} else {
	header("Content-Type:application/json; charset=utf-8", true);
	echo("[");
	foreach($json_arr as $data){
		echo($data);
	}
	echo("]");
}
?>