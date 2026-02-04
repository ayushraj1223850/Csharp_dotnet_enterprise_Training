using System;

namespace FactoryRobotHazardAnalyzer
{
    /// <summary>
    /// Custom exception class used to handle robot safety violations.
    /// The exception itself is responsible for displaying the message.
    /// </summary>
    public class RobotSafetyException : Exception
    {
        // Constructor that passes the error message to the base Exception class
        public RobotSafetyException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// This class contains business logic to calculate robot hazard risk.
    /// </summary>
    public class RobotHazardAuditor
    {
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            // Validate arm precision range
            if (armPrecision < 0.0 || armPrecision > 1.0)
            {
                throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
            }

            // Validate worker density range
            if (workerDensity < 1 || workerDensity > 20)
            {
                throw new RobotSafetyException("Error: Worker density must be 1-20");
            }

            // Determine machine risk factor
            double machineRiskFactor;

            if (machineryState == "Worn")
            {
                machineRiskFactor = 1.3;
            }
            else if (machineryState == "Faulty")
            {
                machineRiskFactor = 2.0;
            }
            else if (machineryState == "Critical")
            {
                machineRiskFactor = 3.0;
            }
            else
            {
                // Invalid machinery state
                throw new RobotSafetyException("Error: Unsupported machinery state");
            }

            // Hazard Risk Calculation Formula
            double hazardRisk =
                ((1.0 - armPrecision) * 15.0) +
                (workerDensity * machineRiskFactor);

            return hazardRisk;
        }
    }

    /// <summary>
    /// Entry point of the application.
    /// Handles user input, method invocation, and exception handling.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Create object of business logic class
            RobotHazardAuditor auditor = new RobotHazardAuditor();

            try
            {
                // Read Arm Precision
                Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
                double armPrecision = Convert.ToDouble(Console.ReadLine());

                // Read Worker Density
                Console.WriteLine("Enter Worker Density (1 - 20):");
                int workerDensity = Convert.ToInt32(Console.ReadLine());

                // Read Machinery State
                Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
                string machineryState = Console.ReadLine()!;

                // Call business logic method
                double riskScore = auditor.CalculateHazardRisk(
                    armPrecision,
                    workerDensity,
                    machineryState
                );

                // Display result
                Console.WriteLine($"Robot Hazard Risk Score: {riskScore}");
            }
            catch (RobotSafetyException ex)
            {
                // Display custom exception message
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // Handles unexpected runtime errors (defensive programming)
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }
    }
}
