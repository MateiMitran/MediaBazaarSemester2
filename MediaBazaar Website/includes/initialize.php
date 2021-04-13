<?php
    // START SESSION AND INCLUDE REQUIRED FILES
    session_start();

    require_once('database.php');
    require_once('auth-functions.php');
    require_once('query-functions.php');

    $successMessages = [];
    $errorMessages = [];
?>