using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStackLab.DTO
{
    public class GetStudentDTO
    {
        public GetStudentDTO()
        {
            Student = new StudentItem();
        }
        public StudentItem Student { get; set; }
    }

    public class StudentItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}