# Como rodar?

1. Para rodar é necessário ter uma instancia do banco postgres rodando. Recomendo -> https://hub.docker.com/_/postgres
2. Restaurar o banco usando backup fornecido (bkp.bkp). Recomendo ferramenta -> https://www.pgadmin.org/download/
3. Configurar appsettings.json adicionar token e conection string, segue exemplo:

    <code>"Token": "MySuperSecretValueOMG!",
    "ConnectionStrings": { "Default": "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=ecom;"}</code>
2. Fazer o Build da solução.
    
    <code>dotnet build</code>
    
3. Rodar o projeto

    <code>dotnet run -p ./Api</code>
    
4. Credenciais de autenticação: usuario: gabriel, senha: 12345678
