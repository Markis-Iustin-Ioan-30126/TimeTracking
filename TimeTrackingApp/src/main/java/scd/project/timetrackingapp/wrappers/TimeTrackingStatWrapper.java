package scd.project.timetrackingapp.wrappers;

import lombok.AllArgsConstructor;
import lombok.Getter;
import scd.project.timetrackingapp.timeTracking.TimeTracking;

@AllArgsConstructor
@Getter
public class TimeTrackingStatWrapper {
    private TimeTracking timeTracking;
    private double workedHours;
}
