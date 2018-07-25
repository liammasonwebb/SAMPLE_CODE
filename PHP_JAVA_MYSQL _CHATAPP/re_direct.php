

<?php
// connection
$link = mysqli_connect("mysql.cms.waikato.ac.nz","ltm8","my10880539sql", "ltm8");
 
// Check connection
if($link === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
 

$un = mysqli_real_escape_string($link, $_REQUEST['userdet']);
$pass = mysqli_real_escape_string($link, $_REQUEST['userchat']);

$sql = "INSERT INTO chats (username, chat) VALUES ('$un', '$pass')";
if(mysqli_query($link, $sql)){
    echo "Records added successfully.";
} else{
    echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
 

mysqli_close($link);

header("Location: home.php");
die();
?>