#pragma checksum "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "c0ae54a97bb8aeed8f2bebda1fb657a86d9a5281abb63e4f01af8846cb43905a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ratings_Rate), @"mvc.1.0.view", @"/Views/Ratings/Rate.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\_ViewImports.cshtml"
using UniversityResturantInformation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\_ViewImports.cshtml"
using UniversityResturantInformation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"c0ae54a97bb8aeed8f2bebda1fb657a86d9a5281abb63e4f01af8846cb43905a", @"/Views/Ratings/Rate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ee10bcb381c623d133f801d4811a1fea9dc5ce9d209206e1f755bc92d5cbb2a4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Ratings_Rate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UniversityResturantInformation.Models.Item>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ratingstyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Rate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("<link rel=\"stylesheet\" type=\"text/css\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css\">\r\n<link rel=\"stylesheet\" href=\"https://pro.fontawesome.com/releases/v5.10.0/css/all.css\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c0ae54a97bb8aeed8f2bebda1fb657a86d9a5281abb63e4f01af8846cb43905a5564", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<!-- default styles -->
<link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css"">
<link href=""https://cdn.jsdelivr.net/gh/kartik-v/bootstrap-star-rating@4.1.2/css/star-rating.min.css"" media=""all"" rel=""stylesheet"" type=""text/css"" />
<!-- with v4.1.0 Krajee SVG theme is used as default (and must be loaded as below) - include any of the other theme CSS files as mentioned below (and change the theme property of the plugin) -->
<link href=""https://cdn.jsdelivr.net/gh/kartik-v/bootstrap-star-rating@4.1.2/themes/krajee-svg/theme.css"" media=""all"" rel=""stylesheet"" type=""text/css"" />
<!-- important mandatory libraries -->
<script src=""https://cdn.jsdelivr.net/gh/kartik-v/bootstrap-star-rating@4.1.2/js/star-rating.min.js"" type=""text/javascript""></script>
<!-- with v4.1.0 Krajee SVG theme is used as default (and must be loaded as below) - include any of the other theme JS files as mentioned below (and change the theme property of the plugin) -->
<script src=""https://");
            WriteLiteral(@"cdn.jsdelivr.net/gh/kartik-v/bootstrap-star-rating@4.1.2/themes/krajee-svg/theme.js""></script>
<!-- optionally if you need translation for your language then include locale file as mentioned below (replace LANG.js with your own locale file) -->
<script src=""https://cdn.jsdelivr.net/gh/kartik-v/bootstrap-star-rating@4.1.2/js/locales/LANG.js""></script>
<script>
");
#nullable restore
#line 22 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
      
        if (@ViewData["Successful"] != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("\r\n            var result = \'");
#nullable restore
#line 26 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                     Write(Html.Raw(ViewData["Successful"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            Swal.fire(result, \'\', \'success\')\r\n                .then(\r\n                    function () {\r\n                        window.location.href = \'");
#nullable restore
#line 30 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                                           Write(Url.Action("Rate","Ratings"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n                    }\r\n                );\r\n            ");
#nullable restore
#line 33 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                   
        }
        else if (@ViewData["Falied"] != null && ViewData["NoRedirect"] == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("\r\n                                            var result = \'");
#nullable restore
#line 38 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                                                     Write(Html.Raw(ViewData["Falied"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            Swal.fire(result, \'\', \'error\')\r\n                .then(\r\n                    function () {\r\n                        window.location.href = \'");
#nullable restore
#line 42 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                                           Write(Url.Action("Rate","Ratings"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n                    }\r\n                );\r\n            ");
#nullable restore
#line 45 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                   
        }
        else if (@ViewData["Falied"] != null && ViewData["NoRedirect"] != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("\r\n                                            var result = \'");
#nullable restore
#line 50 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                                                     Write(Html.Raw(ViewData["Falied"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n            Swal.fire(result, \'\', \'error\');\r\n            ");
#nullable restore
#line 52 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                   
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</script>\r\n    <section class=\"section-100\">\r\n        <div class=\"wrapper fadeInDown\">\r\n");
#nullable restore
#line 58 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div id=\"formContent\">\r\n                    <!-- Tabs Titles -->\r\n                    <br>\r\n                    <h3 class=\"m-b-15\">");
#nullable restore
#line 63 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
                                  Write(item.ItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <hr>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0ae54a97bb8aeed8f2bebda1fb657a86d9a5281abb63e4f01af8846cb43905a12599", async() => {
                WriteLiteral("\r\n\r\n                        <div>\r\n                            <!-- Display properties of each Rating object -->\r\n                            <input name=\"Item\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 3514, "\"", 3530, 1);
#nullable restore
#line 69 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
WriteAttributeValue("", 3522, item.Id, 3522, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                            <label for=""input-1"" class=""control-label""></label>
                            <input id=""input-1"" name=""RateItem"" class=""rating rating-loading"" data-min=""0"" data-max=""5"" data-step=""1"" required>
                            <input type=""submit"" class=""btn btn-danger fw-bolder px-4 ms-2 fs-8"" value=""Submit"">                            
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <br />\r\n");
#nullable restore
#line 77 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Ratings\Rate.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br>\r\n            <br>\r\n            <hr>\r\n\r\n\r\n        </div>\r\n    </section>\r\n    <br />\r\n    <br />\r\n    <br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UniversityResturantInformation.Models.Item>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
