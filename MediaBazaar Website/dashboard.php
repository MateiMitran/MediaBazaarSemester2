<?php
    $page = 'dashboard';
    $functionalityRequirements = ['preferences-functionality', 'absence-functionality'];
    
    require_once('includes/header.php');
?>
    <!-- WELCOME MESSAGE -->
    <p id="welcome-message">Greetings, <span><?php echo $_SESSION['user']->getFirstName(); ?></span></p>
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
                <div id="preferences-wrapper">
                    <form class="simple-form" action="dashboard" method="POST">
                        <h3>Set for specific day</h3>
                        <div class="form-group">
                            <label for="specific-preferences-day">Day:</label>
                            <label class="select-arrow-label">
                                <select name="specific-preferences-day" id="specific-preferences-day">
                                    <option value="monday">Monday</option>
                                    <option value="tuesday">Tuesday</option>
                                    <option value="wednesday">Wednesday</option>
                                    <option value="thursday">Thursday</option>
                                    <option value="friday">Friday</option>
                                    <option value="saturday">Saturday</option>
                                    <option value="sunday">Sunday</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group">
                            <label for="specific-preferences-shift">Preferred Shift:</label>
                            <label class="select-arrow-label">
                                <select name="specific-preferences-shift" id="specific-preferences-shift" required>
                                    <option value="none">None</option>
                                    <option value="morning" selected>Morning</option>
                                    <option value="midday">Midday</option>
                                    <option value="evening">Evening</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group submit">
                            <input type="submit" name="specific-preferences-submit" class="small-submit" value="Save" style="margin-top: 30px;" />
                        </div>
                    </form>
                    <p>OR</p>
                    <form class="simple-form" action="dashboard" method="POST" id="general-form">
                        <h3>Set in general</h3>
                        <div class="form-group">
                            <label for="general-preferences-shift">Preferred Shift:</label>
                            <label class="select-arrow-label">
                                <select id="general-preferences-shift" name="general-preferences-shift" id="general-preferences-shift" required>
                                    <option value="none">None</option>
                                    <option value="morning" selected>Morning</option>
                                    <option value="midday">Midday</option>
                                    <option value="evening">Evening</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group submit">
                            <input type="submit" name="general-preferences-submit" class="small-submit" value="Save" style="margin-top: 30px;" />
                        </div>
                    </form>
                </div>
            </div>
            <!-- ABSENCE -->
            <div class="dashboard-content" id="dashboard-absence">
                <div id="absence-wrapper">
                    <form class="simple-form" method="POST" action="dashboard" id="sick-report-form">
                        <h3>I'm feeling sick today</h3>
                        <div class="form-group">
                            <label for="sick-report-until-date">I will be sick until:</label>
                            <input type="date" name="sick-report-until-date" id="sick-report-until-date" />
                        </div>
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
                            <label for="start-day">I need some days off from:</label>
                            <input type="date" name="start-day" id="start-day" />

                            <input type="checkbox" name="one-day-only" value="one-day-only" id="one-day-only">
                            <label for="one-day-only">I will be needing only one day off</label>
                        </div>
                        <div class="form-group">
                            <label for="end-day">I need some days off until:</label>
                            <input type="date" name="end-day" id="end-day" />
                        </div>
                        <div class="form-group">
                            <label for="urgency">And it is:</label>
                            <label class="select-arrow-label">
                                <select name="urgency" id="urgency" required>
                                    <option value="not-urgent" selected>Not Urgent</option>
                                    <option value="urgent">Urgent</option>
                                </select>
                            </label>
                        </div>
                        <div class="form-group">
                            <label for="reason">I need a day off because:</label>
                            <textarea name="reason"></textarea>
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