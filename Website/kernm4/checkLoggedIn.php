<?php 
    session_start();

    if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){ //if login in session is not set
        header("Location: https://ronaldvanegdom.nl/kernm4/loginClient.php");
        exit;
    }
?>