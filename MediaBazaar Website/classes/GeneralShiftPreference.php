<?php
class GeneralShiftPreference extends ShiftPreference {
    public function __construct($userId, $preference) {
        parent::__construct($userId, $preference);
    }

    public function getUserId() {
        return $this->userId;
    }

    public function getPreference() {
        return $this->preference;
    }
}