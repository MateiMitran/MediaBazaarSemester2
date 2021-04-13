<?php
    $page = 'dashboard';
    $functionalityRequirements = ['preferences-functionality'];
    
    require_once('includes/header.php');
?>
    <!-- DASHBOARD -->
    <div id="dashboard-wrapper">
        <h2 class="section-title">Announcements</h2>
        <div id="dashboard-container">
            <!-- ANNOUNCEMENTS -->
            <div class="dashboard-content visible" id="dashboard-announcements">
                <ul>
                    <li>
                        this is a random announcement
                    </li>
                    <li>
                        hello world
                    </li>
                    <li>
                        this is a test
                    </li>
                    <li>
                        this is a test
                    </li>
                    <li>
                        this is a test
                    </li>
                </ul>
            </div>
            <!-- SCHEDULE -->
            <div class="dashboard-content" id="dashboard-schedule">
                <p>Schedule</p>
            </div>
            <!-- PREFERENCES -->
            <div class="dashboard-content" id="dashboard-preferences">
                <form class="simple-form" action="dashboard" method="POST">
                    <div class="form-group half">
                        <label for="preferences-date">Date:</label>
                        <input type="date" name="preferences-date" id="preferences-date" required />
                    </div>
                    <div class="form-group half">
                        <label for="preferences-shift">Preferred Shift:</label>
                        <label class="select-arrow-label">
                            <select id="preferences-shift" name="preferences-shift" id="preferences-shift" required>
                                <option value="morning" selected>Morning</option>
                                <option value="midday">Midday</option>
                                <option value="evening">Evening</option>
                            </select>
                        </label>
                    </div>
                    <div class="form-group submit">
                        <input type="submit" name="preferences-submit" class="small-submit" value="Save" style="margin-top: 30px;" />
                    </div>
                </form>
            </div>
            <!-- ABSENCE -->
            <div class="dashboard-content" id="dashboard-absence">
                <div id="absence-wrapper">
                    <form class="simple-form" method="POST" action="dashboard" id="sick-report-form">
                        <h3>I'm feeling sick today</h3>
                        <div class="form-group">
                            <label for="sick-report-symptoms">Describe your symptoms:</label>
                            <textarea name="sick-report-symptoms"></textarea>
                        </div>
                        <div class="form-group submit">
                            <input type="submit" class="small-submit" name="sick-report-submit" value="Submit" />
                        </div>
                    </form>
                    <p>OR</p>
                    <form class="simple-form" method="POST" action="dashboard" id="day-off-form">
                        <h3>I need a day off</h3>
                        <div class="form-group">
                            <label for="day-off-day">I need a day off on:</label>
                            <input type="date" name="day-off-day" />
                        </div>
                        <div class="form-group">
                            <label for="day-off-urgency">And it is:</label>
                            <label class="select-arrow-label">
                                <select name="day-off-urgency" id="day-off-urgency">
                                    <option value="not-urgent" selected>Not Urgent</option>
                                    <option value="urgent">Urgent</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group submit">
                            <input type="submit" class="small-submit" name="day-off-submit" value="Request day off" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-announcements" page="dashboard-announcements">
            Announcements
        </a>
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-schedule" page="dashboard-schedule">
            Schedule
        </a>
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-preferences" page="dashboard-preferences">
            Preferences
        </a>
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-absence" page="dashboard-absence">
            Absence
        </a>
    </div>
<?php require_once('includes/footer.php'); ?>