# Dummy dataset seeder for SQL Server
This script uses Faker.net library to generate dummy datasets to then be inserted into a SQL Server database via Entity Framework Core.
By default, it generates datasets with around 15 million records across 8 tables and can be used to simulate a real database.
For this use case, the database structure resembles a simple online store.

![C#](https://img.shields.io/badge/c%23-%23178600.svg?style=for-the-badge&logo=csharp&logoColor=white)
[![License](https://img.shields.io/github/license/Loupeznik/SqlServerDataSeeder?style=for-the-badge)](./LICENSE)

Note that as the datasets are so large, the program might take several hours to 
complete and the generated records can take several gigabytes of your database server's storage.
