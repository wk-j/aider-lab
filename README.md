# MyApp

MyApp is a .NET Core web application that demonstrates basic API functionality.

## Usage

To build and test the project, follow these steps:

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/MyApp.git
   cd MyApp
   ```

2. Build the project:
   ```
   dotnet build
   ```

3. Run the tests:
   ```
   dotnet test tests/MyApp.Tests/MyApp.Tests.csproj
   ```

4. Run the application:
   ```
   dotnet run --project src/MyApp/MyApp.csproj
   ```

The application will start, and you can access the API endpoints using tools like curl, Postman, or by navigating to `http://localhost:5094/swagger` in your web browser to use the Swagger UI.
