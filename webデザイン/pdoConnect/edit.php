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
	
	$sql= "SELECT *FROM seminars WHERE id = :key";
	$stmt = $pdo->prepare($sql);
	$stmt->bindParam(":key", $id, PDO::PARAM_STR);
	$stmt->execute();
	
	while($row = $stmt->fetch(PDO::FETCH_ASSOC)){
	
		$edit_id = $row['id'];
		$edit_title = $row['title'];
		$edit_doc = $row['description'];
	}
	if(isset($_GET['id'])&&!empty($_GET['title'])){
	
		$id = $_GET['id'];
		$title = $_GET['title'];
		$doc = $_GET['description'];
	
		$sql2 = "UPDATE seminars SET title= :key1, description= :key2 WHERE id= :key_id";
		$stmt2 = $pdo->prepare($sql2);
		$stmt2->bindParam(":key_id",$id,PDO::PARAM_INT);
		$stmt2->bindParam(":key1",$title,PDO::PARAM_STR);
		$stmt2->bindParam(":key2",$doc,PDO::PARAM_STR);
		$edit_ok = $stmt2->execute();
	if($edit_ok){
		header("Location:index.php");
		}
	}
}else{
	echo("NO POST");
}
?>
<!DOCTYPE html>
<html>
<head>
<meta charset = "utf-8">
<title>PDO 編集</title>
<style type="text/css">
	form{width: 400px; margin:30px; padding: 10px; background-color: #A66; color:#FFF;}
</style>
</head>
<body>
	<h1>PDO 編集</h1>
	<div id="entry">
		<div>
			<form method="get" action="">
				ID:		<?php echo($edit_id);?><br>
				Title:	<input type="text" name="title" size="20" value="<?php echo($edit_title);?>"><br>
	Doc:	<input type="text" name="description" size="40" value="<?php echo($edit_doc);?>"><br>
			<input type="hidden" name="id" value="<?php echo($edit_id);?>">
			<input type="submit" value="編集">
			<input type="reset" value="リセット">
			</form>
		</div>
</body>
</html>