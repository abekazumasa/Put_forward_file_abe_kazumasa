<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<title>dispatcher</title>
<style type="text/css">
	form{
		border:1px solid #555;
		padding: 20px;
		margin: 10px;
		width: 70%;
	}
	form[method="put"], form[method="delete"]{
		border:1px solid #F55;
		background-color: #FFF5F5;
		
	}
	#put, #delete{
		border:1px solid #0F0;
		background-color: #F5FFF5;
	}
	
</style>
</head>
<body>
<form method="get" action="dispatcher.php">
	<input type="text" name="yourname" value="Test 1. get.">
	<input type="reset">
	<input type="submit">
</form>

<form method="post" action="dispatcher.php">
	<input type="text" name="yourname" value="Test 2. post.">
	<input type="reset">
	<input type="submit">
</form>

<form method="put" action="dispatcher.php">
	<input type="text" name="yourname" value="Test 3. put.">
	<input type="reset">
	<input type="submit">
</form>

<form method="delete" action="dispatcher.php">
	<input type="text" name="yourname" value="Test 4. delete.">
	<input type="reset">
	<input type="submit">
</form>

<!-------------------------------------------------------------->
<form method="put" action="dispatcher.php" id="put">
	<input type="text" name="yourname" value="Test 5. put.">
	<input type="hidden" name="_method" value="PUT">
	<input type="reset">
	<input type="submit">
</form>

<form method="delete" action="dispatcher.php" id="delete">
	<input type="text" name="yourname" value="Test 6. delete.">
	<input type="hidden" name="_method" value="DELETE">
	<input type="reset">
	<input type="submit">
</form>
</body>
</html>