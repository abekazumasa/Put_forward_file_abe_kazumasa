<?php
$point = 18;
if(isset($_POST['id']) && ($_POST['id'] == 2)) {

$point = $point + 1;

// 本当にチェックイン・チェックアウトが戻るのか？ /////////////////////////////////////////
$json = '{"checked_in_on": "2019-05-03", "checked_out_on": "2019-05-07", "point": ' . $point . '}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);

} else {
$point = $point;
$json = '{"id": 2,
					"name": "山田だ がなにか",
					"point": ' . $point . ',
					"reservations": [
							{"room_id": 1,"checked_in_on": "2018-04-10", "checked_out_on": "2018-04-12"},
							{"room_id": 15,"checked_in_on": "2018-10-10", "checked_out_on": "2018-10-20"},
							{"room_id": 21,"checked_in_on": "2019-06-01", "checked_out_on": "2019-06-10"}
						]
				}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
}
?>