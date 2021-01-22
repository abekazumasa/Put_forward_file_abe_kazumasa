<?php
$point = 3;
if(isset($_POST['id']) && ($_POST['id'] == 3)) {

$point = $point + 1;

// 本当にチェックイン・チェックアウトが戻るのか？ /////////////////////////////////////////
$json = '{"room_id": 123,"checked_in_on": "2019-10-01", "checked_out_on": "2019-10-02", "point": ' . $point . '}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);

} else {
$point = $point;
$json = '{"id": 3,
					"name": "Mr. マリック",
					"point": 3,
					"reservations": {"room_id": 123,"checked_in_on": "2019-10-01", "checked_out_on": "2019-10-02"}
				}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
}
?>