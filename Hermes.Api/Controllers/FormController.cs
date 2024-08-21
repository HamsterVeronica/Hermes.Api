using Hermes.Api.Domain.Contracts.Service;
using Hermes.Api.Domain.DTO_s.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost]
        public IActionResult SubmitForm([FromBody] RequestForm form)
        {
            if (form == null)
            {
                return BadRequest("Form data is null");
            }

            _formService.SubmitForm(form);
            return Ok("Form submitted successfully");
        }

        [HttpPost("batch")]
        public IActionResult SubmitForms([FromBody] List<RequestForm> forms)
        {
            if (forms == null || forms.Count == 0)
            {
                return BadRequest("Form list is empty");
            }

            _formService.SubmitForms(forms);
            return Ok("Forms submitted successfully");
        }

        [HttpGet]
        public IActionResult GetForms()
        {
            var forms = _formService.GetForms();
            return Ok(forms);
        }
    }
}
