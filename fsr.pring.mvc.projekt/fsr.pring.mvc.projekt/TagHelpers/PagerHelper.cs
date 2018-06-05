using fsr.pring.mvc.projekt.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fsr.pring.mvc.projekt.TagHelpers
{
    [HtmlTargetElement(Attributes = "page-info")]
    public class PagerTagHelper : TagHelper
    {

        private readonly IUrlHelperFactory urlHelperFactory;
        private readonly AppSettings appData;
        public PagerTagHelper(IUrlHelperFactory helperFactory, IOptionsSnapshot<AppSettings> options)
        {
            urlHelperFactory = helperFactory;
            appData = options.Value;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageInfo { get; set; }

        
        public IPageFilter PageFilter { get; set; }

        
        public string PageAction { get; set; }

       
        public string PageTitle { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            int offset = appData.PageOffset;
            TagBuilder navTag = new TagBuilder("nav");
            TagBuilder paginationList = new TagBuilder("ul");
            paginationList.AddCssClass("pagination");
            navTag.InnerHtml.AppendHtml(paginationList);

            if (PageInfo.CurrentPage - offset > 1)
            {
                var tag = BuildTagForPage(1, "1..");
                paginationList.InnerHtml.AppendHtml(tag);
            }
            for (int i = Math.Max(1, PageInfo.CurrentPage - offset);
                     i <= Math.Min(PageInfo.TotalPages, PageInfo.CurrentPage + offset);
                     i++)
            {
                if (i != PageInfo.CurrentPage)
                {
                    var tag = BuildTagForPage(i);
                    paginationList.InnerHtml.AppendHtml(tag);
                }
                else
                {
                    var tag = BuildPageInputTag(i.ToString());
                    paginationList.InnerHtml.AppendHtml(tag);
                }
            }

            if (PageInfo.CurrentPage + offset < PageInfo.TotalPages)
            {
                var tag = BuildTagForPage(PageInfo.TotalPages, ".. " + PageInfo.TotalPages);
                paginationList.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(navTag);
        }

        private TagBuilder BuildPageInputTag(string text)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder tag = new TagBuilder("input");
            tag.Attributes["type"] = "text";
            tag.Attributes["value"] = text;
            tag.Attributes["data-current"] = text;
            tag.Attributes["data-min"] = "1";
            tag.Attributes["data-max"] = PageInfo.TotalPages.ToString();
            tag.Attributes["data-url"] = urlHelper.Action(PageAction, new
            {
                page = -1,
                sort = PageInfo.Sort,
                ascending = PageInfo.Ascending,
                filter = PageFilter?.ToString()
            });
            tag.AddCssClass("pagebox");

            if (!string.IsNullOrWhiteSpace(PageTitle))
            {
                tag.Attributes["title"] = PageTitle;
            }

            TagBuilder listItemTag = new TagBuilder("li");
            listItemTag.AddCssClass("page-item active");
            listItemTag.InnerHtml.AppendHtml(tag);

            return tag;
        }

        private TagBuilder BuildTagForPage(int i)
        {
            return BuildTagForPage(i, i.ToString());
        }

        private TagBuilder BuildTagForPage(int i, string text)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder tag = new TagBuilder("a");
            tag.InnerHtml.Append(text);
            tag.Attributes["href"] = urlHelper.Action(PageAction, new
            {
                page = i,
                sort = PageInfo.Sort,
                ascending = PageInfo.Ascending,
                filter = PageFilter?.ToString()
            });
            tag.AddCssClass("page-link");

            TagBuilder listItemTag = new TagBuilder("li");
            listItemTag.AddCssClass("page-item");
            listItemTag.InnerHtml.AppendHtml(tag);

            return listItemTag;
        }
    }

}
