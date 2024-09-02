<?php

$num1 = $_POST['inp1'];
$num2 = $_POST['inp2'];
//$sum = ($num1)+($num2);

echo "Data : <br>";

echo "first number : ".$num1."<br>";
echo "Second number : ".$num2."<br>";
echo var_dump(($num1)/($num2));

echo "Div : ".(($num1)/($num2))."<br>";

echo "The date is ".date("Y-m-d");

function data()
{
    echo "first number : ".$num1."<br>";
    echo "Second number : ".$num2."<br>";
}




?>