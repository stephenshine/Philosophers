using Philosophers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Philosophers.Infrastructure
{
    public static class CustomHelpers
    {

        public static MvcHtmlString PhilosopherData(this HtmlHelper html, Philosopher philosopher)
        {
            TagBuilder tag = new TagBuilder("dl");

            TagBuilder data = new TagBuilder("dd");
            
            data.SetInnerText(philosopher.Nationality.Name);
            tag.InnerHtml += data.ToString();

            return new MvcHtmlString(tag.ToString());
        }
    }
}