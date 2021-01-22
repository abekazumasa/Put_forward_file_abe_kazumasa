<?php
$in  = $_POST['checked_in_on'] = "2019-11-15";
$out = $_POST['checked_out_on'] = "2019-11-18";
$num = $_POST['number'] = "2";

$json = '{
		"checked_in_on": "' . $in . '",
		"checked_out_on": "' . $out . '",
		"number": "' . $num . '"
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>