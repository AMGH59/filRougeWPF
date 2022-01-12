
# filRougeWPF

This project is an admin version of [fil-rouge-APS](https://github.com/AMGH59/fil-rouge-ASP) project (support platform between registered users).  
This application will allow to manage users registered, questions and answers posted too.  
  
As we said, this project is linked to [fil-rouge-APS](https://github.com/AMGH59/fil-rouge-ASP), so we used the same Database for both of them.



## Authors

- [@AMGH59](https://www.github.com/AMGH59)
- [@vinceLer](https://www.github.com/vinceLer)


## Prerequisites

- ASP NET Core
- EntityFramework
- Visual Studio
- SQL Server
## Run Locally

Clone the project

```bash
  git clone https://github.com/AMGH59/filRougeWPF
```

Go to the project directory

```bash
  cd filRougeWPF
```



## Installation

Database Initialization  
Check if Database and DataContext (DbContext) are connected, and run this command from the project.

```bash
  dotnet ef database update
```
or run this one from the Package Manager Console  
```bash
  update-database
```
