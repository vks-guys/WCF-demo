using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloserviceClient
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (HelloServiceClient.HelloServiceClient client = new HelloServiceClient.HelloServiceClient("BasicHttpBinding_IHelloService"))
            {
                //new HelloServiceClient.HelloServiceClient().ClientCredentials.

                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var webUserToken = new MessageHeader<string>("joe.blogs");
                    var webUserHeaderToken = webUserToken.GetUntypedHeader("token", "ns");
                    OperationContext.Current.OutgoingMessageHeaders.Add(webUserHeaderToken);

                    var webUserName = new MessageHeader<string>("vivek");
                    var webUserHeaderName = webUserName.GetUntypedHeader("name", "ns");
                    OperationContext.Current.OutgoingMessageHeaders.Add(webUserHeaderName);

                    string str = client.GetMessage(TextBox1.Text);
                    Label1.Text = str;
                }
            }
        }
    }
}