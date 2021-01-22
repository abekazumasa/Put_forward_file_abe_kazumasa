<?php
$json_arr = array();
$json_arr[0] = '
	{"id": 1,
	"name": "Akira TAKASAKI",
	"description": "わーい予約だ予約だ",
	"reservations": 
			{"room_id": 1,"checked_in_on": "2019-11-15", "checked_out_on": "2019-11-18"}
	},';

$json_arr[1] = '
	{"id": 2,
	"name": "山田だがなにか",
	"description": "わーい予約だ予約だ、山田さんだ。",
	"reservations": 
			{"room_id": 21,"checked_in_on": "2019-12-30", "checked_out_on": "2020-01-07"}
	},';

$json_arr[2] = '
	{"id": 3,
	"name": "Mr. マリック",
	"description": "わーい予約だ予約だ、ハンドパワーだ (´ω｀)",
	"reservations": 
			{"room_id": 123,"checked_in_on": "2019-12-01", "checked_out_on": "2019-12-02"}
	}';


header("Content-Type:application/json; charset=utf-8", true);
echo("[");
foreach($json_arr as $data){
	echo($data);
}
echo("]");
?>