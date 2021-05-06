<?php
    $page = 'account';
    $functionalityRequirements = ['account-functionality'];
    
    require_once('includes/header.php');
?>
    <!-- LOGIN FORM -->
    <form class="simple-form" method="POST">
        <h2 class="section-title">Account Preferences</h2>
        <div class="form-group half">
            <label for="preferences-first-name">First Name:</label>
            <input type="text" name="preferences-first-name" id="preferences-first-name" value="<?php echo ucfirst(strtolower($user->getFirstName())); ?>">
        </div>
        <div class="form-group half">
            <label for="preferences-last-name">Last Name:</label>
            <input type="text" name="preferences-last-name" id="preferences-last-name" value="<?php echo ucfirst(strtolower($user->getLastName())); ?>">
        </div>
        <div class="form-group half">
            <label for="preferences-gender">Sex:</label>
            <input type="text" name="preferences-gender" id="preferences-gender" value="<?php echo ucfirst(strtolower($user->getGender())); ?>" disabled>
        </div>
        <div class="form-group half">
            <label for="preferences-birth-date">Birth Date:</label>
            <input type="text" name="preferences-birth-date" id="preferences-birth-date" value="<?php echo $user->getBirthDate(); ?>" disabled>
        </div>
        <div class="form-group full">
            <label for="preferences-email">Email:</label>
            <input type="email" name="preferences-email" id="preferences-email" value="<?php echo $user->getEmail(); ?>" disabled>
        </div>
        <div class="form-group full">
            <label for="preferences-new-password">New Password:</label>
            <input type="password" name="preferences-new-password" id="preferences-new-password">
        </div>
        <div class="form-group full">
            <label for="preferences-confirm-password">Confirm Password:</label>
            <input type="password" name="preferences-confirm-password" id="preferences-confirm-password">
        </div>
        <div class="form-group submit">
            <input type="submit" name="preferences-submit" value="Save">
        </div>
    </form>
<?php require_once('includes/footer.php'); ?>