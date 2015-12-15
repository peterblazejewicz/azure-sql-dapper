# MS SQL command line tool

> Cross platform command line interface for SQL Server

[https://github.com/hasankhan/sql-cli](https://github.com/hasankhan/sql-cli)

## Description

You could use MSSQL tool to connect to your Azure MS SQL database instance:
```
Usage: mssql [options]

Options:

  -h, --help                     output usage information
  -V, --version                  output the version number
  -s, --server <server>          Server to conect to
  -u, --user <user>              User name to use for authentication
  -p, --pass <pass>              Password to use for authentication
  -o, --port <port>              Port to connect to
  -t, --timeout <timeout>        Connection timeout in ms
  -d, --database <database>      Database to connect to
  -q, --query <query>            The query to execute
  -v, --tdsVersion <tdsVersion>  Version of tds protocol to use [7_4, 7_2, 7_3_A, 7_3_B, 7_4]
  -e, --encrypt                  Enable encryption
  -f, --format <format>          The format of output [table, csv, xml, json]
  -c, --config <path>            Read connection information from config file
```

Hidden gem, `mssql-conf.json` default configuration file:
```
{
	"user": "",
	"pass": "",
	"server": "",
	"database": "",
	"port": "",
	"connectionTimeout": "",
	"requestTimeout": "",
	"tdsVersion": "",
	"encrypt": ""
}
```

If you have correct setup in your default configuration file using `mssql` is trivial, just invoke from `cli`:
```
mssql   
Connecting to aservername.database.windows.net...done

sql-cli version 0.4.6
Enter ".help" for usage hints.
mssql> 
```



## Author
@peterblazejewicz