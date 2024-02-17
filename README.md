# trackhab

> A habit management API written in C#

## Setting up and running the project

```bash
git clone https://github.com/paulbgtr/trackhab
cd trackhab/backend/backend
dotnet run
```

## Available endpoints

### Endpoints for working with Habits

```HTTP
GET /Habits/{habitId}
```
Retrieves a specific habit by its ID for a given user. This endpoint takes two parameters: habitId, the ID of the habit to retrieve, and userId, the ID of the user who owns the habit. It returns the habit details if found; otherwise, it returns a 404 status code with a message indicating the habit is not found.

```HTTP
POST /Habits
```
Creates a new habit. This endpoint accepts a Habit object in the request body. It checks if a habit with the same ID already exists to prevent duplicates. If the habit does not exist, it sets the user ID based on the authorized user's ID extracted from the JWT token in the Authorization header, adds the habit to the database, and returns the created habit. If the habit already exists, it returns a 400 status code with a message indicating the habit already exists.

```HTTP
DELETE /Habits/{habitId}
```
Deletes a habit by its ID. This endpoint takes a single parameter: habitId, the ID of the habit to delete. It checks if the habit exists; if it does, the habit is removed from the database, and a success message is returned. If the habit does not exist, it returns a 404 status code with a message indicating the habit is not found.

```HTTP
PUT /Habits
```
Updates an existing habit. This endpoint accepts a Habit object in the request body. It checks if the habit with the provided ID exists; if it does not, it returns a 404 status code with a message indicating the habit is not found. If the habit exists, it updates the habit's title, completion status (IsDone), and the days of the week the habit is tracked. After saving the changes, it returns the updated habit.

### Endpoints for working with Authentication

```HTTP
POST /Auth/login
```
This endpoint is responsible for authenticating users. It accepts a user object containing an email and password. The method attempts to find a user with the matching email in the database. If a user is found, it verifies the password. Upon successful authentication, it generates a JWT token, stores it in an HTTP-only cookie (to mitigate XSS attacks), and returns the user's email. If the user is not found or the password is incorrect, appropriate error messages and status codes are returned.

```HTTP
POST /Auth/register
```
This endpoint handles new user registrations. It receives a user object with an email and password. The method checks if a user with the given email already exists in the database. If not, it hashes the password for secure storage, adds the new user to the database, and returns a success message. If a user with the email already exists, it returns an error message.

```HTTP
POST /Auth/logout
```
This endpoint logs out users by removing the JWT token stored in the HTTP-only cookie. If the cookie exists, it is deleted, and a logout success message is returned. If no such cookie is found, indicating that the user is not logged in, an error message is returned.

```HTTP
DELETE /Auth/{userId}
```
This endpoint facilitates the deletion of a user by their ID. It looks up the user in the database; if the user exists, they are removed, and a success message is returned. If no user with the given ID is found, an error message is returned.

