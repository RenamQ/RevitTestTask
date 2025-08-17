using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System.Linq;
using System.Xaml;

namespace TestTask.Commands
{
    public class BuildWalls
    {
        private Room selectedRoom;
        private Document doc;
        public BuildWalls(Room selectedRoom)
        {
            this.selectedRoom = selectedRoom;
            doc = selectedRoom.Document;
        }
        public void Execute()
        {
            SpatialElementBoundaryOptions spatialElementBoundaryOptions = new SpatialElementBoundaryOptions();
            var roomBoundarySegments = selectedRoom.GetBoundarySegments(spatialElementBoundaryOptions);
            var wallType = new FilteredElementCollector(doc)
                .OfClass(typeof(WallType))
                .Cast<WallType>()
                .First();
            var wallThickness = wallType.Width; 
            var wallTypeId = wallType.Id;
            var levelId = selectedRoom.LevelId;
            using (var transaction = new Transaction(doc, "Построить стены"))
            {
                transaction.Start();
                foreach (var boundaryList in roomBoundarySegments)
                {
                    foreach (var segment in boundaryList)
                    {
                        var curve = segment.GetCurve();
                        var offsetCurve = curve.CreateOffset(-wallThickness / 2, XYZ.BasisZ);
                        Wall.Create(doc, curve, wallTypeId, levelId, 10, 0, false, false);
                    }
                }
                transaction.Commit();
            }
        }
    }
}