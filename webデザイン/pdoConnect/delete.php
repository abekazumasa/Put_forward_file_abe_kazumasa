<?php
$hostname_db1 ="localhost";
$database_db1 ="db1";
$username_db1 ="root";
$password_db1 ="";

if(!empty($_GET['id'])){
	try{
		$pdo = new PDO("mysql:host=$hostname_db1; dbname=$database_db1; charset=utf8",$username_db1,$password_db1);

	}catch(PDOException $e){

		exit("NO　Connected." .$e->getMessage());
	}

	$id = $_GET['id'];
	
	$sql= "DELETE FROM seminars WHERE id = :key";
	$stmt = $pdo->prepare($sql);
	$stmt->bindParam(":key", $id);
	$stmt->execute();
	
	header("Location:" .$_SERVER['HTTP_REFERER']);
	
}else{}
?>