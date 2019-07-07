#pragma checksum "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bb8aa790932cf6b0b1a4408d67a76b9f44177c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_MoviesFromCategory), @"mvc.1.0.view", @"/Views/Movie/MoviesFromCategory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Movie/MoviesFromCategory.cshtml", typeof(AspNetCore.Views_Movie_MoviesFromCategory))]
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
#line 1 "E:\StarCinema\StarCinema\Views\_ViewImports.cshtml"
using StarCinema;

#line default
#line hidden
#line 2 "E:\StarCinema\StarCinema\Views\_ViewImports.cshtml"
using StarCinema.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bb8aa790932cf6b0b1a4408d67a76b9f44177c8", @"/Views/Movie/MoviesFromCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f4f1abac361fdcd5376e984ea10d0dbef4828eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Movie_MoviesFromCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StarCinema.Models.IndexModels.MoviesFromCategoryViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("movie-card-a"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowMovie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Movie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
  
    ViewData["Title"] = "MoviesFromCategory";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(167, 105, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-xs-12\">\r\n        <h2><i class=\"glyphicon glyphicon-th-lis\"></i> ");
            EndContext();
            BeginContext(273, 18, false);
#line 9 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                  Write(Model.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(291, 45, true);
            WriteLiteral("</h2>\r\n        <hr />\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
#line 14 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
 foreach (var movie in Model.MoviesFromCategory)
{
    var imgSrc = "../../images/MoviesPosters/" + movie.Id + ".jpg";

#line default
#line hidden
            BeginContext(458, 97, true);
            WriteLiteral("    <div class=\"row list-movie-panel\">\r\n        <div class=\"col-md-3\">\r\n            <img class=\"\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 555, "\"", 568, 1);
#line 19 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
WriteAttributeValue("", 561, imgSrc, 561, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(569, 73, true);
            WriteLiteral(" alt=\"...\">\r\n        </div>\r\n        <div class=\"col-md-9\">\r\n            ");
            EndContext();
            BeginContext(642, 193, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eab283f9b2484a7984d2c8c7b46621f4", async() => {
                BeginContext(737, 63, true);
                WriteLiteral("\r\n                <h2><i class=\"glyphicon glyphicon-film\"></i> ");
                EndContext();
                BeginContext(801, 11, false);
#line 23 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                        Write(movie.Title);

#line default
#line hidden
                EndContext();
                BeginContext(812, 19, true);
                WriteLiteral("</h2>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 22 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                                                    WriteLiteral(movie.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(835, 76, true);
            WriteLiteral("\r\n                <h4><i class=\"glyphicon glyphicon-calendar\"></i> Release: ");
            EndContext();
            BeginContext(912, 37, false);
#line 25 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                                     Write(movie.ReleaseDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(949, 26, true);
            WriteLiteral("</h4>\r\n                <p>");
            EndContext();
            BeginContext(976, 17, false);
#line 26 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
              Write(movie.Description);

#line default
#line hidden
            EndContext();
            BeginContext(993, 80, true);
            WriteLiteral("</p>\r\n                <h4><i class=\"glyphicon glyphicon-comment\"></i> Comments: ");
            EndContext();
            BeginContext(1074, 20, false);
#line 27 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                                     Write(movie.Comments.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1094, 23, true);
            WriteLiteral("</h4>\r\n                ");
            EndContext();
            BeginContext(1117, 288, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a97829105db4914b4251a30fd05a3a7", async() => {
                BeginContext(1182, 52, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1234, "\"", 1251, 1);
#line 29 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
WriteAttributeValue("", 1242, movie.Id, 1242, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1252, 146, true);
                WriteLiteral(" />\r\n                    <button class=\"btn btn-warning btn-big\"> <i class=\"glyphicon glyphicon-zoom-in\"></i> SHOW MORE</button>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1405, 66, true);
            WriteLiteral("\r\n                <br />\r\n        </div>\r\n    </div>\r\n    <br />\r\n");
            EndContext();
#line 36 "E:\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StarCinema.Models.IndexModels.MoviesFromCategoryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
