<?php
    // GENERAL PREFERENCES
    if(isset($_POST['general-preferences-submit']) && isset($_POST['general-preferences-shift'])) {
        $shift = $_POST['general-preferences-shift'];

        $valid_shifts = ['morning', 'midday', 'evening'];

        if(in_array($shift, $valid_shifts)) {
            $userId = $_SESSION['user']->getId();
            
            $preference = new GeneralShiftPreference($userId, $shift);
            $setPreference = new SetGeneralShiftPreference();

            if($setPreference->setShiftPreference($preference) == 1) {
                // SUCCESSFULLY SET GENERAL PREFERENCES
                successMessage('Successfully set general shift preferences');
            } else {
                // SUCCESSFULLY UPDATED GENERAL PREFERENCES
                $updatePreference = new UpdateGeneralShiftPreference();

                if($updatePreference->updateShiftPreference($preference) == 1) {
                    successMessage('Successfully updated general shift preferences');
                } else {
                    errorMessage('An error occurred, please try again later');
                }
            }
        } else {
            errorMessage('Invalid preference value');
        }
    }
?>