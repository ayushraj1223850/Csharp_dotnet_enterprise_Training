using System;
using System.Collections.Generic;
using System.Linq;

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType
{
    Stock,
    Bond,
    Option,
    Future
}

public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> _holdings = new();

    public void Buy(T instrument, int quantity)
    {
        if (quantity <= 0) throw new Exception("Quantity must be positive");

        if (_holdings.ContainsKey(instrument))
            _holdings[instrument] += quantity;
        else
            _holdings[instrument] = quantity;
    }

    public decimal Sell(T instrument, int quantity)
    {
        if (!_holdings.ContainsKey(instrument) || _holdings[instrument] < quantity)
            throw new Exception("Not enough quantity to sell");

        _holdings[instrument] -= quantity;

        if (_holdings[instrument] == 0)
            _holdings.Remove(instrument);

        return quantity * instrument.CurrentPrice;
    }

    public decimal CalculateTotalValue()
    {
        return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    public IEnumerable<T> GetInstruments() => _holdings.Keys;
}

public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;

    public string CompanyName { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;

    public DateTime MaturityDate { get; set; }
}

public class TradingStrategy<T> where T : IFinancialInstrument
{
    public void Execute(Portfolio<T> portfolio, IEnumerable<T> marketData,
                        Func<T, bool> buyRule,
                        Func<T, bool> sellRule)
    {
        foreach (var instrument in marketData)
        {
            if (buyRule(instrument))
                portfolio.Buy(instrument, 1);

            if (sellRule(instrument))
                portfolio.Sell(instrument, 1);
        }
    }
}

public class PriceHistory<T> where T : IFinancialInstrument
{
    private Dictionary<T, List<decimal>> _prices = new();

    public void AddPrice(T instrument, decimal price)
    {
        if (!_prices.ContainsKey(instrument))
            _prices[instrument] = new List<decimal>();

        _prices[instrument].Add(price);
    }

    public decimal GetMovingAverage(T instrument)
    {
        return _prices[instrument].Average();
    }
}

class Program
{
    static void Main()
    {
        var apple = new Stock { Symbol = "AAPL", CurrentPrice = 180, CompanyName = "Apple" };
        var tesla = new Stock { Symbol = "TSLA", CurrentPrice = 220, CompanyName = "Tesla" };

        var portfolio = new Portfolio<IFinancialInstrument>();

        portfolio.Buy(apple, 2);
        portfolio.Buy(tesla, 1);

        Console.WriteLine($"Portfolio Value: {portfolio.CalculateTotalValue()}");

        var history = new PriceHistory<IFinancialInstrument>();
        history.AddPrice(apple, 170);
        history.AddPrice(apple, 180);
        history.AddPrice(apple, 190);

        Console.WriteLine($"Apple Avg Price: {history.GetMovingAverage(apple)}");

        var strategy = new TradingStrategy<IFinancialInstrument>();

        strategy.Execute(
            portfolio,
            new List<IFinancialInstrument> { apple, tesla },
            i => i.CurrentPrice < 200,   // buy if cheap
            i => i.CurrentPrice > 210    // sell if high
        );

        Console.WriteLine($"Portfolio Value After Strategy: {portfolio.CalculateTotalValue()}");
    }
}
