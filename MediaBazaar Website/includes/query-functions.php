<?php
    function login($conn, $email) {
        $email = mysqli_real_escape_string($conn, $email);

        $sql = "SELECT * FROM employees WHERE email = '$email'";

        $query = mysqli_query($conn, $sql);
        return $query;
    }
    
    function find_day_by_date($conn, $date) {
        $date = mysqli_real_escape_string($conn, $date);

        $sql = "SELECT * FROM days WHERE DATE(date) = '$date'";

        $query = mysqli_query($conn, $sql);
        return $query;
    }

    function set_employee_shift_preferences($conn, $day_id, $employee_id, $shift_preference) {
        $day_id = mysqli_real_escape_string($conn, $day_id);
        $employee_id = mysqli_real_escape_string($conn, $employee_id);
        $shift_preference = mysqli_real_escape_string($conn, $shift_preference);

        $sql = "INSERT INTO employees_preferences (day_id, employee_id, prefered_first_shift) VALUES ('$day_id', '$employee_id', '$shift_preference')";

        $query = mysqli_query($conn, $sql);
        return $query;
    }

    function check_if_shift_preference_exists($conn, $day_id, $employee_id) {
        $day_id = mysqli_real_escape_string($conn, $day_id);
        $employee_id = mysqli_real_escape_string($conn, $employee_id);

        $sql = "SELECT * FROM employees_preferences WHERE day_id = '$day_id' AND employee_id = '$employee_id'";

        $query = mysqli_query($conn, $sql);
        return $query;
    }
    
    function update_shift_preference($conn, $row_id, $day_id, $employee_id, $shift_preference) {
        $row_id = mysqli_real_escape_string($conn, $row_id);
        $day_id = mysqli_real_escape_string($conn, $day_id);
        $employee_id = mysqli_real_escape_string($conn, $employee_id);
        $shift_preference = mysqli_real_escape_string($conn, $shift_preference);

        $sql = "UPDATE employees_preferences SET prefered_first_shift = '$shift_preference' WHERE id = '$row_id' AND day_id = '$day_id' AND employee_id = '$employee_id'";

        $query = mysqli_query($conn, $sql);
        return mysqli_affected_rows($conn);
    }
?>