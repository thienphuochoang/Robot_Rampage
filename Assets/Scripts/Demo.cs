using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo
{
    public static void Main()
    {
        // Create a dictionary with string key and int value pairs
        Dictionary<string, int> cityPopulation = new Dictionary<string, int>();
        cityPopulation.Add("Tokyo", 38000000);
        cityPopulation.Add("Dehli", 25700000);
        cityPopulation.Add("Shanghai", 23700000);
        cityPopulation.Add("San Paulo", 21100000);
        cityPopulation.Add("Mexico City", 21000000);
        // Read all the data
        Console.WriteLine("City Population");

        foreach (KeyValuePair<string, int> city in cityPopulation)
        {
            Console.WriteLine("City: " + city.Key + ", Population: " + city.Value);
        }
    }
}
