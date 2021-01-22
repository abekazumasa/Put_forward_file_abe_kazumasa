<?php

$json = '{"id": 3,
					"name": "Mr. マリック",
					"reservations": {"room_id": 123,"checked_in_on": "2019-10-01", "checked_out_on": "2019-10-02"}
				}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>