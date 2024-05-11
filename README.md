# 2º Checkpoint - ASP.NET_Core_MVC

## Integrantes do Grupo

- Isadora Tatajuba Moreira Pinto - RM552522 
- Kaique Santos de Andrade - RM99562
- Lucas Araujo Oliveira Silva - RM550841
- Marcelo Augusto de Mello Paixão - RM99466
- Maria Eduarda Sousa de Oliveira - RM552477
- Rodrigo Batista Freire - RM99513

# Gaming Cloud

A "Gaming Cloud" é uma plataforma simples de gerenciamento de jogos, oferecendo operações básicas de CRUD (Create, Read, Update, Delete) para manipular dados de jogos, incluindo informações como título, gênero, descrição, data de lançamento, etc. 

## Tecnologias Utilizadas:

- C#
- ASP.NET MVC
- HTML, CSS e JavaScript

## Funcionalidades Principais

- Cadastro de Jogos: Permite aos usuários adicionar novos jogos, especificando título, gênero, data de lançamento, descrição, data de criação e valor.
- Listagem de Jogos: Exibe todos os jogos cadastrados em uma tabela, fornecendo uma visão geral das informações básicas de cada jogo.
- Remoção de jogos: Permite aos usuários remover jogos existentes da plataforma.
- Edição de Jogos: Permite aos usuários editar as informações de um jogo existente.
- Pesquisa de jogos: Permite aos usuários pesquisar jogos por título, facilitando a localização de jogos específicos na plataforma.

 ## Telas

- ### Tela inicial: <br>
A tela inicial da Gaming Cloud é projetada para oferecer uma experiência intuitiva e direta aos usuários. Ao acessar a plataforma, os usuários são recebidos com  uma interface limpa e amigável, centrada em facilitar o acesso às principais funcionalidades da aplicação. 

Na região central, um botão de cadastro convida os usuários a adicionar novos jogos à plataforma, direcionando-os para a tela de cadastro de jogos.

Outro botão com um ícone de lista permite aos usuários explorar a lista completa de jogos disponíveis na Gaming Cloud, redirecionando-os para a tela de listagem de jogos.


