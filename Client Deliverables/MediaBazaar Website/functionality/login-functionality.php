<?php
if(isset($_POST['submit']) && isset($_POST['email']) && isset($_POST['password'])) {
    $email = $_POST['email'];
    $password = $_POST['password'];

    // LOGIN USER
    $login = new LoginEmployee();

    if($login->login($email, $password)) {
        // GET CURRENT SCHEDULE
        $getCurrentSchedule = new GetCurrentSchedule();
        $currentSchedule = $getCurrentSchedule->getSchedule(date('Y-m-d'));

        if($currentSchedule !== false) {
            // GET CURRENT SCHEDULE DAYS
            $getScheduleDays = new GetDaysInRange();
            $scheduleDays = $getScheduleDays->getDays($currentSchedule->getStartDate(), $currentSchedule->getEndDate());

            foreach($scheduleDays as $day) {
                $_SESSION['schedule']->addDay($day);
            }

            // GET EMPLOYEE WORKDAYS
            $getScheduleWorkDays = new GetCurrentScheduleEmployeeWorkdays();
            $scheduleWorkDays = $getScheduleWorkDays->getWorkDays($_SESSION['user']->getId(), $_SESSION['schedule']);

            foreach($scheduleWorkDays as $workDay) {
                $_SESSION['schedule']->addWorkDay($workDay);
            }
            
            successMessage('Successfully logged in');
            redirect_to('/dashboard');
        }
    }
}