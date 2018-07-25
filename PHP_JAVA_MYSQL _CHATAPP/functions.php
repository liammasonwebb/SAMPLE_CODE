<?php
session_start();

$username = "";
$errors = array(); 

//server connect
$db = mysqli_connect("mysql.cms.waikato.ac.nz","ltm8","my10880539sql", "ltm8");

// REGISTER USER
if (isset($_POST['reg_user'])) {
  $username = mysqli_real_escape_string($db, $_POST['username']);
  $password_1 = mysqli_real_escape_string($db, $_POST['password_1']);
  $password_2 = mysqli_real_escape_string($db, $_POST['password_2']);
  if (empty($username)) { array_push($errors, "Please Enter Username"); }
  if (empty($password_1)) { array_push($errors, "Please Enter Password"); }
  if ($password_1 != $password_2) {
	array_push($errors, "The passwords where not the same");
  }
  $user_check_query = "SELECT * FROM users WHERE username='$username' LIMIT 1";
  $result = mysqli_query($db, $user_check_query);
  $user = mysqli_fetch_assoc($result);
  
  if ($user) { 
    if ($user['username'] === $username) {
      array_push($errors, "Username taken");
    }
  }

  if (count($errors) == 0) {
  	$password = md5($password_1);

  	$query = "INSERT INTO users (username, password) 
  			  VALUES('$username', '$password')";
  	mysqli_query($db, $query);
  	$_SESSION['username'] = $username;
  	$_SESSION['success'] = "logged in";
  	header('location: home.php');
  }
}


// LOGIN FUNCTION
if (isset($_POST['login_user'])) {
  $username = mysqli_real_escape_string($db, $_POST['username']);
  $password = mysqli_real_escape_string($db, $_POST['password']);

  if (empty($username)) {
  	array_push($errors, "Username required");
  }
  if (empty($password)) {
  	array_push($errors, "Password required");
  }

  if (count($errors) == 0) {
  	$password = md5($password);
  	$query = "SELECT * FROM users WHERE username='$username' AND password='$password'";
  	$results = mysqli_query($db, $query);
  	if (mysqli_num_rows($results) == 1) {
  	  $_SESSION['username'] = $username;
  	  $_SESSION['success'] = "logged in";
  	  header('location: home.php');
  	}else {
  		array_push($errors, "Wrong username/password");
  	}
  }
}


?>