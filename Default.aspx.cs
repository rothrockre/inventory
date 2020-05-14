using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventory.Database;

namespace Inventory
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddNewUser_Click(object sender, EventArgs e)
        {
            ConnectDatabase conn = new ConnectDatabase();
            conn.AddNewUser(usernametb.Text, passwordtb.Text);
        }
    }
}