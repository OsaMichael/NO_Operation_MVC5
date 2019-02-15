using NoOperation_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoOperation_MVC.Interface
{
    public interface IEmployeeManager
    {
        bool CreateEmp(Employee employee);
        List<Employee> GetEmployees();
        //Employee GetEmployeeById(int emploId);
        Employee GetEmployeeById(int id = 0);
        bool UpdateEmp(Employee employee);
        Employee EmployDetails(int id);
        bool DeleteEmp(int id);


        bool CreateState(State state);
        List<State> GetStates();
        State GetStateById(int id);
        bool CreateLga(LGA lga);
        List<LGA> GetLGAs();
        LGA GetLGAById(int id);
       // List<LGA> GetLGAByStateId(int stateId);
        LGA[] GetLGAByStateId(int stateId);

    }
}