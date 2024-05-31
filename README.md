## Projeto feito em .NET 8 com uso do Entity Framework para realizar o mapeamento das entidades aqui presentes em conjunto com o banco de dados SQL Server 

## Foi utilizado uma API para autenticação e autorização de usuários chamada Idendity.

Algumas etapas necessárias para a execução do projeto:

Passo 1: Ir no arquivo appsettings.json na pasta raiz do projeto e na string "DefaultConnection" tudo o que vier após os dois pontos deverá ser trocado de acordo com sua configuração do SQL Server
  - Para conseguir a informaçãos necessária para a configuração dessa string você precisará ir na tela de conexão do banco e fazer o seguinte:
      "DefaultConnection": "Server=(Tudo que estiver no seu ServerName e é se por acaso tiver alguma \ entre os caminhos dele, necessário adicionar um \ a mais!);Database=(Esse nome é personalizável para o que você quiser);Trusted_Connection=True;",
    
      P.S: Tirar os parênteses na hora que você informar sua configuração.
    
      P.S2: Caso por ventura você decidir usar outro deverá trocar também no arquivo program.cs e adaptar a linha 9 e 10 para o respectivo banco utilizado.
    
Passo 2: Após banco de dados configurado você deverá realizar a migration para criação do banco de dados com suas tabelas e relacionamentos:
  - Ao abrir o projeto no Visual Studio você deverá ir na aba Tools/Ferramentas da IDE e ir até a opção Command Line/Linha de Comando e na opção Developer Command Prompt/ Prompt de Comando de Desenvolvedor
  - Com o prompt de comando aberto você deverá mandar o seguinte comando: cd JuridicoProjeto para entrar na pasta raiz do projeto através da linha de comando
  - Feito isso, você irá digitar o comando: dotnet ef migrations add "PrimeiraMigration" ou o nome que você desejar sem ter espaço, caso seja um nome composto e lembrar de tirar as aspas!!
  - Caso tudo esteja corretamente, irá ser criada uma pasta no projeto com o nome Migrations onde você se tiver curiosidade de abrir, poderá ver um Builder que gerou todos os comandos para criação do banco de dados usando uma tecnologia chamada Code Fist.
  - Para criação do banco de dados em si, você deverá usar o comando dotnet ef database update.

Passo 3: Executar o projeto no botão do Visual Studio.


Modelo de Entidade Relacionamento criado para representar as tabelas e seus relacionamentos no banco.
![Modelo Entidade Relacionamento](https://github.com/RezendeRafaelSC/ProjetoJuridico/blob/master/modeloEr.png)
