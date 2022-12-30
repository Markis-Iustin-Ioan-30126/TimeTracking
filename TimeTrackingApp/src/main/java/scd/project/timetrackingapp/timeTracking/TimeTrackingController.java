package scd.project.timetrackingapp.timeTracking;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import scd.project.timetrackingapp.wrappers.LocalDateWrapper;
import scd.project.timetrackingapp.wrappers.TimeTrackingRecordWrapper;
import java.time.LocalDate;
import java.util.List;

@CrossOrigin
@RestController
@RequestMapping("/timeTracking")
public class TimeTrackingController {
    @Autowired
    private TimeTrackingService timeTrackingService;

    @PostMapping
    public TimeTracking addNewTimeTrackingRecord(@RequestBody TimeTrackingRecordWrapper data) {
        return timeTrackingService.addTimeTrackingRecord(data);
    }

    @GetMapping
    public List<TimeTracking> getAllTimeTrackingRecords() {
        return timeTrackingService.getAllTimeTrackingRecords();
    }

    @GetMapping("/total")
    public double getAllWorkingHours() {
        return timeTrackingService.getAllWorkingHours();
    }

    @GetMapping("/id={id}")
    public double getWorkedHoursByEmployee(@PathVariable(value = "id") Integer id) {
        return timeTrackingService.getWorkedHoursByEmployee(id);
    }

    @GetMapping("/id={id}/year={year}/month={month}")
    public List<TimeTracking> getWorkedHoursByEmployeePerMonth(@PathVariable(value = "id") Integer id,
                                                   @PathVariable(value = "year") Integer year,
                                                   @PathVariable(value = "month") Integer month) {
        return timeTrackingService.getWorkedHoursByEmployeePerMonth(id, year, month);
    }

    @DeleteMapping("/id={id}/{year}-{month}-{day}")
    public boolean deleteRecordByDay(@PathVariable(value = "id") Integer id,
                                       @PathVariable(value = "year") Integer year,
                                       @PathVariable(value = "month") Short month,
                                       @PathVariable(value = "day") Short day) {

        return timeTrackingService.deleteRecordByDay(id, LocalDate.of(year, month, day));
    }

    @PostMapping("/modify/{year}-{month}-{day}")
    public boolean modifyRecordForEmployee(@RequestBody LocalDateWrapper data,
                                           @PathVariable(value = "year") Integer year,
                                           @PathVariable(value = "month") Short month,
                                           @PathVariable(value = "day") Short day) {
        return  timeTrackingService.modifyRecordForEmployee(data.getId(), data.getCheckIn(), data.getCheckOut(), LocalDate.of(year, month, day));
    }
}
