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

<span class="but_red">New agent</span>


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


<tr>
<td>01_01</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00 (12 Open)</td>
<td><span class="but_text_red">Details</span></td>
</tr>


<tr>
<td>01_02</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00 (12 Open)</td>
<td><span class="but_text_red">Details</span></td>
</tr>


<tr>
<td>01_03</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00 (12 Open)</td>
<td><span class="but_text_red">Details</span></td>
</tr>


<tr>
<td>01_04</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00 (12 Open)</td>
<td><span class="but_text_red">Details</span></td>
</tr>


<tr>
<td>01_05</td>
<td>Test fullname</td>
<td>test@test.com</td>
<td>00 000 000 000</td>
<td>1 hour ago <span class="cell_ago_date">0000-00-00 00:00</span></td>
<td>00 (12 Open)</td>
<td><span class="but_text_red">Details</span></td>
</tr>


</table>



</div><!-- rt -->










</div><!-- main pg -->



</body>
</html>


