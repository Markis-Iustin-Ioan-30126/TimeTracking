package scd.project.timetrackingapp.employee;

import jakarta.persistence.*;
import lombok.Data;
import org.hibernate.annotations.CreationTimestamp;
import java.util.Date;

@Entity
@Data
public class Employee {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @Column(nullable = false)
    private String name;

    @Column(nullable = false)
    private String password;

    @Column(nullable = false)
    private String hourlyRate;

    @Column(updatable = false, nullable = false)
    @CreationTimestamp
    private Date enrollDate;
}
