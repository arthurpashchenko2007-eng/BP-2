using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3;

public enum EvictionPolicy { Unlimited, LRU, LFU, TTL, Custom }

public class Memoizer<TInput, TResult>
{
    private readonly Func<TInput, TResult> _fn;
    private readonly Dictionary<TInput, CacheEntry> _cache = new();
    private readonly int _maxSize;
    private readonly TimeSpan? _expiry;
    private readonly EvictionPolicy _policy;
    private readonly Action<Dictionary<TInput, CacheEntry>> _customEviction;
}
public class CacheEntry
{
    public TResult Value { get; }
    public DateTime LastAccessed { get; set; }
    public int AccessCount { get; set; }
    public DateTime CreatedAt { get; set; }

    public Memoize (
        Func<TInput, TResult> fn,
        int maxSize = int.MaxValue,
        TimeSpan? expiry = null,
        EvictionPolicy policy = EvictionPolicy.Unlimited,
        Action<Dictionary<TInput, CacheEntry>> customEviction = null)
    {
    
    _fn = fn;
    _policy = policy;
    _maxSize = maxSize;
    _expiry = expiry;
    _customEviction = customEviction;
    }
    public TResult Execute(TInput input)
    {
        
    }
}
