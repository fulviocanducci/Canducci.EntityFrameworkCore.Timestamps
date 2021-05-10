using Canducci.EntityFrameworkCore.Timestamps.Test.Models;
using Canducci.EntityFrameworkCore.Timestamps.Test.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canducci.EntityFrameworkCore.Timestamps.Test
{
    [TestClass]
    public class UnitTestDatabaseTimestamps
    {
        public Db Db { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Db = new Db();
        }

        [TestMethod]
        public void TestAddPersonCount()
        {
            Person p1 = new Person()
            {
                Name = "Name 1"
            };
            Person p2 = new Person()
            {
                Name = "Name 2"
            };
            Person p3 = new Person()
            {
                Name = "Name 3"
            };
            Person p4 = new Person()
            {
                Name = "Name 4"
            };            
            Db.Person.AddRange(p1, p2, p3, p4);
            int count = Db.SaveChanges();
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void TestPersonEqualCreatedAtAndUpdateAt()
        {
            Person p1 = Db.Person.Find(1);
            Person p2 = Db.Person.Find(2);
            Person p3 = Db.Person.Find(3);
            Person p4 = Db.Person.Find(4);
            Assert.AreEqual(p1.CreatedAt, p1.UpdatedAt);
            Assert.AreEqual(p2.CreatedAt, p2.UpdatedAt);
            Assert.AreEqual(p3.CreatedAt, p3.UpdatedAt);
            Assert.AreEqual(p4.CreatedAt, p4.UpdatedAt);
        }

        [TestMethod]
        public void TestPersonSameCreatedAtAndUpdateAt()
        {
            Person p1 = Db.Person.Find(1);
            Person p2 = Db.Person.Find(2);
            Person p3 = Db.Person.Find(3);
            Person p4 = Db.Person.Find(4);
            p1.Name += " Update";
            p2.Name += " Update";
            p3.Name += " Update";
            p4.Name += " Update";
            int count = Db.SaveChanges();
            Assert.AreEqual(count, 4);
            Assert.AreNotEqual(p1.CreatedAt, p1.UpdatedAt);
            Assert.AreNotEqual(p2.CreatedAt, p2.UpdatedAt);
            Assert.AreNotEqual(p3.CreatedAt, p3.UpdatedAt);
            Assert.AreNotEqual(p4.CreatedAt, p4.UpdatedAt);
        }
    }
}
