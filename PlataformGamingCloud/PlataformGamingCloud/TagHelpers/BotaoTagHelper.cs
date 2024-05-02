using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PlatformGamingCloud.TagHelpers
{
    //Tag: <botao></botao>
    //Tag resultado: <button class="btn btn-primary">Cadastrar</button>
    public class BotaoTagHelper : TagHelper
    {
        public string? Texto { get; set; } = "Cadastrar";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Definir o nome da tag HTML
            output.TagName = "button";

            // Definir os atributos da tag HTML
            output.Attributes.SetAttribute("class", "btn btn-primary");

            // Definir o conteúdo da tag HTML
            output.Content.SetContent(Texto);
        }
    }
}
