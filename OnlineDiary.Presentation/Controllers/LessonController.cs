using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineDiary.Application.Interfaces;

namespace OnlineDiary.Presentation.Controllers;

[Authorize(Roles = "Director")]
[Route("api/[controller]")]
[ApiController]
public class LessonController : BaseController
{
}
