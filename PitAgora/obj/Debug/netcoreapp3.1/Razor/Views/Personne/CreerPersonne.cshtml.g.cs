#pragma checksum "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9624d4c637aaeb3cf4f4b6ac1b8a7718853e8729"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Personne_CreerPersonne), @"mvc.1.0.view", @"/Views/Personne/CreerPersonne.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9624d4c637aaeb3cf4f4b6ac1b8a7718853e8729", @"/Views/Personne/CreerPersonne.cshtml")]
    public class Views_Personne_CreerPersonne : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PitAgora.Models.Personne>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery-3.3.1.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery.validate-vsdoc.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery.validate.unobtrusive.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
    Layout="_Layout";
    ViewBag.Title="Créer une personne";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n");
#nullable restore
#line 7 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
 using (Html.BeginForm()) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset>\n        <legend>Créer une personne : </legend>\n            ");
#nullable restore
#line 10 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
       Write(Html.LabelFor(m => Model.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 11 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
       Write(Html.TextBoxFor(m => Model.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 12 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
       Write(Html.ValidationMessageFor(m => Model.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <br />\n            ");
#nullable restore
#line 14 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
       Write(Html.LabelFor(m => Model.Prenom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 15 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
       Write(Html.TextBoxFor(m => Model.Prenom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 16 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
       Write(Html.ValidationMessageFor(m => Model.Prenom));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <br />\n            <input type=\"submit\" value=\"CreerPersonne\"/>    \n    </fieldset>\n");
#nullable restore
#line 20 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Menu", async() => {
                WriteLiteral("\n    <ul>\n        <li class=\"selectionne\">");
#nullable restore
#line 24 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
                           Write(Html.ActionLink("Accueil", "Index","Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\n        <li>");
#nullable restore
#line 25 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
       Write(Html.ActionLink("Modifier une personne", "ModifierPersonne","Personne"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\n        <li>");
#nullable restore
#line 26 "/Users/rociokeuro/Desktop/Projet2/Pit-Agora/PitAgora/Views/Personne/CreerPersonne.cshtml"
       Write(Html.ActionLink("Ajouter une personne", "CreerPersonne", "Personne"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\n    </ul>\n");
            }
            );
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9624d4c637aaeb3cf4f4b6ac1b8a7718853e87297528", async() => {
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9624d4c637aaeb3cf4f4b6ac1b8a7718853e87298668", async() => {
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9624d4c637aaeb3cf4f4b6ac1b8a7718853e87299808", async() => {
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PitAgora.Models.Personne> Html { get; private set; }
    }
}
#pragma warning restore 1591