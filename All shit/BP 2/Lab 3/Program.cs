using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3;

class Test
{
    static void Main()
    {
        Func<string, int> getLen = s => {
            Console.WriteLine($" [Compute] '{s}'");
            return s.Length;
        };


        Console.WriteLine("=== LRU TEST ===");
        var lru = new Memoizer<string, int>(getLen, maxSize: 2, policy: EvictionPolicy.LRU);
        lru.Execute("A"); 
        lru.Execute("B");
        lru.Execute("A"); 
        lru.Execute("C"); 
        lru.Execute("B"); 


        Console.WriteLine("\n=== LFU TEST ===");
        var lfu = new Memoizer<string, int>(getLen, maxSize: 2, policy: EvictionPolicy.LFU);
        lfu.Execute("X"); 
        lfu.Execute("X"); 
        lfu.Execute("Y"); 
        lfu.Execute("Z"); 


        Console.WriteLine("\n=== TTL TEST ===");
        var ttl = new Memoizer<string, int>(getLen, expiry: TimeSpan.FromSeconds(2));
        ttl.Execute("time"); 
        Thread.Sleep(2500);
        ttl.Execute("time"); 


        Console.WriteLine("\n=== CUSTOM TEST ===");
        var custom = new Memoizer<string, int>(getLen, maxSize: 1, 
            policy: EvictionPolicy.Custom, 
            customEviction: c => c.Remove(c.Keys.First()));
        custom.Execute("one");
        custom.Execute("two");
        Console.WriteLine("\nTests finished.");
    }
}