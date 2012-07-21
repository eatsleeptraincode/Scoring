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
            Editors.IfPropertyIs<Time>().BuildBy(TimeBuilder.BuildEditor);
            Displays.IfPropertyIs<Time>().BuildBy(TimeBuilder.BuildDisplay);
            Editors.If(a => a.Accessor.Name.EndsWith("Id")).Attr("type", "hidden");
            Editors.If(a => a.Accessor.Name.Contains("Pass")).Attr("type", "password");
            Editors.IfPropertyIs<Gender>().BuildBy(GenderBuilder);
            Editors.IfPropertyIs<ScoreType>().BuildBy(ScoreTypeBuilder);
        }

        private HtmlTag ScoreTypeBuilder(ElementRequest request)
        {
            var genders = Enum.GetValues(typeof(ScoreType)).Cast<ScoreType>().ToList();
            var tag = new SelectTag(t =>
            {
                genders.Each(g => t.Option(g.ToString(), g));
                t.SelectByValue((request.RawValue ?? ScoreType.Time).ToString());
            });
            return tag;
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