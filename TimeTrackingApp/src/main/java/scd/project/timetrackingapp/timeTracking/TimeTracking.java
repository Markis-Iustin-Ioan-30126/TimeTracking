package scd.project.timetrackingapp.timeTracking;

import jakarta.persistence.*;
import lombok.Data;
import scd.project.timetrackingapp.employee.Employee;

import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;

@Entity
@Data
public class TimeTracking implements Comparable<TimeTracking> {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private LocalDateTime checkIn;
    private LocalDateTime checkOut;

    @ManyToOne
    @JoinColumn(name = "employeeId")
    private Employee employee;

    @Override
    public int compareTo(TimeTracking o) {
        return (int)ChronoUnit.DAYS.between(this.checkIn, o.getCheckIn());
    }
}
