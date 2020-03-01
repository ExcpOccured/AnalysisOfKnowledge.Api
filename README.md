# Web API

This repository is part of the [project](https://github.com/users/ExcpOccured/projects/1) 
and provides a public API for authorization, accounting for test data and interaction with the admin panel.

## Getting Started

### Build project
Use dotnet cli command:

```
dotnet build
```

And run the project in the desired configuration:

```
dotnet build --configuration <ConfigurationName>
```

Template [appsettings.{ConfigurationName}.json](https://github.com/ExcpOccured/AnalysisOfKnowledge.Api/blob/master/AnalysisofKnowledge.Api/appsettings.json)
it can be flexibly configured because the project supports environment variables

### Database

This project implies using a Postgresql database and NpgSQL provider for Ef Core, 
is also based on the code first Entity Framework Core and Fluent API configurations approach, 
but it can also use any database and any SQL data providers with the ability to configure.

For interact with EF Core CLI can be used PowerShell [script](https://github.com/ExcpOccured/AnalysisOfKnowledge.Api/blob/master/EfCoreCLIScript.ps1)
which must be run from the base directory containing the sln file, and must also have system permissions.

```
Set-ExecutionPolicy RemoteSigned
```

For database entities in the solution has been created the separated dll.

### Running the tests

Information about Docker CI based unit tests will be added in the near future

## Code style

The project does not contain StyleCop, so code style requirements can be based on - [Link](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md)
and my personal preferences ( ͡° ͜ʖ ͡°)

## Deployment & Docker CI

Coming soon :)

## Contributing

1. Fork the project!
2. Create your feature/bug fix branch from the master according to this pattern: `git checkout -b <feature/bugfix>-<brief description of the task>`
3. Commit your changes: `git commit -am 'A brief summary of your changes'`
4. Push the branch: `git push origin my-new-branch`
5. Create a request pool and wait for the review!

## License

Coming soon :)


