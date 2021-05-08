<?php
$valid_urgency_values = ['not-urgent', 'urgent'];

// DAY OFF REQUEST
if(isset($_POST['day-off-submit'])) {
    if(isset($_POST['start-day']) && DateTime::createFromFormat('Y-m-d', $_POST['start-day']) !== false) {
        $startDay = $_POST['start-day'];
        $endDay = null;

        $findDay = new FindDayByDate();

        $firstDayId = $findDay->findDay($startDay)->getId();
        $lastDayId = null;

        $correct = false;

        if(is_null($_POST['one-day-only'])) {
            // GET END DATE
            if(isset($_POST['end-day']) && DateTime::createFromFormat('Y-m-d', $_POST['end-day']) !== false) {
                $endDay = $_POST['end-day'];

                $lastDayId = $findDay->findDay($endDay)->getId();

                $correct = true;
            } else {
                errorMessage('Invalid end date');
            }
        } else {
            $correct = true;
        }

        if($correct) {
            if(isset($_POST['urgency']) && in_array($_POST['urgency'], $valid_urgency_values)) {
                $urgency;

                if($_POST['urgency'] == 'not-urgent') {
                    $urgency = 0;
                } else if($_POST['urgency'] == 'urgent') {
                    $urgency = 1;
                }

                $reason = $_POST['reason'];

                $dayOffRequest = new DayOffRequest(null, $firstDayId, $lastDayId, $_SESSION['user']->getId(), $urgency, $reason, 'pending', null, null);

                $submitRequest = new SubmitDayOffRequest();

                if($submitRequest->submitRequest($dayOffRequest) == 1) {
                    successMessage('Successfully submitted day-off request');
                } else {
                    errorMessage('An error occurred, please try again later');
                }
            } else {
                errorMessage('Invalid urgency value');
            }
        }
    } else {
        errorMessage('Invalid start date');
    }
}