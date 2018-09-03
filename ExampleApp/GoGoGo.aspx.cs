using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ArchestrA.MxAccess;
using System.Threading;

namespace ExampleApp
{
    public partial class GoGoGo : System.Web.UI.Page
    {
        // LMX Interface declarations
        ArchestrA.MxAccess.LMXProxyServerClass LMX_Server;

        // handle of registered LMX server interface
        int hLMX;

        // item information
        int hItem;
        public int blocker = 0;
        int timeout = 10; // 10 seconds in the page load delay
        int userID;


        protected void Page_Load(object sender, EventArgs e)
        {
            LMX_Server = new ArchestrA.MxAccess.LMXProxyServerClass();
            hLMX = LMX_Server.Register("ExampleApp");
            LMX_Server.OnWriteComplete += new _ILMXProxyServerEvents_OnWriteCompleteEventHandler(LMX_OnWriteComplete);
            userID = LMX_Server.AuthenticateUser(hLMX, "administrator", "");
            hItem = LMX_Server.AddItem(hLMX, "MyUDO.MyUDA");
            LMX_Server.Advise(hLMX, hItem);
            LMX_Server.Write(hLMX, hItem, 22, userID);
            while (blocker == 0)
            {
                if (timeout > 0)
                {
                    Thread.Sleep(1000);
                    timeout--;
                }
                else
                {
                    break;
                }
            }
        }

        private void LMX_OnWriteComplete(int hLMXServerHandle, int phItemHandle, ref ArchestrA.MxAccess.MXSTATUS_PROXY[] ItemStatus)
        {
            blocker = 1;
        }

        public int Blocker { get { return blocker; } }
    }
}