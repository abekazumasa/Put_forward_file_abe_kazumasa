<?php

$json = '{"id": 2,
					"name": "山田だ がなにか",
					"reservations": {"room_id": 3,"checked_in_on": "2019-05-03", "checked_out_on": "2019-05-07"}
				}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>