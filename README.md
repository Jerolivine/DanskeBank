[ReadMe.txt](https://github.com/Jerolivine/DanskeBank/files/7037288/ReadMe.txt)

To migrate database

1) set startup project as DanskeBank.API
2) Select DanskeBank.Infrastructure.EntityFramework.Core as selected library before you run add-database and update-database migration codes
3) remove the comment at the function named OnConfiguring in EFCoreDbContext class

To Run the project

1) Set as startup project as docker-compose
2) add comment at the function named OnConfiguring in EFCoreDbContext class


