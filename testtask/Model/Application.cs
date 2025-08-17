using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Reflection;

namespace TestTask.Model
{
    [Transaction(TransactionMode.Manual)]

    public class Application : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            try {
                application.CreateRibbonTab("Тестовое задание");
                PushButtonData pushButtonData = new("appButton", "Кнопка", Assembly.GetExecutingAssembly().Location, nameof(Command));
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Ошибка", ex.Message);
                return Result.Failed;
            }
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
