using AbstractDependencies.Models;

namespace Repository.Model;

public partial class LinkStorageBaseModel : BaseModel, IBusinessModel
{
    public string LinkValue { get; set; } = null!;
    public string LinkKey { get; set; } = null!;
}
