FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY lexicographic_permutations/bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "lexicographic_permutations.dll"]
