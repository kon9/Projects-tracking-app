#Project Management Application

A program for entering and managing data about projects into a database.

Features:
Ability to create/view/edit/delete information about projects and employees.
Ability to add and delete employees from a project.
Filtering by date range, start date, priority, etc. and sorting by basic fields.

The application uses a three-layer architecture and is built with the following technologies:
Automapper for mapping between the domain and the presentation layer.
Mediatr for handling command and query requests.
EntityFrameworkCore (ORM)
Asp.net Core

Information stored in the database includes:

Project name
Project tasks
Name of the client company
Name of the executing company
Employee data (name, surname, projects that employee working on, and email address of the person)
Information about the project manager
Project start and end dates
Project priority
