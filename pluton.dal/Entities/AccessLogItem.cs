using System;

namespace pluton.dal.Entities
{
    public class AccessLogItem : EntityBase<Guid>
    {
        public string Useragent { get; set; }
        public DateTime DateTime { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Username { get; set; }
        public string SessionId { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public string Url { get; set; }
    }
}
