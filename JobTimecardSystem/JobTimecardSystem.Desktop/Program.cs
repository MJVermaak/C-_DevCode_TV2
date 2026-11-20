namespace JobTimecardSystem.Desktop
{
    internal static class Program
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

            // Prevent unhandled UI errors from breaking into Visual Studio
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show(
                    $"Please check your input and try again.\n\nDetails: {args.Exception.Message}",
                    "Input / Application Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            };

            Application.Run(new Form1());

        }

    }
}