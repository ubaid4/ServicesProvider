<p align="center">
<h1 align="center">ServicesProvider</h1>
<h3 align="center"><strong>Powerful .NET 8 Services Provider APIs</strong></h3>
<p align="center">Extend your application with it and customize it as per your own requirements <p>



Live demo : [Services Provider Live](https://sp-azure-container.politesea-3d1e9621.australiaeast.azurecontainerapps.io)

# Core Features:
- **User Registration:**
- **Account Verification:** tr e rt er t
   - item1
   - item2
- **OAuth2.0 standard:** *Access token* for short time and *Refresh token* for longer time to generate new *Access token* after validation.
- **Role-Base Permissions:**
- **Cloud Storage:**
- **Builder Pattern:** some text
- **Serverless architecture:** 
- **Monitoring Logs:**

# Technologies

 - [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
 - [EntityFramework](https://learn.microsoft.com/en-us/ef/)
 - [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
 - [Microsoft Dependency Injection (DI)](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
 - [Azure Storage](https://azure.microsoft.com/en-us/products/storage/blobs)
 - [JWT](https://jwt.io/)
 - [Docker](https://www.docker.com/)
 - [Serilog](https://serilog.net/)
 - [Swashbuckle (Swagger)](https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio)

 - [AutoMapper](https://automapper.org/)

 ## Clean Architecture
 This application is followed by clean architecture:


<img src='./ServicesProvider.UI/wwwroot/images/clean-arch.png' height="500" >

## Solid Principles

## Repository Pattern

## Role

Here is  the list roles :

| Sr. | RoleName |
| --- | -------- |
| 1   | Admin    |
| 2   | Manager  |
| 3   | User     |


# Role's Permissions

### Admin Permissios:


| Module     | CanAdd | CanEdit | CanView | CanDelete |
| -------------- | :------: | :-------: | :-------: | :---------: |
| Dashboard      |  ✔      | ✔       | ✔       | ✔         |
| Users          | ✔      | ✔       | ✔       | ✔         |
| Roles          | ✔      | ✔       | ✔       | ✔         |
| Categories     | ✔      | ✔       | ✔       | ✔         |
| CoreActivities | ✔      | ✔       | ✔       | ✔         |
| Services       | ✔      | ✔       | ✔       | ✔         |
| AzureStorage   | ✔      | ✔       | ✔       | ✔         |


### Manager Permissions:


|   Module          | CanAdd | CanEdit | CanView | CanDelete |
| --------------- | :----: | :-----: | :-----: | :-------: |
| Dashboard       |   ✖    |    ✖    |    ✔    |    ✖      |
| Users           |   ✖    |    ✖    |    ✔    |    ✖      |
| Roles           |   ✖    |    ✖    |    ✔    |    ✖      |
| Categories      |   ✔    |    ✔    |    ✔    |    ✖      |
| CoreActivities  |   ✔    |    ✔    |    ✔    |    ✖      |
| Services        |   ✔    |    ✔    |    ✔    |    ✔      |
| AzureStorage    |   ✔    |    ✔    |    ✔    |    ✔      |


### User Permissions: 

  


 | ModuleName     | CanAdd | CanEdit | CanView | CanDelete |
  | -------------- | :------: | :-------: | :-------: | :---------: |
  | Categories     | ✖      | ✖       | ✔       | ✖         |
  | CoreActivities | ✖      | ✖       | ✔       | ✖         |
  | Services       | ✖      | ✖       | ✔       | ✖         |
  | AzureStorage   | ✔      | ✖       | ✔       | ✖         |
  


## Users
Here is the list of Users:


| UserName | Email            | Password  | Roles |
| -------- | :---------------- | ---------: |---------: |
| Alex     | alex@gmail.com  | Alex!510  |Admin|
| Stark    | stark@gmail.com | Stark@281 |Admin|
| John     | john@gmail.com  | John*412  |Manager, User|
| Chris    | chris@gmail.com | Chris#561 |Manager|
| Mike     | mike@gmail.com  | Mike&843  |User|
| Sara     | sara@gmail.com  | Sara$743  |User|



