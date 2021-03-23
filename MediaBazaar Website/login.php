<?php
    $page == 'login';
    include('includes/header.php');
?>
    <!-- LOGIN FORM -->
    <form class="simple-form" method="POST">
        <h2 class="section-title">Sign in</h2>
        <div class="form-group full">
            <label for="login-email">Email:</label>
            <input type="email" name="login-email" id="login-email" autocomplete="off">
        </div>
        <div class="form-group full">
            <label for="login-password">Password:</label>
            <input type="password" name="login-password" id="login-password" autocomplete="off">
        </div>
        <div class="form-group submit">
            <input type="submit" name="login-submit" value="Log In">
        </div>
    </form>
<?php include('includes/footer.php'); ?>