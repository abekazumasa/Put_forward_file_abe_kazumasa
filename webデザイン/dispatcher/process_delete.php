<?php
session_start();
$yourname =$_SESSION['yourname'];
$method = $_SESSION['_method'];
echo($yourname ."<hr>");
echo("_Method=" .$method ."<hr>");

echo("HTTP Herader=" .$_SERVER['REQUEST_METHOD']);

?>