<?php
$in  = $_POST['checked_in_on'] = "2019-12-29";
$out = $_POST['checked_out_on'] = "2020-01-07";
$num = $_POST['number'] = "45";

$json = '{
		"checked_in_on": "' . $in . '",
		"checked_out_on": "' . $out . '",
		"number": "' . $num . '"
}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>