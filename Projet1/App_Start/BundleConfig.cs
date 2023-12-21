using System.Web;
using System.Web.Optimization;

namespace Projet1
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jsasset").Include(
                        "~/asset/vendor/global/global.min.js",
                        "~/asset/js/quixnav-init.js",
                        "~/asset/js/custom.min.js",
                        "~/asset/vendor/chartist/js/chartist.min.js",
                        "~/asset/vendor/moment/moment.min.js",
                        "~/asset/vendor/pg-calendar/js/pignose.calendar.min.js",
                        "~/asset/js/dashboard/dashboard-2.js"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/asset").Include(
                    "~/asset/vendor/pg-calendar/css/pignose.calendar.min.css",
                    "~/asset/vendor/chartist/css/chartist.min.css,",
                    "~/asset/css/style.css"));
        }
    }
}
