﻿using AbstractDependencies.Models;

namespace DataBaseEf.Model;

public class LinkStorage : BaseEntityModel
{
    public string LinkValue { get; set; } = null!;
    public string LinkKey { get; set; } = null!;

}
