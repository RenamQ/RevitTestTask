using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace TestTask
{
    [Transaction(TransactionMode.Manual)]

    public class Application : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            var tabName = "Построение стен";
            application.CreateRibbonTab(tabName);
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Со смещением");
            var assemblyPath = typeof(Application).Assembly.Location;
            PushButtonData pushButtonData = new PushButtonData("appButton", "Выбор помещения", assemblyPath, "TestTask.Commands.Command");
            var iconPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "wall32.png");
            BitmapImage iconImage = new BitmapImage(new Uri(iconPath));
            pushButtonData.LargeImage = iconImage;
            PushButton pushButton = ribbonPanel.AddItem(pushButtonData) as PushButton;
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
