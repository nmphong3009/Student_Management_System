using AutoMapper;
using Constants;
using DAL;
using DAL.UnitOfWork;
using Domain.Student;
using Domain.Student.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Student.Services
{
    public class StudentService : ServiceBase<StudentService>, IStudentService
    {
        public StudentService(
            ILogger<StudentService> logger,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            IAppUnitOfWork unitOfWork,
            IMapper mapper,
            IStudentRepository studentRepository
            )
            : base(logger, httpContextAccessor, configuration, unitOfWork, mapper, studentRepository)
        { }

        public async Task<Result<CreateStudentDto>> CreateStudent(CreateStudentDto student)
        {
            var result = new Result<CreateStudentDto>();
            try
            {
                var item = _mapper.Map<Models.Student>(student);
                _unitOfWork.BeginTransaction();
                _studentRepository.Create(item);
                await _unitOfWork.SaveChangeAsync();
                _unitOfWork.SaveChange();
                _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                result.StatusCode = Constants.Constants.STATUS_CODE_EXCEPTION;
                result.Message = Constants.ErrorCode.Common.Exception;
                result.Exception = $"Message: {ex.Message}, StackTrace={ex.StackTrace}";
                _logger.LogError(ex, "Create new user error");
            }
            return result;
        }
        public async Task<Result<StudentInforDto>> GetStudentInfor(int studentId)
        {
            var result = new Result<StudentInforDto>();
            try
            {
                var student = _studentRepository.Get(studentId);
                if (student == null)
                {
                    result.StatusCode = Constants.Constants.STATUS_CODE_ERROR;
                    result.Message = Constants.ErrorCode.Common.NotFound;
                    return result;
                }
                result.Data = new StudentInforDto
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    Email = student.Email,
                    Phone = student.Phone,
                    Course = student.Course,
                    StudentId = student.StudentId,
                };
            }
            catch (Exception ex)
            {
                result.Message = Constants.ErrorCode.Common.Exception;
                result.StatusCode = Constants.Constants.STATUS_CODE_EXCEPTION;
                result.Exception = $"Message: {ex.Message}, StackTrace={ex.StackTrace}";
                _logger.LogError(ex, "Get student error: ");
            }
            return result;
        }
        public async Task<Result<UpdateStudentDto>> UpdateStudentInfor(UpdateStudentDto editStudent)
        {
            var result = new Result<UpdateStudentDto>();
            try
            {
                var checkStudent = _studentRepository.Get(editStudent.Id);
                if (checkStudent == null)
                {
                    result.StatusCode = Constants.Constants.STATUS_CODE_ERROR;
                    result.Message = Constants.ErrorCode.Common.NotFound;
                    return result;
                }
                var item = _mapper.Map(editStudent, checkStudent);
                _unitOfWork.BeginTransaction();
                _studentRepository.Update(item);
                await _unitOfWork.SaveChangeAsync();
                _unitOfWork.CommitTransaction();
                var updateStudent = _studentRepository.Get(editStudent.Id);

                result.Data = _mapper.Map<UpdateStudentDto>(updateStudent);
                
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                result.StatusCode = Constants.Constants.STATUS_CODE_EXCEPTION;
                result.Message = Constants.ErrorCode.Common.Exception;
                result.Exception = $"Message: {ex.Message}, StackTrace={ex.StackTrace}";
                _logger.LogError(ex, "Update user error: ");
            }
            return result;
        }

        public async Task<Result<List<SubjectResultDto>>> GetSubjectResult(int studentId)
        {
            Result<List<SubjectResultDto>> result = new Result<List<SubjectResultDto>>();
            try
            {
                var studentScore = _studentRepository.GetList(s => s.Id == studentId,"Subject").ToList();
                result.Data = _mapper.Map<List<SubjectResultDto>>(studentScore);
            }
            catch (Exception ex)
            {
                result.Message = Constants.ErrorCode.Common.Exception;
                result.StatusCode = Constants.Constants.STATUS_CODE_EXCEPTION;
                result.Exception = $"Message: {ex.Message}, StackTrace={ex.StackTrace}";
                _logger.LogError(ex, "Get subject result error: ");
            }
            return result;
        }
        public async Task<Result<CreateSubjectResultDto>> CreateSubjectResult(CreateSubjectResultDto subjectResult)
           {
               Result<CreateSubjectResultDto> result = new Result<CreateSubjectResultDto>();
               try
              {
                var student = _studentRepository.Get(subjectResult.StudentId);
                if (student == null)
                {
                    result.StatusCode = Constants.Constants.STATUS_CODE_ERROR;
                    result.Message = Constants.ErrorCode.Common.NotFound;
                    return result;
                }
                var subject = _studentRepository.Get(subjectResult.SubjectId);
                if (subject == null)
                {
                    result.StatusCode = Constants.Constants.STATUS_CODE_ERROR;
                    result.Message = Constants.ErrorCode.Common.NotFound;
                    return result;
                }
                var score = new Score
                {
                    StudentId = subjectResult.StudentId,
                    SubjectId = subjectResult.SubjectId,
                    ScoreTen = subjectResult.ScoreTen
                };
            }
               catch (Exception ex)
              {
                  result.StatusCode = Constants.Constants.STATUS_CODE_EXCEPTION;
                   result.Message = Constants.ErrorCode.Common.Exception;
                   result.Exception = $"Message: {ex.Message}, StackTrace={ex.StackTrace}";
                  _logger.LogError(ex, "Create new subject result error");
              }
               return result;
           }
        public async Task<Result<UpdateSubjectResultDto>> UpdateSubjectResult(UpdateSubjectResultDto editSubjectResult)
        {
            var result = new Result<UpdateSubjectResultDto>();
            try
            {
                var checkStudent = _studentRepository.Get(editSubjectResult.StudentId);
                if (checkStudent == null)
                {
                    result.StatusCode = Constants.Constants.STATUS_CODE_ERROR;
                    result.Message = Constants.ErrorCode.Common.NotFound;
                    return result;
                }
                var subject = _studentRepository.Get(editSubjectResult.SubjectId);
                if (subject == null)
                {
                    result.StatusCode = Constants.Constants.STATUS_CODE_ERROR;
                    result.Message = Constants.ErrorCode.Common.NotFound;
                    return result;
                }
                var item = _mapper.Map(editSubjectResult, checkStudent);
                _unitOfWork.BeginTransaction();
                _studentRepository.Update(item);
                await _unitOfWork.SaveChangeAsync();
                _unitOfWork.CommitTransaction();
                var updateScore = _studentRepository.Get(editSubjectResult.StudentId);

                result.Data = _mapper.Map<UpdateSubjectResultDto>(updateScore);

            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                result.StatusCode = Constants.Constants.STATUS_CODE_EXCEPTION;
                result.Message = Constants.ErrorCode.Common.Exception;
                result.Exception = $"Message: {ex.Message}, StackTrace={ex.StackTrace}";
                _logger.LogError(ex, "Update user error: ");
            }
            return result;
        }
    }
}