![image](https://github.com/FIAP-2024/CP2_CSharp_ASP.NET_Core_MVC/assets/80494196/ebad52cd-b37d-466e-8376-a151f81e0eaa)

- ### Tela de cadastro: <br>
A tela de cadastro de jogos na Gaming Cloud é desenvolvida para proporcionar aos usuários uma experiência intuitiva e eficiente ao adicionar novos jogos à plataforma. Projetada com uma interface limpa e organizada, esta tela oferece campos claros e acessíveis para inserção de informações detalhadas sobre os jogos.

 - [x] Nome: Um campo de entrada de texto permite que os usuários insiram o título do jogo.
- [x] Gênero: Um menu suspenso oferece opções pré-definidas de gênero para os usuários selecionarem.
- [x] Data de Lançamento: Um campo de seleção de data permite que os usuários escolham a data de lançamento do jogo.
- [x] Descrição: Uma área de texto expandida permite que os usuários forneçam uma descrição detalhada do jogo.
- [x] Valor: Um campo de entrada numérica permite que os usuários insiram o valor do jogo, seja ele o preço de venda ou outro tipo de valor monetário.



#### Implementação na Controller:
```C#
 [HttpPost]
 public IActionResult Cadastrar(Game game)
 {
     //Setar o código do game
     game.GameId = ++_id;

     //Adicionar o game na lista
     _lista.Add(game);

     //Mandar uma mensagem de sucesso para a view
     TempData["msg"] = "Jogo cadastrado com sucesso!";

     //Redireciona para o método Cadastrar
     return RedirectToAction("Cadastrar");
 }
```

![image](https://github.com/FIAP-2024/CP2_CSharp_ASP.NET_Core_MVC/assets/80494196/70d20a6f-ea19-4d82-9f22-ab7134090740)

- ### Tela de listagem
A tela de listagem de jogos na Gaming Cloud é projetada para fornecer aos usuários uma visão abrangente e organizada de todos os jogos disponíveis na plataforma. Com uma interface intuitiva e funcional, esta tela apresenta os principais detalhes de cada jogo, permitindo aos usuários explorar e acessar facilmente informações importantes.

A tela exibe uma tabela que lista todos os jogos cadastrados na plataforma, com cada linha representando um jogo individual.

Para facilitar a gestão dos jogos, botões de edição e remoção são disponibilizados em cada linha da tabela, permitindo aos usuários editar informações ou remover jogos conforme necessário.

```C#
[HttpGet] //Abrir o formulário com os dados preenchidos
public IActionResult PesquisaNome(string searchString)
{
    if (string.IsNullOrEmpty(searchString))
    {
        // Se a string de pesquisa estiver vazia, redireciona para a lista de jogos
        return RedirectToAction("Index");
    }

    // Procura jogos que correspondam ao termo de pesquisa (insensível a maiúsculas e minúsculas)
    var games = _lista.Where(c => c.Nome!.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

    if (games.Count == 0)
    {
        // Caso nenhum jogo for encontrado
        TempData["msg"] = "Nenhum Jogo Encontrado!!";
        return RedirectToAction("Index");
    }

    // Se os jogos forem encontrados, envie-os para a visualização de índice
    return View("Index", games);
}

public IActionResult Index()
{
    //Enviar a lista de game para a view
    return View(_lista);
}
```

![image](https://github.com/FIAP-2024/CP2_CSharp_ASP.NET_Core_MVC/assets/80494196/a8796309-dfda-46dc-a478-62086103faba)

- ### Tela de edição
A tela de edição de jogos na Gaming Cloud proporciona aos usuários a capacidade de atualizar e modificar as informações de jogos já existentes na plataforma. Com uma interface intuitiva e funcional, esta tela permite aos usuários realizar edições precisas e eficientes nos detalhes dos jogos conforme necessário.

A tela apresenta um formulário estruturado, preenchido automaticamente com as informações atuais do jogo selecionado para edição.

#### Implementação na Controller:

```C#
        // Update
    [HttpGet] //Abrir o formulário com os dados preenchidos
    public IActionResult Editar(int id)
    {
        //Recuperar a posição do game na lista através do id
        var index = _lista.FindIndex(c => c.GameId == id);
        //Recuperar o game através do ID
        var game = _lista[index];
        //Enviar o game para a view
        return View(game);
    }

    [HttpPost]
    public IActionResult Editar(Game game)
    {
        //Atualizar o game na lista
        var index = _lista.FindIndex(c => c.GameId == game.GameId);
        //Substitui o objeto na posição do game antigo
        _lista[index] = game;
        //Mensagem de sucesso
        TempData["msg"] = "Jogo atualizado com sucesso!";
        //Redirect para a listagem/editar
        return RedirectToAction("editar");
    }
```

![image](https://github.com/FIAP-2024/CP2_CSharp_ASP.NET_Core_MVC/assets/80494196/afef478f-20c1-4119-943d-3c1fc65431b1)

- ### Modal de remoção
Projetado para evitar remoções acidentais e fornecer uma experiência de usuário clara, este modal oferece uma interface simples e direta para confirmar a exclusão de jogos selecionados.

O modal de remoção aparece sobreposto à tela principal da aplicação, destacando-se visualmente para chamar a atenção do usuário e indicar a ação de remoção iminente.

#### Implementação na Controller:

```C#
// Remove 
[HttpPost]
public IActionResult Remover(int id)
{
        //Remover o game da lista
        _lista.RemoveAt(_lista.FindIndex(c => c.GameId == id));
        //Mensagem de sucesso
        TempData["msg"] = "Jogo removido com sucesso!";
        //Redirecionar para a listagem
        return RedirectToAction("Index");
}
```


![image](https://github.com/FIAP-2024/CP2_CSharp_ASP.NET_Core_MVC/assets/80494196/33132768-2a5a-4ec4-817d-5e0a22fd0fc6)

- ### Tela de privacidade
Esta política de privacidade descreve como tratamos as informações pessoais coletadas e utilizadas em nossa plataforma.

![image](https://github.com/FIAP-2024/CP2_CSharp_ASP.NET_Core_MVC/assets/80494196/ec8d01a0-5e47-43ff-9ed7-ced657eb7ab8)

