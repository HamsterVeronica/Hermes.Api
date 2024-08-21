using Hermes.Api.Domain.DTO_s.Forms;

namespace Hermes.Api.Domain.Contracts.Service
{
    public interface IFormService
    {
        List<RequestForm> GetForms();
        void SubmitForm(RequestForm form);
        void SubmitForms(List<RequestForm> forms);
    }
}
