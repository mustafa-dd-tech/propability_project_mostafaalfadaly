using System;

class Statistics
{
    public int[] data;
    public int n;

    public Statistics(int[] arr)
    {
        data = arr;
        n = data.Length;
    }

    // sort (bubble sort)
    public void Sort()
    {
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
        }
    }

    public double GetMean()
    {
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += data[i];
        }
        return sum / n;
    }

    public double GetMedian()
    {
        if (n % 2 == 0)
        {
            return (data[n / 2] + data[n / 2 - 1]) / 2.0;
        }
        else
        {
            return data[n / 2];
        }
    }

    public int GetMode()
    {
        int mode = data[0];
        int maxCount = 1;

        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (data[i] == data[j])
                {
                    count++;
                }
            }

            if (count > maxCount)
            {
                maxCount = count;
                mode = data[i];
            }
        }

        return mode;
    }

    public double GetVariance(double mean)
    {
        double variance = 0;

        for (int i = 0; i < n; i++)
        {
            variance += Math.Pow(data[i] - mean, 2);
        }

        return variance / n;
    }

    public double GetStdDev(double variance)
    {
        return Math.Sqrt(variance);
    }

    public int GetRange()
    {
        return data[n - 1] - data[0];
    }

    public double GetQ1()
    {
        return data[n / 4];
    }

    public double GetQ2()
    {
        return GetMedian();
    }

    public double GetQ3()
    {
        return data[(3 * n) / 4];
    }

    public double GetIQR()
    {
        return GetQ3() - GetQ1();
    }

    public double GetP20()
    {
        return data[(int)(0.2 * n)];
    }

    public double GetP50()
    {
        return GetMedian();
    }

    public double GetSumOfDeviations(double mean)
    {
        double sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += (data[i] - mean);
        }

        return sum;
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };

        Statistics s = new Statistics(numbers);

        s.Sort();

        double mean = s.GetMean();
        double median = s.GetMedian();
        int mode = s.GetMode();
        double variance = s.GetVariance(mean);
        double stdDev = s.GetStdDev(variance);

        Console.WriteLine("Mean = " + mean);
        Console.WriteLine("Median = " + median);
        Console.WriteLine("Mode = " + mode);
        Console.WriteLine("Variance = " + variance);
        Console.WriteLine("Standard Deviation = " + stdDev);

        Console.WriteLine("Range = " + s.GetRange());

        Console.WriteLine("P20 = " + s.GetP20());
        Console.WriteLine("P50 = " + s.GetP50());

        Console.WriteLine("Q1 = " + s.GetQ1());
        Console.WriteLine("Q2 = " + s.GetQ2());
        Console.WriteLine("Q3 = " + s.GetQ3());

        Console.WriteLine("IQR = " + s.GetIQR());

        Console.WriteLine("Sum of Deviations = " + s.GetSumOfDeviations(mean));
    }
}
