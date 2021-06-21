<?php
if($position == "HRManager"){
    $manager = new HRStatisticsManager();
    $salaries = json_encode($manager->GetAverageSalaryPerDepartment());
    $hrsPerDeptY = json_encode($manager->GetHoursPerDepartmentForYear());
    $hrsPerDeptM = json_encode($manager->GetHoursPerDepartmentPerMonth());
    $topEmpsPerDept = json_encode($manager->GetTopEmployeesPerDepartment());
    $whPerMonth = json_encode($manager->GetHoursPerMonth());


 require_once('charts/hr_charts/salariesChart.php');
 require_once('charts/hr_charts/whDeptChart.php');
 require_once('charts/hr_charts/whDeptChartM.php');
 require_once('charts/hr_charts/topEmpsChart.php');
 require_once('charts/hr_charts/whPerMonth.php');
}
else if($position == "WarehouseManager"){

}

else if($position == "CEO"){

}
?>