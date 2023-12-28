<h1 align='center'> Simple Website </h1>

<h3 align='center'> Database </h3>
<p align='center'>
  <a href="#">
      <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white" />        
  </a>
</p>

<h3 align='center'> Languages </h3>
<p align='center'>
  <a href="#">
      <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
  </a> 
  &nbsp;&nbsp;
  <a href="#">
      <img src="https://img.shields.io/badge/JavaScript-323330?style=for-the-badge&logo=javascript&logoColor=F7DF1E" />        
  </a>
  &nbsp;&nbsp;
  <a href="#">
      <img src="https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white" />        
  </a>
  &nbsp;&nbsp;
  <a href="#">
      <img src="https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white" />        
  </a>
</p>

<h3 align='center'> Framework </h3>
<p align='center'>
  <a href="#">
      <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />        
  </a>
</p>


---


<h3 align='center'> This website is created using <a href=https://dotnet.microsoft.com/en-us/apps/aspnet> ASP.NET Core </a> ( <a href=https://learn.microsoft.com/en-us/aspnet/core/mvc/> MVC </a> ) </h3>

<p align='center'>
  This website is created for one simple reason- for it to be barnched for more trials.
</p>
  
<p align='center'>
  This website shall remain untouched in the future and any modicications to be made <i> only </i> for version updates
</p>


---


# Content available

This website resembles [Microsoft documentation for First MVC App](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/)


### Brief 
- The website contains of a **Post page** besides **Home page** and **Privacy page**. 
- User can `Create` `Edit` and `Delete` posts.
- Post has a `Title` and `Description`
- Post has a `Detail` page which displays the post content besides `Index` page


## Created Files available

### MVVMC
<sub> [MVC] + [MVVM] </sub>
- Models
  - PostModel
  
- View
  - Index
  - Create
  - Edit
  - Delete
  - Detail
 
- ViewModel
  - PostCreateViewModel
  - PostEditViewModel

- Controllers
  - PostController

[MVC]:https://learn.microsoft.com/en-us/aspnet/core/mvc/
[MVVM]:https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm

### Database
- Data
  - DatabaseContext
 
- Migrations

### Additional
- Interfaces
  - IPostInterface

- Repository
  - PostRepository


---


## [NuGet Packages]
### [Bootstrap]
> The most popular front-end framework for developing responsive, mobile first projects on the web.

### [CloudinaryDotNet]
> The Cloudinary .NET SDK allows you to quickly and easily integrate your application with Cloudinary. Effortlessly optimize, transform, upload and manage your cloud's assets.
- Documentation [here](https://cloudinary.com/documentation/)

### [Microsoft.AspNetCore.Identity.EntityFrameworkCore]
> ASP.NET Core Identity provider that uses Entity Framework Core.
- The package was built from this [source code](https://github.com/dotnet/aspnetcore/tree/3f1acb59718cadf111a0a796681e3d3509bb3381)

### [Microsoft.EntityFrameworkCore]
> Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations. EF Core works with SQL Server, Azure SQL Database, SQLite, Azure Cosmos DB, MySQL, PostgreSQL, and other databases through a provider plugin API.
- Commonly Used Types:
  - Microsoft.EntityFrameworkCore.DbContext
  - Microsoft.EntityFrameworkCore.DbSet

### [Microsoft.EntityFrameworkCore.SqlServer]
> Microsoft SQL Server database provider for Entity Framework Core.

### [Microsoft.EntityFrameworkCore.Tools]
> Entity Framework Core Tools for the NuGet Package Manager Console in Visual Studio.
- Enables these commonly used commands:
  - Add-Migration
  - Bundle-Migration
  - Drop-Database
  - Get-DbContext
  - Get-Migration
  - Optimize-DbContext
  - Remove-Migration
  - Scaffold-DbContext
  - Script-Migration
  - Update-Database

[NuGet Packages]: https://www.nuget.org/
[Bootstrap]: https://www.nuget.org/packages/bootstrap
[CloudinaryDotNet]: https://www.nuget.org/packages/CloudinaryDotNet
[Microsoft.AspNetCore.Identity.EntityFrameworkCore]: https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore
[Microsoft.EntityFrameworkCore]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore
[Microsoft.EntityFrameworkCore.SqlServer]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer
[Microsoft.EntityFrameworkCore.Tools]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools
