﻿using System;
using System.Web;
using Core.Player;

namespace X.Media.WebPlayer
{
    public abstract class Player : IPlayer
    {
        protected string _url;

        public Player()
        {
            Width = 500;
            Height = 300;
        }

        public Player(string url)
            : this()
        {
            _url = url;
        }


        public abstract HtmlString Render();

        public static IPlayer Create(string url)
        {
            if (url.Contains("youtube"))
            {
                return new YouTubePlayer(url);
            }
            else if (url.Contains("vimeo"))
            {
                return new VimeoPlayer(url);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public int Height { get; set; }
        public int Width { get; set; }

        public abstract void Initilize(string url);
    }
}
