<?php
    class Database {
        public static $host = "localhost:8889";
        public static $dbName = "test";
        public static $username = "root";
        public static $password = "root";
        
        public static function connect() {
            $pdo = new PDO('mysql:host=localhost:8889;dbname=test', "root", "root");
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

            return $pdo;
        }

        public static function query($query, $params = array()) {
            $statement = self::connect()->prepare($query);
            $statement->execute($params);

            if (explode(' ', $query)[0] == 'SELECT') {
                $data = $statement->fetchAll();
                return $data;
            }
        }
    }
?>