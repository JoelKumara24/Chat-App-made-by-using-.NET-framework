<?php 
include '../addon_page_preload.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
<title></title>
<meta name="description" content="" />
<meta name="author" content="">
<link rel="apple-touch-icon" href="img/app-icon.png">
<link rel="icon" href="../img/app-icon.png">
<meta name="robots" content="noindex">
<meta name="googlebot" content="noindex">
<link rel="stylesheet" type="text/css" href="../css/main.css?<?php echo strtotime('now'); ?>">



<style>

.cell_ago_date{font-size: 12px;font-style: italic;}

</style>

</head>


<body>


<?php include 'addon_topbar.php'; ?>


<div id="main_pg">
    

<?php include 'addon_lt_nav.php'; ?>


    

<div class="rt_page">


<h1>Team</h1>

<span>New agent</span>



<table>

<tr>
<th>Agent ID</th>
<th>Name</th>
<th>Email</th>
<th>Tel/Mobile</th>
<th>Last active</th>
<th>Cases</th>
<th></th>
</tr>



<?php

if (is_numeric($uid) && $security_check1 == 1) {
	# code...





require '../addon_dbcon_s.php';
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}





$conn -> close()


}else{
	
error_log('Attempted access without valid sec1 IP:'.$ip);
	$url = 'https://pnccsupport.com/u/enter';

	echo '<meta http-equiv="refresh" content="0; URL='.$url.'">';
}




$sql = "SELECT uid, fname, lname, email, tel1 FROM system_users";


$result = $conn->query($sql);

  while($row = $result->fetch_assoc()) {
  	  echo "<tr>";
      echo "<td>{$row['uid']}</td>";
      echo "<td>{$row['fname']}<br>{$row['lname']}</td>";
      echo "<td>{$row['email']}</td>";
      echo "<td>{$row['tel1']}</td>";
         echo "</tr>";
  }
?>

<tr>
<td>01_01</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00</td>
<td>Details</td>
</tr>


<tr>
<td>01_02</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00</td>
<td>Details</td>
</tr>


<tr>
<td>01_03</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00</td>
<td>Details</td>
</tr>


<tr>
<td>01_04</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00</td>
<td>Details</td>
</tr>


<tr>
<td>01_05</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00</td>
<td>Details</td>
</tr>


</table>



</div><!-- rt -->










</div><!-- main pg -->



</body>
</html>


