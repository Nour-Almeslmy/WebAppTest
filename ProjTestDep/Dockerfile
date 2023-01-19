#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
EXPOSE 8080
#ENV ASPNETCORE_DEFAULT_PORT=5000
ENV ASPNETCORE_URLS=http://*:5000;http://*:8080;http://*:5001;https://*:5000;https://*:8080;https://*:5001
ENV ASPNETCORE_ENVIRONMENT=”production”

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjTestDep/ProjTestDep.csproj", "ProjTestDep/"]
COPY ["ClassLibrary/ClassLibrary.csproj", "ClassLibrary/"]
RUN dotnet restore "ProjTestDep/ProjTestDep.csproj"
COPY . .
WORKDIR "/src/ProjTestDep"
RUN dotnet build "ProjTestDep.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjTestDep.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjTestDep.dll"]