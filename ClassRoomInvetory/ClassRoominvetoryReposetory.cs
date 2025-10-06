using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomInvetory
{
    public class ClassRoominvetoryReposetory
    {
        private List<ClassRoom> _classRooms = new List<ClassRoom> ();
  
        private int _nextid;

        public ClassRoominvetoryReposetory()
        {
            _classRooms.Add(new ClassRoom { Id=_nextid++, Name="Malaga", Chairs=25,Tables= 10,Board= 1,SmartBoard= 1 });
            _classRooms.Add(new ClassRoom { Id = _nextid++, Name = "Valencia", Chairs = 29, Tables = 15, Board = 2, SmartBoard = 1 });
            _classRooms.Add(new ClassRoom { Id = _nextid++, Name = "Aalborg", Chairs = 32, Tables = 16, Board = 3, SmartBoard = 1 });

        }
        public int Count { get { return _classRooms.Count(); } }

        public List<ClassRoom> GetAll()
        {
            return _classRooms;
        }

        public List<ClassRoom> Get(
            string? name = null,
            int? minNumberOfBords = null,
            int? minNumberOfsmartbords = null,
            int? minNumberOfChairs = null,
            string? sortBy =null
            )
            {
            List<ClassRoom> _listOfClassRooms = new List<ClassRoom>(_classRooms);
            if( name != null) 
            {
                _listOfClassRooms = _listOfClassRooms.Where(cr => 
                                                            cr.Name !=null && 
                                                            cr.Name.StartsWith(name,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (minNumberOfBords != null) 
            {
                _listOfClassRooms = _listOfClassRooms.Where(cr => cr.Board>=minNumberOfBords).ToList();
            }
            if (minNumberOfsmartbords != null) 
            {
                _listOfClassRooms = _listOfClassRooms.FindAll(cr => cr.SmartBoard>= minNumberOfsmartbords);
            }
            if (minNumberOfChairs != null) 
            {
                _listOfClassRooms = _listOfClassRooms.Where(cr => cr.Chairs >= minNumberOfChairs).ToList();
            }
            if(sortBy != null) 
            {
                if(sortBy.Equals("name",StringComparison.OrdinalIgnoreCase))
                {
                    _listOfClassRooms =_listOfClassRooms.OrderBy(cr => cr.Name).ToList();
                }
                
            }
            
            return _listOfClassRooms;
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
