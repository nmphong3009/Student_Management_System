using DAL;
using Domain.Student.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student.Services
{
    public interface  IStudentService : IServiceBase
    {
        Task<Result<CreateStudentDto>> CreateStudent(CreateStudentDto student);
        // Tạo thông tin sinh viên mới
        Task<Result<StudentInforDto>> GetStudentInfor(int studentId);
        // Xem thông tin sinh viên theo Id
        Task<Result<UpdateStudentDto>> UpdateStudentInfor(UpdateStudentDto editStudent);
        // Cập nhật thông tin sinh viên 
        Task<Result<List<SubjectResultDto>>> GetSubjectResult(int studentId);
        // Xem điểm số sinh viên 
        Task<Result<CreateSubjectResultDto>> CreateSubjectResult(CreateSubjectResultDto subjectResult);
        // Tạo điểm môn học mới
        Task<Result<UpdateSubjectResultDto>> UpdateSubjectResult(UpdateSubjectResultDto editSubjectResult);
        // Sửa điểm môn học
    }
}
