# Items API

This is a sample .NET project that exposes an API for managing a list of items.
The API is built using ASP.NET Core 6.0 and MongoDB as the data store for items and uses Docker for the mongo container.

The hosting of mongo in docker container is optional and you can also host it locally. After hosting it locally make sure to update the mongo API url in `appsettings.json` file.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.
 
### Prerequisites
- .NET Core 6.0
- Visual Studio 2019 (optional)
- Docker
- Docker Desktop (optional)
### Installing

- Clone the repository
- Copy code
```
git clone https://github.com/shivam-51/Play.Catalog
```
- Navigate to the project directory
```
cd Play.Catalog
cd src/Play.Catalog.Service/Play.Catalog.Service
```

Start a mongo container at port 27017
```
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
```

Run the project
```
dotnet run
```

The API will be available at https://localhost:7018
and the swagger UI will be available at https://localhost:7018/swagger

## API Endpoints
The following endpoints are available:

### `GET /items`
Retrieves a list of all items.

Example Request
```
curl -X 'GET' \
  'https://localhost:7018/items' \
  -H 'accept: text/plain'
```
Example Response

```
[
    {
        "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "Name": "string",
        "Description": "string",
        "Price": 0,
        "CreatedTime": "2023-01-04T16:03:48.381Z"
    }
]
```

### `GET /items/{id}`
Retrieves a single item by its ID.

Example Request

```
curl -X 'GET' \
  'https://localhost:7018/items/bd997d92-8d63-4267-a17d-e8835e3f0b61' \
  -H 'accept: text/plain'
```
Example Response
```
{
  "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "Name": "string",
  "Description": "string",
  "Price": 0,
  "CreatedTime": "2023-01-04T16:08:11.948Z"
}
```

### `POST /items`
Creates a new item.

Example Request

```
curl -X 'POST' \
  'https://localhost:7018/items' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "Name": "Alpha",
  "Description": "Latest Addition",
  "Price": 51
}'
```

Example Response

```
{
  "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "Name": "string",
  "Description": "string",
  "Price": 0,
  "CreatedTime": "2023-01-04T16:09:13.160Z"
}
```
### `PUT /items/{id}`
Updates an existing item.

Example Request
```
curl -X 'PUT' \
  'https://localhost:7018/items/f7fce19a-e08d-4e57-8136-3868d69ce6db' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "Name": "Updated name",
  "Description": "Updated desc"
}'
```

Example Response

```
Status 204
```

### `DELETE /items/{id}`
Deletes an existing item.

Example Request

```
curl -X 'DELETE' \
  'https://localhost:7018/items/f7fce19a-e08d-4e57-8136-3868d69ce6db' \
  -H 'accept: */*'
```

Example Response

```
Status 204
```