using David.BooksStore.WebApp.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Text;

namespace Microsoft.AspNetCore.Mvc
{
    public static class PagingHelpers
    {
        /// <summary>
        /// Create html tag like 
        /// <a class="btn btn-default" href="/?page=2">2</a>
        /// <a class="btn btn-default btn-primary selected" href="/?page=3">3</a>
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static HtmlString PageLinks(this IHtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml.AppendHtml(i.ToString());
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return new HtmlString(result.ToString());
        }
    }
}
