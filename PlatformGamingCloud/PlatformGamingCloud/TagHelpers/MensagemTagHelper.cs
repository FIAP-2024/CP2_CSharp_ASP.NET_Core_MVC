using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Claims;

namespace PlatformGamingCloud.TagHelpers;

[HtmlTargetElement("mensagem")]
public class MensagemTagHelper : TagHelper
{
    public string? Texto { get; set; }
    public string? Class { get; set; } = "content-alert-sucess";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "h2";
        if (!string.IsNullOrEmpty(Texto))
            output.Attributes.SetAttribute("class", Class);
        output.Content.SetContent(Texto);
    }
}
