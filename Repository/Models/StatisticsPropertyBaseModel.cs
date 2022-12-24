using AbstractDependencies.Models;

namespace Repository.Model;

public partial class StatisticsPropertyBaseModel : BaseModel, IBusinessModel
{
    public string Name { get; set; } = null!;
}
