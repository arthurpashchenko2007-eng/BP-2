using System;
public class CacheEntry<TValue> 
{
public TValue Value { get; }
public DateTime CreatedAt { get; }
public DateTime LastAccessedAt { get; private set; }
public int AccessCount { get; private set; }
public CacheEntry(TValue value)
{

    Value = value;
    CreatedAt = DateTime.UtcNow;
    LastAccessedAt = DateTime.UtcNow;
    AccessCount = 1;

}
public void UpdateAccess()
{
    LastAccessedAt = DateTime.UtcNow;
    AccessCount++;
}
    } 