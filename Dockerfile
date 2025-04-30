# ����� ������� �����, � ������� ����� �������� �����
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# ������������� ������ �����-���������� ������� ����������, ��� ������� ����� ���� ������ ����� �������� ������������ ���� ����������. ���� � ��� - �� ��� ��������
WORKDIR /src

# �������� ������ � �����, �������� ����� ������ ��������� � ����
COPY ["src/OzonEdu.StockApi/OzonEdu.StockApi.csproj", "src/OzonEdu.StockApi/"]

# ��������� ����������� � �������
RUN dotnet restore "./src/OzonEdu.StockApi/OzonEdu.StockApi.csproj"

# �������� �� �� �� �� ��������� ���������� ����������� �������������� �������, � ���������� ������
COPY . .

# ��������� ������� ����������, ����� ����� ������� ��� ������ � ������
WORKDIR "/src/src/OzonEdu.StockApi"

# ��������� �������� ��� ��� ��������
RUN dotnet build "OzonEdu.StockApi.csproj" -c Release -o /app/build

# ��������� �� ������ ���� � publish. ��� ������� ���������. � ����� ����� publish
FROM build AS publish
RUN dotnet publish "OzonEdu.StockApi.csproj" -c Release -o /app/publish
COPY "entrypoint.sh" "/app/publish/."

# ����� ����� ����� .Net ��� ������� � �� ������ ����������.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS runtime

# ������ ����� ����� � ����� ����������
WORKDIR /app

# ����� ����� ����� ��������
EXPOSE 5000
EXPOSE 5002

# ������ ��������� ����� �� ���� runtime
FROM runtime AS final

# ������ ����� ����� � ����� ������
WORKDIR /app

# �������� �� publish ������, �� ����� � �� /app/publish � ������� �������� ( . ) final ������
COPY --from=publish /app/publish .

# �����, �� ������� ��������� ����� �����������
#ENTRYPOINT ["dotnet","OzonEdu.StockApi.dll"]

# ������� Windows CR � ��� �����
RUN chmod +x entrypoint.sh

# ������ ������� �������� (JSON-������ ��� ���������� ��������� ��������)
CMD ["/bin/bash", "entrypoint.sh"]