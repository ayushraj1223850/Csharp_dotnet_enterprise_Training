using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerSystem
{
    internal static class Program
    {
        private static async Task Main()
        {
            using var orderQueue = new BlockingCollection<Order>(boundedCapacity: 100);

            int totalProcessed = 0;

            // Start producer
            Task producer = Task.Run(() => ProduceOrders(orderQueue));

            // Start 3 consumer workers
            Task[] consumers =
            {
                Task.Run(() => ConsumeOrders(orderQueue, ref totalProcessed)),
                Task.Run(() => ConsumeOrders(orderQueue, ref totalProcessed)),
                Task.Run(() => ConsumeOrders(orderQueue, ref totalProcessed))
            };

            // Wait for producer to finish
            await producer;

            // Signal no more items will be added
            orderQueue.CompleteAdding();

            // Wait for consumers to finish processing
            await Task.WhenAll(consumers);

            Console.WriteLine($"\nTotal orders processed: {totalProcessed}");
        }

        // ===================== PRODUCER =====================

        private static void ProduceOrders(BlockingCollection<Order> queue)
        {
            for (int i = 1; i <= 20; i++)
            {
                Order order = new Order { OrderId = i };
                queue.Add(order);

                Console.WriteLine($"Produced Order {i}");
                Thread.Sleep(100); // Simulate arrival delay
            }
        }

        // ===================== CONSUMER =====================

        private static void ConsumeOrders(
            BlockingCollection<Order> queue,
            ref int totalProcessed)
        {
            foreach (Order order in queue.GetConsumingEnumerable())
            {
                ProcessOrder(order);

                // Thread-safe increment
                Interlocked.Increment(ref totalProcessed);
            }
        }

        // ===================== BUSINESS LOGIC =====================

        private static void ProcessOrder(Order order)
        {
            Console.WriteLine($"Processing Order {order.OrderId}");
            Thread.Sleep(300); // Simulate work
        }
    }

    // ===================== MODEL =====================

    internal sealed class Order
    {
        public int OrderId { get; init; }
    }
}
