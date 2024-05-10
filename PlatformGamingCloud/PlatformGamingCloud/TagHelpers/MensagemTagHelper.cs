using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PlatformGamingCloud.TagHelpers;

[HtmlTargetElement("mensagem")]
public class MensagemTagHelper : TagHelper
{
    public string? Texto { get; set; }
    // public string? Class { get; set; } = "content-alert-sucess";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "h1";
        output.Content.SetContent(Texto);
    }
}
