# Store POC

This is a simple POC that represents a store with a list of products and a cart.

## Mount the database

You need to have docker installed on your machine.

```bash
docker-compose up -d
```

This will mount a postgres database on port 5432 and pgAdmin on port 5050.

## How to run

Navigate to the `src` directory and run the following command:

```bash
dotnet build
```

Then, run the database migrations.

```bash
dotnet ef migrations add My-Migration --project Store.DataAccess -o Persistence/Migrations --startup-project Store.Api
```

```bash
dotnet ef database update --project Store.DataAccess --startup-project Store.Api
```

After that, you can run the application.

```bash
dotnet run --project Store.Api
```

## Check the database

In your browser go to `http://localhost:5050` and login with the following credentials:

```bash
email: training@training.com
password: training
```

Then add a new server with the following credentials:

```bash
host: training-db
port: 5432
username: training
password: training
```

If you followed the steps above, you should be able to see the database(training-db) and the tables.

**Note:** The project is still in development.
