<?php
class Database {
    public static function connect() {
        $host = "studmysql01.fhict.local";
        $username = "dbi460221";
        $password = "lol";
        $database = "dbi460221";

        try {
            $conn = new PDO("mysql:host=$host;dbname=$database", $username, $password);

            return $conn;
        } catch(PDOException $e) {
            errorMessage('An error occurred, please try again later');
        }
    }
}

