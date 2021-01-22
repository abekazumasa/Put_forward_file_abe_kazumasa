<?php
$json_arr = array();
$json_arr[0] = '
	{"id": 1,
	"name": "Akira TAKASAKI",
	"point": 37,
	"description": "わーい昔の予約だ",
	"reservations": 
			{"room_id": 1,"checked_in_on": "2018-04-10", "checked_out_on": "2018-04-15"}
	},';

$json_arr[1] = '
	{"id": 2,
	"name": "山田だ がなにか",
	"point": 18,
	"description": "わーい昔の予約だ、山田さんだ。",
	"reservations": 
			{"room_id": 3,"checked_in_on": "2019-05-03", "checked_out_on": "2019-05-07"}
	},';

$json_arr[2] = '
	{"id": 3,
	"name": "Mr. マリック",
	"point": 3,
	"description": "わーい昔の予約だ、ハンドパワーの予約だ (´ω｀)",
	"reservations": 
			{"room_id": 123,"checked_in_on": "2019-10-01", "checked_out_on": "2019-10-02"}
	}';


header("Content-Type:application/json; charset=utf-8", true);
echo("[");
foreach($json_arr as $data){
	echo($data);
}
echo("]");
?>