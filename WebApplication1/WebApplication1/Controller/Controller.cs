using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities.DTO;
using WebApplication1.Service;

namespace WebApplication1.Controller;

[ApiController]
[Route("/api/animal")]
public class Controller : ControllerBase
{
    private IService _service;
    public Controller(IService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddRecipe(RequestDTO request)
    {
        await _service.AddRecipe(request);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> PatientData(int idPatient)
    {
        return Ok(await _service.PatientData(idPatient));
    }
}