#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App

ENV COMPlus_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "DockerTest.dll"]

