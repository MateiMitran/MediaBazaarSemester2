<?php
    require_once('initialize.php');

    // REDIRECT
    if($page != 'login' && empty($_SESSION['user_id'])) {
        header("Location: /login");
        exit();
    }

    // LOGOUT
    if(isset($_REQUEST['logout'])) {
        session_destroy();
        header("Location: /login");
        exit();
    }
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>MediaBazaar: Dashboard</title>
    <!-- GOOGLE FONTS -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@300;400;600;700&display=swap" rel="stylesheet">
    <!-- FONTAWESOME -->
    <script src="https://use.fontawesome.com/560785642e.js"></script>
    <!-- CSS IMPORTS -->
    <link rel="stylesheet" href="../css/essentials.css" type="text/css">
    <?php
        if($page == 'dashboard') {
    ?>
        <link rel="stylesheet" href="../css/dashboard.css" type="text/css">
    <?php
        }
    ?>
</head>
<body>
<!-- BODY WRAPPER -->
<div id="body-wrapper">
    <!-- TOP NAV -->
    <nav id="top-nav">
        <a href="/dashboard" id="logo"><span>Media</span>Bazaar</a>
        <?php
            if($page == 'dashboard' || $page == 'account') {
        ?>
            <ul>
                <li>
                    <a href="/dashboard">Dashboard</a>
                </li><li>
                    <a href="/account">Account</a>
                </li>
                <li>
                    <form method="POST">
                        <input type="submit" name="logout" id="top-nav-sign-in-button" value="Log Out">
                    </form>
                </li>
            </ul>
        <?php
            } else {
        
        ?>
            <ul>
                <li>
                    <a href="/login" id="top-nav-sign-in-button">Sign In</a>
                </li>
            </ul>
        <?php
            }
        ?>
    </nav>