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

            // Act
            list.AddToBegin(item);

            // Assert
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item, list.beg.Data);
            Assert.AreEqual(item, list.end.Data);
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
        [ExpectedException(typeof(Exception), "ñïèñîê ïóñò")]
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
        [ExpectedException(typeof(Exception), "ïóñòàÿ êîëëåêöèÿ")]
        public void ConstructorWithArray_ThrowsExceptionForNullArray()
        {
            // Arrange
            zAircraft[] items = null;

            // Act
            var list = new MyList<zAircraft>(items);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ïóñòàÿ êîëëåêöèÿ")]
        public void ConstructorWithArray_ThrowsExceptionForEmptyArray()
        {
            // Arrange
            zAircraft[] items = new zAircraft[0];

            // Act
            var list = new MyList<zAircraft>(items);

            // Assert
        }

        [TestMethod]
        public void ConstructorWithList_CopiesList()
        {
            // Arrange
            var originalList = new MyList<zAircraft>();
            originalList.AddToEnd(new zAircraft());
            originalList.AddToEnd(new zAircraft());

            // Act
            var list = new MyList<zAircraft>(originalList);

            // Assert
            Assert.AreEqual(originalList.count, list.count);
            Assert.AreNotSame(originalList.beg, list.beg);
            Assert.AreNotSame(originalList.end, list.end);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ïóñòàÿ êîëëåêöèÿ")]
        public void ConstructorWithList_ThrowsExceptionForNullList()
        {
            // Arrange
            MyList<zAircraft> originalList = null;

            // Act
            var list = new MyList<zAircraft>(originalList);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ïóñòàÿ êîëëåêöèÿ")]
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
            item1.RandomInit(); // Èíèöèàëèçèðóåì item1 ñëó÷àéíûìè çíà÷åíèÿìè
            list.AddToEnd(item1);

            var item2 = new zAircraft();
            item2.RandomInit(); // Èíèöèàëèçèðóåì item2 ñëó÷àéíûìè çíà÷åíèÿìè, îòëè÷íûìè îò item1

            // Act
            var result = list.FindItem(item2);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void RemoveItem_RemovesItemFromList()
        {
            // Arrange
            var list = new MyList<zAircraft>();
            var item1 = new zAircraft();
            var item2 = new zAircraft();
            list.AddToEnd(item1);
            list.AddToEnd(item2);

            // Act
            var result = list.RemoveItem(item1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, list.count);
            Assert.AreEqual(item2, list.beg.Data);
            Assert.AreEqual(item2, list.end.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "ñïèñîê ïóñòîé")]
        public void RemoveItem_ThrowsExceptionForEmptyList()
        {
            // Arrange
            var list = new MyList<zAircraft>();

            // Act
            var result = list.RemoveItem(new zAircraft());

            // Assert
        }
    }
}