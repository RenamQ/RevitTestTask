using Autodesk.Revit.DB;
using System.Collections.ObjectModel;
using TestTask.Model;
using TestTask.Commands;
using System.Windows.Controls;
using Autodesk.Revit.UI;
using System.Windows.Input;
using System;

namespace TestTask.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<RoomModel> Rooms { get; set; }
        public ICommand BuildWallsCommand { get; }
        public MainViewModel(Document doc)
        {
            Rooms = RoomList.GetRooms(doc);
            BuildWallsCommand = new RelayCommand(BuildWallsExecute, CanBuildWallsExecute);
        }

        private void BuildWallsExecute(object obj)
        {
            var room = SelectedRoom;
            if (room != null)
            {
                var builder = new BuildWalls(room.Room);
                builder.Execute();
            }
        }
        
        private bool CanBuildWallsExecute(object arg)
        {
            return SelectedRoom != null;
        }


        private RoomModel selectedRoom;
        public RoomModel SelectedRoom {
            get => selectedRoom;
            set
            {
                selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

    }
}