using Core.Base;
using Core.Enum;

namespace Core.Entities
{
    public class Sms : BaseEntity
    {
        public SmsStatus Status { get; set; }
        public SmsResult Result { get; set; }
        public string Exception { get; set; }
        public string Message { get; set; }
        public Guid? LogId { get; set; }
        //        public Log Log { get; set; }
        public int NumberOfTry { get; set; }
        public int MaxNumberOfTry { get; set; }
        public DateTime LastTryTimestamp { get; set; }
        public SMSLogType Type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid? ContractId { get; set; }
        public Agreement Contract { get; set; }
        public string ToNumber { get; set; }
    }
}
