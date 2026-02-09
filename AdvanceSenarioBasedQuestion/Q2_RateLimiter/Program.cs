using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RateLimiterSystem
{
    // Sliding window rate limiter
    public class SlidingWindowRateLimiter
    {
        private readonly int _maxRequests;
        private readonly TimeSpan _window;

        // Each client has its own request timestamps
        private readonly ConcurrentDictionary<string, Queue<DateTime>> _clientRequests
            = new ConcurrentDictionary<string, Queue<DateTime>>();

        // Lock per client for better scalability
        private readonly ConcurrentDictionary<string, object> _clientLocks
            = new ConcurrentDictionary<string, object>();

        public SlidingWindowRateLimiter(int maxRequests, TimeSpan window)
        {
            _maxRequests = maxRequests;
            _window = window;
        }

        public bool AllowRequest(string clientId, DateTime now)
        {
            var requestQueue = _clientRequests.GetOrAdd(clientId, _ => new Queue<DateTime>());
            var clientLock = _clientLocks.GetOrAdd(clientId, _ => new object());

            lock (clientLock)
            {
                // Remove expired timestamps outside sliding window
                while (requestQueue.Count > 0 &&
                       now - requestQueue.Peek() > _window)
                {
                    requestQueue.Dequeue();
                }

                if (requestQueue.Count >= _maxRequests)
                {
                    Console.WriteLine($"{clientId} blocked");
                    return false;
                }

                // Allow request and record timestamp
                requestQueue.Enqueue(now);
                Console.WriteLine($"{clientId} allowed ({requestQueue.Count})");
                return true;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var limiter = new SlidingWindowRateLimiter(
                maxRequests: 5,
                window: TimeSpan.FromSeconds(10));

            string client = "ClientA";

            // Simulate 7 fast API calls
            for (int i = 1; i <= 7; i++)
            {
                limiter.AllowRequest(client, DateTime.UtcNow);
            }

            Console.WriteLine("\nWaiting 11 seconds...\n");
            System.Threading.Thread.Sleep(11000);

            // Window slides → requests allowed again
            limiter.AllowRequest(client, DateTime.UtcNow);
        }
    }
}
