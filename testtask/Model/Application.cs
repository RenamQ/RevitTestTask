using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace TestTask.Model
{
    [Transaction(TransactionMode.Manual)]

    public class Application : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            try {
                application.CreateRibbonTab("Тестовое задание");
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
