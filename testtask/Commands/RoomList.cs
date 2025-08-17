using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TestTask.Model;

namespace TestTask.Commands
{
    public class RoomList
    {
        public static ObservableCollection<RoomModel> GetRooms(Document doc)
        {
            var rooms = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Rooms)
                .WhereElementIsNotElementType()
                .Cast<Room>()
                .Select(room => new RoomModel { Name = room.Name, Number = room.Number, Room = room });
            return new ObservableCollection<RoomModel>(rooms);
        }
    }
}
