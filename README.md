# Prosoft.Company

## Tecnologias

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-blue?logo=postgresql&style=for-the-badge&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-MicroORM-blue?logo=nuget&style=for-the-badge&logoColor=white)

## Objetivo

CRUD de Empresas para validação de Testes de Serviço/Integração

## Instruções para Rodar Testes (Prosoft.Company.Repositories)

- Para rodar os testes é necessário ter pelo menos uma instancia do PostgreSQL tanto local (OnPremisses, WSL ou Container)
ou instancia remota (desde que tenha acesso e tenha permissão de criar databases e rules)
- Criar arquivo .env configurando seus dados baseados .model-env opcionalmente você pode deixar essas configurações 
no App.Config e usar a classe AppConfigMannager para pegar os dados de conexão

### Modelo de arquivo .env
```
DB_HOST=[servidor]
DB_NAME=[nomebanco]
DB_PORT=[porta]
DB_USER={usuariobanco}
DB_PASSWORD=[senha]
TEST_CONNECTION=Host=[servidor];Port=5432;Database=postgres;Username=postgres;Password=[senha_usuario_master];Include Error Detail=true;
```

### Modelo de Dados App.Config
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="DB_HOST" value="[servidor]" />
    <add key="DB_PORT" value="[porta]" />
    <add key="DB_NAME" value="[nomebanco]" />
    <add key="DB_PASSWORD" value="[senha]" />
    <add key="TEST_CONNECTION" value="Host=[servidor];Port=5432;Database=postgres;Username=postgres;Password=[senha_usuario_master];Include Error Detail=true;" />
  </appSettings>
</configuration>
```

### Script de Criação da Tabela
```
-- Conceder permissões totais no esquema público
GRANT ALL PRIVILEGES ON SCHEMA public TO @userName;

-- Conceder permissões totais em todas as tabelas, sequências e funções no esquema 'geral'
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO @userName;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO @userName;
GRANT ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public TO @userName;

-- Criar schema 'geral' se não existir
CREATE SCHEMA IF NOT EXISTS geral;

-- Conceder permissões totais no esquema geral
GRANT ALL PRIVILEGES ON SCHEMA geral TO @userName;

-- Conceder permissões totais em todas as tabelas, sequências e funções no esquema 'geral'
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA geral TO @userName;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA geral TO @userName;
GRANT ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA geral TO @userName;

-- Criação da tabela 'empresas'
CREATE TABLE IF NOT EXISTS geral.empresas (
    Id UUID PRIMARY KEY NOT NULL,
    Nome VARCHAR(255) NOT NULL,
    Cnpj VARCHAR(512) UNIQUE NOT NULL,
    Endereco VARCHAR(255) NOT NULL,
    Telefone VARCHAR(15) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    DataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    DataAtualizacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Para Garantir caso a tabela exista e não seja criada executa um truncate
TRUNCATE TABLE geral.empresas CASCADE;
```

### Modelo de docker-compose.yml baseado no ambiente usado em DEV
```
services:
  postgresql:
    image: bitnami/postgresql:16.4.0
    environment:
      - POSTGRES_PASSWORD=12345678  # Variável de senha correta para o PostgreSQL
      - PATH=/opt/bitnami/postgresql/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin
      - HOME=/
      - OS_ARCH=amd64
      - OS_FLAVOUR=debian-12
      - OS_NAME=linux
      - APP_VERSION=16.4.0
      - BITNAMI_APP_NAME=postgresql
      - LANG=en_US.UTF-8
      - LANGUAGE=en_US:en
      - NSS_WRAPPER_LIB=/opt/bitnami/common/lib/libnss_wrapper.so
    ports:
      - "5432:5432/tcp"  # Mapeamento de portas (evitar duplicatas)
    volumes:
      - /var/lib/docker/volumes/1f91ee68fc564e6662f83db8977c34b25d6baa327559a04ed8079b17730ef51d/_data:/bitnami/postgresql
      - /var/lib/docker/volumes/639591f5cdf35c9fdb51f8e9e589e371a27bf3755dd83f90f593b7be61891440/_data:/docker-entrypoint-initdb.d
      - /var/lib/docker/volumes/469b9d1e637948d6d42b983455cbc6bd0aaa72da2db86364a4fe00b0935fbaf2/_data:/docker-entrypoint-preinitdb.d
```

### Comando para executar no bash
```
docker run -d \
  --name postgresql \
  -e POSTGRESQL_PASSWORD=12345678 \
  -p 5432:5432 \
  bitnami/postgresql:latest
```
