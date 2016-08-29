using System.Web;
using System.Web.UI;

namespace Maintenance
{
    public partial class Default : Page
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.Redirect("Angular/Index.html");
        }
    }
}