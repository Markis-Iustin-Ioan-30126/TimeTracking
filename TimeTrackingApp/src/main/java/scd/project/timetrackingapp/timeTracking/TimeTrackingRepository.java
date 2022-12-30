package scd.project.timetrackingapp.timeTracking;

import org.springframework.data.jpa.repository.JpaRepository;

public interface TimeTrackingRepository extends JpaRepository<TimeTracking, Integer> {
}
