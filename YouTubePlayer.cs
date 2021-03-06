﻿using System;
using System.Text.RegularExpressions;
using System.Web;

namespace X.Media.WebPlayer
{
    public class YouTubePlayer : Player
    {
        private string url;

        public YouTubePlayer(string url)
            : base(url)
        {
            Theme = Theme.Dark;
        }

        public Theme Theme { get; set; }

        public override HtmlString Render()
        {
            //Youtube: youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)
            var regex = new Regex("youtu(?:\\.be|be\\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)");

            var youtubeMatch = regex.Match(_url);

            string id;

            if (youtubeMatch.Success)
            {
                id = youtubeMatch.Groups[1].Value;
            }
            else
            {
                return new HtmlString("Cannot load player");
            }

            var embedUrl = String.Format("//www.youtube.com/embed/{0}", id);

            var width = Width == 0 ? "100%" : Width + "px";

            var theme = String.Empty;

            if (Theme == WebPlayer.Theme.Dark)
            {
                theme = "dark";
            }
            else if (Theme == WebPlayer.Theme.Light)
            {
                theme = "light";
            }

            var str = String.Format("<iframe width=\"{0}\" height=\"{1}px\" src=\"{2}?theme={3}\" frameborder=\"0\" allowfullscreen></iframe>",
                    width, Height, embedUrl, theme);

            return new HtmlString(str);
        }
    }
}
