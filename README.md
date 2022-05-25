# PizzaAPI

Set Up DB

dotnet tool install --global dotnet-ef --version 5.0.17

dotnet ef migrations add Initial --context PizzaContext --project PizzaAPI

dotnet ef database update --context PizzaContext --project PizzaAPI
