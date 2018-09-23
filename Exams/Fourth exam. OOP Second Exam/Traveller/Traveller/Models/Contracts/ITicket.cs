﻿namespace Traveller.Models.Contracts
{
    public interface ITicket
    {
        decimal AdministrativeCosts { get; }

        IJourney Journey { get; }

        decimal CalculatePrice();
    }
}