<?php
    // REDIRECT IF EMPLOYEE IS NOT LOGGED IN
    if($page != 'login' && empty($_SESSION['user_id'])) {
        header("Location: /login");
        exit();
    }

    // REDIRECT TO DASHBBOARD FROM LOGIN PAGE IF EMPLOYEE IS LOGGED IN
    if($page == 'login' && !empty($_SESSION['user_id'])) {
        header("Location: /dashboard");
        exit();
    }
?>