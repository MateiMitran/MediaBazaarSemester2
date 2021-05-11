<?php
class SetGeneralShiftPreference extends Database {
    public function setShiftPreference($generalShiftPreference) {
        $userId = $generalShiftPreference->getUserId();
        $preference = $generalShiftPreference->getPreference();

        $sql = "INSERT INTO employees_preferences (employee_id, monday, tuesday, wednesday, thursday, friday, saturday, sunday) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$userId, $preference, $preference, $preference, $preference, $preference, $preference, $preference]);

        return $result;
    }
}