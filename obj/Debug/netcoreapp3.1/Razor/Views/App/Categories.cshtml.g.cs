#pragma checksum "C:\Users\Marko\Desktop\M\Projekti\InventoryApp\Views\App\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "986a651629bb22839b92bdc9cdcf375302f059fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_App_Categories), @"mvc.1.0.view", @"/Views/App/Categories.cshtml")]
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
#line 1 "C:\Users\Marko\Desktop\M\Projekti\InventoryApp\Views\_ViewImports.cshtml"
using Inventory;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Marko\Desktop\M\Projekti\InventoryApp\Views\_ViewImports.cshtml"
using Inventory.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"986a651629bb22839b92bdc9cdcf375302f059fe", @"/Views/App/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddd647dc521e354fabd3c5f5959fac0949cf3697", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_App_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""text-center"">
    <h1 class=""display-4"">Categories</h1>
    <button onclick=""openForm()"">Add New Category</button>
</div>

<div class=""listsContainer"">
    <table id=""categoryTable"">
        <tr>
            <th>Category Name</th>
            <th></th>
            <th></th>
        </tr>
    </table>
</div>

");
            WriteLiteral("<div id=\"myModal\" class=\"modal\">\r\n\r\n  <!-- Modal content -->\r\n  <div class=\"modal-content\">\r\n    <span class=\"close\" onclick=\"closeForm()\">&times;</span>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "986a651629bb22839b92bdc9cdcf375302f059fe3812", async() => {
                WriteLiteral("\r\n        <input placeholder=\"Category name...\" id=\"categoryName\"/>\r\n        <input class=\"itemForm-input\" type=\"button\" value=\"Add\" id=\"addButton\" onclick=\"addCategory()\" />\r\n\r\n    ");
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
            WriteLiteral("\r\n  </div>\r\n</div>\r\n<div id=\"myModal2\" class=\"modal2\">\r\n\r\n  <!-- Modal content -->\r\n  <div class=\"modal-content2\">\r\n    <span class=\"close2\" onclick=\"closeForm2()\">&times;</span>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "986a651629bb22839b92bdc9cdcf375302f059fe5449", async() => {
                WriteLiteral("\r\n        <input placeholder=\"Category name...\" id=\"categoryName2\"/>\r\n        <input class=\"itemForm-input\" type=\"button\" value=\"Edit\" id=\"editButton\" />\r\n\r\n    ");
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
            WriteLiteral(@"
  </div>
</div>

<script type=""text/javascript"">
window.onclick = function(event) {
  modal = document.getElementById(""myModal"");
  if (event.target == modal) {
    modal.style.display = ""none"";
    document.getElementById(""categoryName"").value="""";
    document.getElementById(""categoryName2"").value="""";
  }
}
function openForm() {
    document.getElementById(""myModal"").style.display = ""block"";
}
function closeForm() {
      document.getElementById(""myModal"").style.display = ""none"";
      document.getElementById(""categoryName"").value="""";

}
function addCategory() {
    let categoryName = document.getElementById(""categoryName"").value;
    console.log(categoryName);
    var category = {
        ""CategoryId"":0,
        ""CategoryName"":categoryName
    }
    axios.post(""/api/category/addcategory"", category).then(response=>(addOneCategory(response.data)));
    closeForm();
}
function addOneCategory(category) {
    let table = document.getElementById(""categoryTable"");
    var tr = doc");
            WriteLiteral(@"ument.createElement(""tr"");
    var categoryName = document.createElement(""td"");
    var del=document.createElement(""td"");
    var ed = document.createElement(""td"");
    categoryName.innerHTML = category.categoryName;
    del.innerHTML=`<input type=""button"" value = ""Delete"" onClick=""Delete(${category.categoryId},this)"">`;
    ed.innerHTML=`<input type=""button"" value = ""Edit"" onClick=""openForm2(${category.categoryId},this)"">`;
        
        
    tr.appendChild(categoryName);
    tr.appendChild(del);
    tr.appendChild(ed);

    table.appendChild(tr);
}
function fillItem(categories) {
    
    let table = document.getElementById(""categoryTable"");
    for (var i = 0; i < categories.length; i++) {
        var tr = document.createElement(""tr"");
        var categoryName = document.createElement(""td"");
        var del=document.createElement(""td"");
        var ed = document.createElement(""td"");

        
       
        categoryName.innerHTML = categories[i].categoryName;
        del.inne");
            WriteLiteral(@"rHTML=`<input type=""button"" value = ""Delete"" onClick=""Delete(${categories[i].categoryId},this)"">`;
        ed.innerHTML=`<input type=""button"" value = ""Edit"" onClick=""openForm2(${categories[i].categoryId},this)"">`;
        
        
        tr.appendChild(categoryName);
        tr.appendChild(del);
        tr.appendChild(ed);

        table.appendChild(tr);
    }

}
function Delete(id,r) {
    console.log(""delete clik on "", id);
    axios.delete(`/api/category/${id}`);
    var i = r.parentNode.parentNode.rowIndex;
    document.getElementById(""categoryTable"").deleteRow(i);
}
function openForm2(id,r) {
    var i = r.parentNode.parentNode.rowIndex;

    document.getElementById(""myModal2"").style.display = ""block"";
    axios.get(`/api/category/${id}`).then(response=>(console.log(response.data),
        document.getElementById(""categoryName2"").value = response.data.categoryName,
        document.getElementById(""editButton"").setAttribute(""onclick"",`editCategory(${response.data.categoryId},${i}");
            WriteLiteral(@")`)))
}
function closeForm2() {
      document.getElementById(""myModal2"").style.display = ""none"";
}
function editCategory(id,i) {
    console.log(""edit clik on "", id);
    let editedCategory = {
        ""CategoryId"":id,
        ""CategoryName"":document.getElementById(""categoryName2"").value
    }
    axios.put(`/api/category/categoryedit/`,editedCategory);
    document.getElementById(""categoryTable"").rows[i].cells[0].innerHTML=document.getElementById(""categoryName2"").value;
    closeForm2(); 
}
axios.get(""/api/category"").then(response => (fillItem(response.data), console.log(response.data)));
</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
