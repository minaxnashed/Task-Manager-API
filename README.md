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

TaskManagerApi/
│
├── Program.cs // API entry point
├── Models/ // Task entity models
├── Data/ // EF Core DbContext and Seed data
├── Controllers/ // API endpoints
├── Services/ // Business logic (optional, for clean separation)
└── Repositories/ // Data access layer (optional, for clean architecture)

---

## 🚀 Getting Started

### 1. Clone the Repository

```
bash git clone https://github.com/your-username/task-manager-api.git
cd task-manager-api ```
```

### 1. Run the Application
dotnet run

## 🛠️ API Endpoints

### ✅ Get All Tasks

```
http
GET /api/tasks
[
  {
    "id": 1,
    "title": "Buy groceries",
    "isCompleted": false
  }
]
```


