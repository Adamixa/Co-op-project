#pragma checksum "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "391a471b9b9e3a18315b1482142912b953b7d6dd0b4eb5c8b493e60f7e78b691"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_MenuItem), @"mvc.1.0.view", @"/Views/Items/MenuItem.cshtml")]
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
#line 1 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"391a471b9b9e3a18315b1482142912b953b7d6dd0b4eb5c8b493e60f7e78b691", @"/Views/Items/MenuItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ee10bcb381c623d133f801d4811a1fea9dc5ce9d209206e1f755bc92d5cbb2a4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Items_MenuItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UniversityResturantInformation.Models.Menu_Item>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "Meal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MenuItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MIIndex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
  
    ViewData["Title"] = "Create";
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
            WriteLiteral("<h1>Create</h1>\r\n\r\n<h4>Item</h4>\r\n<hr />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "391a471b9b9e3a18315b1482142912b953b7d6dd0b4eb5c8b493e60f7e78b6916801", async() => {
                WriteLiteral("\r\n<fieldset class=\"border p-2\">\r\n    <legend class=\"w-auto\">Items:</legend>\r\n");
                WriteLiteral(@"    <div class=""table-responsive"">
        <table id=""myTable"" class=""table table-striped table-sm border"">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Code</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 54 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
                  
                    //if (ViewBag.Model != null)
                    //{
                        foreach (Item item in ViewBag.Item)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 60 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
                               Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 61 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
                               Write(item.ItemName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 62 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
                               Write(item.ItemCode);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 64 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
                        }
                    //}
                

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </tbody>
        </table>
    </div>
    <div class=""row"" hidden>
        <div class=""col-md-10"">
            <label class=""control-label"">You are Selected:</label>
            <textarea id=""tableInfoId"" class=""form-control"" name=""tableInfo"" readonly></textarea>
        </div>
    </div>
    <label style=""color:red; display:none"" id=""CoursSelect"">Please Select</label>
    <div class=""row"">
        <div class=""col-md-12"">
            <label class=""control-label required"">You are Selected:</label>
");
                WriteLiteral("        </div>\r\n        <div id=\"SelectedValues\">\r\n        </div>\r\n    </div>\r\n</fieldset>\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n");
                WriteLiteral("            <div class=\"form-group\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "391a471b9b9e3a18315b1482142912b953b7d6dd0b4eb5c8b493e60f7e78b69110083", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 95 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Menu.Meal);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "391a471b9b9e3a18315b1482142912b953b7d6dd0b4eb5c8b493e60f7e78b69111729", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 96 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Meal;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "391a471b9b9e3a18315b1482142912b953b7d6dd0b4eb5c8b493e60f7e78b69113522", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 97 "C:\Users\ASUS\Documents\GitHub\Co-op-project\UniversityResturantInformation\Views\Items\MenuItem.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Menu);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Create\" class=\"btn btn-primary\" />\r\n            </div>\r\n        \r\n    </div>\r\n</div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "391a471b9b9e3a18315b1482142912b953b7d6dd0b4eb5c8b493e60f7e78b69116613", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            WriteLiteral(@"<script>
    $(document).ready(function () {
                var table = $('#myTable').DataTable();
                $('#CrnSearch').on('change', function () {
                    table.search(this.value).draw();
                });

                //var newarray1 = [];
                $('#myTable tbody').on('click', 'tr', function () {
                    var str = """";
                    newarray = [];
                    //newarray1 = [];
                    $(this).toggleClass('selected');
                    var data = table.rows('.selected').data();
                    for (var i = 0; i < data.length; i++) {
                        //alert(""SectionName: "" + data[i][0] + "" SectionCrn: "" + data[i][1] + "" courseName: "" + data[i][2]
                        //    + "" LectureNumber: "" + data[i][3] + "" LectureDate: "" + data[i][4] + "" LectureTime: "" + data[i][5]);
                        newarray.push(JSON.parse('{ ""ItemId"": ""' + data[i][0] + '"", ""ItemName"":""' + data[i][1] + '""}'));
          ");
            WriteLiteral(@"              str = str + `<div class=""col-md-3"">
                        <div class=""block text-center"">
                            <div class=""block-header remove-padding"" style=""border-bottom: 1px solid #e8e8e8;background-color:#0d6f77;"">
                                <h3 class=""block-title remove-margin"" style=""color: white;"">${data[i][1]}</h3>
                            </div>
                            <div class=""block-content remove-padding"" style=""background-color:#bf8f2a;"">
                                <span style=""color:Black;"">${data[i][1]}</span>
                            </div>
                        </div>
                    </div>`
                    }
                    if (data.length != 0) {
                        var sData = JSON.stringify(newarray);
                        document.getElementById(""tableInfoId"").value = sData;
                        $(""#SelectedValues"").html(str);
                        //var sData1 = JSON.stringify(newarray1);
            ");
            WriteLiteral(@"            //document.getElementById(""tableInfoId1"").value = sData1;
                    }
                    else {
                        document.getElementById(""tableInfoId"").value = '';
                        $(""#SelectedValues"").html('');
                        //document.getElementById(""tableInfoId1"").value = '';
                    }
                });

                $('#button').on('click', function () {
                    //alert(table.rows('.selected').data().length + ' row(s) selected');
                    //alert(sData);
                });
            });
</script>");
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
