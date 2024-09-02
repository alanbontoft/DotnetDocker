FROM mcr.microsoft.com/dotnet/sdk:8.0 as debug

#install debugger for NET Core
RUN apt-get update
#unzip needed for vsdbg, procps needed for ps utility
RUN apt-get install -y unzip procps
RUN curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l ~/vsdbg

RUN mkdir /work/
WORKDIR /work/

COPY ./DotnetDocker.csproj /work/DotnetDocker.csproj
RUN dotnet restore

COPY ./ /work/
RUN mkdir /out/
RUN dotnet publish --output /out/ --configuration Release

ENTRYPOINT ["dotnet", "run"]

###########START NEW IMAGE###########################################

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim as prod

RUN mkdir /app/
WORKDIR /app/
COPY --from=debug /out/ /app/
RUN chmod +x /app/ 
CMD dotnet work.dll
