using System.Runtime.Serialization;

namespace Core.Entities.Order_Entities
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        pending,
        [EnumMember(Value = "Payment Succeeded")]
        paymentSucceeded,
        [EnumMember(Value = "Payment Failed")]
        paymentFailed
    }
}