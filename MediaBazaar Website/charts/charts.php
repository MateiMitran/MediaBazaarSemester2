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
    $manager = new WHStatisticsManager();
      
    if($content == 'market'){
        $monthlySales = $manager->MonthlySales();
        $yearlySales = $manager->YearlySales();

        require_once('charts/wh_charts/MonthlySales.php');
        require_once('charts/wh_charts/YearlySales.php');

    }
    else if($content == 'restocks'){
        $monthlyRestocks = $manager->MonthlyRestocks();
        $yearlyRestocks = $manager->YearlyRestocks();

        require_once('charts/wh_charts/MonthlyRestocks.php');
        require_once('charts/wh_charts/YearlyRestocks.php');
        
    }

}

else if($position == "CEO"){

}
?>