#!!!!!SETUP STEPS!!!!!
 Update host file on your PC 
   like this instruction https://www.nublue.co.uk/guides/edit-hosts-file/#:~:text=In%20Windows%2010%20the%20hosts,%5CDrivers%5Cetc%5Chosts.
   
Need to path these lines

    127.0.0.1 www.alevelwebsite.com
    0.0.0.0 www.alevelwebsite.com
    192.168.0.4 www.alevelwebsite.com

#docker
docker-compose build --no-cache

docker-compose up

#Add-Migration
dotnet ef --startup-project Catalog/Catalog.Host migrations add InitialMigration --project Catalog/Catalog.Host

#Update-Migration
dotnet ef --startup-project Catalog/Catalog.Host database update InitialMigration --project Catalog/Catalog.Host

#Remove-Migration
dotnet ef --startup-project Catalog/Catalog.Host migrations remove --project Catalog/Catalog.Host -f

We might need to add a migration in the "Catalog" and "Order" projects, there are postgreSQL databases. Without migrations there will not be databases, thus no products in the catalog and
no functionality in this sample (I am not sure whether or not it is necessary to add migration on another PC, maybe it is just enough to rebuild a solution in Visual Studio, on my own I have added migrations via VS Package Manager Console).
Anyway, check folders Migrations in Order, Catalog they should not be empty.

After we made all steps, setup file hosts, install Docker (for windows needs a WSL first to be installed then a Docker), we can 1) run the Docker program; 2) open a terminal in a folder of the sample,
write 1) docker-compose build --no-cache; 2) docker-compose up. The project on containers should be deployed in Docker (you should see a set of containers in Docker: Ide.basket.api, Ide.catalog.api, Ide.order.api, Ide.postgres...).
Now we can access and test the functionality of the project:
1. http://www.alevelwebsite.com:5001/  -- WEB
2. http://www.alevelwebsite.com:5000/swagger/index.html -- Swagger for catalog.
3. http://www.alevelwebsite.com:5005/swagger/index.html -- Swagger for basket.
4. http://www.alevelwebsite.com:5006/swagger/index.html -- Swagger for order.

There is an Authorization and Authentication in the project, so to test it's functionality you need some login and password, use:
1. Login: alice, password: alice.

Or

2. Login: bob, password: bob.

Key idea of this project was to learn how to write an API/Bff Controllers for a WEB, but WEB received less attention.