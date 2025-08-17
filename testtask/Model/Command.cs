using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using TestTask.View;
using TestTask.ViewModel;

namespace TestTask.Model
{
    [Transaction(TransactionMode.Manual)]

    class Command : IExternalCommand
    {
        static AddInId addinid = new AddInId(new Guid("E67C73A9-C790-4EF4-9137-0DC44D0A9F1B"));
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                var viewModel = new MainViewModel();
                var window = new MainWindow
                {
                    DataContext = viewModel
                };

                window.ShowDialog();
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
