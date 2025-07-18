# Task Manager API (Backend - .NET Core)

A lightweight RESTful API for managing tasks. Built using **.NET Core** and **Entity Framework Core**, this backend allows clients to retrieve all tasks, add new tasks, and toggle task completion status.

---

## 🔧 Features

- ✅ Get all tasks
- ➕ Create a new task
- 🔁 Toggle the "completed" status of a task

---

## 🏗️ Tech Stack

- [.NET Core 7.0+](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SQLite](https://www.sqlite.org/) or In-Memory DB
- Minimal API or Clean Architecture (depending on your structure)

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
├── Services/ # Business logic layer (optional)
│ └── TaskService.cs
├── Repositories/ # Data access layer (optional)
│ └── TaskRepository.cs
└── appsettings.json # App configuration file
```

---

## 🚀 Getting Started

### 1. Clone the Repository

```
bash git clone https://github.com/your-username/task-manager-api.git
cd task-manager-api
```

### 1. Run the Application
```
dotnet run
```

## 🛠️ API Endpoints

### ✅ Get All Tasks

```
GET /api/tasks
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
POST /api/tasks
Content-Type: application/json

{
  "title": "Buy groceries"
}
```

### 🔁 Toggle Task Completion

```
PUT /api/tasks/{id}/toggle

{
  "id": 2,
  "title": "Buy groceries",
  "description": "Milk, Eggs, Bread",
  "isCompleted": true
}
```
