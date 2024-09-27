# Library Console

## Descrição

O projeto **Library Console** é uma aplicação de console destinada à gestão de bibliotecas, permitindo o controle de leitores, livros e aluguéis de forma simples e eficiente.

## Funcionalidades

### Funcionalidades do Leitor
* Adicionar novo leitor;
* Listar todos os leitores;
* Listar leitor pelo CPF;
* Alterar dados do leitor;
* Alterar status do leitor;

### Funcionalidades do Livro
* Adicionar novo livro;
* Listar todos os livros;
* Listar livro pelo título;
* Listar livros do mesmo autor;
* Alterar dados do livro;
* Alterar status do livro;
* Alterar condição do livro;

### Funcionalidades do Aluguel
* Cadastrar aluguel de livro;
* Devolver livro alugado;
* Listar todos os livros alugados;
* Listar todos os livros alugados com situação em atraso;
* Listar livro alugado pelo título;

## Tecnologias Utilizadas
* **C#**
* **SQL Server**

## Como Executar o Projeto

1. **Rode os scripts do banco de dados**
    - Execute o script `CREATE DATABASE.sql` para criar o banco de dados.
    - Em seguida, execute o script `CREATE TABLES.sql` para criar as tabelas necessárias.

2. **Altere o arquivo `Program.cs`**
    - Atualize a linha de configuração da conexão com o banco de dados em `Program.cs`:

        ```csharp
        var dbSettings = new DbSettings("Server=localhost; Database=LIBRARY_CONSOLE; " +
          "User ID=YourUser; Password=YourPassword; Encrypt=True; TrustServerCertificate=True; Connection Timeout=30;");
        ```

3. **Compile e execute a aplicação**
    - Abra o projeto em sua IDE preferida.
    - Compile o projeto e execute a aplicação.

## Contato

Para mais informações ou feedback, entre em contato:

- **E-mail**: gustavo_carl@hotmail.com
- **LinkedIn**: [Meu perfil](https://linkedin.com/in/gustavocarl)
