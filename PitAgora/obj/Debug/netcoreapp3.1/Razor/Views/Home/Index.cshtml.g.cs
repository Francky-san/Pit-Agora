#pragma checksum "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b362c64819927d84cd079cc175027a9154a9a13d"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b362c64819927d84cd079cc175027a9154a9a13d", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PitAgora.ViewModels.HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Home/Index.cshtml"
   Layout = "_Layout";
ViewBag.Title = "Accueil Pit'Agora"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Bienvenue sur Pit\'Agora</h1>\n<p>Accueil</p>\n\n\n");
            DefineSection("Menu", async() => {
                WriteLiteral("\n    <ul>\n        <li class=\"selectionne\">");
#nullable restore
#line 11 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Home/Index.cshtml"
                           Write(Html.ActionLink("Accueil", "Index","Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\n        <li>");
#nullable restore
#line 12 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Home/Index.cshtml"
       Write(Html.ActionLink("Modifier une personne", "ModifierPersonne", "Personne"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\n        <li>");
#nullable restore
#line 13 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Home/Index.cshtml"
       Write(Html.ActionLink("Ajouter une personne", "CreerPersonne", "Personne"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\n    </ul>\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PitAgora.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
