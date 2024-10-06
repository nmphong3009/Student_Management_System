using AutoMapper;
using Constants;
using DAL.UnitOfWork;
using Domain.Student;
using Domain.Student.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceBase<TService> : IServiceBase
    {
        public readonly ILogger<TService> _logger;
        public readonly IHttpContextAccessor _contextAccessor;
        public readonly IConfiguration _configuration;
        public readonly IAppUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IStudentRepository _studentRepository;
       

        public ServiceBase(ILogger<TService> logger,
                           IHttpContextAccessor httpContextAccessor,
                           IConfiguration configuration,
                           IAppUnitOfWork unitOfWork,
                           IMapper mapper,
                           IStudentRepository studentRepository
                           )
        {
            _logger = logger;
            _contextAccessor = httpContextAccessor;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
            
        }
    }
}
