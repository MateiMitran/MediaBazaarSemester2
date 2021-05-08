<?php
class Day extends Database {
    private $id;
    private $date;
    private $schedule_id;
    private $security_needed;
    private $cashiers_needed;
    private $stockers_needed;
    private $sales_assistants_needed;
    private $warehouse_managers_needed;
    private $week_id;
    private $security_assigned;
    private $cashiers_assigned;
    private $stockers_assigned;
    private $sales_assistants_assigned;
    private $warehouse_managers_assigned;

    public function __construct($id, $date, $schedule_id, $security_needed, $cashiers_needed, $stockers_needed, $sales_assistants_needed, $warehouse_managers_needed, $week_id, $security_assigned, $cashiers_assigned, $stockers_assigned, $sales_assistants_assigned, $warehouse_managers_assigned) {
        $this->id = $id;
        $this->date = $date;
        $this->schedule_id = $schedule_id;
        $this->security_needed = $security_needed;
        $this->cashiers_needed = $cashiers_needed;
        $this->stockers_needed = $stockers_needed;
        $this->sales_assistants_needed = $sales_assistants_needed;
        $this->warehouse_managers_needed = $warehouse_managers_needed;
        $this->week_id = $week_id;
        $this->security_assigned = $security_assigned;
        $this->cashiers_assigned = $cashiers_assigned;
        $this->stockers_assigned = $stockers_assigned;
        $this->sales_assistants_assigned = $sales_assistants_assigned;
        $this->warehouse_managers_assigned = $warehouse_managers_assigned;
    }

    public function getId() {
        return $this->id;
    }
}