using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3;

public enum EvictionPolicy { Unlimited, LRU, LFU, TTL, Custom }

public class CacheEntry<TResult>
{
    public TResult Value { get; init; } = default!;
    public DateTime LastAccessed { get; set; } = DateTime.Now;
    public int AccessCount { get; set; } = 1;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}

public class Memoizer<TInput, TResult> where TInput : notnull
{
    private readonly Func<TInput, TResult> _fn;
    private readonly Dictionary<TInput, CacheEntry<TResult>> _cache = new();
    private readonly int _maxSize;
    private readonly TimeSpan? _expiry;
    private readonly EvictionPolicy _policy;
    private readonly Action<Dictionary<TInput, CacheEntry<TResult>>>? _customEviction;

    public Memoizer(
        Func<TInput, TResult> fn,
        int maxSize = int.MaxValue,
        TimeSpan? expiry = null,
        EvictionPolicy policy = EvictionPolicy.Unlimited,
        Action<Dictionary<TInput, CacheEntry<TResult>>>? customEviction = null)
    {
        _fn = fn;
        _policy = policy;
        _maxSize = maxSize;
        _expiry = expiry;
        _customEviction = customEviction;
    }

    public TResult Execute(TInput input)
    {

        if (_cache.TryGetValue(input, out var entry))
        {
            if (_expiry.HasValue && DateTime.Now - entry.CreatedAt > _expiry.Value)
            {
                _cache.Remove(input);
            }
            else
            {
                entry.LastAccessed = DateTime.Now;
                entry.AccessCount++;
                return entry.Value;
            }
        }

        TResult result = _fn(input);

        if (_cache.Count >= _maxSize && _policy != EvictionPolicy.Unlimited)
        {
            ApplyEviction();
        }

        _cache[input] = new CacheEntry<TResult> { Value = result };
        return result;
    }

    private void ApplyEviction()
    {
        if (_cache.Count == 0) return;
        if (_policy == EvictionPolicy.Custom && _customEviction != null)
        {
            _customEviction(_cache);
            return;
        }

        var query = _cache.AsEnumerable();
        TInput keyToRemove = _policy switch
        {
            EvictionPolicy.LRU => query.OrderBy(x => x.Value.LastAccessed).First().Key,
            EvictionPolicy.LFU => query.OrderBy(x => x.Value.AccessCount).First().Key,
            EvictionPolicy.TTL => query.OrderBy(x => x.Value.CreatedAt).First().Key,
            _ => _cache.Keys.First()
        };

        _cache.Remove(keyToRemove);
    }
}



