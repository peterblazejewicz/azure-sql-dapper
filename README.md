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
user-secret set server {your_server}
user-secret set database {your_database}
user-secret set username {your_username}
user-secret set password {your_password}
```

Verify:
```
user-secret list

➜  AdventureWorks.App  user-secret list
info: username = ############
info: password = #################
info: server = ###########
info: database = AdventureWorks
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

## Author

@peterblazejewicz
