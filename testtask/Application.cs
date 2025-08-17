using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Reflection;

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
            PushButton pushButton = ribbonPanel.AddItem(pushButtonData) as PushButton;
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
