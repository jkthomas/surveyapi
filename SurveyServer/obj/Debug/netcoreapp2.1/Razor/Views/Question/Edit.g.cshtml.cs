#pragma checksum "E:\VisualStudioProjects\SurveyServer\SurveyServer\Views\Question\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15014276f48872ce0af4d961f1f687d8b0d10481"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Question_Edit), @"mvc.1.0.view", @"/Views/Question/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Question/Edit.cshtml", typeof(AspNetCore.Views_Question_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15014276f48872ce0af4d961f1f687d8b0d10481", @"/Views/Question/Edit.cshtml")]
    public class Views_Question_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SurveyServer.Context.Survey.Entities.Entity_Question>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\VisualStudioProjects\SurveyServer\SurveyServer\Views\Question\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
            BeginContext(103, 1045, true);
            WriteLiteral(@"
<h2>Edit</h2>

<h4>Entity_Question</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""Id"" />
            <div class=""form-group"">
                <label asp-for=""Content"" class=""control-label""></label>
                <input asp-for=""Content"" class=""form-control"" />
                <span asp-validation-for=""Content"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Type"" class=""control-label""></label>
                <input asp-for=""Type"" class=""form-control"" />
                <span asp-validation-for=""Type"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-default"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to");
            WriteLiteral(" List</a>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1166, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 38 "E:\VisualStudioProjects\SurveyServer\SurveyServer\Views\Question\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SurveyServer.Context.Survey.Entities.Entity_Question> Html { get; private set; }
    }
}
#pragma warning restore 1591