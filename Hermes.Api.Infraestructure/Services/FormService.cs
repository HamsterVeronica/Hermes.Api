using Hermes.Api.Domain.Contracts.Repositories;
using Hermes.Api.Domain.Contracts.Service;
using Hermes.Api.Domain.DTO_s.Forms;

namespace Hermes.Api.Infraestructure.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public List<RequestForm> GetForms()
        {
            return _formRepository.LoadForms();
        }

        public void SubmitForm(RequestForm form)
        {
            _formRepository.AddForm(form);
        }

        public void SubmitForms(List<RequestForm> forms)
        {
            foreach (var form in forms)
            {
                _formRepository.AddForm(form);
            }
        }
    }
}
