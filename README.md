<p align="center">
<h1 align="center">ServicesProvider</h1>
<h3 align="center"><strong>Powerful .NET 8 Services Provider APIs</strong></h3>
<p align="center">Extend your application with it and customize it as per your own requirements <p>



Live demo : [Services Provider Live](https://sp-azure-container.politesea-3d1e9621.australiaeast.azurecontainerapps.io)

# Core Features:
- **User Registration:** Allow users to sign up with their unique email address and strong password.
- **Account Verification:** Upon registration, create a verification token which could: 
   - Sent to registered email address, inside a unique link
   - be  used to verify his account by htting the specified end point using swagger, postman or anyother http(s) supported way. 
- **OAuth2.0 standard:** Utilize OAuth2.0 for secure authentication and authorization:
   - Implement Access Tokens with short expiration times and Refresh Tokens for longer-term authentication.
   - Define token endpoints for generating new Access Tokens using Refresh Tokens after validation.
- **Role-Base Permissions:** Each module's End Points, excluding Accounts, require seprate Authorization to access.
   - Implemented role-based access control (RBAC) to define different levels of permissions for users.
   - Define roles such as Admin, User, etc., and assign appropriate permissions to each role.
- **Cloud Storage:** Integrated with ***Azure Blob Storage*** for scalable and cost-effective storage of media file.
- **Builder Pattern:** Utilized the Builder Pattern for creating complex objects with flexible configurations.
- **Serverless architecture:** Docker Image created  while publishing the application:
   - Uses Azure Container Registory (ACR) to store that Image, Application Image upload on this Registory
   - Azure Container App configured with that registory, which run the Application Image,  create access url and make  available this app for users.
- **Monitoring Logs:** Implement logging mechanisms to capture application events and errors for monitoring and debugging purposes.
   - Utilize Serilog framework to store logs centrally and analyze them efficiently.





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

| Sr. | Role Name |Default Role|
| --- | -------- |:---:|
| 1   | Admin    |✖|
| 2   | Manager  |✖|
| 3   | User     |✔|


# Role's Permissions

**Admin Permissions:**


| Module Name     | CanAdd | CanEdit | CanView | CanDelete |
| -------------- | :------: | :-------: | :-------: | :---------: |
| Dashboard      |  ✔      | ✔       | ✔       | ✔         |
| Users          | ✔      | ✔       | ✔       | ✔         |
| Roles          | ✔      | ✔       | ✔       | ✔         |
| Categories     | ✔      | ✔       | ✔       | ✔         |
| CoreActivities | ✔      | ✔       | ✔       | ✔         |
| Services       | ✔      | ✔       | ✔       | ✔         |
| AzureStorage   | ✔      | ✔       | ✔       | ✔         |


**Manager Permissions:**


|   ModuleName          | CanAdd | CanEdit | CanView | CanDelete |
| --------------- | :----: | :-----: | :-----: | :-------: |
| Dashboard       |   ✖    |    ✖    |    ✔    |    ✖      |
| Users           |   ✖    |    ✖    |    ✔    |    ✖      |
| Roles           |   ✖    |    ✖    |    ✔    |    ✖      |
| Categories      |   ✔    |    ✔    |    ✔    |    ✖      |
| CoreActivities  |   ✔    |    ✔    |    ✔    |    ✖      |
| Services        |   ✔    |    ✔    |    ✔    |    ✔      |
| AzureStorage    |   ✔    |    ✔    |    ✔    |    ✔      |


**User Permissions:** 

  


 | ModuleName     | CanAdd | CanEdit | CanView | CanDelete |
  | -------------- | :------: | :-------: | :-------: | :---------: |
  | Categories     | ✖      | ✖       | ✔       | ✖         |
  | CoreActivities | ✖      | ✖       | ✔       | ✖         |
  | Services       | ✖      | ✖       | ✔       | ✖         |
  | AzureStorage   | ✔      | ✖       | ✔       | ✖         |
  


## Users
Here is the list of Users with their Roles:



| UserName | Email            | Password  | Role(s) |
| -------- | :---------------- | :--------- | :--------- | 
| Alex     | alex@gmail.com  | Alex!510  |Admin|
| Stark    | stark@gmail.com | Stark@281 |Admin|
| John     | john@gmail.com  | John*412  |Manager, User|
| Chris    | chris@gmail.com | Chris#561 |Manager|
| Mike     | mike@gmail.com  | Mike&843  |User|
| Sara     | sara@gmail.com  | Sara$743  |User|


### Note:
> The Users with Admin Role are Not availalbe on **live Server**, but will work if you download this repo and run it locally.

>you can use `UserName` or `Email` with Password to signIn.