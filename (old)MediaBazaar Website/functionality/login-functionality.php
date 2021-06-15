<?php
if(isset($_POST['submit']) && isset($_POST['email']) && isset($_POST['password'])) {
    $email = $_POST['email'];
    $password = $_POST['password'];

    // LOGIN USER
    $login = new LoginEmployee();

    if($login->login($email, $password)) {
        // GET CURRENT SCHEDULE
        $getSchedule = new UpdateCurrentSchedule();
        $getSchedule->updateSchedule();

        successMessage('Successfully logged in');
        redirect_to('/dashboard');
    }
}