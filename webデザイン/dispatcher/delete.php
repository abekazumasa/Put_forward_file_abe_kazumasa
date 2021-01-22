<?php

session_start();
$yourname = $_SESSION['yourname'];
header("Location:process_delete.php");
?>
<h1>PUT ページ</h1>