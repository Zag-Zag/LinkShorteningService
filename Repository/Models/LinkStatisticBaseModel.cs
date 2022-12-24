using AbstractDependencies.Models;

namespace Repository.Model;

public class LinkStatisticBaseModel : BaseModel, IBusinessModel
{
    public Guid LinkId { get; set; }
    public Guid PropertyId { get; set; }
    public int Value { get; set; }
    public DateTime Date { get; set; }

}
