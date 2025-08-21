namespace checkerlib;
using System;
using System.Diagnostics;

public interface ICheckerDisplay
{
    void DisplayVitalsAlert(string message);
}

public class ConsoleCheckerDisplay : ICheckerDisplay
{
    public void DisplayVitalsAlert(string message)
    {
        Console.WriteLine(message);
        for (int i = 0; i < 6; i++)
        {
            Console.Write("\r* ");
            System.Threading.Thread.Sleep(1000);
            Console.Write("\r *");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
public class Checker
{
    private static ICheckerDisplay _display = new ConsoleCheckerDisplay();

    public Checker(ICheckerDisplay display)
    {
        _display = display;
    }

    private static bool isVitalInRange(float max, float min, float value)
    {
        return value >= min && value <= max;
    }

    private static bool alertWhenNotInRange(float max, float min, float value, string message)
    {
        if (!isVitalInRange(max, min, value))
        {
            _display.DisplayVitalsAlert(message);
            return false;
        }
        return true;
    }

    private static bool isTemperatureOk(float temperature)
    {
        return alertWhenNotInRange(102, 95, temperature, "Temperature critical!");
    }

    private static bool isPulseRateOk(int pulseRate)
    {
        return alertWhenNotInRange(100, 60, pulseRate, "Pulse Rate is out of range!");
    }

    private static bool isSpo2Ok(int spo2)
    {
        return alertWhenNotInRange(100, 90, spo2, "Oxygen Saturation is below normal!");
    }

    public static bool VitalsOk(float temperature, int pulseRate, int spo2)
    {
        if (!isTemperatureOk(temperature) || !isPulseRateOk(pulseRate) || !isSpo2Ok(spo2))
        {
            Console.WriteLine("Vitals are not within normal range");
            return false;
        }
        Console.WriteLine("Vitals received within normal range");
        Console.WriteLine("Temperature: {0} Pulse: {1}, SO2: {2}", temperature, pulseRate, spo2);
        return true;
    }
}