#pragma checksum "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6afd01014289b3554ce8568b30810ea2e7e382b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DetailsOrder), @"mvc.1.0.view", @"/Views/Admin/DetailsOrder.cshtml")]
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
#line 1 "/home/miku/TiendaEnLinea2/Views/_ViewImports.cshtml"
using TiendaEnLinea2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/miku/TiendaEnLinea2/Views/_ViewImports.cshtml"
using TiendaEnLinea2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/miku/TiendaEnLinea2/Views/_ViewImports.cshtml"
using TiendaEnLinea2.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/miku/TiendaEnLinea2/Views/_ViewImports.cshtml"
using TiendaEnLinea2.Data.Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/miku/TiendaEnLinea2/Views/_ViewImports.cshtml"
using TiendaEnLinea2.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6afd01014289b3554ce8568b30810ea2e7e382b", @"/Views/Admin/DetailsOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f449383220723390ac5b92af3223db9a89aed3d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_DetailsOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TiendaEnLinea2.Controllers.TmpList>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:250px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
  
    ViewData["Title"] = "DetailsOrder";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Detalles de la orden:</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>Nombre del producto</th>
            <th>Descripci&oacute;n</th>
            <th>Precio</th>
            <th>Cantidad</th>
            <th>Imagen</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n           <td>");
#nullable restore
#line 22 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
          Write(item.prod.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n           <td>");
#nullable restore
#line 23 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
          Write(item.prod.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n           <td>");
#nullable restore
#line 24 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
          Write(item.prod.Precio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n           <td>");
#nullable restore
#line 25 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
          Write(item.Cantidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n           <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6afd01014289b3554ce8568b30810ea2e7e382b5489", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 635, "~/UploadedImages/", 635, 17, true);
#nullable restore
#line 26 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
AddHtmlAttributeValue("", 652, item.prod.Imagen, 652, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 26 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
AddHtmlAttributeValue("", 676, item.prod.Nombre, 676, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 28 "/home/miku/TiendaEnLinea2/Views/Admin/DetailsOrder.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TiendaEnLinea2.Controllers.TmpList>> Html { get; private set; }
    }
}
#pragma warning restore 1591
