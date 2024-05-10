﻿using Microsoft.AspNetCore.Mvc;
using PlatformGamingCloud.Models;

namespace PlatformGamingCloud.Controllers;

public class GameController : Controller
{
    //Lista de carro para simular o banco de dados
    private static List<Game> _lista = new List<Game>();
    private static int _id = 0; //Controla o ID

    // Create
    [HttpGet] //Abrir a página com o formulário HTML
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(Game game)
    {
        //Setar o código do game
        game.GameId = ++_id;
        //Adicionar o game na lista
        _lista.Add(game);
        //Mandar uma mensagem de sucesso para a view
        TempData["msg"] = "Jogo cadastrado!";
        //Redireciona para o método Cadastrar
        return RedirectToAction("Cadastrar");
    }

    // Read
    public IActionResult Index()
    {
        //Enviar a lista de game para a view
        return View(_lista);
    }

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
        TempData["msg"] = "Jogo atualizado!";
        //Redirect para a listagem/editar
        return RedirectToAction("editar");
    }

    // Remove 
    [HttpPost]
    public IActionResult Remover(int id)
    {
        //Remover o game da lista
        _lista.RemoveAt(_lista.FindIndex(c => c.GameId == id));
        //Mensagem de sucesso
        TempData["msg"] = "Jogo removido!";
        //Redirecionar para a listagem
        return RedirectToAction("Index");
    }
}