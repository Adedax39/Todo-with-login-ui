using System.Runtime.Serialization;

namespace Domain.Enums;

public enum TaskActivation
{
    [EnumMember(Value = "Active")] Active = 1,
    [EnumMember(Value = "Cancelled")] Cancelled = 2,
}