using NoOperation_MVC.Interface;
using NoOperation_MVC.Models;
using NoOperation_MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoOperation_MVC.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private ApplicationDbContext _context;

        public EmployeeManager(ApplicationDbContext context)
        {
           this._context = context;
        }

        public bool CreateEmp(Employee employee)
        {
            var isexist = _context.Employees.Where(x => x.Email == employee.Email).FirstOrDefault();
            if (isexist != null) throw new Exception("already exist");

            var result = new Employee
            {
                 FirstName = employee.FirstName,
                 LastName = employee.LastName,
                 Address = employee.Address,
                 Email = employee.Email
                 
            };
            _context.Employees.Add(result);
            _context.SaveChanges();

            return true;
        }

        public List<Employee> GetEmployees()
        {
            var entities = _context.Employees.ToList();

            var results = entities.Select(s => new Employee
            {
                Address = s.Address,
                FirstName = s.FirstName,
                Email = s.Email,
                LastName = s.LastName,
                Id = s.Id
            }).ToList();
            return results;
        }
        public bool UpdateEmp(Employee employee)
        {
            var isexist = _context.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (isexist == null) throw new Exception("user not found");

            var emInDB = _context.Employees.Find(employee.Id);
            if (emInDB != null)
            {
                emInDB.FirstName = employee.FirstName;
                emInDB.LastName = employee.LastName;
                emInDB.Email = employee.Email;
                emInDB.Address = employee.Address;

                _context.Entry(emInDB).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();         
            }

            return true;
        }

        public  Employee GetEmployeeById(int id)
        {
            var entity = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null) throw new Exception("user not found");

            var result = new Employee
            {
                Address = entity.Address,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Id = entity.Id
            };
            return result;
        }
        public Employee EmployDetails (int id)
        {
            var entity = _context.Employees.FirstOrDefault(s => s.Id == id);
            if (entity == null) throw new Exception("employee not found");

            var result = new Employee
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Email = entity.Email,
                Id = entity.Id
            };
            return result;
        }

        public bool DeleteEmp (int id)
        {
            var entity = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null) throw new Exception("does not exist");

            _context.Employees.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        #region  State 

        public bool CreateState (State state)
        {
            var entity = _context.States.Where(s => s.StateName == state.StateName).FirstOrDefault();
            if (entity != null) throw new Exception("already exist");

            var newState = new State
            {
                 StateName = state.StateName                            
            };

            _context.States.Add(newState);
            _context.SaveChanges();
            return true;
        }

        public List<State> GetStates()
        {
            var entities = _context.States.ToList();
            var models = entities.Select(s => new State
            {
                 StateName = s.StateName,
                  StateId = s.StateId
                  
            }).ToList();
            return models;
        }

        public State GetStateById(int id)
        {
            var entity = _context.States.Where(s => s.StateId == id).FirstOrDefault();
            if (entity == null) throw new Exception("state id not found");

            var result = new State
            {
                 StateName = entity.StateName,
                 StateId = entity.StateId
            };
            return result;
        }
        #endregion

        #region LGA 

        public bool CreateLga(LGA lga)
        {
            var entity = _context.LGAs.Where(l => l.LGAName == lga.LGAName).FirstOrDefault();
            if (entity != null) throw new Exception("lga already exist");

            var newLga = new LGA
            {
                 LGAName = lga.LGAName,
                 StateId = lga.StateId
            };
            _context.LGAs.Add(newLga);
            _context.SaveChanges();
            return true;
        }

        public List<LGA> GetLGAs()
        {
            var entities = _context.LGAs.ToList();

            var models = entities.Select(s => new LGA
            {
                 LGAName = s.LGAName,
                 LGAId = s.LGAId,
                 StateId = s.StateId
            }).ToList();
            return models;
        }

        public LGA GetLGAById(int id)
        {
            var entity = _context.LGAs.Where(l => l.LGAId == id).FirstOrDefault();
            if (entity == null) throw new Exception("id not found");

            var lga = new LGA
            {
                 LGAName = entity.LGAName,
                  StateId = entity.StateId
            };
            return lga;
        }

        public  LGA[] GetLGAByStateId(int stateId)
        {
            var entities = _context.LGAs.Where(l => l.StateId == stateId).ToList();
            var models = entities.Select(l => new LGA
            {
                LGAName = l.LGAName,
                StateId = l.StateId,
                LGAId = l.LGAId


            }).ToArray();
            return models;
        }
     

        #endregion
    }
}