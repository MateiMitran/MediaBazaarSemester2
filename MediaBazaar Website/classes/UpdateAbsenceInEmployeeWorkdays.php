<?php
class UpdateAbsenceInEmployeeWorkdays extends Database {
    public function updateAbsence($dayIds, $employeeId, $absenceReason) {
        $sql = "UPDATE employees_workdays SET `first_shift` = 'none', `second_shift` = 'none', `absence` = 1, `absence_reason` = ? WHERE day_id IN (". implode(',', $dayIds) . ") AND employee_id = ?";
        $query = Database::connect()->prepare($sql);
        $result = $query->execute([$absenceReason, $employeeId]);

        return $result;
    }
}