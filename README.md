# MITA Backend - .NET (ASP.NET Core)

ASP.NET Core 10 backend for the Mini Issue Tracker Application.

## Tech Stack

- **.NET 10 / ASP.NET Core 10**
- **Swagger/OpenAPI** (Swashbuckle)
- **Entity Framework Core** (to be implemented)
- **MySQL** (via Pomelo provider, to be implemented)

## Getting Started

### Prerequisites

- .NET 10 SDK
- MySQL 8.0 (for later implementation)

### Running the Application

```bash
# Clone with submodule
git clone --recurse-submodules https://github.com/vmatviichuk-epam/mita-backend-dotnet.git
cd mita-backend-dotnet

# Restore and run
dotnet restore
dotnet run
```

The API will be available at `http://localhost:5000`

Swagger UI: `http://localhost:5000/swagger`

## API Endpoints

### Implemented (Skeleton)

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/login` | Login (returns mock JWT) |

### To Implement (Workshop)

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | User registration |
| POST | `/api/auth/logout` | User logout |
| GET | `/api/issues` | List user's issues |
| POST | `/api/issues` | Create issue |
| GET | `/api/issues/{id}` | Get issue |
| PUT | `/api/issues/{id}` | Update issue |
| DELETE | `/api/issues/{id}` | Delete issue |

## Testing the Login Endpoint

```bash
curl -X POST http://localhost:5000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username": "testuser", "password": "password123"}'
```

Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwidXNlcm5hbWUiOiJ0ZXN0dXNlciJ9.MOCK",
  "user": {
    "id": 1,
    "username": "testuser"
  }
}
```

## Project Structure

```
.
├── Controllers/
│   └── AuthController.cs      # Authentication endpoints
├── Models/
│   ├── LoginRequest.cs
│   ├── LoginResponse.cs
│   ├── UserDto.cs
│   └── ErrorResponse.cs
├── Program.cs                 # Application entry point & configuration
├── appsettings.json           # Configuration
└── Mita.csproj                # Project file
```

## Workshop Tasks

1. **Database Setup** - Add EF Core with MySQL, create entities
2. **User Registration** - Implement `/api/auth/register` with password hashing
3. **JWT Authentication** - Configure JWT Bearer authentication
4. **Issue CRUD** - Implement all issue endpoints
5. **User Isolation** - Ensure users can only access their own issues

## API Contract

See [mita-api-contract](https://github.com/vmatviichuk-epam/mita-api-contract) for the OpenAPI specification.

## License

MIT
