<div align="center">
  <img src="https://readme-typing-svg.demolab.com?font=Fira+Code&size=50&duration=3000&pause=200&color=6366F1FF&center=true&vCenter=true&multiline=true&random=false&width=435&height=100&lines=VideoGame+API"> 
</div>

<h2 align="center">API RESTful para gerenciamento de videogames com Entity Framework e SQL Server.</h2>

## **Visão Geral**

A **VideoGame API** é uma aplicação web desenvolvida em ASP.NET Core que oferece um sistema completo para gerenciamento de videogames. A API permite cadastrar, consultar, atualizar e excluir informações sobre jogos, incluindo título, plataforma, desenvolvedor e publicador.

## **Instruções de Uso**

Para rodar a **VideoGame API** localmente, siga os passos abaixo:

### **Pré-requisitos**

#### **Instalação do SQL Server**

**Windows:**

1. Baixe o SQL Server Developer Edition no [site oficial da Microsoft](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
2. Execute o instalador e siga as instruções
3. Configure uma senha forte para o usuário `sa`

**Ubuntu:**

```bash
# Importar chave GPG da Microsoft
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -

# Adicionar repositório do SQL Server
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/20.04/mssql-server-2019.list)"

# Instalar SQL Server
sudo apt-get update
sudo apt-get install -y mssql-server

# Configurar SQL Server
sudo /opt/mssql/bin/mssql-conf setup

# Instalar ferramentas de linha de comando
curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list | sudo tee /etc/apt/sources.list.d/msprod.list
sudo apt-get update
sudo apt-get install mssql-tools unixodbc-dev
```

### **Configuração do Projeto**

1. Clone este repositório:

   ```bash
   git clone https://github.com/seu-usuario/VideoGameApi.git
   ```

2. Acesse o diretório do projeto:

   ```bash
   cd ./VideoGameApi
   ```

3. Configure as variáveis de ambiente criando um arquivo `.env`:

   ```bash
   DB_USER=sa
   DB_PASSWORD=SuaSenhaAqui
   ```

4. Instale as dependências do projeto:

   ```bash
   dotnet restore
   ```

5. Execute as migrações do banco de dados:

   ```bash
   dotnet ef database update
   ```

6. Inicie a aplicação em modo de desenvolvimento:

   ```bash
   dotnet watch run
   ```

7. Acesse a documentação da API:
   - **Scalar UI:** `http://localhost:5250/scalar/v1`
   - **OpenAPI/Swagger:** `http://localhost:5250/openapi/v1.json`

## **Endpoints Disponíveis**

| Método | Endpoint              | Descrição                       |
| ------ | --------------------- | ------------------------------- |
| GET    | `/api/videogame`      | Lista todos os videogames       |
| GET    | `/api/videogame/{id}` | Busca um videogame por ID       |
| POST   | `/api/videogame`      | Cria um novo videogame          |
| PUT    | `/api/videogame/{id}` | Atualiza um videogame existente |
| DELETE | `/api/videogame/{id}` | Remove um videogame             |

## **Variáveis de Ambiente**

A aplicação utiliza as seguintes variáveis de ambiente para configuração segura:

- `DB_USER`: Usuário do banco de dados (padrão: sa)
- `DB_PASSWORD`: Senha do banco de dados SQL Server

**Importante:** Você deve criar manualmente o arquivo `.env` no diretório raiz do projeto, pois ele não é versionado no Git por questões de segurança.

## **Tecnologias Utilizadas**

- **Framework:** ASP.NET Core 9.0
- **ORM:** Entity Framework Core
- **Banco de Dados:** SQL Server
- **Documentação:** OpenAPI/Swagger + Scalar
- **Segurança:** Variáveis de ambiente com DotNetEnv
- **Controle de Versão:** Git e GitHub

## **Estrutura do Projeto**

```
VideoGameApi/
├── Controllers/          # Controladores da API
├── Data/                 # Contexto do banco de dados
├── Migrations/           # Migrações do Entity Framework
├── appsettings.json      # Configurações da aplicação
├── Program.cs            # Configuração e inicialização
└── .env                  # Variáveis de ambiente (não versionado)
```
