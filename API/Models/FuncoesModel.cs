using API.Enums;

namespace API.Models
{
    public class FuncoesModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public StatusFuncoes Status { get; set; }
    }
}
