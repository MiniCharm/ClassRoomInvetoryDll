using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomInvetory
{
    public class ClassRoominvetoryReposetory
    {
        private List<ClassRoom> _classRooms = new List<ClassRoom> { new (1, "Malaga", 25, 9, 1, 1), new (2, "Valencia", 25, 9, 1, 1) };
  
        private int _nextid;

        public int Count { get { return _classRooms.Count(); } }
        public List<ClassRoom> GetAll()
        {
            return _classRooms;
        }

        public List<ClassRoom> Get()
        {
            return _classRooms;
        }

        public ClassRoom AddClassRoom(ClassRoom classRoom) 
        {
            classRoom.Id = _nextid++;
            _classRooms.Add(classRoom);
            return classRoom;
        }

        public ClassRoom? GetClassRoomByID(int id) 
        {
            return _classRooms.Find(cr => cr.Id == id);
        }

        public ClassRoom Delte(int id) 
        {
            ClassRoom? cr = GetClassRoomByID(id);
            if (cr != null) 
            {
                _classRooms.Remove(cr);
            }
            return cr;
        }

        public ClassRoom UpdateClassRoom(int id,ClassRoom classRoomNewData) 
        {
            ClassRoom? foundCr = GetClassRoomByID(id);
            if (foundCr != null) 
            {
                foundCr.Name = classRoomNewData.Name;
                foundCr.Tables = classRoomNewData.Tables;
                foundCr.Chairs = classRoomNewData.Chairs;
                foundCr.Board = classRoomNewData.Board;
                foundCr.SmartBoard = classRoomNewData.SmartBoard;
            }
            return classRoomNewData;
        }
    }
}
