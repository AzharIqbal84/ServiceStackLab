using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStackLab.Redis;
using StackExchange.Redis;

namespace ServiceStackLab.Tests.Test.Redis
{
    [TestClass]
    public class RedisClientTest
    {

        public string RedisConnectionString { get; set; }
        public int DataBaseNumber { get; set; }
        public IDatabase DataBase { get; set; }

        public RedisClientManager RedisManager { get; set; }
        
        [TestInitialize]
        public void TestInit()
        {
            RedisConnectionString = "localhost";
            DataBaseNumber = 1;


            RedisManager = new RedisClientManager();

            RedisManager.GetDatabase(RedisConnectionString, DataBaseNumber);

    
        }
        
        [TestMethod]
        public void WriteInRedis()
        {

            var key = string.Format("Traveller:{0}", "1354");
            var value = "132154";

            DataBase.StringSet(key, value);

            Assert.AreEqual(DataBase.StringGet(key), value);
        }

        [TestMethod]
        public void WriteComplexObjectInRedis()
        {
            Student student = new Student() { Id = 1, Name = "Azhar" };

            RedisManager.Set<Student>(student,string.Format("student:{0}", student.Id));


            Student student1 = new Student() { Id = 2, Name = "Azhar" };
            RedisManager.SetAsync<Student>(student1, string.Format("student:{0}", student1.Id));
        }

        [TestMethod]
        public void TestExist()
        {
            var isExist = RedisManager.Exist("student:3");

            Assert.AreEqual(isExist, true);

        }

        [TestMethod]
        public void GetTest()
        {
            var key = "student:1";
             RedisManager.GetAsync<Student>(key);

        }

        [TestMethod]
        public void GetDataBaseNumberTest()
        {
            var dbNumber = RedisManager.Database;
        }

        [TestMethod]
        public void DeleteKeyTest()
        {
            var Isdeleted = RedisManager.Delete("student:1");
            Assert.AreEqual(Isdeleted, true);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            RedisManager.Close();
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
