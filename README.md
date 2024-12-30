Database connectivity using Entity framework
    create new project of asp.net core mvc
    In solution Explorer(Right click) -> Dependencies -> Manage NuGet Package
    Install Microsoft.EntityFrameworkCore.sqlserver , Microsoft.EntityFrameworkCore.Tools , Microsoft.EntityFrameworkCore.Design
    In appsettings.json add connectionstring
    In program.cs add builder.service and connect to database
    create model file add columns of the Database
    create cs file for ApplicationDbContext

    open Package Manager Console (view -> other windows -> Package Manager Console)
    write command "add-migration initialmigrate"
    Now this Command"update-database"
    
    Now create controller, view, model and creates a webpage
  
