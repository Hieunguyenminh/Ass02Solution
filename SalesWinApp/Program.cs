namespace SalesWinApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            frmLogin frmLogin = new frmLogin();
            Application.Run(frmLogin);
            if (frmLogin.UserSuccessfullAuthentication)
            {
                if (frmLogin.isAdmin == true)
                {
                    Application.Run(new frmMain() { isAdmin = true });
                }
                else
                {
                    Application.Run(new frmMain() { isAdmin = false, id=frmLogin.id });
                }
            }
        }
    }
}