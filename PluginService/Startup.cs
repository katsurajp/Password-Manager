using Owin;
using System.Web.Http;

namespace PluginServiceApplication {
    public class Startup {
        public void Configuration(IAppBuilder appBuilder) {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "PwApi",
                routeTemplate: "PwApi/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);
        }
    }
}
