using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace Board2
{
    public partial class _Default : Page
    {
        public string User_Id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserRepository userRepo = new UserRepository();
            User_Id = userRepo.GetUserId(txtUserID.Text, txtPassword.Text);

            if (userRepo.IsCorrectUser(txtUserID.Text, txtPassword.Text) == true)
            {
                // [!] 인증 부여
                if (!String.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    // 인증 쿠키값 부여
                    FormsAuthentication.RedirectFromLoginPage(txtUserID.Text, false); //원래 요청된 URL로 돌아감
                else
                {
                    // 인증 쿠키값 부여
                    FormsAuthentication.SetAuthCookie(txtUserID.Text, false);
                    Response.Redirect("~/Welcome.aspx?User_Id=" + User_Id);
                }
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showMsg", "<script>alert('잘못된 사용자입니다.');</script>");
        }
    }
}