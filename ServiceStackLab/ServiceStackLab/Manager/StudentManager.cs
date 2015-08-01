using ServiceStackLab.Redis;

namespace ServiceStackLab.Manager
{
    public class StudentManager
    {

        public RedisClientManager RedisManager { get; set; }

        public StudentManager(RedisClientManager redisManager)
        {
            RedisManager = redisManager;
        }


        public void AddStudent(string name, string lastName, string emailAddress)
        {
            return;
        }

    }
}