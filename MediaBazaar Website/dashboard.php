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
                <form class="simple-form" action="/dashboard" method="POST" style="margin-top: 70px;">
                    <div class="form-group half">
                        <label for="preferences-date">Date:</label>
                        <input type="date" name="preferences-date" id="preferences-date" required />
                    </div>
                    <div class="form-group half">
                        <label for="preferences-shift">Preferred Shift:</label>
                        <label id="shift-preferences-arrow-label">
                            <select id="preferences-shift" name="preferences-shift" id="preferences-shift" required>
                                <option value="morning">Morning</option>
                                <option value="midday">Midday</option>
                                <option value="evening">Evening</option>
                            </select>
                        </label>
                    </div>
                    <div class="form-group submit">
                        <input type="submit" name="preferences-submit" class="small-submit" value="Save" style="margin-top: 30px;">
                    </div>
                </form>
            </div>
            <!-- RULES -->
            <div class="dashboard-content" id="dashboard-rules">
                <ol>
                    <li>
                        this is a random rule
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
                </ol>
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
        <a href="javascript:void(0)" class="dashboard-button" id="dashboard-button-rules" page="dashboard-rules">
            Rules
        </a>
    </div>
<?php require_once('includes/footer.php'); ?>