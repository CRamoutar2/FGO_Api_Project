## FGO_Api_Project
# By Chethram Ramoutar

This repo represents an API project based on Fate Grand Order, that I developed. 
In order to create the api yourself:

1) Download the .SQL files and the .CSV files in the "SQL Table Files" folder
2) Open MySQL Workbench and use the .SQL file downloaded to create the database and the tables.
3) Import table data using the .CSV files downloaded from the repo.

## API Reference

For statusCode refer to https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.statuscodes?view=aspnetcore-6.0
For SQL constraints refer to https://www.w3schools.com/sql/sql_constraints.asp

## HTTP Methods

#### Get all Servamts

```http
  GET /api/Servants
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Delete user

```http
  DELETE /api/Servants/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### Post new user

```http
  POST /api/Servants/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to post  |



## SQL Constraints

```NOT NULL```

## Endpoints

#### Get Servants Table

```http
  Servants: /api/Servants
```

#### Get Servants Sorted By Specified Rarity

```http
  User-Inputted Rarity: /api/Servants/getbystarrarity/${id}
```

#### Get NoblePhantasms Table

```http
  NoblePhantasms: /api/NoblePhantasms/
```

## Documentation

Models have a basic response model (named StatusResponse) 
that returns StatusCode whether or not API endpoint is successful.
String StatusDescription prints StatusCode result
List of returned items as properties if GET method used (=new())

Servants contains:
	primary key 
  bool of if the servant is owned
	string of servant name
	int of servant number
  int of servant's star rarity

Noble Phantasms contains:
	primary key
	foreign key - list of users
  int of NpID
  string of the Np's Name
  int of the NpLevel
  int of the Corresponding Servant Level
