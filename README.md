# Canducci EntityFrameworkCore Timestamps

[![NuGet](https://img.shields.io/nuget/v/Canducci.EntityFrameworkCore.Timestamps.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.EntityFrameworkCore.Timestamps/)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.EntityFrameworkCore.Timestamps.svg)](https://www.nuget.org/packages/Canducci.EntityFrameworkCore.Timestamps/)
[![.NET](https://github.com/fulviocanducci/Canducci.EntityFrameworkCore.Timestamps/actions/workflows/dotnet.yml/badge.svg)](https://github.com/fulviocanducci/Canducci.EntityFrameworkCore.Timestamps/actions/workflows/dotnet.yml)

TimeStamps

## Package Installation (NUGET)

```Csharp

PM> Install-Package Canducci.EntityFrameworkCore.Timestamps

```

## How to use?

The namespace `using Canducci.EntityFrameworkCore.Timestamps;` and implementation `class`, example:

```Csharp
public class Person : ITimestamps
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
}
```

In the configuration em `DbContext`, configure `AddInterceptorTimestamps` (`Canducci.EntityFrameworkCore.Timestamps.Extensions`)  is method extension:

* `.AddInterceptorTimestamps()`

`OnConfiguring` example:

```Csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.AddInterceptorTimestamps();
}
```

* `OnModelCreating` mapping `class` example:

```Csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Person>(config =>
    {
        config.HasKey(x => x.Id);
        config.Property(x => x.Id);
        config.Property(x => x.Name);
        config.Property(x => x.CreatedAt); //mapping required
        config.Property(x => x.UpdatedAt); //mapping required
    });
}
```

## Example Application:

[Console Application Example](https://github.com/fulviocanducci/Canducci.EntityFrameworkCore.Timestamps/tree/master/CslAppConsole)