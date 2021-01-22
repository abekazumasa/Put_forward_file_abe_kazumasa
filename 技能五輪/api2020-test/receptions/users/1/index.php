<?php
$point = 37;
if(isset($_POST['id'])) {

$point = $point + 1;

// 本当にチェックイン・チェックアウトが戻るのか？ /////////////////////////////////////////
$json = '{"checked_in_on": "2018-04-1sdsdsd0", "checked_out_on": "2018-04-12", "point": ' . $point . '}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);

} else {
$point = $point;
$json = '{"id": 1,
					"name": "Akira TAKASAKI~",
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