# Web API

This repository is part of the [project](https://github.com/users/ExcpOccured/projects/1) 
and provides a public API for authorization, accounting for test data and interaction with the admin panel.

## Getting Started

### Build project
Use _dotnet cli_ command:

```
dotnet build
```

And run the project in the desired configuration:

```
dotnet build --configuration <ConfigurationName>
```

Template [appsettings.{ConfigurationName}.json](https://github.com/ExcpOccured/AnalysisOfKnowledge.Api/blob/master/AnalysisofKnowledge.Api/appsettings.json)
can be flexibly configured because the solution supports environment variables

### Database

This solution implies using a Postgresql database and NpgSQL provider for Ef Core, 
is also based on the code first Entity Framework Core and Fluent API configurations approach, 
but it can also use any database and any SQL data providers with the ability to configure.

For interact with EF Core CLI can be used PowerShell [script](https://github.com/ExcpOccured/AnalysisOfKnowledge.Api/blob/master/EfCoreCLIScript.ps1)
which must be run from the base directory containing the sln file, and must also have system permissions.

```
Set-ExecutionPolicy RemoteSigned
```

For database entities in the solution has been created the separated dll, 
on which the main project has a dependency

### Running the tests

Information about Docker CI based unit tests will be added in the near future

## Code style

The solution doesnt contain StyleCop, so code style requirements can be based on - [Link](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md)
and my personal preferences ( ͡° ͜ʖ ͡°)

## Deployment & Docker CI

Coming soon :)

## Contributing

1. Fork the repository!
2. Create your feature/bug fix branch from the master according to this pattern: `git checkout -b <feature/bugfix>-<brief description of the changes context>`
3. Commit your changes: `git commit -m 'A summary of your changes'`
4. Push the branch with all commits 
5. Create a pool request and wait for the review!

## License

Coming soon :)


