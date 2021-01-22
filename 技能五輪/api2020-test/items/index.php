<?php
if($_SERVER['REQUEST_METHOD'] == "GET") {
	$json_arr = array();
	$json_arr[0] = '
		{"id": 1,
		"name": "Akira TAKASAKI",
		"order": "カツカレーだ！",
		"numbers": 3
		},';
		
	$json_arr[1] = '
		{"id": 2,
		"name": "やまだ　五郎",
		"order": "チキンカレーだ！",
		"numbers": 1
		},';
	
	$json_arr[2] = '
		{"id": 3,
		"name": "Akira TAKASAKI",
		"order": "やっぱりカツカレーだ！",
		"numbers": 2
		}';
	
	
	header("Content-Type:application/json; charset=utf-8", true);
	echo("[");
	foreach($json_arr as $data){
		echo($data);
	}
	echo("]");

} else if($_SERVER['REQUEST_METHOD'] == "POST") {
	
	$order    = $_POST['order'];
	$yourname = $_POST['yourname'];
	$address  = $_POST['address'];
	$number   = $_POST['number'];
	$date     = $_POST['date'];
	$time     = $_POST['time'];
	
	$json_arr = array("order"=>$order, "number"=>$number, "yourname"=>$yourname, "address"=>$address, "date"=>$date, "time"=>$time);
	
	header("Content-Type:application/json; charset=utf-8", true);
	echo(json_encode($json_arr));
}
?>