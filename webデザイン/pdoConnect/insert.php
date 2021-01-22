<?php
$hostname_db1 ="localhost";
$database_db1 ="db1";
$username_db1 ="root";
$password_db1 ="";

if(!empty($_POST['title'])){
	try{
		$pdo = new PDO("mysql:host=$hostname_db1; dbname=$database_db1; charset=utf8",$username_db1,$password_db1);

	}catch(PDOException $e){

		exit("NO　Connected." .$e->getMessage());
	}

	$title = $_POST['title'];
	$doc = $_POST['description'];
 
	$sql= "INSERT INTO seminars (title,description) VALUES (:key1, :key2)";
	$stmt = $pdo->prepare($sql);
	$stmt->bindParam(":key1",$title);
	$stmt->bindParam(":key2",$doc);
	$stmt->execute();
}else{

	echo("何か入力してください");
}
?>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<title>PDO挿入</title>
<style type="text/css">

form{width: 400px; margin:30px 20px; padding: 10px; background-color: #A66; color:#FFF;}
form input{display: block; margin: 10px 0px}
</style>
</head>
<body>
<h1>PDO挿入</h1>
<a href ="index.php">TOPへ</a>
<div id="entry">
<div>
<form method="post" action="">
	Title: <input type="text" name="title" size="20">
	Document:<input type="text" name="description" size="40">
			<input type="submit" value="1件追加">
			<input type="reset" value="リセット">
</form>
</body>
</html>