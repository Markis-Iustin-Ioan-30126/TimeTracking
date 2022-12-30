package scd.project.timetrackingapp.employee;

import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class EmployeeService {
    @Autowired
    private EmployeeRepository employeeRepository;

    @Transactional
    public Employee addNewEmployee(Employee employee) {
        return employeeRepository.save(employee);
    }

    public List<Employee> getAllEmployees() {
        return employeeRepository.findAll();
    }

    public List<Employee> getEmployeesByName(String employeeName) {
        List<Employee> employeeList = employeeRepository.findAll();
        return employeeList
                .stream()
                .filter(e -> e.getName().equals(employeeName))
                .collect(Collectors.toList());
    }

    public Employee getEmployeeById(Integer id) {
        Optional<Employee> optEmployee = employeeRepository.findById(id);
        if (optEmployee.isEmpty()) return null;
        return optEmployee.get();
    }

    @Transactional
    public boolean deleteEmployee(Integer id) {
        Optional<Employee> optEmployee = employeeRepository.findById(id);
        if (optEmployee.isEmpty()) return  false;

        employeeRepository.delete(optEmployee.get());
        return true;
    }

    @Transactional
    public Employee modifyEmployee(Integer id, String newEmployeeName, String newHourlyRate) {
        Optional<Employee> optEmployee = employeeRepository.findById(id);
        if (optEmployee.isEmpty()) return null;

        Employee employee = optEmployee.get();
        employee.setName(newEmployeeName);
        employee.setHourlyRate(newHourlyRate);
        return employeeRepository.save(employee);
    }
}
