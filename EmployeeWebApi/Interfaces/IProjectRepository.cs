using EmployeeWebApi.Models;

namespace EmployeeWebApi.Interfaces
{

    //these are like jpa repositories
    // but dont have JPA queryMethods
    //we need to mention the methods here - and impl their behaviour in reposiroy class accessing dbcontext
    public interface IProjectRepository
    {

        //each methods is like a queryMethods in jpa - but here need to impl behaviour in repo class accessing db context
        ICollection<Project> GetAllProjects ();//ICollection only for read? cannot edit

        Project GetProjectById (int id);

        Project GetProjectByName (string name);

    }
}
