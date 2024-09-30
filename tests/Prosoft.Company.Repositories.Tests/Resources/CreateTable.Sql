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
