using Funq;
using ServiceStack;
using ServiceStack.Validation;
using ServiceStackLab.Redis;
using ServiceStackLab.Services;
using ServiceStackLab.Validator;
using System.Configuration;

namespace ServiceStackLab
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("ServiceStackLab", typeof(Student).Assembly)
        {
            /* some comment*/
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            /* Add validation feature  */
            Plugins.Add(new ValidationFeature());

            /* validators registration */
            RegisterValidators(container);

            /* Register RedisClientManager */
            container.Register<IRedisClientManager>(new RedisClientManager(ConfigurationManager.AppSettings["Redis"], 
                int.Parse(ConfigurationManager.AppSettings["Database"])));
        }
        
        /// <summary>
        /// Register validators instance in container  
        /// </summary>
        /// <param name="container"></param>
        public void RegisterValidators ( Container container)
        {
            container.RegisterAutoWired<GetStudentValidator>();
        }


    }
}   