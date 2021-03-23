<?php
    if(isset($_POST['submit']) && isset($_POST['email']) && isset($_POST['password'])) {
        $email = $_POST['email'];
        $password = $_POST['password'];

        $results = login($conn, $email, $password);
        $numRows = mysqli_num_rows($results);

        if($numRows === 1) {
            foreach($results as $r) {
                if(mysqli_real_escape_string($conn, $r['password']) == mysqli_real_escape_string($conn, $password)) {
                    // SET SESSION VARIABLES IF LOGIN SUCCESSFUL AND REDIRECT TO DASHBOARD
                    $_SESSION['user_id'] = $r['id'];
                    $_SESSION['email'] = $r['email'];
                    $_SESSION['login_message'] = 'Successfully logged in!';

                    header("Location: /dashboard");
                    exit();
                } else {
                    array_push($errorMessages, 'Incorrect password');
                }
            }
        } else {
            array_push($errorMessages, 'No employee was found with the given email');
        }
    }
?>