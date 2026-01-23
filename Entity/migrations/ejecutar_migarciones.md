# migraciones metase al web

## instalar el dotnet ef
dotnet tool install --global dotnet-ef

## migraciones de la base de datos
dotnet ef migrations add InitialCreate --project ../Entity/ --startup-project .
# Aplicar la migración y crear la base de datos en MySQL/MariaDB.
dotnet ef database update --project ../Entity/ --startup-project .

# estructura de la base de datos

## Esquema de la base de datos (Markdown)
