# 📊 SalesWebMvc

Aplicação ASP.NET Core MVC para gerenciamento de vendedores, departamentos e registros de vendas.  
O projeto foi desenvolvido como estudo prático de **C#**, **.NET Core** e **Entity Framework**, aplicando conceitos de **MVC**, **injeção de dependência**, **CRUD** e **LINQ**.

---

## 🚀 Tecnologias Utilizadas

- **C#**  
- **ASP.NET Core MVC**  
- **Entity Framework Core** (ORM)  
- **MySQL** (banco de dados relacional)  
- **Bootstrap** (estilização)  
- **LINQ** para consultas  
- **Injeção de Dependência (DI)**  

---

## 📌 Funcionalidades

- Cadastro e gerenciamento de **Departamentos**  
- Cadastro e gerenciamento de **Vendedores**  
- Registro de **Vendas**  
- Relatórios e filtros por data  
- Integração com banco de dados MySQL usando **Entity Framework Core**  
- Operações CRUD completas (Create, Read, Update, Delete)  

---

## 📂 Estrutura do Projeto

```
SalesWebMvc/
│-- Controllers/       # Lógica de controle da aplicação (Departamentos, Vendedores, Vendas)
│-- Models/            # Classes de domínio (Department, Seller, SalesRecord)
│-- Data/              # Contexto do banco (DbContext) e seeding
│-- Services/          # Regras de negócio e serviços auxiliares
│-- Views/             # Páginas Razor (MVC Views)
│-- wwwroot/           # Arquivos estáticos (CSS, JS, imagens)
│-- appsettings.json   # Configurações do projeto (string de conexão etc.)
```

---

## ⚙️ Como Executar o Projeto

### 🔹 Pré-requisitos
- [.NET SDK 6+](https://dotnet.microsoft.com/en-us/download)
- [MySQL](https://dev.mysql.com/downloads/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### 🔹 Passo a passo

1. Clone o repositório:
   ```bash
   git clone https://github.com/BernTomaz/SalesWebMvc.git
   cd SalesWebMvc
   ```

2. Configure a **string de conexão** no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "SalesWebMvcContext": "server=localhost;userid=seu_usuario;password=sua_senha;database=saleswebmvcappdb"
   }
   ```

3. Execute as **migrações do Entity Framework** para criar o banco:
   ```bash
   dotnet ef database update
   ```

4. Rode o projeto:
   ```bash
   dotnet run
   ```

5. Acesse no navegador:
   ```
   http://localhost:5000
   ```

---

## 📊 Modelo Conceitual

O sistema segue o seguinte modelo de entidades:

- **Department** → possui vários **Sellers**  
- **Seller** → pertence a um **Department** e possui vários **SalesRecords**  
- **SalesRecord** → vinculado a um **Seller**  

---





