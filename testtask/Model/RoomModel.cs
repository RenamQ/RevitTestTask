using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System.Collections.Generic;
using System.Linq;

namespace TestTask.Model
{
    public class RoomModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public Room Room { get; set; }
    }
}
