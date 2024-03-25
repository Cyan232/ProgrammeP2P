FROM ubuntu:latest

EXPOSE 245/udp
RUN mkdir /opt/app
COPY . /opt/app
WORKDIR /opt/app

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

ENTRYPOINT ["bin/Debug/netcoreapp3.1/ubuntu.22.04-x64/App", "start", "master", "245", "172.17.0.2"]