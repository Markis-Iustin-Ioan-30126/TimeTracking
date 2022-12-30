package scd.project.timetrackingapp.wrappers;

import lombok.Getter;
import java.time.LocalDateTime;

@Getter
public class LocalDateWrapper {
    private Integer id;
    private LocalDateTime checkIn;
    private LocalDateTime checkOut;
}
