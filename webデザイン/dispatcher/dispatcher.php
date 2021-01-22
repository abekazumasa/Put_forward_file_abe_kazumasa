<?php
session_start();

$method = $_SERVER['REQUEST_METHOD'];

if($method=="POST"){

$_SESSION['yourname'] = $_POST['yourname'];
header("Location: post.php");

}else if($method=="GET"){

	if(isset($_GET['_method']) && $_GET['_method']== "PUT"){
	
	$_SESSION['yourname'] = $_GET['yourname'];
	$_SESSION['_method'] = $_GET['_method'];
	header("Location:put.php");
	
	}else if(isset($_GET['_method']) && $_GET['_method']== "DELETE"){
	$_SESSION['yourname'] = $_GET['yourname'];
	$_SESSION['_method'] = $_GET['_method'];
	header("Location:delete.php");
	}else{
	$_SESSION['yourname'] = $_GET['yourname'];
	header("Location:get.php");
	}
	
}
?>