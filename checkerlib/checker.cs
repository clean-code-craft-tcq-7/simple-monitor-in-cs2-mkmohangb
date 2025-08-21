namespace checkerlib;
using System;
using System.Diagnostics;

public class Checker
{
    private static void displayVitalsAlert(string message)
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

    public static bool VitalsOk(float temperature, int pulseRate, int spo2)
    {
        if(temperature >102 || temperature < 95)
        {
            displayVitalsAlert("Temperature critical!");
            return false;
        }
        else if (pulseRate < 60 || pulseRate > 100)
        {
            displayVitalsAlert("Pulse Rate is out of range!");
            return false;
        }
        else if (spo2 < 90)
        {
            displayVitalsAlert("Oxygen Saturation is below normal!");
            return false;
        }
        Console.WriteLine("Vitals received within normal range");
        Console.WriteLine("Temperature: {0} Pulse: {1}, SO2: {2}", temperature, pulseRate, spo2);
        return true;
    }
}