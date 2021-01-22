<?php
$json_arr = array();
$json_arr[0] = '
		{
		"date": "2019-11-01",
		"title": "創立記念日休業",
		"description": "ヒューマンアカデミーの創立記念日なので下記の日程にて休業させていただきます。でも五輪授業はあります。",
		"created_at":	"2019-10-27 13:10:00",
		"updated_at":	"2019-10-27 13:10:00"
},';

$json_arr[1] = '
	{
		"date":			"2019-12-31",
		"title":			"大晦日",
		"description":	"大晦日ですが終夜営業します。",
		"created_at":	"2019-10-27 13:10:00",
		"updated_at":	"2019-10-27 13:10:00"
	},';

$json_arr[2] = '
	{
		"date":			"2020-01-01",
		"title":			"明けオメ",
		"description":	"お正月は全従業員あげてお休みです。",
		"created_at":	"2019-10-27 13:10:00",
		"updated_at":	"2019-10-27 13:10:00"
	}';


header("Content-Type:application/json; charset=utf-8", true);
echo("[");
foreach($json_arr as $data){
	echo($data);
}
echo("]");
?>