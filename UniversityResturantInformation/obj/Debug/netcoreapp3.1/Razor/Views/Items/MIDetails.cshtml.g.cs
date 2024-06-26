#pragma checksum "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17b1fe515c7c33dd8dda6df16c12dec7d7518fa60091ff24b6612133b201aa54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_MIDetails), @"mvc.1.0.view", @"/Views/Items/MIDetails.cshtml")]
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
#nullable restore
#line 1 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"17b1fe515c7c33dd8dda6df16c12dec7d7518fa60091ff24b6612133b201aa54", @"/Views/Items/MIDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ee10bcb381c623d133f801d4811a1fea9dc5ce9d209206e1f755bc92d5cbb2a4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Items_MIDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UniversityResturantInformation.Models.Menu_Item>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MIIndex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
  
    ViewData["Title"] = "Details";
    if (User.FindFirst(ClaimTypes.Role).Value == "DataEntry")
    {
        Layout = "DataEntryLayout";
    }
    else if (User.FindFirst(ClaimTypes.Role).Value == "Admin")
    {
        Layout = "AdminLayout";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Menu Item</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 23 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Item.ItemCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 26 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
       Write(Html.DisplayFor(model => model.Item.ItemCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 29 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Item.ItemName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 32 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
       Write(Html.DisplayFor(model => model.Item.ItemName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 35 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Item.Cal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 38 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
       Write(Html.DisplayFor(model => model.Item.Cal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Image\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 1199, "\"", 1221, 1);
#nullable restore
#line 44 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
WriteAttributeValue("", 1205, Model.Item.File, 1205, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"170\"");
            BeginWriteAttribute("alt", " alt=\"", 1234, "\"", 1240, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Menu Number\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 51 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
       Write(Html.DisplayFor(model => model.Menu.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 54 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Menu.Meal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 57 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
             if (Model.Menu.Meal == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>BreakFast</td>\r\n");
#nullable restore
#line 60 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
            }
            else if (Model.Menu.Meal == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>Lunch</td>\r\n");
#nullable restore
#line 64 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>Dinner</td>\r\n");
#nullable restore
#line 68 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MIDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "17b1fe515c7c33dd8dda6df16c12dec7d7518fa60091ff24b6612133b201aa549316", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UniversityResturantInformation.Models.Menu_Item> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
