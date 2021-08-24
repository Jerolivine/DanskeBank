#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["API/DanskeBank.API/DanskeBank.API.csproj", "API/DanskeBank.API/"]
COPY ["Application/DanskeBank.Application/DanskeBank.Application.csproj", "Application/DanskeBank.Application/"]
COPY ["Domain/DanskeBank.Domain/DanskeBank.Domain.csproj", "Domain/DanskeBank.Domain/"]
COPY ["Domain/Core/DanskeBank.Domain.Core/DanskeBank.Domain.Core.csproj", "Domain/Core/DanskeBank.Domain.Core/"]
COPY ["Application/Contract/DanskeBank.Application.Contract/DanskeBank.Application.Contract.csproj", "Application/Contract/DanskeBank.Application.Contract/"]
COPY ["Infrastructure/Constants/DanskeBank.Constants/DanskeBank.Constants.csproj", "Infrastructure/Constants/DanskeBank.Constants/"]
COPY ["Application/DanskeBank.Application.Core/DanskeBank.Application.Core.csproj", "Application/DanskeBank.Application.Core/"]
COPY ["Infrastructure/Transversal/Mapper/DanskeBank.Mapper/DanskeBank.Mapper.csproj", "Infrastructure/Transversal/Mapper/DanskeBank.Mapper/"]
COPY ["API/DanskeBank.API.Core/DanskeBank.API.Core.csproj", "API/DanskeBank.API.Core/"]
COPY ["Infrastructure/Transversal/Persistance/DanskeBank.Infrastructure.EntityFramework.Core/DanskeBank.Infrastructure.EntityFramework.Core.csproj", "Infrastructure/Transversal/Persistance/DanskeBank.Infrastructure.EntityFramework.Core/"]
COPY ["UnitOfWork/DanskeBank.UnitOfWork/DanskeBank.UnitOfWork.csproj", "UnitOfWork/DanskeBank.UnitOfWork/"]
COPY ["Infrastructure/Transversal/Mapper/DanskeBank.Mapper.Mapster/DanskeBank.Mapper.Mapster.csproj", "Infrastructure/Transversal/Mapper/DanskeBank.Mapper.Mapster/"]
RUN dotnet restore "API/DanskeBank.API/DanskeBank.API.csproj"
COPY . .
WORKDIR "/src/API/DanskeBank.API"
RUN dotnet build "DanskeBank.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DanskeBank.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DanskeBank.API.dll"]