using Hermes.Api.Domain.DTO_s.Forms;

namespace Hermes.Api.Domain.Contracts.Repositories
{
    public interface IFormRepository
    {
        List<RequestForm> LoadForms();
        void SaveForms(List<RequestForm> forms);
        void AddForm(RequestForm form);
    }
}
