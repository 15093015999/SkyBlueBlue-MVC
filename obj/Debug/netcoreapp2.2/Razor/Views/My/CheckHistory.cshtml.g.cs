#pragma checksum "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\CheckHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dee5b3563fc7a7b08d4ce95135da66f46b00493d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_My_CheckHistory), @"mvc.1.0.view", @"/Views/My/CheckHistory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/My/CheckHistory.cshtml", typeof(AspNetCore.Views_My_CheckHistory))]
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
#line 1 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\_ViewImports.cshtml"
using SkyBlueBlue;

#line default
#line hidden
#line 2 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\_ViewImports.cshtml"
using SkyBlueBlue.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dee5b3563fc7a7b08d4ce95135da66f46b00493d", @"/Views/My/CheckHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2769b4ee00c9af1927105065dbc82ec6231c0cff", @"/Views/_ViewImports.cshtml")]
    public class Views_My_CheckHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\CheckHistory.cshtml"
  
    ViewData["Title"] = "历史成绩";

#line default
#line hidden
            BeginContext(40, 261, true);
            WriteLiteral(@"<h1>历史成绩</h1>
<table class=""table"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">id</th>
            <th scope=""col"">试卷</th>
            <th scope=""col"">总分</th>
            <th scope=""col"">得分</th>
        </tr>
    </thead>
");
            EndContext();
#line 14 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\CheckHistory.cshtml"
     foreach (var item in ViewBag.SuccessList)
    {

#line default
#line hidden
            BeginContext(356, 55, true);
            WriteLiteral("        <tbody>\r\n            <tr>\r\n                <td>");
            EndContext();
            BeginContext(412, 7, false);
#line 18 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\CheckHistory.cshtml"
               Write(item.id);

#line default
#line hidden
            EndContext();
            BeginContext(419, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(447, 10, false);
#line 19 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\CheckHistory.cshtml"
               Write(item.paper);

#line default
#line hidden
            EndContext();
            BeginContext(457, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(485, 13, false);
#line 20 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\CheckHistory.cshtml"
               Write(item.subtotal);

#line default
#line hidden
            EndContext();
            BeginContext(498, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(526, 11, false);
#line 21 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\CheckHistory.cshtml"
               Write(item.scores);

#line default
#line hidden
            EndContext();
            BeginContext(537, 44, true);
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n");
            EndContext();
#line 24 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\CheckHistory.cshtml"
    }

#line default
#line hidden
            BeginContext(588, 8, true);
            WriteLiteral("</table>");
            EndContext();
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