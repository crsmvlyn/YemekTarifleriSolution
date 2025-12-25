# Altyapı
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Tüm dosyaları kopyala
COPY . ./

# Projeyi derle (Dosya yolu değiştiği için klasör adını ekledik)
RUN dotnet restore
RUN dotnet publish YemekTarifleriApp/YemekTarifleriApp.csproj -c Release -o out

# Çalıştırma
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "YemekTarifleriApp.dll"]