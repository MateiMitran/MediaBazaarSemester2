<?php
abstract class ShiftPreference extends Database {
    protected $userId;
    protected $preference;

    public function __construct($userId, $preference) {
        $this->userId = $userId;
        $this->preference = $preference;
    }
}