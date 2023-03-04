using System;

namespace ProjectTracking.Core.Interfaces;

public interface IIdentifiable
{
    public Guid Id { get; }
}