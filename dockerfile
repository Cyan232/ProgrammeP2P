# FROM ubuntu:latest
# EXPOSE 245/udp
# RUN mkdir /opt/app
# COPY . /opt/app
# WORKDIR /opt/app

# RUN apt update
# RUN apt-get update && apt-get install -y sudo


# RUN sudo apt install gnupg ca-certificates -y
# RUN sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
# RUN echo "deb https://download.mono-project.com/repo/ubuntu stable-bionic main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list
# RUN sudo apt update
# RUN sudo apt install mono-devel -y
# RUN mcs App.cs
# CMD ["mono", "App.exe"]

FROM ubuntu:latest
EXPOSE 245/udp
RUN mkdir /opt/app
COPY . /opt/app
WORKDIR /opt/app
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
#RUN msbuild App.csproj
#RUN apt-get install openssl -y
# RUN dotnet build App.csproj
#RUN mcs App.cs Commands.cs

#CMD ["bin/Debug/netcoreapp3.1/ubuntu.22.04-x64/App -start node 10.0.0.33 245"]
ENTRYPOINT ["bin/Debug/netcoreapp3.1/ubuntu.22.04-x64/App", "start", "master", "245", "172.17.0.2"]