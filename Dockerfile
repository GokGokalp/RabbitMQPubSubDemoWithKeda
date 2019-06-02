#Build Stage
FROM microsoft/dotnet:2.2-sdk AS build-env

WORKDIR /workdir

COPY ./Todo.Contracts ./Todo.Contracts/
COPY ./Todo.Consumer ./Todo.Consumer/

RUN dotnet restore ./Todo.Consumer/Todo.Consumer.csproj
RUN dotnet publish ./Todo.Consumer/Todo.Consumer.csproj -c Release -o /publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime
COPY --from=build-env /publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet", "Todo.Consumer.dll"]