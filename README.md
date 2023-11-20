# KodeProExercise1
Here I have uploaded the resolution of the Develop a WinForms Application with SQL Server Integration exercise

----------
The main class is "Form1.cs", here a simple interface was defined to meet the criteria of the exercise.
So, first of all... We run this scripts to create the DB, tables and populate this tables. (SQLExpress)

-- WE CREATE THE BD
CREATE DATABASE KODEPROExercise; 
USE KODEPROExercise;

-- SCHOOL TABLE
CREATE TABLE school (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    id_country INT
);

-- STUDENT TABLE WITH THE FK
CREATE TABLE student (
    identity_card INT PRIMARY KEY,
    names VARCHAR(255),
    surnames VARCHAR(255),
    date_of_birth DATE,
    id_school INT,
    FOREIGN KEY (id_school) REFERENCES school(id)
);

-- FILL WITH SOME VALUES
INSERT INTO student (identity_card, names, surnames, date_of_birth, id_school) VALUES
(1001, 'John', 'Smith', '2000-01-01', 1),
(1002, 'Maria Jose', 'Prado Aguirre', '2000-02-02', 2),
(1003, 'Vincent', 'Montecarlo Rojas', '2000-03-03', 3),
(1004, 'Alice Johnson', 'Hernandez Rojas', '2000-04-04', 1),
(1005, 'Michael', 'Brown', '2000-05-05', 2),
(1006, 'Sophia', 'Williams', '2000-06-06', 3),
(1007, 'David', 'Davis', '2000-07-07', 1),
(1008, 'Emma', 'Miller', '2000-08-08', 2),
(1009, 'James', 'Martinez', '2000-09-09', 3),
(1010, 'Olivia', 'Anderson Romero', '2000-10-10', 1),
(1011, 'William Mathews', 'Garcia', '2000-11-11', 2),
(1012, 'Ava', 'Rodriguez Nano', '2000-12-12', 3),
(1013, 'Ethan', 'Taylor', '2001-01-01', 1);

In order to easily carry out the integration with the database, the strategy of dependency injection, interface segregation, and using EF in combination with the LINQ language to make the queries was used.
First we replicate the database using Database First Approach, we define an interface with the main method that is going to take care of all the work.

First we replicate the database using Database First Approach, we define an interface with the main method that is going to take care of all the work. We also define some DTOs to handle queries that may arrive and the corresponding responses.
With this, I believe I have fulfilled the requirements of this first exercise.
