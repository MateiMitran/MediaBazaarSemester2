<?php
    $page = 'statistics';
    $functionalityRequirements = ['login-functionality'];
    
    require_once('includes/header.php');
?>

    <div id="statistics-wrapper">
        <h2 class="section-title">Statistics: Topic</h2>
         <div class="query-button all-charts">
                            <input type="submit" name="show-statistics-all" class="small-submit" value="All Charts" style="margin-top: 30px;" />
                        </div>
        <div id="statistics-filters-container">
                    <form class="simple-form">
                        <h3>Filters</h3>
                        <div class="select-group">
                            <label>Select 1:</label>
                            <label class="select-arrow-label">
                                <select name="statistics-select" id="statistics-select">
                                    <option value="val">First value </option>
                                    <option value="val">Second value</option>
                                </select>
                            </label>
                        </div>
                       <div class="select-group">
                            <label>Select 1:</label>
                            <label class="select-arrow-label">
                                <select name="statistics-select" id="statistics-select">
                                    <option value="val">First value </option>
                                    <option value="val">Second value</option>
                                </select>
                            </label>
                        </div>
                       <div class="select-group">
                            <label>Select 1:</label>
                            <label class="select-arrow-label">
                                <select name="statistics-select" id="statistics-select">
                                    <option value="val">First value </option>
                                    <option value="val">Second value</option>
                                </select>
                            </label>
                        </div>
                    </div>
                        <div class="query-button filter">
                            <input type="submit" id = #filter name="show-statistics-filtered" class="small-submit" value="Apply Filters" />
                   </div>
                    </form>
                        <div class="chart-container" style="position: relative; height:40vh; width:80vw">
    <canvas id="chart"></canvas>
                       </div>
        </div>
    </div>
<?php require_once('includes/footer.php'); ?>
