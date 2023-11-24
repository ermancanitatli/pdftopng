FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PDFconverter/PDFconverter.csproj", "PDFconverter/"]
RUN dotnet restore "PDFconverter/PDFconverter.csproj"
COPY . .
WORKDIR "/src/PDFconverter"
RUN dotnet build "PDFconverter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PDFconverter.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PDFconverter.dll"]
