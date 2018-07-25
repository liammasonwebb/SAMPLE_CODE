<?php

$con = mysqli_connect("mysql.cms.waikato.ac.nz","ltm8","my10880539sql", "ltm8");

$query = "select * from chats";

$result = mysqli_query($con,$query);
while($row = mysqli_fetch_assoc($result)) {
 echo $row['username'] . "<br>";
 echo $row['chat'] . "<br>";
 echo $row['date'] . "<br>";
  }
mysqli_close($con);
?>
