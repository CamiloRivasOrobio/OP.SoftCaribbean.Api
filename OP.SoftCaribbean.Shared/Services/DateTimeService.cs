using OP.SoftCaribbean.Application.Interfaces;

namespace OP.SoftCaribbean.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.Now;
    }
}
