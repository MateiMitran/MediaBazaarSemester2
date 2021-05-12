<?php
    $page = 'index';
    require_once('includes/header.php');

    if(empty($_SESSION['user_id'])) {
        header("Location: /login");
    } else {
        header("Location: /dashboard");
    }
?>