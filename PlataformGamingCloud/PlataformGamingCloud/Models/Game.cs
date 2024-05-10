using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PlatformGamingCloud.Models;

public class Game
{
    [HiddenInput]
    public int GameId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public DateOnly DataLancamento { get; set; }
    public DateTime DataCreated { get; set; } = DateTime.Now;

    [Display(Name ="Gênero")]
    public Genero? Genero { get; set; }
    public decimal? Valor { get; set; }
}

public enum Genero
{
        Corrida, Ficção, Ação, Aventura, FPS, RPG
}
