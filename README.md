## FGO_Api_Project
# By Chethram Ramoutar

This repo represents an API project based on Fate Grand Order, that I developed. 
In order to create the api yourself:

1) Import ServantInfo.csv file.

2) Use Existing Table: fgo.servants

3) Make sure the Source Columns and Destination Columns align. Ie: ServantNumber = ServantNumber, ServantName = ServantName, isOwned = isOwned, StarRarity = StarRarity

4) Continue to import and done. 




5) Import the NpInfo.csv

6) Use Existing Table: fgo.noblephantasms

7) Make sure the Source Columns and Destination Columns align. Ie: NpID = NpID, NpName = NpName, NpLevel = NpLevel, CorrespondingServantNumber = CorrespondingServantNumber

8) Continue to import and done. 




9) (Optional) After importing, if the result says "0 records imported", retry the process.


To test that the data is there. Test in an SQL file: Select * From noblephantasms(or servants)
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
