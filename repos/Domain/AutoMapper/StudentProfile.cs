using AutoMapper;
using Domain.Student.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AutoMapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<CreateStudentDto, Models.Student>();
            CreateMap<Models.Student, CreateStudentDto>();

            CreateMap<Models.Student, StudentInforDto>();

            CreateMap<UpdateStudentDto, Models.Student>();
            CreateMap<Models.Student, UpdateStudentDto>();
            
        }
    }
}
