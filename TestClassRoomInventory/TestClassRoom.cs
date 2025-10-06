using ClassRoomInvetory;
using System;
using System.Xml.Linq;

namespace TestClassRoomInventory
{
    [TestClass]
    public sealed class TestClassRoom
    {
        [DataTestMethod]
        [DataRow(5,"Malaga",25,9,1,1)]
        [DataRow(6,"Mallorca", 45, 21, 3, 1)]
        [DataRow(7,"Valencia", 32, 5, 2, 1)]
        [DataRow(8,"L.A.", 25, 6, 0, 1)]
        [DataRow(6, "kolokjugrtystungtind", 45, 21, 3, 1)]
        [TestMethod]
        public void ClassRoomCreateSucsess(int id,string name,int chair, int table, int board, int smartbord)
        {
            //Act
            ClassRoom cr = new ClassRoom(id,name,chair,table,board,smartbord);

            //Assert
            Assert.AreEqual(cr.Name,name);
        }

        [DataTestMethod]
        [DataRow(5, "M", 25, 4, 1, 1)]
        [DataRow(6, "kolokjugrtystungtind7", 45, 21, 3, 1)]
        [DataRow(7, "By", 32, 5, 2, 1)]
        [DataRow(8, "C", 25, 5, 0, 1)]
        [TestMethod]
        public void ClassRoomCreateFailName(int id, string name, int chair, int table, int board, int smartbord)
        {
            //Act
            Action invalidName = () => new ClassRoom(id, name, chair, table, board, smartbord);

            //Assert
            Assert.ThrowsException<ArgumentException>(invalidName);
        }

        [DataTestMethod]
        [DataRow(5, "M", 25, 0, 1, 1)]
        [DataRow(6, "kolokjugrtystungtind7", 45, 5, 3, 1)]
        [TestMethod]
        public void ClassRoomCreateFailTable(int id, string name, int chair, int table, int board, int smartbord)
        {
            //Act
            Action invalidTableCount = () => new ClassRoom(id, name, chair, table, board, smartbord);

            //Assert
            Assert.ThrowsException<ArgumentException>(invalidTableCount);
        }


        [DataTestMethod]
        [DataRow(5, "M", 0, 4, 1, 1)]
        [DataRow(6, "kolokjugrtystungtind7", 1, 21, 3, 1)]
        [TestMethod]
        public void ClassRoomCreateFailChair(int id, string name, int chair, int table, int board, int smartbord)
        {
            //Act
            Action invalidChairCount = () => new ClassRoom(id, name, chair, table, board, smartbord);

            //Assert
            Assert.ThrowsException<ArgumentException>(invalidChairCount);
        }
    }
}
