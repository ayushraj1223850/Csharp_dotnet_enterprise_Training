using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentResilience
{
    internal static class Program
    {
        // Entry point of application
        private static async Task Main()
        {
            // Dependency creation (DI-ready design)
            IPaymentGateway gateway = new SimulatedPaymentGateway();
            ICircuitBreaker circuitBreaker = new CircuitBreaker();

            PaymentProcessor processor = new PaymentProcessor(gateway, circuitBreaker);

            using CancellationTokenSource tokenSource = new CancellationTokenSource();

            // Simulate multiple payment attempts
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    PaymentResult result = await processor.ProcessAsync(
                        new PaymentRequest { Amount = 1000 },
                        tokenSource.Token);

                    Console.WriteLine($"{result.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }

    // ===================== CONFIGURATION CONSTANTS =====================

    // Centralized constants avoid magic numbers (SonarQube best practice)
    internal static class ResilienceSettings
    {
        public const int MaxRetries = 3;
        public const int FailureThreshold = 5;
        public const int CircuitOpenSeconds = 30;
        public const int RetryDelayMilliseconds = 500;
    }

    // ===================== DATA MODELS =====================

    // Represents payment request payload
    internal sealed class PaymentRequest
    {
        public decimal Amount { get; init; }
    }

    // Represents result returned by gateway
    internal sealed class PaymentResult
    {
        public bool Success { get; init; }
        public string Message { get; init; }
    }

    // ===================== ABSTRACTIONS =====================

    // Abstraction for any payment provider
    internal interface IPaymentGateway
    {
        Task<PaymentResult> ProcessAsync(
            PaymentRequest request,
            CancellationToken cancellationToken);
    }

    // Abstraction for circuit breaker logic
    internal interface ICircuitBreaker
    {
        bool IsOpen();
        void RecordFailure();
        void RecordSuccess();
    }

    // ===================== PAYMENT GATEWAY =====================

    // Simulates unreliable external service (timeouts, network failures)
    internal sealed class SimulatedPaymentGateway : IPaymentGateway
    {
        private readonly Random _random = new Random();

        public async Task<PaymentResult> ProcessAsync(
            PaymentRequest request,
            CancellationToken cancellationToken)
        {
            // Simulated network delay
            await Task.Delay(300, cancellationToken);

            // 60% chance of failure
            if (_random.NextDouble() < 0.6)
            {
                throw new TimeoutException("Payment provider timeout");
            }

            // Successful response
            return new PaymentResult
            {
                Success = true,
                Message = "Payment completed successfully"
            };
        }
    }

    // ===================== CIRCUIT BREAKER =====================

    // Protects system from cascading failures
    internal sealed class CircuitBreaker : ICircuitBreaker
    {
        private int _failureCount;
        private DateTime _lastFailureUtc;
        private bool _isOpen;

        // Checks whether circuit is currently blocking requests
        public bool IsOpen()
        {
            if (!_isOpen)
            {
                return false;
            }

            // Auto-reset after cooldown period
            if (DateTime.UtcNow - _lastFailureUtc >
                TimeSpan.FromSeconds(ResilienceSettings.CircuitOpenSeconds))
            {
                Reset();
            }

            return _isOpen;
        }

        // Records failed attempts
        public void RecordFailure()
        {
            _failureCount++;
            _lastFailureUtc = DateTime.UtcNow;

            // Open circuit when threshold reached
            if (_failureCount >= ResilienceSettings.FailureThreshold)
            {
                _isOpen = true;
            }
        }

        // Resets breaker after successful call
        public void RecordSuccess()
        {
            Reset();
        }

        private void Reset()
        {
            _failureCount = 0;
            _isOpen = false;
        }
    }

    // ===================== PAYMENT PROCESSOR =====================

    // Orchestrates retries + breaker logic
    internal sealed class PaymentProcessor
    {
        private readonly IPaymentGateway _gateway;
        private readonly ICircuitBreaker _circuitBreaker;

        public PaymentProcessor(
            IPaymentGateway gateway,
            ICircuitBreaker circuitBreaker)
        {
            _gateway = gateway;
            _circuitBreaker = circuitBreaker;
        }

        // Main resilient payment flow
        public async Task<PaymentResult> ProcessAsync(
            PaymentRequest request,
            CancellationToken cancellationToken)
        {
            // Fail fast if system unhealthy
            if (_circuitBreaker.IsOpen())
            {
                throw new CircuitOpenException();
            }

            // Retry logic for transient failures
            for (int attempt = 1; attempt <= ResilienceSettings.MaxRetries; attempt++)
            {
                try
                {
                    PaymentResult result = await _gateway.ProcessAsync(
                        request,
                        cancellationToken);

                    // Reset breaker after success
                    _circuitBreaker.RecordSuccess();
                    return result;
                }
                catch (TimeoutException)
                {
                    // Register failure
                    _circuitBreaker.RecordFailure();

                    // Stop retrying if limit reached
                    if (attempt == ResilienceSettings.MaxRetries)
                    {
                        throw;
                    }

                    // Backoff before retry
                    await Task.Delay(
                        ResilienceSettings.RetryDelayMilliseconds,
                        cancellationToken);
                }
            }

            // Should never reach here (defensive programming)
            throw new RetryLimitExceededException();
        }
    }

    // ===================== CUSTOM EXCEPTIONS =====================

    // Thrown when breaker blocks requests
    internal sealed class CircuitOpenException : Exception
    {
        public CircuitOpenException()
            : base("Circuit breaker is open. Please retry later.") { }
    }

    // Thrown when all retries fail
    internal sealed class RetryLimitExceededException : Exception
    {
        public RetryLimitExceededException()
            : base("Maximum retry attempts exceeded.") { }
    }
}
