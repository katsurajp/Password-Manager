using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace PluginServiceApplication {
    class Program {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args) {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url: baseAddress)) {
                HttpClient client = new HttpClient();
                Console.ReadLine();
            }
        }
    }
}
