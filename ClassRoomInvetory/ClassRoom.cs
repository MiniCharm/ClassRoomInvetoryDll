using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomInvetory
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Chairs { get; set; }

        public int Tables {  get; set; }

        public int Board { get; set; }
        public int SmartBoard { get; set; }

        public ClassRoom()
        {
            
        }
        public ClassRoom(int id, string name, int chairs, int tables, int board, int smartBoard)
        {
            Id = id;
            if(name == null)
            {
                throw new ArgumentException("The classRoom needs a name");
            }
            if (name.Length<3||name.Length>20)
            {
                throw new ArgumentException("The name must be between 3 and 20 charecters");
            }
            Name = name;
            if(chairs < 1||tables<5)
            {
                throw new ArgumentException("A classroom must have chairs and tables");
            }
            Chairs = chairs;
            Tables = tables;
            Board = board;
            SmartBoard = smartBoard;
        }


    }
}
