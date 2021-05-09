<?php
class EmployeeWorkday extends Database {
    private $day_id;
    private $employee_id;
    private $first_shift;
    private $second_shift;
    private $absence;
    private $absence_reason;

    public function __construct($day_id, $employee_id, $first_shift, $second_shift, $absence, $absence_reason) {
        $this->day_id = $day_id;
        $this->employee_id = $employee_id;
        $this->first_shift = $first_shift;
        $this->second_shift = $second_shift;
        $this->absence = $absence;
        $this->absence_reason = $absence_reason;
    }
}