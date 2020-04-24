#pragma checksum "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b337354bf8e8f4dd423025daa64f952678ee797"
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
#line 1 "C:\Users\Konrad\StarCinema\StarCinema\Views\_ViewImports.cshtml"
using StarCinema;

#line default
#line hidden
#line 2 "C:\Users\Konrad\StarCinema\StarCinema\Views\_ViewImports.cshtml"
using StarCinema.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b337354bf8e8f4dd423025daa64f952678ee797", @"/Views/Movie/MoviesFromCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc3cd5b81a2f73d0e8b6090a82c9e0b98b6d9c4d", @"/Views/_ViewImports.cshtml")]
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
#line 2 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
  
    ViewData["Title"] = "MoviesFromCategory";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(162, 102, true);
            WriteLiteral("\n<div class=\"row\">\n    <div class=\"col-xs-12\">\n        <h2><i class=\"glyphicon glyphicon-th-lis\"></i> ");
            EndContext();
            BeginContext(265, 18, false);
#line 9 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                  Write(Model.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(283, 40, true);
            WriteLiteral("</h2>\n        <hr />\n    </div>\n</div>\n\n");
            EndContext();
#line 14 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
 foreach (var movie in Model.MoviesFromCategory)
{
    var imgSrc = "../../images/MoviesPosters/" + movie.Id + ".jpg";

#line default
#line hidden
            BeginContext(442, 95, true);
            WriteLiteral("    <div class=\"row list-movie-panel\">\n        <div class=\"col-md-3\">\n            <img class=\"\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 537, "\"", 550, 1);
#line 19 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
WriteAttributeValue("", 543, imgSrc, 543, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(551, 70, true);
            WriteLiteral(" alt=\"...\">\n        </div>\n        <div class=\"col-md-9\">\n            ");
            EndContext();
            BeginContext(621, 191, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07a8d634ec2b445c8e8a767d28be4770", async() => {
                BeginContext(716, 62, true);
                WriteLiteral("\n                <h2><i class=\"glyphicon glyphicon-film\"></i> ");
                EndContext();
                BeginContext(779, 11, false);
#line 23 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                        Write(movie.Title);

#line default
#line hidden
                EndContext();
                BeginContext(790, 18, true);
                WriteLiteral("</h2>\n            ");
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
#line 22 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
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
            BeginContext(812, 75, true);
            WriteLiteral("\n                <h4><i class=\"glyphicon glyphicon-calendar\"></i> Release: ");
            EndContext();
            BeginContext(888, 37, false);
#line 25 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                                     Write(movie.ReleaseDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(925, 25, true);
            WriteLiteral("</h4>\n                <p>");
            EndContext();
            BeginContext(951, 17, false);
#line 26 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
              Write(movie.Description);

#line default
#line hidden
            EndContext();
            BeginContext(968, 79, true);
            WriteLiteral("</p>\n                <h4><i class=\"glyphicon glyphicon-comment\"></i> Comments: ");
            EndContext();
            BeginContext(1048, 20, false);
#line 27 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
                                                                     Write(movie.Comments.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1068, 22, true);
            WriteLiteral("</h4>\n                ");
            EndContext();
            BeginContext(1090, 290, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4b1f12ab05045f38af6d6bd479fa64b", async() => {
                BeginContext(1155, 56, true);
                WriteLiteral("\n                    <input type=\"hidden\" name=\"movieId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1211, "\"", 1228, 1);
#line 29 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
WriteAttributeValue("", 1219, movie.Id, 1219, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1229, 144, true);
                WriteLiteral(" />\n                    <button class=\"btn btn-warning btn-big\"> <i class=\"glyphicon glyphicon-zoom-in\"></i> SHOW MORE</button>\n                ");
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
            BeginContext(1380, 61, true);
            WriteLiteral("\n                <br />\n        </div>\n    </div>\n    <br />\n");
            EndContext();
#line 36 "C:\Users\Konrad\StarCinema\StarCinema\Views\Movie\MoviesFromCategory.cshtml"
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
