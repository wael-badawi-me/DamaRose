﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Dama.POS.DAL.Models;

public partial class Location
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Ip { get; set; }

    public string Photo { get; set; }

    public string Description { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; }

    public virtual User LastModifiedByNavigation { get; set; }

    public virtual ICollection<LocationLanguage> LocationLanguages { get; set; } = new List<LocationLanguage>();
}