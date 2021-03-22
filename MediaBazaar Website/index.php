<?php
    spl_autoload_register('load_classes');

    function load_classes($class_name) {
        if(file_exists('./classes/'.$class_name.'.php')) {
            require_once './classes/'.$class_name.'.php';
        } else if('./controllers/'.$class_name.'.php') {
            require_once './controllers/'.$class_name.'.php';   
        }
    }

    require_once('includes/routes.php');
?>