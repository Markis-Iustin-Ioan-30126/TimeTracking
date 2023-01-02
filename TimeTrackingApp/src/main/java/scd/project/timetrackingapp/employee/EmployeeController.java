package scd.project.timetrackingapp.employee;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import scd.project.timetrackingapp.wrappers.AuthenticationWrapper;

import java.util.List;

@CrossOrigin
@RestController
@RequestMapping("/employee")
public class EmployeeController {
    @Autowired
    private EmployeeService employeeService;

    @GetMapping
    public List<Employee> getAllEmployees() {
        return employeeService.getAllEmployees();
    }

    @PostMapping
    public Employee addNewEmployee(@RequestBody Employee employee) {
        return employeeService.addNewEmployee(employee);
    }

    @GetMapping("/employeeName={employeeName}")
    public List<Employee> getEmployeesByName(@PathVariable(value = "employeeName") String employeeName) {
        return employeeService.getEmployeesByName(employeeName);
    }

    @GetMapping("/id={id}")
    public Employee getEmployeeById(@PathVariable(value = "id") Integer id) {
        return employeeService.getEmployeeById(id);
    }

    @DeleteMapping("/id={id}")
    public boolean deleteEmployee(@PathVariable(value = "id") Integer id) {
        return employeeService.deleteEmployee(id);
    }

    @PostMapping("/id={id}/employeeName={employeeName}/hourlyRate={hourlyRate}/password={password}")
    public Employee modifyEmployee(@PathVariable(value = "id") Integer id,
                                   @PathVariable(value = "employeeName") String employeeName,
                                   @PathVariable(value = "hourlyRate") String hourlyRate,
                                   @PathVariable(value = "password") String password) {
        return employeeService.modifyEmployee(id, employeeName, hourlyRate, password);
    }

    @PostMapping("/auth")
    public Integer authenticateEmployee(@RequestBody AuthenticationWrapper authenticationWrapper) {
        return employeeService.authenticateEmployee(authenticationWrapper);
    }
}
