<?php
    $page = 'login';
    require_once('includes/header.php');

    // LOGIN
    if(isset($_POST['submit']) && isset($_POST['email']) && isset($_POST['password'])) {
        $email = $_POST['email'];
        $password = $_POST['password'];

        $results = login($conn, $email, $password);
        $numRows = mysqli_num_rows($results);

        if($numRows === 1) {
            foreach($results as $r) {
                $_SESSION['user_id'] = $r['id'];
                $_SESSION['email'] = $r['email'];

                header("Location: /dashboard");
                exit();
            }
        }
    }
?>
    <!-- LOGIN FORM -->
    <form class="simple-form" action="/login" method="POST">
        <h2 class="section-title">Sign in</h2>
        <div class="form-group full">
            <label for="login-email">Email:</label>
            <input type="email" name="email" id="login-email" autocomplete="off" required />
        </div>
        <div class="form-group full">
            <label for="login-password">Password:</label>
            <input type="password" name="password" id="login-password" autocomplete="off" required />
        </div>
        <div class="form-group submit">
            <input type="submit" name="submit" value="Log In">
        </div>
    </form>
<?php require_once('includes/footer.php'); ?>1