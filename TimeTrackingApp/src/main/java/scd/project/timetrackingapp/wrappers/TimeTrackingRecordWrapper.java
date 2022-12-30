package scd.project.timetrackingapp.wrappers;

import lombok.Getter;

@Getter
public class TimeTrackingRecordWrapper {
    private Integer employeeId;
    private Integer year;
    private Integer month;
    private Integer day;
    private Integer checkInHour;
    private Integer checkInMinute;
    private Integer checkInSecond;
    private Integer checkOutHour;
    private Integer checkOutMinute;
    private Integer checkOutSecond;
}
