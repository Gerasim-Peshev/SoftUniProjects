using SoftUni.Data;
using System.Text;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetAddressesByTown(context));
        }


        //03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.OrderBy(e => e.EmployeeId).ToList();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {(e.MiddleName == null ? "" : e.MiddleName)} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString();
        }

        //04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString();
        }

        //05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Department.Name == "Research and Development").Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
                                   .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }


        //06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var employee = context.Employees.First(e => e.LastName.Contains("Nakov"));

            employee.Address = address;
            context.SaveChanges();

            var employees = context.Employees.OrderByDescending(e => e.AddressId).Select(e => new
            {
                e.Address.AddressText
            }).ToList().Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee1 in employees)
            {
                sb.AppendLine($"{employee1.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        //07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            //var employeesWithProjects = context.Employees
            //                       .Take(10)
            //                       .Select(e => new
            //                        {
            //                            FirstName = e.FirstName,
            //                            LastName = e.LastName,
            //                            ManagerFirstName = e.FirstName,
            //                            ManagerLastName = e.LastName,
            //                            Projects = e.EmployeesProjects
            //                                        .Where(ep => ep.Project.StartDate.Year >= 2001 &&
            //                                                     ep.Project.StartDate.Year <= 2003)
            //                                        .Select(ep => new
            //                                         {
            //                                             ProjectName = ep.Project.Name,
            //                                             StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
            //                                             EndDate = ep.Project.EndDate.HasValue ? 
            //                                                 ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
            //                                                 "not finished" 
            //                                         })
            //                                        .ToArray()

            //                        }).ToArray();
            StringBuilder sb = new StringBuilder();

            var employeesWithProjects = context.Employees
                                               .Take(10)
                                               .Select(e => new
                                               {
                                                   e.FirstName,
                                                   e.LastName,
                                                   ManagerFirstName = e.Manager.FirstName,
                                                   ManagerLastName = e.Manager.LastName,
                                                   Projects = e.EmployeesProjects
                                                                .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                                                             ep.Project.StartDate.Year <= 2003)
                                                                .Select(ep => new
                                                                {
                                                                    ProjectName = ep.Project.Name,
                                                                    StartDate = ep.Project.StartDate.ToString(
                                                                         "M/d/yyyy h:mm:ss tt"),
                                                                    EndDate = ep.Project.EndDate.HasValue
                                                                         ? ep.Project.EndDate.Value.ToString(
                                                                             "M/d/yyyy h:mm:ss tt")
                                                                         : "not finished"
                                                                }).ToArray()
                                               }).ToArray();


            foreach (var employee in employeesWithProjects)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.Projects)
                {
                    sb.AppendLine(
                        $"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                                   .OrderByDescending(a => a.Employees.Count())
                                   .ThenBy(a => a.Town.Name)
                                   .ThenBy(a => a.AddressText).Take(10)
                                   .Select(a => new
                                    {
                                        a.AddressText,
                                        TownName = a.Town.Name,
                                        a.Employees
                                    })
                                   .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.Employees.Count()} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //09
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees
                                  .Select(e => new
                                  {
                                      e.EmployeeId,
                                      e.FirstName,
                                      e.LastName,
                                      e.JobTitle,
                                      Projects = e.EmployeesProjects
                                                   .Select(p => new
                                                   {
                                                       p.Project.Name
                                                   }).OrderBy(p => p.Name).ToList()
                                  }).FirstOrDefault(e => e.EmployeeId == 147);


            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        //10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                                     .Where(d => d.Employees.Count() > 5)
                                     .OrderBy(d => d.Employees.Count())
                                     .ThenBy(d => d.Name)
                                     .Select(d => new
                                     {
                                         d.Name,
                                         ManagerFirstName = d.Manager.FirstName,
                                         ManagerLastName = d.Manager.LastName,
                                         Employees = d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList()
                                     }).ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName}  {department.ManagerLastName}");
                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10).OrderBy(p => p.Name).Select(
                p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate,
                }).ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(
                    $"{project.Name}\n{project.Description}\n{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }

        //12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                                   .Where(e =>
                                              e.Department.Name == "Engineering" ||
                                              e.Department.Name == "Tool Design" ||
                                              e.Department.Name == "Marketing" ||
                                              e.Department.Name == "Information Services")
                                   .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                                   .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary * 1.12m:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                                   .Where(e => e.FirstName.StartsWith("Sa"))
                                   .Select(e => new
                                    {
                                        e.FirstName,
                                        e.LastName,
                                        e.JobTitle,
                                        e.Salary
                                    })
                                   .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                                   .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projectToDelete = context.Projects.First(p => p.ProjectId == 2);

            context.EmployeesProjects.ToList().ForEach(ep => context.EmployeesProjects.Remove(ep));
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            var projects = context.Projects.Take(10).ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        //15
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context
                              .Towns
                              .First(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDelete =
                context
                   .Addresses
                   .Where(a => a.TownId == townToDelete.TownId);

            int addressesCount = addressesToDelete.Count();

            IQueryable<Employee> employeesOnDeletedAddresses =
                context
                   .Employees
                   .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employeesOnDeletedAddresses)
            {
                employee.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Remove(townToDelete);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";

        }
    }
}