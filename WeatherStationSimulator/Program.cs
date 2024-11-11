namespace WeatherStationSimulator;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Enter the number of days to simulate: ");
        int days = int.Parse(Console.ReadLine());

        int[] temperature = new int[days];
        string[] conditions = { "Sunny", "Rainy", "Cloudy", "Snowy" };
        string[] weatherConditions = new string[days];

        var random = new Random();

        for (int i = 0; i < days; i++)
        {

            temperature[i] = random.Next(-10, 40);
            //weatherConditions[i] = conditions[random.Next(conditions.Length)];
            if (temperature[i] <= -5)
            {
                weatherConditions[i] = "Snowy";
            }
            else if (temperature[i] < 0 && temperature[i] > -5)
            {
                weatherConditions[i] = conditions[random.Next(0, 4)];
            }
            else if (temperature[i] >= 0 && temperature[i] <= 25)
            {
                weatherConditions[i] = conditions[random.Next(0, 3)];
            }
            else
            {
                weatherConditions[i] = "Sunny";
            }
            Console.WriteLine($"{temperature[i]} - {weatherConditions[i]}");

        };

        int maxTemperature = temperature.Max();
        int minTemperature = temperature.Min();

        double averageTemp = CalculateAverage(temperature);

        Console.WriteLine($"Average temperature is: {averageTemp}.");
        Console.WriteLine($"The max temp was: {maxTemperature}.");
        Console.WriteLine($"The min temp was: {minTemperature}.");
        Console.WriteLine($"Most common condition is: {MostCommonCondition(weatherConditions)}.");
    }

    static string MostCommonCondition(string[] conditions) 
    {
        int count = 0;
        string mostCommon = conditions[0];

        for (int i = 0; i < conditions.Length; i++) 
        {
            int tempCount = 0;
            for (int j = 0; j < conditions.Length; j++) 
            {
                if (conditions[j] == conditions[i]) 
                {
                    tempCount++;
                }
            }

            if (tempCount > count)
            {
                count = tempCount;
                mostCommon = conditions[i];
            }   
        }

        return mostCommon;
    }

    static double CalculateAverage(int[] temperature) 
    {
        
        double sum = 0;

        foreach (int i in temperature) 
        {
            sum += i;
        }

        double average =  sum / temperature.Length;

        return average;

    }

    //static int MinTemperature(int[] temperature) 
    //{
    //    int min = temperature[0];
    //    foreach (int temp in temperature) 
    //    {
    //        if (temp < min) 
    //        {
    //            min = temp;
    //        }
    //    }

    //    return min;

    //}

}

