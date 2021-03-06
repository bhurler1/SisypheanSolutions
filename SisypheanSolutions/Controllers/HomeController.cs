﻿using System;
using System.Web.Mvc;
using System.Xml;
using System.Text;
using System.Web;
using SisypheanSolutions.Utilities;

namespace SisypheanSolutions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return PartialView("_Home");
        }

        public ActionResult News()
        {
            string feed = ParseRssFile(System.Web.HttpContext.Current);
            return PartialView("_News", feed);
        }

        public ActionResult About()
        {
            return PartialView("_About");
        }

        private static string ParseRssFile(HttpContext context)
        {
            const string cachedFeed = "RssFeed";

            //Get feed if it is in the cache.
            string feed = context.Cache[cachedFeed] as string ?? "";

            //Return cached feed.
            if (!string.IsNullOrEmpty(feed)) return feed;

            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load("https://wdrl.info/feed");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();

            if (rssNodes == null) return "No feed available.";

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode?.InnerText ?? "";

                title = "Web Development Reading List, Issue " + title;

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode?.InnerText ?? "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode?.InnerText ?? "";

                rssContent.Append("<a href='" + link + "'>" + title + "</a>" + description);
            }

            // Return the string that contain the RSS items and remove the promotional GetPocket links.
            string output = rssContent.ToString().ReplaceAll("<a class=\"save-service-link\"", "</a>");

            //Cache the feed for an hour.
            context.Cache.Insert(cachedFeed, output, null, DateTime.UtcNow.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration);

            return output;
        }
    }
}