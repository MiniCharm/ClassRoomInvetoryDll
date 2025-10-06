using ClassRoomInvetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClassRoomInventory
{
    [TestClass]
    public sealed class TestClassRoomInventory
    {
        [TestMethod]
        public void GetAll()
        {
            //Arrange
            ClassRoominvetoryReposetory CR = new ClassRoominvetoryReposetory();
            List<ClassRoom> Rooms = CR.GetAll();

            //Assert
            Assert.IsNotNull(Rooms);
        }

        [TestMethod]
        public void GetOrderByName() 
        {
            //Arrange
            ClassRoominvetoryReposetory CR = new ClassRoominvetoryReposetory();
            List<ClassRoom> rooms = CR.GetAll();

            //Act
            List<ClassRoom> orderdList = CR.Get(null, null, null, null, "name");

            //Assert
            Assert.AreNotEqual(rooms, orderdList);
        }

        [TestMethod]
        public void ClassRoomAdd()
        {
            //Arrange
            ClassRoominvetoryReposetory CR= new ClassRoominvetoryReposetory();
            List<ClassRoom> Rooms = CR.GetAll();

            //Act
            int countBefoor = Rooms.Count();
            CR.AddClassRoom( new ClassRoom(5, "Malaga", 25, 9, 1, 1));
            int countAfter = Rooms.Count();
            //Assert
            Assert.AreEqual(countBefoor+1, countAfter);
        }

        [TestMethod]
        public void GetClassRoomById()
        {
            //Arrange
            ClassRoominvetoryReposetory CR = new ClassRoominvetoryReposetory();
            List<ClassRoom> Rooms = CR.GetAll();

            //Act
            ClassRoom? cr = CR.GetClassRoomByID(1);

            //Assert
            Assert.IsNotNull(cr);
        }

        [TestMethod]
        public void DeleteClassRoom()
        {
            //Arrange
            ClassRoominvetoryReposetory CR = new ClassRoominvetoryReposetory();
            List<ClassRoom> Rooms = CR.GetAll();

            //Act
            int countBefore = Rooms.Count();
            ClassRoom? cr = CR.Delte(1);
            int countAfter = Rooms.Count();

            //Assert
            Assert.AreEqual(countBefore-1,countAfter);
        }

        [TestMethod]
        public void UpdateRoom() 
        {
            //Arrange
            ClassRoominvetoryReposetory CR = new ClassRoominvetoryReposetory();
            List<ClassRoom> Rooms = CR.GetAll();
            ClassRoom newRoomData = new ClassRoom(2, "Berlin", 20, 8, 1, 1);

            //Act
            ClassRoom? oldroom = CR.GetClassRoomByID(2);
            CR.UpdateClassRoom(2,newRoomData);
            ClassRoom? updatedRoom = CR.GetClassRoomByID(2);

            //Assert
            Assert.AreEqual(newRoomData,updatedRoom);
        }
    }
}
