FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Gudulion.BackEnd/Gudulion.BackEnd.csproj", "Gudulion.BackEnd/"]
RUN dotnet restore "Gudulion.BackEnd/Gudulion.BackEnd.csproj"
COPY . .
WORKDIR "/src/Gudulion.BackEnd"
RUN dotnet build "Gudulion.BackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gudulion.BackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gudulion.BackEnd.dll"]
