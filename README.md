# Azure (DNX) with Dapper.net

## Known Limitations:

Example command line application that queries Azure SQL Database using Dapper, built on DNX.

Known limitations:

- no SSL (trusted connection) on OS X/Linux in RC1
- better support for CoreCLR (actually some parts simply do not work under Mono)

## Running example

```
cd src/AdventureWorks.App
dnu restore
dnu build
dnx run ...
```

** IMPORTANT **

Install `user-secret` tool:

```
dnu commands install Microsoft.Extensions.SecretManager --overwrite
```

http://docs.asp.net/en/latest/security/app-secrets.html

On your Azure port SQL database settings open connection string and set configuration based on them:

```
user-secret set Azure:Server {your_server}
user-secret set Azure:Database {your_database}
user-secret set Azure:Username {your_username}
user-secret set Azure:Password {your_password}
```

Verify:
```
user-secret list

➜  AdventureWorks.App  user-secret list
info: Azure:Username = ############
info: Azure:Password = #################
info: Azure:Server = ###########
info: Azure:Database = AdventureWorks
```

## Simple mapping

Simple POCO:
```
{
  "AddressID": 25,
  "AddressLine1": "9178 Jumping St.",
  "City": "Dallas",
  "CountryRegion": "United States"
}
```

Nested POCO:

```
{
  "ProductID": 680,
  "Name": "HL Road Frame - Black, 58",
  "ProductNumber": "FR-R92B-58",
  "ModifiedDate": "2008-03-11T10:01:36.827",
  "Model": {
    "ProductModelID": 6,
    "Name": "HL Road Frame",
    "CatalogDescription": null,
    "rowguid": "4d332ecc-48b3-4e04-b7e7-227f3ac2a7ec",
    "ModifiedDate": "2002-05-02T00:00:00"
  }
}
```

A POCO with nested List of POCOs:
```
{
  "CustomerID": 29485,
  "Title": "Ms.",
  "FirstName": "Catherine",
  "LastName": "Abel",
  "CompanyName": "Professional Sales and Service",
  "EmailAddress": "catherine0@adventure-works.com",
  "Sales": [
    {
      "SalesOrderID": 71782,
      "CustomerID": 29485,
      "OrderDate": "2008-06-01T00:00:00",
      "SalesOrderNumber": "SO71782",
      "rowguid": "f1be45a5-5c57-4a50-93c6-5f8be44cb7cb"
    }
  ]
}
```

## Author

@peterblazejewicz
