﻿using System;
namespace SoS.Models
{
    public interface IBaseEvent : IBaseModel
    {
        string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
