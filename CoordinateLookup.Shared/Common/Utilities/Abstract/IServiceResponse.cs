using CoordinateLookup.Shared.Common.Utilities.ComplexTypes;

namespace CoordinateLookup.Shared.Common.Utilities.Abstract
{
    public interface IServiceResponse
    {
        ResponseCode ResponseCode { get; }
        string Message { get; }
    }
}
