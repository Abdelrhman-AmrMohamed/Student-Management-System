**Student Management System API**
- A Web API for managing students and departments, providing an interactive and structured environment for learning management and administration. Supports CRUD operations on students and departments with JWT authentication, validation, and centralized error handling.

**Features**
- CRUD operations on Students and Departments
- List all students and departments
- Fetch a student by ID
- Add, edit, and delete students
- JWT-based authentication
- Email confirmation for user actions
- Pipeline behavior for validation & generic responses
- Centralized error handling via middleware

**Endpoints**

**Student**
- GET /Student/List – Get all students
- GET /Student/ByID – Get a student by ID
- POST /Add/Student – Add a new student
- PUT /Edit/Student/{id} – Update student details
- DELETE /Edit/Student/{id} – Delete a student

**Department**
- GET /Department/List – Get all departments

**Technologies Used**
- C#
- ASP.NET Core Web API
- JWT Authentication
- AutoMapper
- Repository Pattern
- MediatR & CQRS
- Middleware-based error handling

**Future Improvements**
- Add Courses module
- Implement Role-based authentication
- Add Department CRUD endpoints
- Enhance validation and error handling
