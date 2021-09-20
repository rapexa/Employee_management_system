# Employee_management_system
Employee management system focuses on the employee to ensure they are performing their best in order to achieve bigger organizational goals. In doing so, teams can capitalize on employee strengths and needs to maximize on a functional and efficient workplace.

## How to run

TODO: make best document for it after project `its just a simple one`

0. Install Visual Studio, MySQL in your system.

[+] create a new database and first table:

1. run this comand in MYSQL database : `CREATE DATABASE Employee;`

2. run this comand in MYSQL database : `CREATE USER 'ADMIN_ROOT'@'localhost' IDENTIFIED BY 'Employer';`   #user,pass

3. run this comand in MYSQL database : `GRANT ALL PRIVILEGES ON Employee.* TO 'ADMIN_ROOT'@'localhost';`

4. run this comand in MYSQL database : `use employee;`

5. run this comand in MYSQL database : `DROP TABLE IF EXISTS ALL_USERS;`

6. run this comand in MYSQL database : `CREATE TABLE ALL_USERS (id INT AUTO_INCREMENT,UName VARCHAR(255),Password VARCHAR(255),PRIMARY KEY (id));`

After creating the new table, open Visual Studio and click on New Project and name the project. It will open the new project, then click on Solution Explorer (F4), right click on “Reference” to add a new reference into the project. Reference those two .dll files to the project (MySql.dll (Win apps), MySql.web.dll (Web apps)).

<https://www.codeproject.com/KB/database/423233/image004.jpg>

