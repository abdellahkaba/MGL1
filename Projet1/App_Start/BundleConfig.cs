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

            bundles.Add(new ScriptBundle("~/bundles/sweetalert/js").Include(
                       "~/Content/sweetalert/sweetalert2.all.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert/js").Include(
                      "~/Content/sweetalert/sweetalert2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jsasset").Include(
                        "~/asset/vendor/global/global.min.js",
                        "~/asset/js/quixnav-init.js",
                        "~/asset/js/custom.min.js",
                        "~/asset/js/plugins-init/jquery-asColorPicke.init.js",
                        "~/asset/js/plugins-init/jquery-steps-init.js",
                        "~/asset/js/plugins-init/jquery.bootgrid-init.js",
                        "~/asset/js/plugins-init/jquery.validate-init.js",
                        "~/asset/vendor/chartist/js/chartist.min.js",
                         "~/asset/vendor/jquery/jquery.min.css",
                        "~/asset/vendor/moment/moment.min.js",
                        "~/asset/vendor/pg-calendar/js/pignose.calendar.min.js",
                        "~/asset/js/dashboard/dashboard-2.js"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/boostrap.css",
                "~/Content/PagedList.css",
                "~/Content/site.css"
                ));

            bundles.Add(new StyleBundle("~/Content/asset").Include(
                    "~/asset/vendor/pg-calendar/css/pignose.calendar.min.css",
                    "~/asset/vendor/chartist/css/chartist.min.css",
                    "~/Content/PagedList.css",
                    "~/asset/css/style.css"));
        }
    }
}
