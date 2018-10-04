FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TextFileWriter.csproj TextFileWriter/
RUN dotnet restore TextFileWriter/TextFileWriter.csproj
COPY . ./TextFileWriter
WORKDIR /src/TextFileWriter
RUN dotnet build TextFileWriter.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TextFileWriter.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

CMD ["dotnet", "TextFileWriter.dll"]
