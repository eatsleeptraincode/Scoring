using System;
using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;
using Scoring.Web.Models;

namespace Scoring.Web.Config
{
    public class ConfigureHtml : HtmlConventionRegistry
    {
        public ConfigureHtml()
        {
            Editors.IfPropertyIs<Gender>().BuildBy(GenderBuilder);
        }

        private HtmlTag GenderBuilder(ElementRequest request)
        {
            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            var tag = new SelectTag(t =>
            {
                genders.Each(g => t.Option(g.ToString(), g));
                t.SelectByValue((request.RawValue ?? Gender.Male).ToString());
            });
            return tag;
        }
    }
}