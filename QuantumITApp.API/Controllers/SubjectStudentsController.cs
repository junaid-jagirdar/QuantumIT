using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantumITApp.Core.Repositories;
using QuantumITApp.Core.Services;

namespace QuantumITApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectStudentsController : ControllerBase
    {
        private readonly IQuantumITAppService _quantumITAppService;

        public SubjectStudentsController(IQuantumITAppService quantumITAppService)
        {
            _quantumITAppService = quantumITAppService;
        }


        
    }
}