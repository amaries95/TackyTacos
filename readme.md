# Welcome to the start of the workshop practical 🎉


## Required installations

1. [.NET SDK](https://dotnet.microsoft.com/en-us/download)
2. IDE of choice
3. [Docker desktop](https://www.docker.com/products/docker-desktop/)
4. [SQL Server Management Studio](https://aka.ms/ssmsfullsetup) for Windows or if on MAC or Linux [Azure data studio](https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver16&tabs=redhat-install%2Credhat-uninstall)
5. [Azurite](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio) - comes installed with Visual Studio
6. Clone this repo to your computer!


## Chapter One - Developing apps with .NET 7: a recap.

### A tour around the Modular Monolith
1. Note the use of accessors through the code base
2. Class Libraries
3. There are no tests in this app - but there should be!!!


### Add a web app to the `Web` directory

1. Add an executable
From the CLI navigate to the web project and type the following command:

```
dotnet new webapi -minimal
```
This will create a minimal API application which will be our main application executable.

2. Note the lack of a `Startup.cs` file - everything is in the `Program.cs` file. This is called the *Minimal Hosting Pattern* with *Top-level statements*. This doesn't mean you can't use the old way with a `Startup` and a `Main` method, in some cases it may make sense. Your IDE may even be able to convert this for you if that is your preference. In this workshop, the vast majority of the demos will be using the minimal pattern.

Other noteworthy items:
- Global usings
- File-scoped namespaces

Let's delete all the unneccessary code from the `Program.cs` file (basically everything to do with `WeatherForecast`).


1. Adding configuration

The `builder` object has a `Configuration` property which we can configure. We'll want to use the local appsettings, environment variables, command line arguments, and user secrets so let's add this:

```csharp
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .AddCommandLine(args)
    .Build();
```
If you wanted to use an `appsettings.development.json` file you could also add that in here too.

4. Add references to the `Orders` and `Payments` projects

Open the `csproj` og the new web api and add the following:

```XML
  <ItemGroup>
    <ProjectReference Include="..\..\Orders\Orders\Orders.csproj" />
    <ProjectReference Include="..\..\Payments\Payments\Payments.csproj" />
  </ItemGroup>
```

### Registering dependencies from other projects

You'll remember that to try to use the compiler to enforce the modular architecture of our application, most of the code in the *Orders* and *Payment* project is protected by an `internal` accessor at least.
So how can we register the dependencies and any endpoints we may want?

By using extension methods!

In the *Orders* project, create a new file and call it `OrderServiceCollections.cs` and add/update the code to the following:

```csharp
namespace Orders;
public static class OrderServiceCollections
{
}
```

Add the following method:
```csharp
public static IServiceCollection AddOrders(this IServiceCollection services)
{
    return services;
}
```
The above code will now give us a place to register all the code required in the *Orders* module, such as the *OrderService* - let's register that as a Singleton:
```csharp
services.AddSingleton<OrderService>();
```

In the `Program.cs` file of the *Web* project you can add the following code after the configuration:
```csharp
builder.Services.AddOrders();
```

Now we can repeat for the *Payments* project.

Add a file called `PaymentsServiceCollections.cs` and update it to the following code:

```csharp
using Payments.Services;

namespace Payments;
public static class PaymentsServiceCollection
{
    public static IServiceCollection AddPayments(this IServiceCollection services)
    {
        services.AddSingleton<PaymentService>();
        return services;
    }
}
```

Then register it in the `Program.cs` file in the *Web* project.

```csharp
builder.Services.AddPayments();
```

Awesome - we're now ready to add some data stores!