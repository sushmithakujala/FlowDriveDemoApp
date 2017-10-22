using Xamarin.UITest;
using Xamarin.UITest.Android;
namespace FlowDrive
{
    public static class FlowDriveApp
    {
        public static AndroidApp app;
        public static void StartApp()
        {
            app = ConfigureApp.Android
                .ApkFile(@"C:\Users\kv\documents\visual studio 2015\Projects\FlowDrive\FlowDrive\FlowDriveApp.apk")
                .StartApp();
        }   
    }
}
