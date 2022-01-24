Project
--
Test Project for Mover interview ,to manage simple inventory management

Design and Architecture
--
The technical architecture focus on the multi-layer-based solution.
The design approach is based on architecture which supports the further evolution of domain model and future business requirement that might arise.

DataLayer
-
-	MoverInventoryDBContext
         Manages DB connectivity and model creation.
-	Repository interfaces and implementations manages the data operations.
-	UnitOfWork objects and interfaces for managing transactions.
-	Factory manages object creation.

Business Domain Layer
-
The features to existing business objects and new business objects can be added with minimal changes.
-	IProductBusiness interface and corresponding implementation manages business operations related to product.

ApplicationLayer
-
-	WatchHands Interfaces and implementation to manage the service that provide the CalculateLeast angle operation.
-	Product Interfaces and implementation to manage the service that provide the inventory related operation.
-	The Model related classes are kept in Application layer
-	Mapper object to translate between business models and presentation models.

API Layer
-
-	Product Controller manages the request related to product related operations.
-	CalculateLeastAngle Controller manages the request related to WatchHand related operations.

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
IoC
Factory
Adapter


Tools , technologies, platforms
-
-	Language & Platforms: C# ,ASP.Net Core, .Net 5/.Net Core, Web API
-	Database : SQL server (localdb)
-	ORM : Entity Framework
-	Unit Testing :MS Test ,Moq frame work
        
Packages
-
Unity IoC ,Autofac Mapper

TO DO
-
-	Improve the data model with more business objects and corresponding data models.
-	Manage the validation of data at different levels.
-	Exception handling and logging.
-	More unit tests to cover the framework ,objects and functions at different layers
