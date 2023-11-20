# KodeProExercise1
Here I have uploaded the resolution of the Develop a WinForms Application with SQL Server Integration exercise

----------
The main class is "Form1.cs", here a simple interface was defined to meet the criteria of the exercise.
So, first of all... We run the script (DBScript.sql) to create the DB, tables and populate this tables. (SQLExpress)

In order to easily carry out the integration with the database, the strategy of dependency injection, interface segregation, and using EF in combination with the LINQ language to make the queries was used.
First we replicate the database using Database First Approach, we define an interface with the main method that is going to take care of all the work.

First we replicate the database using Database First Approach, we define an interface with the main method that is going to take care of all the work. We also define some DTOs to handle queries that may arrive and the corresponding responses.
With this, I believe I have fulfilled the requirements of this first exercise.
