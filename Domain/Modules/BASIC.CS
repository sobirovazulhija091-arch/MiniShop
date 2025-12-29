public class Basic
{
    public int Id{get;set;}
    // utcnow => (for customers from other countrys that have different time or clock)
    public DateTimeOffset CreatedAt{get;set;}=DateTimeOffset.UtcNow;
}