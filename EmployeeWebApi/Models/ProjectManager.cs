namespace EmployeeWebApi.Models
{
    public class ProjectManager
    {
        public int ProjectId { get; set; }
        public int ManagerId{ get; set; }

        public Manager Manager { get; set; }
        public Project Project { get; set; }


        /*
         how to get db connection string..
        go to sql server 
        click on relevant db server - get its name
        come back to IDE SQL server object explorer
        click add sql server
        paste that name in server name
        select ur db in below drop down
        and click connect
        this will open the db server in object explorer
        .. then go to relavant db click properties there fine connection string

        //
        add connection string to appsettings.json
        "ConnectionStrings": {
        "DefaultConnection": "Data Source=VIMUKTHI-K;Initial Catalog=employeewebapidb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
    }

        then add nuget ef core
        EntityFrameworkCore.SqlServer and EntityFrameworkCore.Design


        data context create

         */

    }
}
