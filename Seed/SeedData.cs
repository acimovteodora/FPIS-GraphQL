using DataAccessLayer;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seed
{
    public class SeedData
    {
        public static void SeedScientificAreas(FPISContext context)
        {
            if (!context.ScientificAreas.Any())
            {
                var areasData = System.IO.File.ReadAllText("../Seed/Data/ScientificAreaData.json");
                var areas = JsonConvert.DeserializeObject<List<ScientificArea>>(areasData);
                foreach (var area in areas)
                {
                    context.ScientificAreas.Add(area);
                }
                context.SaveChanges();
            }
        }

        public static void SeedCities(FPISContext context)
        {
            var citiesData = System.IO.File.ReadAllText("../Seed/Data/CityData.json");
            var cities = JsonConvert.DeserializeObject<List<City>>(citiesData);
            foreach (var city in cities)
            {
                context.Cities.Add(city);
            }
            context.SaveChanges();
        }

        public static void SeedPositions(FPISContext context)
        {
            if (!context.Positions.Any())
            {
                var positionsData = System.IO.File.ReadAllText("../Seed/Data/PositionData.json");
                var positions = JsonConvert.DeserializeObject<List<Position>>(positionsData);
                foreach (var position in positions)
                {
                    context.Positions.Add(position);
                }
                context.SaveChanges();
            }
        }

        public static void SeedCompanies(FPISContext context)
        {
            if (!context.Companies.Any())
            {
                var companyData = System.IO.File.ReadAllText("../Seed/Data/CompanyData.json");
                var companies = JsonConvert.DeserializeObject<List<Company>>(companyData);
                foreach (var company in companies)
                {
                    foreach (var location in company.Locations)
                    {
                        location.City = context.Cities.FirstOrDefault(l => l.Name == location.City.Name);
                        location.CityID = location.City.CityID;
                    }
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("tea", out passwordHash, out passwordSalt);
                    company.PasswordHash = passwordHash;
                    company.PasswordSalt = passwordSalt;
                    context.Companies.Add(company);
                }
                context.SaveChanges();
            }
        }

        public static void SeedEmployees(FPISContext context)
        {
            if (!context.Employees.Any())
            {
                var employeesData = System.IO.File.ReadAllText("../Seed/Data/EmployeeData.json");
                var employees = JsonConvert.DeserializeObject<List<Employee>>(employeesData);

                foreach (var emp in employees)
                {
                    emp.Positions = new List<EmployeePosition>();
                    switch (emp.Username)
                    {
                        case "miki":
                            {
                                emp.Positions.Add(new EmployeePosition
                                {
                                    PositionID = context.Positions.FirstOrDefault(x => x.Name == "Декан").PositionID,
                                    DateFrom = DateTime.Today.AddYears(-2)
                                });
                                break;
                            }
                        case "aco":
                            {
                                emp.Positions.Add(new EmployeePosition
                                {
                                    PositionID = context.Positions.FirstOrDefault(x => x.Name == "Продекан за наставу").PositionID,
                                    DateFrom = DateTime.Today.AddYears(-2)
                                });
                                break;
                            }
                        case "sanja":
                            {
                                emp.Positions.Add(new EmployeePosition
                                {
                                    PositionID = context.Positions.FirstOrDefault(x => x.Name == "Продекан за међународну сарадњу").PositionID,
                                    DateFrom = DateTime.Today.AddYears(-2)
                                });
                                break;
                            }
                        case "aki":
                            {
                                emp.Positions.Add(new EmployeePosition
                                {
                                    PositionID = context.Positions.FirstOrDefault(x => x.Name == "Продекан за организацију и финансије").PositionID,
                                    DateFrom = DateTime.Today.AddYears(-2)
                                });
                                break;
                            }
                        case "mare":
                            {
                                emp.Positions.Add(new EmployeePosition
                                {
                                    PositionID = context.Positions.FirstOrDefault(x => x.Name == "Продекан за научно-истраживачки рад").PositionID,
                                    DateFrom = DateTime.Today.AddYears(-2)
                                });
                                break;
                            }
                        case "goca":
                            {
                                emp.Positions.Add(new EmployeePosition
                                {
                                    PositionID = context.Positions.FirstOrDefault(x => x.Name == "Секретар факултета").PositionID,
                                    DateFrom = DateTime.Today.AddYears(-2)
                                });
                                break;
                            }
                        case "irc":
                            {
                                emp.Positions.Add(new EmployeePosition
                                {
                                    PositionID = context.Positions.FirstOrDefault(x => x.Name == "Ирц админ").PositionID,
                                    DateFrom = DateTime.Today.AddYears(-2)
                                });
                                break;
                            }
                    }
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("1234", out passwordHash, out passwordSalt);
                    emp.PasswordHash = passwordHash;
                    emp.PasswordSalt = passwordSalt;
                    context.Employees.Add(emp);
                }
                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static void SeedProjectsProposals(FPISContext context)
        {
            if (!context.ProjectProposals.Any())
            {
                var proposalsData = System.IO.File.ReadAllText("../Seed/Data/ProjectProposalData.json");
                var proposals = JsonConvert.DeserializeObject<List<ProjectProposal>>(proposalsData);
                foreach (var proposal in proposals)
                {
                    proposal.Company = context.Companies
                        .FirstOrDefault(x => x.Name == proposal.Company.Name);
                    proposal.ExternalMentor = context.ExternalMentors
                        .FirstOrDefault(x => x.Name == proposal.ExternalMentor.Name && x.Surname == proposal.ExternalMentor.Surname);
                    foreach (ProjectCoveringSubject subject in proposal.Subjects)
                    {
                        subject.ScientificArea = context.ScientificAreas
                            .FirstOrDefault(x => x.Name == subject.ScientificArea.Name);
                    }
                    context.ProjectProposals.Add(proposal);
                }
                context.SaveChanges();
            }
        }

        public static void SeedProjects(FPISContext context)
        {
            if (!context.Projects.Any())
            {
                var projectsData = System.IO.File.ReadAllText("../Seed/Data/ProjectData.json");
                var projects = JsonConvert.DeserializeObject<List<Project>>(projectsData);
                foreach (Project project in projects)
                {
                    project.DecisionMaker = context.Employees
                        .FirstOrDefault(x => x.Name == project.DecisionMaker.Name && x.Surname == project.DecisionMaker.Surname);
                    project.InternalMentor = context.Employees
                        .FirstOrDefault(x => x.Name == project.InternalMentor.Name && x.Surname == project.InternalMentor.Surname);
                    project.ProjectProposal = context.ProjectProposals
                        .FirstOrDefault(x => x.Name == project.ProjectProposal.Name);
                    if (project.Applications != null)
                    {
                        foreach (Application application in project.Applications)
                        {
                            application.Student = context.Students
                                .FirstOrDefault(x => x.Index == application.Student.Index);
                            application.StudentID = application.Student.StudentID;
                        } 
                    }
                    context.Projects.Add(project);
                }
                context.SaveChanges();
            }
        }

        public static void SeedStudents(FPISContext context)
        {
            if (!context.Students.Any())
            {
                var studentsData = System.IO.File.ReadAllText("../Seed/Data/StudentData.json");
                var students = JsonConvert.DeserializeObject<List<Student>>(studentsData);
                foreach (Student student in students)
                {
                    context.Students.Add(student);
                }
                context.SaveChanges();
            }
        }
    }
}
