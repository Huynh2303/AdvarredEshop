using System.Text.Json;
namespace abvancedEshop.Infrastructure
{
    public static class SessionExtensions
    {
           public static void Setjson (this ISession session , string key , object value)
        {
            session.SetString(key, JsonSerializer.Serialize (value));
        }
        public static T? GetJson<T> ( this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return session== null 
                ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
