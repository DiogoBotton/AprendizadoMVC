#pragma checksum "C:\Users\42299106812\Documents\JornalOnlineMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c1e87c76cf9b91372b3e59004c4d3d2d85e7966"
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
#line 1 "C:\Users\42299106812\Documents\JornalOnlineMVC\Views\_ViewImports.cshtml"
using JornalOnlineMVC;

#line default
#line hidden
#line 2 "C:\Users\42299106812\Documents\JornalOnlineMVC\Views\_ViewImports.cshtml"
using JornalOnlineMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c1e87c76cf9b91372b3e59004c4d3d2d85e7966", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be482d8f8c8cccec8fa395969e05217b2f39b0a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 40, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"pt-br\">\r\n\r\n");
            EndContext();
            BeginContext(40, 312, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9817a4b8484fc4a54dec80f81f3bda", async() => {
                BeginContext(46, 299, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <title>Bona Notícias</title>
    <link rel=""stylesheet"" href=""css/style.css"">
    <!-- Explicação sobre o VIEWPORT: https://blog.caelum.com.br/pixels-pixels-ou-pixels-dicas-de-web-mobile-com-viewport/ -->
    <meta name=""viewport"" content=""width=device-width"">
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(352, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(356, 4300, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c8685506fac44799b2ad28b63b4bcfe6", async() => {
                BeginContext(362, 4287, true);
                WriteLiteral(@"
    <header>

        <div id=""cabeçalho"">
            <div class=""section-container"">
                <h2 class=""titulo"">Bona<br> Notícias</h2>
            </div>
        </div>
        <nav class=""menu"">
            <div class=""section-container"">
                <ul>
                    <li><a href=""#"">Novas</a></li>
                    <li><a href=""#"">Esporte</a></li>
                    <li><a href=""#"">Política</a></li>
                    <li><a href=""#"">Educação</a></li>
                    <li><a href=""#"">Economia</a></li>
                    <li><a href=""#"">Ciência</a></li>
                </ul>
            </div>
        </nav>
    </header>
    <main>
        <!--Manchete principal-->
        <div class=""manchete-principal"">
            <div>
                <a href=""#"" id=""manchete"">
                    <div class=""image"">
                        <ul>
                            <li>Meio ambiente</li>
                            <li class=""space""></li>
              ");
                WriteLiteral(@"              <li class=""main-manchete"">Foto de fumaça das queimadas na Amazônia é registrada por
                                astronauta na Estação Espacial.</li>
                        </ul>
                    </div>
                </a>
            </div>
            <!------------------------>
            <div class=""sessao-principais"">

                <div>
                    <a href=""#"" class=""exemplo"">

                        <figure>
                            <img src=""Img/Amazonia.jpg"">
                            <figcaption>Algo que resume a imagem.</figcaption>
                        </figure>
                        <div class=""main-title"">
                            <p>Foto de fumaça das queimadas na Amazônia é registrada por astronauta na Estação Espacial.
                            </p>
                            <p>Subtitulo</p>
                        </div>
                    </a>
                </div>

                <div>
                    <a hr");
                WriteLiteral(@"ef=""#"" class=""exemplo"">

                        <figure>
                            <img src=""Img/Amazonia.jpg"">
                            <figcaption>Algo que resume a imagem.</figcaption>
                        </figure>
                        <div class=""main-title"">
                            <p>Manchete</p>
                            <p>Subtítulo</p>
                        </div>
                    </a>
                </div>

                <div>
                    <a href=""#"" class=""exemplo"">

                        <figure>
                            <img src=""Img/Amazonia.jpg"">
                            <figcaption>Algo que resume a imagem.</figcaption>
                        </figure>
                        <div class=""main-title"">
                            <p>Manchete</p>
                            <p>Subtítulo</p>
                        </div>
                    </a>
                </div>

                <div>
                    <a href=""#"" cla");
                WriteLiteral(@"ss=""exemplo"">

                        <figure>
                            <img src=""Img/Amazonia.jpg"">
                            <figcaption>Algo que resume a imagem.</figcaption>
                        </figure>
                        <div class=""main-title"">
                            <p>Manchete</p>
                            <p>Subtítulo</p>
                        </div>
                    </a>
                </div>

            </div>

        </div>
        


    </main>
    <footer>
        <nav class=""menu-bottom"">
            <div class=""section-container"">
                <ul>
                    <li><a href=""#"">Novas</a></li>
                    <li><a href=""#"">Esporte</a></li>
                    <li><a href=""#"">Política</a></li>
                    <li><a href=""#"">Educação</a></li>
                    <li><a href=""#"">Economia</a></li>
                    <li><a href=""#"">Ciência</a></li>
                </ul>
            </div>
        </nav>
        <d");
                WriteLiteral("iv id=\"cabecalho-bottom\">\r\n            <div class=\"section-container\">\r\n                <h2 class=\"titulo-bottom\">Bona<br> Notícias</h2>\r\n            </div>\r\n        </div>\r\n    </footer>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4656, 11, true);
            WriteLiteral("\r\n\r\n</html>");
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
