# Task Manager API (Backend - .NET Core)

A lightweight RESTful API for managing tasks. Built using **.NET Core** and **Entity Framework Core**, this backend allows clients to retrieve all tasks, add new tasks, and toggle task completion status.

---

## 🔧 Features

- ✅ Get all tasks
- ➕ Create a new task
- 🔁 Toggle the "completed" status of a task
- ❌ Delete a task

---

## 🏗️ Tech Stack

- [.NET Core 7.0+](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SQLite](https://www.sqlite.org/) or In-Memory DB

---

## 📁 Project Structure

```
TaskManagerApi/
├── Program.cs # Entry point of the application
├── Models/ # Task entity definitions
│ └── Task.cs
├── Data/ # EF Core DbContext and seed data
│ └── AppDbContext.cs
├── Controllers/ # HTTP route handlers
│ └── TaskController.cs
├── Services/ 
│ └── TaskService.cs
├── Repositories/ # Data access layer
│ └── ITaskRepository.cs
| └── TaskRepository.cs
└── appsettings.json # App configuration file
```

---

## 🚀 Getting Started

### 📦 Prerequisites

- 🧰 [Git](https://git-scm.com/) – for cloning the repository  
- 🧱 [.NET 8 SDK](https://dotnet.microsoft.com/download) – for building and running the backend  

### 1. Clone the Repository

```
git clone https://github.com/minaxnashed/task-manager-api.git
cd task-manager-api
```

### 1. Run the Application
```
dotnet run
```

### 🔧 Optional: Run on a Specific Port
If you want to override the default port (from launchSettings.json), you can specify a custom port like this:
```
dotnet run --urls=http://localhost:5010
```

## 🛠️ API Endpoints

### ✅ Get All Tasks

```
GET /tasks
[
  {
    "id": 1,
    "title": "Buy groceries",
    "isCompleted": false
  }
]
```

### ➕ Create a New Task
```
POST /tasks
Content-Type: application/json

{
  "title": "Buy groceries"
}
```

### 🔁 Toggle Task Completion
```
PUT /tasks/{id}/toggle

{
  "id": 2,
  "title": "Buy groceries",
  "description": "Milk, Eggs, Bread",
  "isCompleted": true
}
```

### ❌ Delete a Task
```
DELETE /tasks/{id}
```


## ⚙️ launchSettings.json Overview

The launchSettings.json file configures how the ASP.NET Core application is launched during development. It defines profiles for running the app via different protocols (e.g., HTTP and HTTPS) with settings such as ports, browser behavior, and environment variables.

### 📁 Example: Development Profiles
```
{
  "profiles": {
    "http": {
      "applicationUrl": "http://localhost:5010",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "applicationUrl": "https://localhost:7190;http://localhost:5010",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## 🔍 Key Properties
- commandName: Tells the IDE to launch the project.
- launchBrowser: If true, the default browser opens on run.
- applicationUrl: Specifies the URLs where the app will be available.
- environmentVariables: Sets ASPNETCORE_ENVIRONMENT to Development, enabling detailed errors, Swagger, etc.

