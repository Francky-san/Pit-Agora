#pragma checksum "C:\Users\Developpeur\source\repos\Pit-Agora\PitAgora\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07e9b5f2a68bdb0f1c825b1cfcdbf524fa644e9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07e9b5f2a68bdb0f1c825b1cfcdbf524fa644e9f", @"/Views/Home/Index.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PitAgora.ViewModels.HomeViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Developpeur\source\repos\Pit-Agora\PitAgora\Views\Home\Index.cshtml"
   Layout = "_Layout";
ViewBag.Title = "Accueil Pit'Agora"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Bienvenue sur Pit\'Agora</h1>\r\n<p>Accueil</p>\r\n\r\n\r\n");
            DefineSection("Menu", async() => {
                WriteLiteral("\r\n    <ul>\r\n        <li class=\"selectionne\">");
#nullable restore
#line 11 "C:\Users\Developpeur\source\repos\Pit-Agora\PitAgora\Views\Home\Index.cshtml"
                           Write(Html.ActionLink("Accueil", "Index","Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n        <li>");
#nullable restore
#line 12 "C:\Users\Developpeur\source\repos\Pit-Agora\PitAgora\Views\Home\Index.cshtml"
       Write(Html.ActionLink("Modifier une personne", "ModifierPersonne", "Personne"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n        <li>");
#nullable restore
#line 13 "C:\Users\Developpeur\source\repos\Pit-Agora\PitAgora\Views\Home\Index.cshtml"
       Write(Html.ActionLink("Ajouter une personne", "CreerPersonne", "Personne"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n    </ul>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PitAgora.ViewModels.HomeViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
