using EmployeeWebApi.Data;
using EmployeeWebApi.Interfaces;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _dataContext;
        public ProjectRepository(DataContext dataContext) //DI?
        {
            this._dataContext = dataContext;
        }


        //need to impl the behaviour of each of these quesy method accessing db context
        // use linq
        public  ICollection<Project> GetAllProjects() {
            return _dataContext.Projects.OrderBy(p => p.Id).ToList(); //default sort by id
        }

        //TODO : try with given column sorting

        public Project GetProjectById(int id) {
            return _dataContext.Projects
                .SingleOrDefault(p => p.Id == id);//if not found return default null
            //.SingleOrDefault(p => p.Id == id)??new Project();  -- if not found return new project

            //.Single(p => p.Id == id)  -- if not found gives error


            //use .Where(p => p.Id == id) with multiple.. like filtering gives multiple results
        }

        public Project GetProjectByName(string name) {
            return _dataContext.Projects
                .SingleOrDefault(p => p.ProjectName == name);
        }

    }
}
