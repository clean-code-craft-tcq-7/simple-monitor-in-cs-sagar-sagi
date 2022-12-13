using System;
using System.Diagnostics;

class Checker
{
    static bool CheckBatteryIsOk(float temperature, float soc, float chargeRate) 
    {
        bool tempOk = CheckTemperature(temperature);
        bool socOk = CheckSoc(soc);
        bool chargeRateOk = CheckChargeRate(chargeRate);
        
        if(tempOk && socOk && chargeRateOk == true)
        {
            return true;
        }
        else return false;
    }
    
    static bool CheckTemperature(float temperature)
    {
        if(temperature < 0 || temperature > 45) return false;
        else return true;
    }
    
    static bool CheckSoc(float soc)
    {
        if(soc < 20 || soc > 80) return false;
        else return true;
    }
    
    static bool CheckChargeRate(float chargeRate)
    {
        if(chargeRate < 0.5 || chargeRate > 0.8) return false;
        else return true;
    }

    static void ExpectBatteryCondition(bool batteryCondition, bool expectedCondition) {
        if(batteryCondition != expectedCondition) {
            Console.WriteLine("Expected {0}, but got {1}", expectedCondition, batteryCondition);
            Environment.Exit(1);
        }
    }
    
    static int Main() 
    {
        ExpectBatteryCondition(CheckBatteryIsOk(25, 70, 0.7f), true);
        ExpectBatteryCondition(CheckBatteryIsOk(50, 85, 0.0f), false);
        Console.WriteLine("All ok");
        return 0;
    }
}
