using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TestTask.Model;

namespace TestTask.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<RoomModel> Rooms { get; set; }

        public MainViewModel(Document doc)
        {
            Rooms = new ObservableCollection<RoomModel>(GetAllRooms(doc).Select(room => new RoomModel {
                Name = room.Name,
                Number = room.Number
            }));
        }

        public List<Room> GetAllRooms(Document doc)
        {
            return new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Rooms)
                .WhereElementIsNotElementType()
                .Cast<Room>()
                .ToList();
        }

    }
}