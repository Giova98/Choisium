````markdown
# Diagrama de Clases - Choisium

classDiagram

class User {
    int Id
    string CompleteName
    string Email
    string Password
}

class Project {
    int Id
    string Name
    string Description
    ProjectStatus Status
    int UserId
}

class Task {
    int Id
    string Description
    TaskStatus Status
    int ProjectId
}

class Option {
    int Id
    string Name
    decimal Score
    OptionStatus Status
    int TaskId
}

User "1" --> "0..*" Project
Project "1" --> "0..*" Task
Task "1" --> "0..*" Option