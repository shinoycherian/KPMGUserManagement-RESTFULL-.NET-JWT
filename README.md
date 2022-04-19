# KPMGUserManagement-RESTFULL-.NET-JWT

Project
--
Test solution based on .NET C# ,to manage simple user management.


Design and Architecture
--
The technical architecture focus on the multi-layer-based solution.
The design approach is based on architecture which supports the further evolution of domain model and future business requirement that might arise in future.

DataLayer
-
-	KPMGUserManagementDBContext
         Manages DB connectivity and model creation.
-	Repository interfaces and implementations manages the data operations.
-	UnitOfWork objects and interfaces for managing transactions.
-	Factory manages object creation.

Business Domain Layer
-
The features to existing business objects and new business objects can be added with minimal changes.
-	IProductBusiness interface and corresponding implementation manages business operations related to product.

ApplicationLayer

-	UserService Interfaces and implementation to manage the service that calls the User Business objects which provide the usermanagement related operation.
-	The Model related classes are kept in Application layer
-	Mapper object to translate between business models and presentation models.

API Layer
-
-	User Controller manages the request related to user management related operations.


Testing
-
-	UnitTest project to test basic tests using MS Test

Coding principle
-
-	SOLID approach
-	Domain Driven

Design patterns
-
Repository
UoW
IoC Dependency Injection
Factory
Adapter


Tools , technologies, platforms
-
-	Language & Platforms: C# ,ASP.Net Core, .Net 5/.Net Core, Web API
-	Database : SQL server (localdb)
-	ORM : Entity Framework
-   Security is implemnted based on JWT and ASP.NET Authentication/ of users 
-	Unit Testing :MS Test ,Moq frame work
        
External Packages
-
Unity IoC ,Autofac Mapper,JWTBearer

TO DO
-
-	Improve the data model with more business objects and corresponding data models.
-	Manage the validation of data at different levels.
-	Exception handling and logging.
-	More unit tests to cover the framework ,objects and functions at different layers