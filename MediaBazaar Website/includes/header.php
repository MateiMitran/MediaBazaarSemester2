<?php
    require_once('initialize.php');

    // INCLUDE REQUIRED FUNCTIONALITY FILES
    require_once('functionality/redirect-functionality.php');
    require_once('functionality/logout-functionality.php');

    if(!empty($functionalityRequirements)) {
        foreach($functionalityRequirements as $functionality) {
            require_once('functionality/' . $functionality . '.php');
        }
    }

    // GET LOGIN SUCCESS MESSAGE
    if(!empty($_SESSION['login_message'])) {
        array_push($successMessages, $_SESSION['login_message']);
        unset($_SESSION['login_message']);
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
    <script src="https://kit.fontawesome.com/3073970c9d.js" crossorigin="anonymous"></script>
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
    <!-- ERROR MESSAGES -->
    <div id="messages-container">
        <ul id="success-messages">
        <?php 
            if(!empty($successMessages)) {
                foreach($successMessages as $message) {
        ?>
                <li>
                    <p><?php echo $message; ?></p>
                    <i class="fal fa-times"></i>
                </li>
        <?php
                }
            }
        ?>
        </ul>
        <ul id="error-messages">
        <?php 
            if(!empty($errorMessages)) {
                foreach($errorMessages as $message) {
        ?>
                <li>
                    <p><?php echo $message; ?></p>
                    <i class="fal fa-times"></i>
                </li>
        <?php
                }
            }
        ?>
        </ul>
    </div>
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