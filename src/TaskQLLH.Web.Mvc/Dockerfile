FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/TaskQLLH.Web.Mvc/TaskQLLH.Web.Mvc.csproj", "src/TaskQLLH.Web.Mvc/"]
COPY ["src/TaskQLLH.Web.Core/TaskQLLH.Web.Core.csproj", "src/TaskQLLH.Web.Core/"]
COPY ["src/TaskQLLH.Application/TaskQLLH.Application.csproj", "src/TaskQLLH.Application/"]
COPY ["src/TaskQLLH.Core/TaskQLLH.Core.csproj", "src/TaskQLLH.Core/"]
COPY ["src/TaskQLLH.EntityFrameworkCore/TaskQLLH.EntityFrameworkCore.csproj", "src/TaskQLLH.EntityFrameworkCore/"]
WORKDIR "/src/src/TaskQLLH.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/TaskQLLH.Web.Mvc", "src/TaskQLLH.Web.Mvc"]
COPY ["src/TaskQLLH.Web.Core", "src/TaskQLLH.Web.Core"]
COPY ["src/TaskQLLH.Application", "src/TaskQLLH.Application"]
COPY ["src/TaskQLLH.Core", "src/TaskQLLH.Core"]
COPY ["src/TaskQLLH.EntityFrameworkCore", "src/TaskQLLH.EntityFrameworkCore"]
WORKDIR "/src/src/TaskQLLH.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TaskQLLH.Web.Mvc.dll"]
