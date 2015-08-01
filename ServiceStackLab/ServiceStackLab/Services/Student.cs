using ServiceStack;
using ServiceStack.FluentValidation;
using ServiceStackLab.DTO;
using ServiceStackLab.Redis;
using ServiceStackLab.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStackLab.Infrastructure;
using ServiceStackLab.Infrastructure.Logger;

namespace ServiceStackLab.Services
{
    public class Student : UepBaseServices
    {
    
        public GetStudentValidator GetStudentValidator { get; set; }

        public Student()
        {
        }
        public GetStudentDTO Get(GetStudentRequest request)
        {
            var response = new GetStudentDTO();

            try
            {
                /* validator */
                GetStudentValidator.ValidateAndThrow(request, ApplyTo.Get);

                /* construct Redis Key*/
                var RedisKeyStudent = string.Format("ssl:student:id:{0}",request.Id);

                /* fetch cachedContent from Redis */
                var cachedContent = RedisClientManager.Get<GetStudentDTO>(RedisKeyStudent);
                if (cachedContent != null) return cachedContent;

                /* Incoke StudentManager */
                var student = new StudentItem() { Id = "123", Name = "Azhar", Email = "iazhar73@gmail.com" };
                response.Student = student;

                /* write content in Redis */
                RedisClientManager.SetAsync(response, RedisKeyStudent, new TimeSpan(0, 10, 0));

            }
            catch (Exception ex)
            {
                LoggerHelper.Error("GetStudent", ex, request);
            }

            return response;
        }
    }



    [Route("/student", Verbs = "GET" , Summary ="Get student by Id")]
    [Route("/student/{Id}", Verbs = "GET", Summary = "Get student by Id")]
    public class GetStudentRequest : IReturn<GetStudentDTO>
    {
        public string Id { get; set; }
    }
}