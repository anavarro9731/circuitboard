using System;

namespace CircuitBoard
{
    public class ErrorCode : TypedEnumeration<ErrorCode>
    {
        public static ErrorCode Create(Guid code, string messageSafeForInternalAndExternalClients = "An Error Occurred")
        {
            return Create(code.ToString(), messageSafeForInternalAndExternalClients);
        }

        public new static ErrorCode Create(string guid, string messageSafeForInternalAndExternalClients = "An Error Occurred")
        {
            //HACK hide the base method with it's confusing argument names
            return TypedEnumeration<ErrorCode>.Create(Guid.Parse(guid).ToString(),
                messageSafeForInternalAndExternalClients);
        }

        public override string ToString()
        {
            return $"{Key}";
        }
    }
}