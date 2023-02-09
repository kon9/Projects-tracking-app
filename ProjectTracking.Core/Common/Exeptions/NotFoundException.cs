using System;

namespace ProjectTracking.Core.Common.Exeptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key} not found.") { }
    }
}
