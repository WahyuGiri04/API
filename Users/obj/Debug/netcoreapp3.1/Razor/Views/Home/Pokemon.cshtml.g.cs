#pragma checksum "E:\MCC\Project Tugas\API\Users\Views\Home\Pokemon.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1c70f5eabe35bd512cd0c501997a881d21f1241"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Pokemon), @"mvc.1.0.view", @"/Views/Home/Pokemon.cshtml")]
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
#line 1 "E:\MCC\Project Tugas\API\Users\Views\_ViewImports.cshtml"
using Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\MCC\Project Tugas\API\Users\Views\_ViewImports.cshtml"
using Users.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1c70f5eabe35bd512cd0c501997a881d21f1241", @"/Views/Home/Pokemon.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76329950902ad88d0f03302c587e74adc798fd8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Pokemon : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/datatables/jquery.dataTables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/datatables/dataTables.bootstrap4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/demo/datatables-demo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Pokemon.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "E:\MCC\Project Tugas\API\Users\Views\Home\Pokemon.cshtml"
  
    ViewData["Title"] = "Employee";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .btn-poison {
        color: #fff;
        background-color: #B76EA4;
    }

    .btn-grass {
        color: #fff;
        background-color: #80BE62;
    }

    .btn-normal {
        color: #fff;
        background-color: #B7B6A4;
    }

    .btn-flying {
        color: #fff;
        background-color: #9AA8FA;
    }

    .btn-bug {
        color: #fff;
        background-color: #B7C43F;
    }

    .btn-water {
        color: #fff;
        background-color: #3399FF;
    }
</style>

<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-xl-12 col-md-6 mb-4"">
            <div class=""card border-left-primary shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <h1 class=""h3 mb-2 text-gray-800"">Tabel Data Pokemon</h1>
                        </div>
                        <div class=""col-auto");
            WriteLiteral(@""">
                            <i class=""fas fa-file fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">DataTables Example</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-hover"" id=""tabelPoke"">
                    <thead class=""table"">
                        <tr>
                            <th scope=""col"">No</th>
                            <th scope=""col"">Nama</th>
                            <th scope=""col"">Aksi</th>
                        </tr>
                    </thead>
                    <tbody id=""tabelPokemon"">
                        <tr>
                            <td scope=""col"">No</td>
                            <td scope=""col"">Nama</td>
           ");
            WriteLiteral(@"                 <td scope=""col"">Aksi</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<div class=""modal"" id=""myModal"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">

            <!-- Modal Header -->
            <div class=""modal-header text-center"">
                <h4 class=""modal-title"" id=""namaPokemon""></h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>

            <!-- Modal body -->
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-6"" id=""gambarPokemon"">

                    </div>
                    <div class=""col-6"">
                        <div class=""row"">
                            <div class=""col-12"">
                                <h3>Pokemon Data</h3>
                                <table class=""table table-hover"">
     ");
            WriteLiteral(@"                               <tr>
                                        <td>Height </td>
                                        <td> : </td>
                                        <td id=""heightPokemon""></td>
                                    </tr>
                                    <tr>
                                        <td>Weight </td>
                                        <td> : </td>
                                        <td id=""weightPokemon""> 10 cm</td>
                                    </tr>
                                    <tr>
                                        <td>Ability </td>
                                        <td> : </td>
                                        <td id=""abilityPokemon""></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-12"">
                 ");
            WriteLiteral(@"               <h3>Type</h3>
                                <div id=""typePokemon"">
                                    <span class=""badge badge-danger""> Danger</span>
                                    <span class=""badge badge-danger""> Danger</span>
                                    <span class=""badge badge-danger""> Danger</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal footer -->
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Close</button>
            </div>

        </div>
    </div>
</div>


");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1c70f5eabe35bd512cd0c501997a881d21f12419872", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1c70f5eabe35bd512cd0c501997a881d21f124110971", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1c70f5eabe35bd512cd0c501997a881d21f124112071", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/buttons/2.0.1/js/dataTables.buttons.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.0.1/js/buttons.html5.min.js""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1c70f5eabe35bd512cd0c501997a881d21f124113760", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
