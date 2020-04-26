FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
WORKDIR /sln

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY ./Trademe.Automation.Core/*.csproj ./Trademe.Automation.Core/
COPY ./Trademe.Automation.Api.Tests/*.csproj ./Trademe.Automation.Api.Tests/
COPY ./Trademe.Automation.Web.Tests/*.csproj ./Trademe.Automation.Web.Tests/
COPY ./Trademe.Automation.Web.Driver/*.csproj ./Trademe.Automation.Web.Driver/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet build

# run api tests
FROM build-env AS apitestrunner
WORKDIR /sln/Trademe.Automation.Api.Tests
CMD ["dotnet", "test", "--logger:trx"]


# run web tests
FROM build-env AS webtestrunner
WORKDIR /sln/Trademe.Automation.Web.Tests
CMD ["dotnet", "test", "--logger:trx"]