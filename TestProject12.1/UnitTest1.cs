using library;
using labar12._1;
namespace TestProject12._1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddsItemToBeginning()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item = new zAircraft();
            item.RandomInit();

            // Act
            list.AddToBegin(item);

            // Assert
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item, list.beg.Data);
            Assert.AreEqual(item, list.end.Data);
        }

        [TestMethod]
        public void AddsItemToBegin()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item = new zAircraft();
            item.RandomInit();

            // Act
            list.AddToBegin(item);

            // Assert
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item, list.beg.Data);
            Assert.AreEqual(item, list.end.Data);
        }

        [TestMethod]
        public void AddsItemToBegin2()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit();
            list.AddToEnd(item1);

            var item2 = new zAircraft();
            item2.RandomInit();

            // Act
            list.AddToBegin(item2);

            // Assert
            Assert.AreEqual(2, list.count);
            Assert.AreEqual(item2, list.beg.Data);
            Assert.AreEqual(item1, list.end.Data);
        }

        [TestMethod]
        public void AddsItemToEnd()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item = new zAircraft();

            // Act
            list.AddToEnd(item);

            // Assert
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item, list.beg.Data);
            Assert.AreEqual(item, list.end.Data);
        }

        [TestMethod]
        public void RemoveItemSingle()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item = new zAircraft();
            item.RandomInit();
            list.AddToBegin(item);

            // Act
            var result = list.RemoveItem(item);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, list.count);
            Assert.IsNull(list.beg);
            Assert.IsNull(list.end);
        }

        [TestMethod]
        public void RemoveItemFirst()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit();
            var item2 = new zAircraft();
            item2.RandomInit();
            list.AddToEnd(item1);
            list.AddToEnd(item2);

            // Act
            var result = list.RemoveItem(item1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item2, list.beg.Data);
            Assert.AreEqual(item2, list.end.Data);
            Assert.IsNull(list.beg.Prev);
        }

        [TestMethod]
        public void RemoveItemLast()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit();
            var item2 = new zAircraft();
            item2.RandomInit();
            list.AddToEnd(item1);
            list.AddToEnd(item2);

            // Act
            var result = list.RemoveItem(item2);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item1, list.beg.Data);
            Assert.AreEqual(item1, list.end.Data);
            Assert.IsNull(list.end.Next);
        }

        [TestMethod]
        public void RemoveItemMiddle()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit();
            var item2 = new zAircraft();
            item2.RandomInit();
            var item3 = new zAircraft();
            item3.RandomInit();
            list.AddToEnd(item1);
            list.AddToEnd(item2);
            list.AddToEnd(item3);

            // Act
            var result = list.RemoveItem(item2);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(2, list.count);
            Assert.AreEqual(item1, list.beg.Data);
            Assert.AreEqual(item3, list.end.Data);
            Assert.AreEqual(item3, list.beg.Next.Data);
            Assert.AreEqual(item1, list.end.Prev.Data);
        }

        [TestMethod]
        public void RemoveItemNotFound()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit();
            var item2 = new zAircraft();
            item2.RandomInit();
            list.AddToEnd(item1);

            // Act
            var result = list.RemoveItem(item2);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item1, list.beg.Data);
            Assert.AreEqual(item1, list.end.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "список пустой")]
        public void RemoveItemThrowsException()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item = new zAircraft();
            item.RandomInit();

            // Act
            list.RemoveItem(item);

            // Assert
        }

        [TestMethod]
        public void AddPointByIndexAtBeginning()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item = new zAircraft();
            item.RandomInit();

            // Act
            list.AddPointByIndex(0, item);

            // Assert
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item, list.beg.Data);
            Assert.AreEqual(item, list.end.Data);
        }

        [TestMethod]
        public void AddPointByIndexAtEnd()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit();
            list.AddToEnd(item1);

            var item2 = new zAircraft();
            item2.RandomInit();

            // Act
            list.AddPointByIndex(1, item2);

            // Assert
            Assert.AreEqual(2, list.count);
            Assert.AreEqual(item1, list.beg.Data);
            Assert.AreEqual(item2, list.end.Data);
        }

        [TestMethod]
        public void AddPointByIndexInMiddle()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit();
            var item2 = new zAircraft();
            item2.RandomInit();
            list.AddToEnd(item1);
            list.AddToEnd(item2);

            var newItem = new zAircraft();
            newItem.RandomInit();

            // Act
            list.AddPointByIndex(1, newItem);

            // Assert
            Assert.AreEqual(3, list.count);
            Assert.AreEqual(item1, list.beg.Data);
            Assert.AreEqual(newItem, list.beg.Next.Data);
            Assert.AreEqual(item2, list.end.Data);
        }

        [TestMethod]
        public void RemoveOddIndexes()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var items = new zAircraft[5];
            for (int i = 0; i < 5; i++)
            {
                items[i] = new zAircraft();
                items[i].RandomInit();
                list.AddToEnd(items[i]);
            }

            // Act
            list.RemoveOddIndexes();

            // Assert
            Assert.AreEqual(3, list.count);
            Assert.AreEqual(items[0], list.beg.Data);
            Assert.AreEqual(items[2], list.beg.Next.Data);
            Assert.AreEqual(items[4], list.end.Data);
        }

        [TestMethod]
        public void RemoveOddIndexesEmptyList()
        {
            // Arrange
            var list = new MyList<zAircraft>();

            // Act
            list.RemoveOddIndexes();

            // Assert
            Assert.AreEqual(0, list.count);
            Assert.IsNull(list.beg);
            Assert.IsNull(list.end);
        }

        [TestMethod]
        public void ConstructorWithSize_CreatesListWithRandomItems()
        {
            // Arrange
            int size = 5;

            // Act
            var list = new MyList<zAircraft>(size);

            // Assert
            Assert.AreEqual(size, list.count);
            Assert.IsNotNull(list.beg);
            Assert.IsNotNull(list.end);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Список пуст")]
        public void ConstructorWithSize_ThrowsExceptionForZeroOrNegativeSize()
        {
            // Arrange
            int size = 0;

            // Act
            var list = new MyList<zAircraft>(size);

            // Assert
        }

        [TestMethod]
        public void ConstructorWithArray_CreatesListFromArray()
        {
            // Arrange
            var items = new zAircraft[]
            {
                new zAircraft(),
                new zAircraft(),
                new zAircraft()
            };

            // Act
            var list = new MyList<zAircraft>(items);

            // Assert
            Assert.AreEqual(items.Length, list.count);
            Assert.AreEqual(items[0], list.beg.Data);
            Assert.AreEqual(items[items.Length - 1], list.end.Data);
        }

        [TestMethod]
        public void ConstructorWithList_CopiesList()
        {
            // Arrange
            var originalList = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit();
            var item2 = new zAircraft();
            item2.RandomInit();
            originalList.AddToEnd(item1);
            originalList.AddToEnd(item2);

            // Act
            var newList = new MyList<zAircraft>(originalList);

            // Assert
            Assert.AreEqual(originalList.count, newList.count);

            var originalCurrent = originalList.beg;
            var newCurrent = newList.beg;

            while (originalCurrent != null && newCurrent != null)
            {
                Assert.AreEqual(originalCurrent.Data, newCurrent.Data);
                originalCurrent = originalCurrent.Next;
                newCurrent = newCurrent.Next;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "пустая коллекция")]
        public void ConstructorWithNullList_ThrowsException()
        {
            // Arrange
            MyList<zAircraft> originalList = null;

            // Act
            var newList = new MyList<zAircraft>(originalList);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "пустая коллекция")]
        public void ConstructorWithEmptyList_ThrowsException()
        {
            // Arrange
            var originalList = new MyList<zAircraft>();

            // Act
            var newList = new MyList<zAircraft>(originalList);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Список пуст")]
        public void ConstructorWithList_ThrowsExceptionForNullList()
        {
            // Arrange
            MyList<zAircraft> originalList = null;

            // Act
            var list = new MyList<zAircraft>(originalList);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Список пуст")]
        public void ConstructorWithList_ThrowsExceptionForEmptyList()
        {
            // Arrange
            var originalList = new MyList<zAircraft>();

            // Act
            var list = new MyList<zAircraft>(originalList);

            // Assert
        }

        [TestMethod]
        public void FindItem_ReturnsPointWithItem()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            var item2 = new zAircraft();
            list.AddToEnd(item1);
            list.AddToEnd(item2);

            // Act
            var result = list.FindItem(item2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(item2, result.Data);
        }
        [TestMethod]
        public void FindItem_ReturnsNullForItemNotInList()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            item1.RandomInit(); 
            list.AddToEnd(item1);

            var item2 = new zAircraft();
            item2.RandomInit(); 

            // Act
            var result = list.FindItem(item2);

            // Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void DeleteList()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var items = new zAircraft[5];
            for (int i = 0; i < 5; i++)
            {
                items[i] = new zAircraft();
                items[i].RandomInit();
                list.AddToEnd(items[i]);
            }

            // Act
            list.DeleteList();

            // Assert
            Assert.AreEqual(0, list.count);
            Assert.IsNull(list.beg);
            Assert.IsNull(list.end);
        }

        [TestMethod]
        public void DeleteListEmptyList()
        {
            // Arrange
            var list = new MyList<zAircraft>();

            // Act
            list.DeleteList();

            // Assert
            Assert.AreEqual(0, list.count);
            Assert.IsNull(list.beg);
            Assert.IsNull(list.end);
        }
        [TestMethod]
        public void Point()
        {
            // Arrange
            var point = new Point<zAircraft>();

            // Act

            // Assert
            Assert.AreEqual(default(zAircraft), point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Prev);
        }
        [TestMethod]
        public void ToString()
        {
            // Arrange
            var data = new zAircraft();
            var point = new Point<zAircraft>(data);

            // Act
            var result = point.ToString();

            // Assert
            Assert.AreEqual(data.ToString(), result);
        }

        [TestMethod]
        public void Clone()
        {
            // Arrange
            var originalData = new zAircraft();
            var originalPoint = new Point<zAircraft>(originalData);

            // Act
            var clonedPoint = originalPoint.Clone();

            // Assert
            Assert.AreEqual(originalData, clonedPoint.Data);
            Assert.AreNotSame(originalPoint, clonedPoint);
        }
    }
}