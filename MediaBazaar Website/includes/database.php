<?php
    $host = "studmysql01.fhict.local";
    $username = "dbi460221";
    $password = "lol";
    $database = "dbi460221";
    
    // Create connection
    $conn = new mysqli($host, $username, $password, $database);
    
    // Check connection
    if($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }
?>