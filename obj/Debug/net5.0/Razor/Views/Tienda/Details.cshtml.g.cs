#pragma checksum "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a56cefd377b5690dc6328ab1a7da683968675674"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tienda_Details), @"mvc.1.0.view", @"/Views/Tienda/Details.cshtml")]
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
#line 1 "/home/miku/Codigos/TiaShop/TammyCookies/Views/_ViewImports.cshtml"
using TiendaEnLinea2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/miku/Codigos/TiaShop/TammyCookies/Views/_ViewImports.cshtml"
using TiendaEnLinea2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/miku/Codigos/TiaShop/TammyCookies/Views/_ViewImports.cshtml"
using TiendaEnLinea2.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/miku/Codigos/TiaShop/TammyCookies/Views/_ViewImports.cshtml"
using TiendaEnLinea2.Data.Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/miku/Codigos/TiaShop/TammyCookies/Views/_ViewImports.cshtml"
using TiendaEnLinea2.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a56cefd377b5690dc6328ab1a7da683968675674", @"/Views/Tienda/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f449383220723390ac5b92af3223db9a89aed3d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Tienda_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TiendaEnLinea2.Data.Models.OrderDetail>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MisCompras", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:150px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
  
    ViewData["Title"] = "Detalles";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalles</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a56cefd377b5690dc6328ab1a7da6839686756745295", async() => {
                WriteLiteral("Regresar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table table-responsive"">
    <thead>
        <tr>
            <th>
                Producto
            </th>
            <th>
                Imagen
            </th>
            <th>
                Descripci&oacute;n
            </th>
            <th>
                ");
#nullable restore
#line 25 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Subtotal\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 33 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
         foreach (var item in Model)
        {
            var prod = context.Producto.FirstOrDefault(p => p.id == Convert.ToInt32(item.Prodid));
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
             if (prod != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
                   Write(prod.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a56cefd377b5690dc6328ab1a7da6839686756748100", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1091, "~/UploadedImages/", 1091, 17, true);
#nullable restore
#line 43 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
AddHtmlAttributeValue("", 1108, prod.Imagen, 1108, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 43 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
AddHtmlAttributeValue("", 1127, prod.Nombre, 1127, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-wrap\">\r\n                        ");
#nullable restore
#line 46 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
                   Write(prod.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
                   Write(item.Cantidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"text-success\">\r\n                        $");
#nullable restore
#line 52 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
                     Write(item.Cantidad*prod.Precio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 55 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "/home/miku/Codigos/TiaShop/TammyCookies/Views/Tienda/Details.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TiendaEnLinea2.Data.Models.OrderDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
