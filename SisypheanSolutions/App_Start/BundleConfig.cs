﻿using System.Web;
using System.Web.Optimization;

namespace SisypheanSolutions
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts")
                   .Include("~/Scripts/alertify.min.js", 
                            "~/Scripts/bootstrap-dialog.min.js",
                            "~/Scripts/sammy.min.js",
                            "~/Scripts/routing.js"));

            bundles.Add(new StyleBundle("~/bundles/styles")
                   .Include("~/Content/CSS/bootstrap.min.css",
                            "~/Content/CSS/bootstrap.min.css.map",
                            "~/Content/CSS/bootstrap-dialog.min.css",
                            "~/Content/CSS/font-awesome.min.css",
                            "~/Content/CSS/*.css"));
        }
    }
}
