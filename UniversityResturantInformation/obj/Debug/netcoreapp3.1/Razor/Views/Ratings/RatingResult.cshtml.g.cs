#pragma checksum "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\Ratings\RatingResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d9806f6bc3a1d685aa1f9384d6a543277645b2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ratings_RatingResult), @"mvc.1.0.view", @"/Views/Ratings/RatingResult.cshtml")]
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
#nullable restore
#line 1 "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\_ViewImports.cshtml"
using UniversityResturantInformation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\_ViewImports.cshtml"
using UniversityResturantInformation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d9806f6bc3a1d685aa1f9384d6a543277645b2e", @"/Views/Ratings/RatingResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea0741eef1fb5427e5230865d07ce6fff8b84a75", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Ratings_RatingResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UniversityResturantInformation.Models.Item>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\Ratings\RatingResult.cshtml"
  
    ViewData["Title"] = "Rating Result";
    Layout = "AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<br />
<br />
<br />
<div class=""table-responsive"">
    <table id=""myTable"" class=""table table-striped table-sm border"">
        <thead>
            <tr>
                <th></th>
                <th></th>
                <th>
                     Name
                </th>
                <th>
                    Rating
                </th>
                <th>
                   Number of ratings
                </th>
                
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 31 "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\Ratings\RatingResult.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td></td>\r\n                    <td></td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\Ratings\RatingResult.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ItemName ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 41 "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\Ratings\RatingResult.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("/5\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 44 "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\Ratings\RatingResult.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NumberOfRating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    \r\n                </tr>\r\n");
#nullable restore
#line 48 "E:\coop project repo\UniversityResturantInformation\Co-op-project\UniversityResturantInformation\Views\Ratings\RatingResult.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
