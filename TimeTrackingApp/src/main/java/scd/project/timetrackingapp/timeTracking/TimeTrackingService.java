package scd.project.timetrackingapp.timeTracking;

import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import scd.project.timetrackingapp.employee.EmployeeService;
import scd.project.timetrackingapp.wrappers.TimeTrackingRecordWrapper;
import scd.project.timetrackingapp.wrappers.TimeTrackingStatWrapper;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@Service
public class TimeTrackingService {
    @Autowired
    private TimeTrackingRepository timeTrackingRepository;
    @Autowired
    private EmployeeService employeeService;

    @Transactional
    public TimeTracking addTimeTrackingRecord(TimeTrackingRecordWrapper data) {
        TimeTracking timeTracking = new TimeTracking();
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findAll();
        for (TimeTracking record : timeTrackingList) {
            if (record.getCheckIn().getYear() == data.getYear() && record.getCheckIn().getMonth().getValue() == data.getMonth()
            && record.getCheckIn().getDayOfMonth() == data.getDay() && record.getEmployee().getId() == data.getEmployeeId()) {
                return null;
            }
        }

        timeTracking.setEmployee(employeeService.getEmployeeById(data.getEmployeeId()));
        timeTracking.setCheckIn(LocalDateTime.of(data.getYear(), data.getMonth(), data.getDay(), data.getCheckInHour(), data.getCheckInMinute(), data.getCheckInSecond()));
        timeTracking.setCheckOut(LocalDateTime.of(data.getYear(), data.getMonth(), data.getDay(), data.getCheckOutHour(), data.getCheckOutMinute(), data.getCheckOutSecond()));

        return timeTrackingRepository.save(timeTracking);
    }

    public List<TimeTrackingStatWrapper> getAllTimeTrackingRecords() {
        List<TimeTrackingStatWrapper> wrapperList = new ArrayList<>();
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findAll();

        for (TimeTracking record : timeTrackingList) {
            wrapperList.add(new TimeTrackingStatWrapper(record, ChronoUnit.MINUTES.between(record.getCheckIn(), record.getCheckOut())/60.0));
        }

        return wrapperList;
    }

    public double getAllWorkingHours() {
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findAll();
        if (timeTrackingList.isEmpty()) return -1;

        double totalWorkedHours = 0;
        for (TimeTracking record : timeTrackingList) {
            totalWorkedHours = totalWorkedHours + ChronoUnit.MINUTES.between(record.getCheckIn(), record.getCheckOut());
        }
        return  totalWorkedHours/60;
    }

    public double getWorkedHoursByEmployee(Integer id) {
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findAll();
        if (timeTrackingList.isEmpty()) return -1;

        double totalWorkedHours = 0;
        for (TimeTracking record : timeTrackingList) {
            if (record.getEmployee().getId() == id) {
                totalWorkedHours = totalWorkedHours + ChronoUnit.HOURS.between(record.getCheckIn(), record.getCheckOut());
            }
        }

        return totalWorkedHours;
    }

    public List<TimeTrackingStatWrapper> getWorkedHoursByEmployeePerMonth(Integer id, Integer year, Integer month) {
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findAll();
        List<TimeTrackingStatWrapper> wrapperList = new ArrayList<>();
        if (timeTrackingList.isEmpty()) return null;

        List<TimeTracking> filteredTimeTrackingList = timeTrackingList
                .stream()
                .filter(r -> r.getEmployee().getId().equals(id) && r.getCheckIn().getYear() == year && r.getCheckIn().getMonth().getValue() == month)
                .toList();
        filteredTimeTrackingList = new ArrayList<>(filteredTimeTrackingList);
        Collections.sort(filteredTimeTrackingList, Collections.reverseOrder());

        for (TimeTracking record : filteredTimeTrackingList) {
            wrapperList.add(new TimeTrackingStatWrapper(record, ChronoUnit.MINUTES.between(record.getCheckIn(), record.getCheckOut())/60.0));
        }

        return wrapperList;
    }

    public boolean deleteRecordByDay(Integer id, LocalDate date) {
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findAll();
        if (timeTrackingList.isEmpty()) return false;

        for (TimeTracking record : timeTrackingList) {
            LocalDateTime checkIn = record.getCheckIn();
            LocalDate recordDate = LocalDate.of(checkIn.getYear(), checkIn.getMonth(), checkIn.getDayOfMonth());
            if (record.getEmployee().getId().equals(id) && recordDate.compareTo(date) == 0) {
                timeTrackingRepository.delete(record);
                return true;
            }
        }

        return false;
    }

    @Transactional
    public boolean modifyRecordForEmployee(Integer id, LocalDateTime newCheckIn, LocalDateTime newCheckOut, LocalDate date) {
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findAll();
        if (timeTrackingList.isEmpty()) return false;

        for (TimeTracking record : timeTrackingList) {
            LocalDateTime checkIn = record.getCheckIn();
            LocalDate recordDate = LocalDate.of(checkIn.getYear(), checkIn.getMonth(), checkIn.getDayOfMonth());
            if (record.getEmployee().getId().equals(id) && recordDate.compareTo(date) == 0) {
                record.setCheckIn(newCheckIn);
                record.setCheckOut(newCheckOut);
                return true;
            }
        }

        return false;
    }
}
