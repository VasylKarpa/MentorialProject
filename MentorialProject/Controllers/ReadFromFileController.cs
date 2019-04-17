using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorialProject.DAL.Enteties;
using MentorialProject.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorialProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadFromFileController : ControllerBase
    {
    private readonly IReadFromFileService<Sale> _readService;
    public ReadFromFileController(IReadFromFileService<Sale> readService) {
      _readService = readService;
    }

    [HttpGet]
    public void ReadFromFile() {
      _readService.LoadJson();
    }
  }
}