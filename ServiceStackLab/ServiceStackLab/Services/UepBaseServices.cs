using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStackLab.Redis;

namespace ServiceStackLab.Services
{
    public class UepBaseServices : Service
    {

        public IRedisClientManager RedisClientManager { get; set; }

        public UepBaseServices()
        {
            
        }
    }
}