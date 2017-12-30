using System;
using System.Collections.Generic;
using System.Text;

namespace Paperboy.Models.NewsInfo
{
    public enum NewsCategoryType
    {
        Business,
        Entertainment,
        Health,
        Politics,
        ScienceAndTechnology,
        Sports,
        World
    }

    public class NewsInformation
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class NewsResult
    {
        public string ReadLink { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public Value[] Value { get; set; }
    }

    public class Value
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }
        public About[] About { get; set; }
        public Provider[] Provider { get; set; }
        public DateTime DatePublished { get; set; }
        public string Category { get; set; }
        public Video Video { get; set; }
        public Clusteredarticle[] ClusteredArticles { get; set; }
    }

    public class Image
    {
        public Thumbnail Thumbnail { get; set; }
    }

    public class Thumbnail
    {
        public string ContentUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Video
    {
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool AllowHttpsEmbed { get; set; }
        public Thumbnail1 Thumbnail { get; set; }
    }

    public class Thumbnail1
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class About
    {
        public string ReadLink { get; set; }
        public string Name { get; set; }
    }

    public class Provider
    {
        public string Name { get; set; }
    }

    public class Clusteredarticle
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public About1[] About { get; set; }
        public Mention[] Mentions { get; set; }
        public Provider1[] Provider { get; set; }
        public DateTime DatePublished { get; set; }
        public string Category { get; set; }
    }

    public class About1
    {
        public string ReadLink { get; set; }
        public string Name { get; set; }
    }

    public class Mention
    {
        public string Name { get; set; }
    }

    public class Provider1
    {
        public string Name { get; set; }
    }
}
