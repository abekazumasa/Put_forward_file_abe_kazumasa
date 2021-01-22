<?php

$json = '{"id": 1,
					"name": "Akira TAKASAKI",
					"reservations": {"room_id": 1,"checked_in_on": "2018-04-10", "checked_out_on": "2018-04-15"}
				}';

header("Content-Type:application/json; charset=utf-8", true);
echo($json);
?>