#pragma checksum "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bcfe2d795c1286195e16ab6c6de396ada49986d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_My_Index), @"mvc.1.0.view", @"/Views/My/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/My/Index.cshtml", typeof(AspNetCore.Views_My_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bcfe2d795c1286195e16ab6c6de396ada49986d", @"/Views/My/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2769b4ee00c9af1927105065dbc82ec6231c0cff", @"/Views/_ViewImports.cshtml")]
    public class Views_My_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyInfoModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckHistory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangePassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 1 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
  
    ViewData["Title"] = "我的信息";

#line default
#line hidden
            BeginContext(60, 51, true);
            WriteLiteral("\r\n<div class=\"jumbotron\">\r\n  <h1 class=\"display-4\">");
            EndContext();
            BeginContext(112, 12, false);
#line 7 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
                   Write(Model.avatar);

#line default
#line hidden
            EndContext();
            BeginContext(124, 29, true);
            WriteLiteral("</h1>\r\n  <p class=\"lead\">ID: ");
            EndContext();
            BeginContext(154, 8, false);
#line 8 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
                 Write(Model.id);

#line default
#line hidden
            EndContext();
            BeginContext(162, 28, true);
            WriteLiteral("</p>\r\n  <p class=\"lead\">账号: ");
            EndContext();
            BeginContext(191, 14, false);
#line 9 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
                 Write(Model.userName);

#line default
#line hidden
            EndContext();
            BeginContext(205, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 10 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
   if(@Model.email!=null)
  {

#line default
#line hidden
            BeginContext(243, 26, true);
            WriteLiteral("      <p class=\"lead\">邮箱: ");
            EndContext();
            BeginContext(270, 11, false);
#line 12 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
                     Write(Model.email);

#line default
#line hidden
            EndContext();
            BeginContext(281, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 13 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
  }

#line default
#line hidden
            BeginContext(292, 53, true);
            WriteLiteral("  \r\n  <hr class=\"my-4\">\r\n  <p class=\"lead\">身份: </p>\r\n");
            EndContext();
#line 17 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
   foreach (var item in Model.roles)
  {

#line default
#line hidden
            BeginContext(388, 9, true);
            WriteLiteral("      <p>");
            EndContext();
            BeginContext(398, 4, false);
#line 19 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
    Write(item);

#line default
#line hidden
            EndContext();
            BeginContext(402, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 20 "E:\天蓝蓝考试系统\SkyBlueBlue\Views\My\Index.cshtml"
  }

#line default
#line hidden
            BeginContext(413, 28, true);
            WriteLiteral("  \r\n  <p class=\"lead\">\r\n    ");
            EndContext();
            BeginContext(441, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bcfe2d795c1286195e16ab6c6de396ada49986d7087", async() => {
                BeginContext(515, 4, true);
                WriteLiteral("历史成绩");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(523, 38, true);
            WriteLiteral("\r\n  </p>\r\n  \r\n  <p class=\"lead\">\r\n    ");
            EndContext();
            BeginContext(561, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bcfe2d795c1286195e16ab6c6de396ada49986d8665", async() => {
                BeginContext(637, 4, true);
                WriteLiteral("修改密码");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(645, 24, true);
            WriteLiteral("\r\n  </p>\r\n  \r\n  \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyInfoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
