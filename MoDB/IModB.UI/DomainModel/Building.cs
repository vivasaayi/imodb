using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IModB.UI.DomainModel
{
    public class Building
    {
        Dictionary<String, Room> _rooms = new Dictionary<string, Room>();

        public Dictionary<String, Room> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }

        public void Initialize()
        {
            var buildingsDataSet = new DataSet();
            buildingsDataSet.ReadXml("building.xml");

            var rooms = buildingsDataSet.Tables["room"];
            var door = buildingsDataSet.Tables["door"];
            var sensor = buildingsDataSet.Tables["sensor"];

            AddRooms(rooms);
            AddDoors(door);
            AddSensor(sensor);
        }

        private void AddSensor(DataTable sensorsDataTable)
        {
            foreach (DataRow row in sensorsDataTable.Rows)
            {
                var sensor = new Sensor();
                sensor.Id = row["id"].ToString();
                sensor.RoomId = row["roomid"].ToString();
                sensor.Orientation = row["orientation"].ToString();
                sensor.Alignment = row["alignment"].ToString();

                _rooms[sensor.RoomId].AddSensor(sensor);
            }
        }

        private void AddRooms(DataTable roomsDataTable)
        {
            foreach (DataRow row in roomsDataTable.Rows)
            {
                var room = new Room();
                room.Id = row.Field<string>("id");
                room.Top = int.Parse(row.Field<string>("top"));
                room.Left = int.Parse(row.Field<string>("left"));
                room.Width = int.Parse(row.Field<string>("width"));
                room.Height = int.Parse(row.Field<string>("height"));

                _rooms.Add(room.Id, room);
            }
        }

        private void AddDoors(DataTable doorsDataTable)
        {
            foreach (DataRow row in doorsDataTable.Rows)
            {
                var door = new Door();
                door.RoomId = row["roomid"].ToString();
                door.Id = row["id"].ToString();
                door.Orientation = row["orientation"].ToString();
                door.Alignment = row["alignment"].ToString();

                _rooms[door.RoomId].AddDoor(door);
            }
        }
    }
}
