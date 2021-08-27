<?php
/* Database credentials. */
define('DB_SERVER', 'localhost');
define('DB_USERNAME', 'u30186p23947_phpAccess');
define('DB_PASSWORD', '8447cowbunga');
define('DB_NAME', 'u30186p23947_waddoo');
define('DB_PORT', 3306);
 
/* Attempt to connect to MySQL database */
$link = mysqli_connect(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME, DB_PORT);
 
// Check connection
if($link === false) {
    echo "Error: Unable to connect to MySQL." . PHP_EOL;
    echo "Debugging errno: " . mysqli_connect_errno() . PHP_EOL;
    echo "Debugging error: " . mysqli_connect_error() . PHP_EOL;

}
else {
    echo("Connection succesful!");
}
?>