# Items API

This is a sample .NET project that exposes an API for managing a list of items.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 
 
### Prerequisites
- .NET Core 6.0
- Visual Studio 2019 (optional)
- Docker Desktop (optional)
### Installing

- Clone the repository
- Copy code
```
git clone https://github.com/shivam-51/items-api.git
```
- Navigate to the project directory
```
cd Play.Catalog
cd src/Play.Catalog.Service/Play.Catalog.Service
```

Restore the packages
```
dotnet restore
```
Run the project
```
dotnet run
```

## API Endpoints
The following endpoints are available:

### GET /items
Retrieves a list of all items.

Example Request
```
curl -X GET http://localhost:5000/items
```
Example Response

```[
    {
        "id": 1,
        "name": "Item 1",
        "description": "This is item 1"
    },
    {
        "id": 2,
        "name": "Item 2",
        "description": "This is item 2"
    }
]
```

### GET /items/{id}
Retrieves a single item by its ID.

Example Request

```
curl -X GET http://localhost:5000/items/1\
```
Example Response
```{
    "id": 1,
    "name": "Item 1",
    "description": "This is item 1"
}
```

### POST /items
Creates a new item.

Example Request

```curl -X POST \
  http://localhost:5000/items \
  -H 'Content-Type: application/json' \
  -d '{
    "name": "Item 3",
    "description": "This is item 3"
}'
```

Example Response

```{
    "id": 3,
    "name": "Item 3",
    "description": "This is item 3"
}
```
### PUT /items/{id}
Updates an existing item.

Example Request
```
curl -X PUT \
  http://localhost:5000/items/3 \
  -H 'Content-Type: application/json' \
  -d '{
    "name": "Updated Item 3",
    "description": "This is the updated item 3"
}'
```

Example Response

```
{
    "id": 3,
    "name": "Updated Item 3",
    "description": "This is the updated item 3"
}```
