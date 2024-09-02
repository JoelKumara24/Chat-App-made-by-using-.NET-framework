<?php

$src = $_POST['inp1'];
$cf3 = $_POST['inp2'];
$cf4 = $_POST['inp3'];
$cf5 = $_POST['inp4'];
$cf13 = $_POST['inp5'];
$cf6 = $_POST['inp6'];
//$sum = ($num1)+($num2);

echo "Data : <br><br>";

echo "src :  ".$src."<br><br>";
echo "pre_name :   ".$cf3."<br><br>";
echo "pre_fam_name :   ".$cf4."<br><br>";
echo "pre_from_email :   ".$cf5."<br><br>";
echo "pre_message :   ".$cf13."<br><br>";
echo "pre_tel :   ".$cf6."<br><br>";

date_default_timezone_set('Asia/Colombo');
$timestamp = time();
echo(date("F d, Y h:i:s", $timestamp));

$logFile = fopen("log_en.txt", "a") or die("Unable to open file!");
fwrite($logFile,"Date and time :  \n".(date("F d, Y h:i:s", $timestamp)));
fwrite($logFile,"\n\nsrc :  \n");
fwrite($logFile,"#!#".$src."#!#");
fwrite($logFile,"\n\npre_name :   \n");
fwrite($logFile,"#%#".$cf3."#%#");
fwrite($logFile,"\n\npre_fam_name :   \n");
fwrite($logFile,"#^#".$cf4."#^#");
fwrite($logFile,"\n\nspre_from_email :   \n");
fwrite($logFile,"#*#".$cf5."#*#");
fwrite($logFile,"\n\npre_message :   \n");
fwrite($logFile,"#+#".$cf13."#+#");
fwrite($logFile,"\n\npre_tel :   \n");
fwrite($logFile,"#-#".$cf6."#-#");
fwrite($logFile," \n\n-------------------------------------------------------------------------------\n");



fclose($logFile);






?>