#pragma checksum "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5558ca69475e6b12ef07c183bf133fdc025113fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\_ViewImports.cshtml"
using StarCinema;

#line default
#line hidden
#line 2 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\_ViewImports.cshtml"
using StarCinema.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5558ca69475e6b12ef07c183bf133fdc025113fb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f4f1abac361fdcd5376e984ea10d0dbef4828eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StarCinema.Models.IndexModels.IndexMoviesListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Movie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MoviesFromCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("movie-card-a"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowMovie", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(108, 401, true);
            WriteLiteral(@"<div id=""carousel-example-generic"" class=""carousel slide"" data-ride=""carousel"">
    <!-- Indicators -->
    <ol class=""carousel-indicators"">
        <li data-target=""#carousel-example-generic"" data-slide-to=""0"" class=""active""></li>
        <li data-target=""#carousel-example-generic"" data-slide-to=""1""></li>
        <li data-target=""#carousel-example-generic"" data-slide-to=""2""></li>
    </ol>
");
            EndContext();
#line 12 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
      
        var path = "images/MoviesPosters/";
    

#line default
#line hidden
            BeginContext(569, 161, true);
            WriteLiteral("    <!-- Wrapper for slides -->\r\n    <div class=\"carousel-inner\" role=\"listbox\">\r\n        <div class=\"item active\">\r\n            <div class=\"item-container-left\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 730, "\"", 878, 2);
            WriteAttributeValue("", 738, "background:linear-gradient(0deg,rgba(30,30,30,0.3),rgba(30,30,30,0.3)),url(", 738, 75, true);
#line 18 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
WriteAttributeValue("", 813, path+Model.LatestMovies.ElementAt(0).Id.ToString()+"Index.jpg", 813, 65, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(879, 100, true);
            WriteLiteral(">\r\n                <div class=\"item-content col-md-5\">\r\n                    <h2 class=\"carousel-h2\">");
            EndContext();
            BeginContext(980, 37, false);
#line 20 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                       Write(Model.LatestMovies.ElementAt(0).Title);

#line default
#line hidden
            EndContext();
            BeginContext(1017, 60, true);
            WriteLiteral("</h2>\r\n                    <h3 class=\"carousel-h3\">Release: ");
            EndContext();
            BeginContext(1078, 63, false);
#line 21 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                                Write(Model.LatestMovies.ElementAt(0).ReleaseDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1141, 531, true);
            WriteLiteral(@"</h3>
                    <button class=""btn btn-danger carousel-button"">SHOW MORE</button>
                    <button class=""btn btn-warning carousel-button"">BOOK A TICKET</button>
                </div>
                <div class=""item-content-transparent col-md-7"">
                    <i class=""glyphicon glyphicon-play-circle carousel-icon""></i><h1 class=""watch-trailer-h1"">TRAILER</h1>
                </div>
            </div>
        </div>
        <div class=""item"">
            <div class=""item-container-left""");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 1672, "\"", 1820, 2);
            WriteAttributeValue("", 1680, "background:linear-gradient(0deg,rgba(30,30,30,0.3),rgba(30,30,30,0.3)),url(", 1680, 75, true);
#line 31 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
WriteAttributeValue("", 1755, path+Model.LatestMovies.ElementAt(1).Id.ToString()+"Index.jpg", 1755, 65, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1821, 100, true);
            WriteLiteral(">\r\n                <div class=\"item-content col-md-5\">\r\n                    <h2 class=\"carousel-h2\">");
            EndContext();
            BeginContext(1922, 37, false);
#line 33 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                       Write(Model.LatestMovies.ElementAt(1).Title);

#line default
#line hidden
            EndContext();
            BeginContext(1959, 60, true);
            WriteLiteral("</h2>\r\n                    <h3 class=\"carousel-h3\">Release: ");
            EndContext();
            BeginContext(2020, 63, false);
#line 34 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                                Write(Model.LatestMovies.ElementAt(1).ReleaseDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(2083, 531, true);
            WriteLiteral(@"</h3>
                    <button class=""btn btn-danger carousel-button"">SHOW MORE</button>
                    <button class=""btn btn-warning carousel-button"">BOOK A TICKET</button>
                </div>
                <div class=""item-content-transparent col-md-7"">
                    <i class=""glyphicon glyphicon-play-circle carousel-icon""></i><h1 class=""watch-trailer-h1"">TRAILER</h1>
                </div>
            </div>
        </div>
        <div class=""item"">
            <div class=""item-container-left""");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2614, "\"", 2762, 2);
            WriteAttributeValue("", 2622, "background:linear-gradient(0deg,rgba(30,30,30,0.3),rgba(30,30,30,0.3)),url(", 2622, 75, true);
#line 44 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
WriteAttributeValue("", 2697, path+Model.LatestMovies.ElementAt(2).Id.ToString()+"Index.jpg", 2697, 65, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2763, 100, true);
            WriteLiteral(">\r\n                <div class=\"item-content col-md-5\">\r\n                    <h2 class=\"carousel-h2\">");
            EndContext();
            BeginContext(2864, 37, false);
#line 46 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                       Write(Model.LatestMovies.ElementAt(2).Title);

#line default
#line hidden
            EndContext();
            BeginContext(2901, 60, true);
            WriteLiteral("</h2>\r\n                    <h3 class=\"carousel-h3\">Release: ");
            EndContext();
            BeginContext(2962, 63, false);
#line 47 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                                Write(Model.LatestMovies.ElementAt(2).ReleaseDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(3025, 662, true);
            WriteLiteral(@"</h3>
                    <button class=""btn btn-danger carousel-button"">SHOW MORE</button>
                    <button class=""btn btn-warning carousel-button"">BOOK A TICKET</button>
                </div>
                <div class=""item-content-transparent col-md-7"">
                    <i class=""glyphicon glyphicon-play-circle carousel-icon""></i><h1 class=""watch-trailer-h1"">TRAILER</h1>
                </div>
            </div>
        </div>
    </div>
</div>
<br />
<div id=""collapse2"" class=""row"">
    <div class=""hidden-md hidden-sm hidden-xs col-lg-8"">
        <div class=""btn-group btn-group-justified"" role=""group"" aria-label=""..."">
");
            EndContext();
#line 62 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
             foreach (var category in Model.Categories)
            {


#line default
#line hidden
            BeginContext(3761, 74, true);
            WriteLiteral("                <div class=\"btn-group\" role=\"group\">\r\n                    ");
            EndContext();
            BeginContext(3835, 319, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd728f6e25814cbfbfe63e0b6fecd146", async() => {
                BeginContext(3909, 66, true);
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"categoryName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3975, "\"", 4005, 1);
#line 67 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
WriteAttributeValue("", 3983, category.CategoryName, 3983, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4006, 88, true);
                WriteLiteral(" />\r\n                        <button type=\"submit\" class=\"btn-category btn btn-default\">");
                EndContext();
                BeginContext(4095, 21, false);
#line 68 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                                                              Write(category.CategoryName);

#line default
#line hidden
                EndContext();
                BeginContext(4116, 31, true);
                WriteLiteral("</button>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4154, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
#line 71 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(4195, 66, true);
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n    <div class=\"col-lg-4\">\r\n        ");
            EndContext();
            BeginContext(4261, 369, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c863a2ceab248aeb5b8506eead152c2", async() => {
                BeginContext(4267, 356, true);
                WriteLiteral(@"
            <div class=""input-group"">
                <input type=""text"" class=""nav-search form-control"" placeholder=""Find your cinema"">
                <span class=""input-group-btn"">
                    <button class=""btn-search btn btn-danger"" type=""button"">SEARCH</button>
                </span>
            </div><!-- /input-group -->
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4630, 641, true);
            WriteLiteral(@"
    </div>
</div>
<div class=""row"">
    <div class=""index-content col-lg-12"">
        <ul class=""nav nav-pills nav-justified"" id=""indexTab"">
            <li class=""active""><a data-toggle=""tab"" href=""#newest""><i class=""glyphicon glyphicon-time""></i> Newest</a></li>
            <li><a data-toggle=""tab"" href=""#soon""><i class=""glyphicon glyphicon-calendar""></i> Coming soon</a></li>
            <li><a data-toggle=""tab"" href=""#highestRated""><i class=""glyphicon glyphicon-fire""></i> Most popular</a></li>
        </ul>
        <br />
        <div class=""tab-content"">
            <div id=""newest"" class=""tab-pane fade in active"">
");
            EndContext();
#line 96 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                 foreach (var m in Model.LatestMovies)
                {
                    var imgSrc = "images/MoviesPosters/" + m.Id.ToString() + ".jpg";

#line default
#line hidden
            BeginContext(5432, 162, true);
            WriteLiteral("                    <div class=\"col-sm-6 col-md-4\">\r\n                        <br />\r\n                        <div class=\"thumbnail\">\r\n                            ");
            EndContext();
            BeginContext(5594, 327, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c070bed3d6c43de94162d98836f7e58", async() => {
                BeginContext(5685, 61, true);
                WriteLiteral("\r\n                                <img class=\"movie-card-img\"");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 5746, "\"", 5759, 1);
#line 103 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
WriteAttributeValue("", 5752, imgSrc, 5752, 7, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5760, 49, true);
                WriteLiteral(" alt=\"...\">\r\n                                <h4>");
                EndContext();
                BeginContext(5810, 7, false);
#line 104 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                               Write(m.Title);

#line default
#line hidden
                EndContext();
                BeginContext(5817, 42, true);
                WriteLiteral("</h4>\r\n                                <p>");
                EndContext();
                BeginContext(5860, 23, false);
#line 105 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                              Write(m.Category.CategoryName);

#line default
#line hidden
                EndContext();
                BeginContext(5883, 34, true);
                WriteLiteral("</p>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 102 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                                                                                    WriteLiteral(m.Id);

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
            BeginContext(5921, 62, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 109 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(6002, 71, true);
            WriteLiteral("            </div>\r\n            <div id=\"soon\" class=\"tab-pane fade\">\r\n");
            EndContext();
#line 112 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                 foreach (var m in Model.ComingSoonMovies)
                {
                    var imgSrc = "images/MoviesPosters/" + m.Id.ToString() + ".jpg";

#line default
#line hidden
            BeginContext(6238, 162, true);
            WriteLiteral("                    <div class=\"col-sm-6 col-md-4\">\r\n                        <br />\r\n                        <div class=\"thumbnail\">\r\n                            ");
            EndContext();
            BeginContext(6400, 317, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "084916637c4b430797342e9025794169", async() => {
                BeginContext(6491, 61, true);
                WriteLiteral("\r\n                                <img class=\"movie-card-img\"");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 6552, "\"", 6565, 1);
#line 119 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
WriteAttributeValue("", 6558, imgSrc, 6558, 7, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6566, 39, true);
                WriteLiteral(">\r\n                                <h4>");
                EndContext();
                BeginContext(6606, 7, false);
#line 120 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                               Write(m.Title);

#line default
#line hidden
                EndContext();
                BeginContext(6613, 42, true);
                WriteLiteral("</h4>\r\n                                <p>");
                EndContext();
                BeginContext(6656, 23, false);
#line 121 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                              Write(m.Category.CategoryName);

#line default
#line hidden
                EndContext();
                BeginContext(6679, 34, true);
                WriteLiteral("</p>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 118 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                                                                                    WriteLiteral(m.Id);

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
            BeginContext(6717, 62, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 125 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(6798, 79, true);
            WriteLiteral("            </div>\r\n            <div id=\"highestRated\" class=\"tab-pane fade\">\r\n");
            EndContext();
#line 128 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                 foreach (var m in Model.MostPopularMovies)
                {
                    var imgSrc = "images/MoviesPosters/" + m.Id.ToString() + ".jpg";

#line default
#line hidden
            BeginContext(7043, 162, true);
            WriteLiteral("                    <div class=\"col-sm-6 col-md-4\">\r\n                        <br />\r\n                        <div class=\"thumbnail\">\r\n                            ");
            EndContext();
            BeginContext(7205, 317, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9cd6a9c409e41a99ae085796395cdd3", async() => {
                BeginContext(7296, 61, true);
                WriteLiteral("\r\n                                <img class=\"movie-card-img\"");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 7357, "\"", 7370, 1);
#line 135 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
WriteAttributeValue("", 7363, imgSrc, 7363, 7, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(7371, 39, true);
                WriteLiteral(">\r\n                                <h4>");
                EndContext();
                BeginContext(7411, 7, false);
#line 136 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                               Write(m.Title);

#line default
#line hidden
                EndContext();
                BeginContext(7418, 42, true);
                WriteLiteral("</h4>\r\n                                <p>");
                EndContext();
                BeginContext(7461, 23, false);
#line 137 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                              Write(m.Category.CategoryName);

#line default
#line hidden
                EndContext();
                BeginContext(7484, 34, true);
                WriteLiteral("</p>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 134 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                                                                                                    WriteLiteral(m.Id);

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
            BeginContext(7522, 62, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 141 "C:\Users\User\Desktop\StarCinema\StarCinema\Views\Home\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(7603, 72, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n<br />\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StarCinema.Models.IndexModels.IndexMoviesListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
