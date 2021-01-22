<?php
session_start();

// -------------------------------------------------
$login    = array("palace@skilljapan.info", "inn@skilljapan.info", "premium@skilljapan.info", "user01@skilljapan.info", "user02@skilljapan.info",  "user03@skilljapan.info");
$password = array("staff01", "staff02", "staff03", "password01", "password02", "password03");

$token    = "a8414fd8704811e8a360cbcc29616d17";
// -------------------------------------------------



if($_SERVER['REQUEST_METHOD'] == "POST") {
	/*
	$_POST['login']    = "user01@skilljapan.info";
	$_POST['password'] = "password01";
	*/
	$_POST['token']    = "a8414fd8704811e8a360cbcc29616d17";
	
	
	if(($token == $_POST['token']) && ($login[3] == $_POST['login']) && ($password[3] == $_POST['password'])){
		// ----------------------------------- 
		// ログイン・トークン使用時の処理はここに記す
		// ----------------------------------- 
		
		$login = '{"status": "success",' . '"token": "' . $token . '"}';
		header("Content-Type:application/json; charset=utf-8", true);
		echo($login);
		
	} else {
		// ユーザID、パスワードの値が不正な場合の処理 -----------------------
			header("Content-Type:application/json; charset=utf-8", true);
			echo('{"status":"login failed"}');
	}
	
} else {
	header("Content-Type:application/json; charset=utf-8", true);
	echo('{"status": "failure"}');
}

?>