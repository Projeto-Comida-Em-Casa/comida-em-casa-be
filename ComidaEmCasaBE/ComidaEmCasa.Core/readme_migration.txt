*** Instalar cli dotnet
dotnet tool install --global dotnet-ef 
*** gerar um ponto de migrations é o nome da migration gerada, deve ser alterada decorrente da implementação
dotnet ef migrations add [MIGRATION_NAME] --project ComidaEmCasa.Core --startup-project ComidaEmCasa
*** manda atualizar a database baseada na ultima migrations gerada
$env:ASPNETCORE_ENVIRONMENT = 'Local'
dotnet ef database update --project ComidaEmCasa.Core --startup-project ComidaEmCasa
*** caso queira voltar para uma migration especifica
dotnet ef database update <MIGRATION> --project ComidaEmCasa.Core --startup-project ComidaEmCasa
*** manda remover o arquivo migrations gerado
dotnet ef migrations remove --project ComidaEmCasa.Core --startup-project ComidaEmCasa


https://www.learnentityframeworkcore.com/migrations