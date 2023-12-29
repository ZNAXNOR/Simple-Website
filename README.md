<h1 align='center'> Simple Website </h1>

<div align='center'>

<table>
  
  <tr> </tr>
  
  <td valign="top" width="33%">
    
  ## Database  
  <div align="center">  
    <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white" />
  </div>
  
  </td>


  <td valign="top" width="33%">
    
  ## Languages  
  <div align="center">
    <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
    <img src="https://img.shields.io/badge/JavaScript-323330?style=for-the-badge&logo=javascript&logoColor=F7DF1E" />
    <img src="https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white" />
    <img src="https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white" />
  </div>
  
  </td>

  
  <td valign="top" width="33%">
    
  ## Framework  
  <div align="center">  
    <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  </div>   
  
  </td>
    
  </tr>
</table> 

</div>

<br/>  

---


> [!Important]
> ### This website is created using [ASP.NET Core] ( [MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/) )
>
> This website is created for one simple reason- for it to be barnched for more trials.
>
> This website shall remain untouched in the future and any modicications to be made <i> only </i> for version updates

[ASP.NET Core]:https://dotnet.microsoft.com/en-us/apps/aspnet


---


# Content available
This website resembles [Microsoft documentation for First MVC App](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/)


> [!Note]
> The website contains of a **Post page** besides **Home page** and **Privacy page**.
> 
> User can `Create` `Edit` and `Delete` posts.
> 
> Post has a `Title` and `Description`
> 
> Post has a `Detail` page which displays the post content besides `Index` page


## Created Files available
### MVVMC
<sub> [MVC] + [MVVM] </sub>

<details>
<summary> MVVMC Files </summary>
  
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
</details>

[MVC]:https://learn.microsoft.com/en-us/aspnet/core/mvc/
[MVVM]:https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm


### Database

<details>
<summary> Database Files </summary>
  
- Data
  - DatabaseContext
 
- Migrations
  
</details>

### Additional

<details>
<summary> Additional Files </summary>
  
- Interfaces
  - IPostInterface

- Repository
  - PostRepository
    
</details>

---


## [NuGet Packages]
### [Bootstrap]
<details>
<summary> Description </summary>
  
> The most popular front-end framework for developing responsive, mobile first projects on the web.

</details>


### [Microsoft.AspNetCore.Identity.EntityFrameworkCore]
<details>
<summary> Description </summary>
  
> ASP.NET Core Identity provider that uses Entity Framework Core.

</details>

> [!Note]
> The package was built from this [source code](https://github.com/dotnet/aspnetcore/tree/3f1acb59718cadf111a0a796681e3d3509bb3381)


### [Microsoft.EntityFrameworkCore]
<details>
<summary> Description </summary>
  
> Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations. EF Core works with SQL Server, Azure SQL Database, SQLite, Azure Cosmos DB, MySQL, PostgreSQL, and other databases through a provider plugin API.

</details>

> [!Tip]
> Commonly Used Types:
>  - Microsoft.EntityFrameworkCore.DbContext
>  - Microsoft.EntityFrameworkCore.DbSet


### [Microsoft.EntityFrameworkCore.SqlServer]
<details>
<summary> Description </summary>
  
> Microsoft SQL Server database provider for Entity Framework Core.

</details>


### [Microsoft.EntityFrameworkCore.Tools]
<details>
<summary> Description </summary>
  
> Entity Framework Core Tools for the NuGet Package Manager Console in Visual Studio.

</details>

> [!Tip]
> - Enables these commonly used commands:
>   - Add-Migration
>   - Bundle-Migration
>   - Drop-Database
>   - Get-DbContext
>   - Get-Migration
>   - Optimize-DbContext
>   - Remove-Migration
>   - Scaffold-DbContext
>   - Script-Migration
>   - Update-Database


[NuGet Packages]: https://www.nuget.org/
[Bootstrap]: https://www.nuget.org/packages/bootstrap
[CloudinaryDotNet]: https://www.nuget.org/packages/CloudinaryDotNet
[Microsoft.AspNetCore.Identity.EntityFrameworkCore]: https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore
[Microsoft.EntityFrameworkCore]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore
[Microsoft.EntityFrameworkCore.SqlServer]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer
[Microsoft.EntityFrameworkCore.Tools]: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools
