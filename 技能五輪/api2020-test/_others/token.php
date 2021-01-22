<?php
$json_arr = array();
$json_arr[0] = '{"id": 1,"title": "恩納なべの万座毛","content": "1万人上に乗っても大丈夫。","latitude": "36.575298","longitude": 136.602973, "created_at": "2019-06-25 10:00:00"},';
$json_arr[1] = '{"id": 2,"title": "カンジャガー","content": "古くから産井（ウブガー）として地元の人々が生活の中で利用してきた石造りの井戸。","latitude": 35.4709476,"longitude": 139.5872329, "created_at": "2019-06-30 10:00:00"},';
$json_arr[2] = '{"id": 3,"title": "神アシャギ ","content": "琉球王府時代の恩納間切の中心地で恩納番所があった","latitude": 35.6882075,"longitude": 139.6898791, "created_at": "2019-07-05 12:30:00"},';
$json_arr[3] = '{"id": 7,"title": "首里の王府","content": "琉球王国の統治組織で地方には間切(まぎり)とよばれる行政単位ごとに番所という役所が置かれた。","latitude": 35.6882075,"longitude": 139.6898791, "created_at": "2019-07-10 10:00:00"}';


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

	$title    = $_POST['title'];
	$content  = $_POST['content'];
	$posted_json = '{"id": 10,"title": "' . $title . '","' . $content . '": "Dummy content","latitude": "36.0' . mt_rand(0,99) . '","longitude": "136.0' . mt_rand(0,99) . '", "created_at": "2019-07-25 10:00:00"}';
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