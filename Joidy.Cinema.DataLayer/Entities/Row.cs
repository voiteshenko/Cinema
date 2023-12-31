﻿using Cinema.Common.Enums;

namespace Cinema.DataLayer.Entities;

public class Row
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public ChairType ChairType { get; set; }

    public int SeatsCount { get; set; }

    public decimal Price { get; set; }
}