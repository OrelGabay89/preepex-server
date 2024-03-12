using AutoMapper;
using Swiftrade.Core.Domain.ValueObjects;

namespace Swiftrade.Core.Application.Mappings.Resolvers
{
    public class StringToPhoneNumberConverter : ITypeConverter<string, PhoneNumber>
    {
        public PhoneNumber Convert(string source, PhoneNumber destination, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source)) return null;

            return new PhoneNumber(source);
        }
    }

    public class PhoneNumberToStringConverter : ITypeConverter<PhoneNumber, string>
    {
        public string Convert(PhoneNumber sourceMember, string destination, ResolutionContext context)
        {
            return sourceMember?.Value;
        }
    }
}
