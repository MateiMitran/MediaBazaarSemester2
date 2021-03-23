<?php
    function login($conn, $email, $password) {
        $email = mysqli_real_escape_string($conn, $email);
        $password = mysqli_real_escape_string($conn, $password);

        $sql = "SELECT * FROM employees WHERE email = '$email' AND password = '$password'";
        $query = mysqli_query($conn, $sql);
        return $query;
    }
?>