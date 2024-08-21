using Hermes.Api.Domain.Contracts.Repositories;
using Hermes.Api.Domain.DTO_s.Forms;
using Newtonsoft.Json;

namespace Hermes.Api.Infraestructure.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly string _filePath = "forms.json";

        public List<RequestForm> LoadForms()
        {
            if (!File.Exists(_filePath))
            {
                return new List<RequestForm>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<RequestForm>>(json) ?? new List<RequestForm>();
        }

        public void SaveForms(List<RequestForm> forms)
        {
            var json = JsonConvert.SerializeObject(forms, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void AddForm(RequestForm form)
        {
            var forms = LoadForms();
            forms.Add(form);
            SaveForms(forms);
        }
    }
}
