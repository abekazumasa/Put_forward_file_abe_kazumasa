<?php
$json_arr = array();
$json_arr[0] = '
	{"id": 1,
	"name": "Akira TAKASAKI",
	"description": "わーい昔の予約だ",
	"reservations": [
			{"room_id": 1,"checked_in_on": "2018-04-10", "checked_out_on": "2018-04-12"},
			{"room_id": 15,"checked_in_on": "2018-10-10", "checked_out_on": "2018-10-20"},
			{"room_id": 21,"checked_in_on": "2019-06-01", "checked_out_on": "2019-06-10"}
			]
	},';

$json_arr[1] = '
	{"id": 2,
	"name": "山田だ がなにか",
	"description": "わーい昔の予約だ、山田さんだ。",
	"reservations": [
			{"room_id": 3,"checked_in_on": "2018-12-30", "checked_out_on": "2019-01-04"},
			{"room_id": 3,"checked_in_on": "2019-05-03", "checked_out_on": "2019-05-07"}
			]
	},';

$json_arr[2] = '
	{"id": 3,
	"name": "Mr. マリック",
	"description": "わーい昔の予約だ、ハンドパワーの予約だ (´ω｀)",
	"reservations": [
			{"room_id": 123,"checked_in_on": "2019-10-01", "checked_out_on": "2019-10-02"}
			]
	}';


header("Content-Type:application/json; charset=utf-8", true);
echo("[");
foreach($json_arr as $data){
	echo($data);
}
echo("]");
?>