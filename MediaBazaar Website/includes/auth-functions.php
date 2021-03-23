<?php
    function employee_logged_in() {
        if(empty($_SESSION['user_id'])) {
            return false;
        } else {
            return true;
        }
    }

    function confirm_logged_in() {
        if(!employee_logged_in()) {
            header("Location: /login");
            exit();
        }
    }    
?>