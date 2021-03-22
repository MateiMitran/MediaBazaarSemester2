<?php
    Route::set('login', function() {
        Dashboard::CreateView("Login");
     });

    Route::set('dashboard', function() {
       Dashboard::CreateView("Dashboard");
    });

    Route::set('account', function() {
        Dashboard::CreateView("Account");
    });
?>