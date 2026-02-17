public class CreditRiskProcessor
{
    // VALIDATION METHOD
    public static bool ValidateCustomerDetails(
        int age,
        string employmentType,
        double monthlyIncome,
        double dues,
        int creditScore,
        int defaults)
    {
        if (age < 21 || age > 65)
            throw new InvalidCreditDataException("Invalid age");

        if (employmentType != "Salaried" && employmentType != "Self-Employed")
            throw new InvalidCreditDataException("Invalid employment type");

        if (monthlyIncome < 20000)
            throw new InvalidCreditDataException("Invalid monthly income");

        if (dues < 0)
            throw new InvalidCreditDataException("Invalid credit dues");

        if (creditScore < 300 || creditScore > 900)
            throw new InvalidCreditDataException("Invalid credit score");

        if (defaults < 0)
            throw new InvalidCreditDataException("Invalid default count");

        return true;
    }

    // CREDIT LIMIT CALCULATION
    public static double CalculateCreditLimit(
        double monthlyIncome,
        double dues,
        int creditScore,
        int defaults)
    {
        double debtRatio = dues / (monthlyIncome * 12);

        // HIGH RISK
        if (creditScore < 600 || defaults >= 3 || debtRatio > 0.4)
            return 50000;

        // MEDIUM RISK
        if ((creditScore >= 600 && creditScore <= 749) ||
            (defaults == 1 || defaults == 2))
            return 150000;

        // LOW RISK
        if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            return 300000;

        return 0;
    }
}
