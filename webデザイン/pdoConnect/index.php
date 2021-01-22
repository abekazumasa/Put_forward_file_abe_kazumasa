<?php
$hostname_db1 ="localhost";
$database_db1 ="db1";
$username_db1 ="root";
$password_db1 ="";

	try{
		$pdo = new PDO("mysql:host=$hostname_db1; dbname=$database_db1; charset=utf8",$username_db1,$password_db1);

	}catch(PDOException $e){

		exit("NO　Connected." .$e->getMessage());
	}
	
	$sql ="SELECT * FROM seminars";
	$stmt = $pdo->prepare($sql);
	$stmt->execute();
	
	$result ="<table id=\"all_list\">";
	while($row = $stmt->fetch()){
	$result .="<tr><td><a href=\"delete.php?id=" . $row['id'] . "\">" . $row['id']  . "</a></td><td>" . $row['title'] . "</td><td>" . $row['description'] . "</td><td><a href=\"edit.php?id=" . $row['id'] . "\">" . "編集" . "</a></td></tr>";
	}
	$result .="</table>";
	$count = $stmt->rowCount();
?>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<title>PDO接続</title>
<style type="text/css">
	#all_list{width: 70%; border:2px solid #333; background-color: #FFE; border-collapse:collapse;}
	#all_list tr td{border:2px solid #333; padding:8px;}
	form{width: 400px; margin:30px; padding: 10px; background-color: #A66; color:#FFF;}
</style>
</head>
<body>
<h1>レコードの一覧</h1>
<a href="insert.php">追加する</a>
<div id="entry">
<?php

echo($result);
echo("残りは" . $count . "件です。");

?>
<div>
</body>
</html>