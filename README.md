# Azure (DNX) with Dapper.net


## Running example

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
```
➜  AdventureWorks.App  user-secret list
info: username = ############
info: password = #################
info: server = ###########
info: database = AdventureWorks
```
## Author
@peterblazejewicz
