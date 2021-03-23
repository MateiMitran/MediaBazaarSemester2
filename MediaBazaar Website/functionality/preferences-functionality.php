<?php
    confirm_logged_in();

    if(isset($_POST['preferences-date']) && isset($_POST['preferences-shift'])) {
        $date = $_POST['preferences-date'];
        $shift = $_POST['preferences-shift'];

        if($date == null) {
            array_push($errorMessages, "Please select a date first");
        } else if(date($date) >= date("Y-m-d")) {
            $results = find_day_by_date($conn, $date);
            $numRows = mysqli_num_rows($results);

            if($numRows === 1) {
                foreach($results as $r) {
                    // IF DAY IS FOUND SET THE PREFERENCE
                    $day_id = $r['id'];
                    $employee_id = $_SESSION['user_id'];
                    $shift_preference = ucfirst($shift);

                    $existingPreference = check_if_shift_preference_exists($conn, $day_id, $employee_id);
                    $existingPreferenceNumRows = mysqli_num_rows($existingPreference);  

                    if($existingPreferenceNumRows === 0) {
                        // PREFERENCE HAS NOT BEEN SET FOR THAT DAY (CREATE IT)
                        $resultsPreference = set_employee_shift_preferences($conn, $day_id, $employee_id, $shift_preference);
                        $numRowsPreference = mysqli_num_rows($resultsPreference);

                        if($resultsPreference === true) {
                            array_push($successMessages, "Successfully saved shift preference!");
                        } else {
                            array_push($errorMessages, "An error occurred, please try again later");
                        }
                    } else {
                        foreach($existingPreference as $e) {
                            if($e['prefered_first_shift'] !== $shift_preference) {
                                // UPDATE PREFERENCE
                                $updatePreferenceRowsChanged = update_shift_preference($conn, $e['id'], $e['day_id'], 1, $shift_preference);
                                
                                if($updatePreferenceRowsChanged === 1) {
                                    array_push($successMessages, "Shift preference successfully updated!");
                                } else {
                                    array_push($errorMessages, "An error occurred, please try again later");
                                }
                            } else {
                                array_push($errorMessages, "Preference for that day has already been set to selected value");
                            }
                        }
                    }
                }
            } else {
                array_push($errorMessages, 'Invalid date');
            }
        } else {
            array_push($errorMessages, 'Cannot set preferences for past dates');
        }
    }
?>