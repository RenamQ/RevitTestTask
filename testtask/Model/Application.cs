using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using TestTask.ViewModel;

namespace TestTask.Model
{
    [Transaction(TransactionMode.Manual)]

    class Application : IExternalApplication
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
