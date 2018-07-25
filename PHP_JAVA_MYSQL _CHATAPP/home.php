
<?php 
  session_start(); 

  if (!isset($_SESSION['username'])) {
  	$_SESSION['msg'] = "You must log in first";
  	header('location: login.php');
  }
  if (isset($_GET['logout'])) {
  	session_destroy();
  	unset($_SESSION['username']);
  	header("location: login.php");
  }
?>
<!DOCTYPE html>
<html>
<head>
	<title>Chat Page</title>
	<link rel="stylesheet" type="text/css" href="stylesheet.css">
</head>
<body>

<div class="header">
	<h2>Chat Page</h2>
</div>
<div class="content">
  	<?php if (isset($_SESSION['success'])) : ?>
        	<?php endif ?>

    
    <?php  if (isset($_SESSION['username'])) : ?>
    	<p>Welcome <strong><?php echo $_SESSION['username']; ?></strong>
    	<a href="home.php?logout='1'" style="color: red;">logout</a> </p>
    <?php endif ?>
</div>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
<p5>
	<div class="chat">
		<?php

		$con = mysqli_connect("mysql.cms.waikato.ac.nz","ltm8","my10880539sql", "ltm8");

		$query = "select * from chats";
		$result = mysqli_query($con,$query);
		while($row = mysqli_fetch_assoc($result)) {
		echo $row['username'] . "<br>";
		}
		mysqli_close($con);
		?>
	</div>
<p5>
	<div class="chat2">
		<?php

		$con = mysqli_connect("mysql.cms.waikato.ac.nz","ltm8","my10880539sql", "ltm8");

		$query = "select * from chats";
		$result = mysqli_query($con,$query);
		while($row = mysqli_fetch_assoc($result)) {
		echo $row['chat'] . "<br>";

		}
		mysqli_close($con);
		?>
	</div>

	<div class="chat3">
		<?php

		$con = mysqli_connect("mysql.cms.waikato.ac.nz","ltm8","my10880539sql", "ltm8");

		$query = "select * from chats";
		$result = mysqli_query($con,$query);
		while($row = mysqli_fetch_assoc($result)) {
		echo $row['date'] . "<br>";
		}
		mysqli_close($con);
		?>
	</div>


 <form action="re_direct.php" method="post">
    <p>
        <label for="firstName"></label>
        <input type="text" name="userdet" id="firstName" value=<?php echo $_SESSION['username']; ?>>
    </p>
    <p>
        <label for="lastName"></label>
        <input type="text" name="userchat" id="lastName">
    </p>

    <input type="submit" value="Submit">
</form>
		
</body>
</html>