<?php
    if(isset($_POST['submit']) && isset($_POST['email']) && isset($_POST['password'])) {
        $email = $_POST['email'];
        $password = $_POST['password'];

        $login = new LoginEmployee();

        if($login->login($email, $password)) {
            successMessage('Successfully logged in');
            redirect_to('/dashboard');
        }
    }
?>