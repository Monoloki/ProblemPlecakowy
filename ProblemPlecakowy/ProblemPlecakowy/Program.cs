using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program {
    static Random random = new Random();
    static int backpackCapacity = 2500;
    static int numItems = 100;
    static int minVolume = 10;
    static int maxVolume = 90;
    static int maxGenerations = 1000; // Maksymalna liczba pokoleń
    static int maxFailedMutations = 2000; // Maksymalna liczba nieudanych mutacji
    static TimeSpan maxRunTime = TimeSpan.FromMinutes(5);

    static void Main() {
        List<int> items = Enumerable.Range(0, numItems).Select(_ => random.Next(minVolume, maxVolume + 1)).ToList();
        Console.WriteLine("Wygenerowane przedmioty:");
        Console.WriteLine(string.Join(", ", items));

        Stopwatch stopwatch = Stopwatch.StartNew();

        List<bool> parent = GenerateRandomSolution(items);
        int parentVolume = TotalVolume(parent, items);
        int failedMutations = 0;

        for (int generation = 0; generation < maxGenerations; generation++) {
            if (stopwatch.Elapsed > maxRunTime || failedMutations >= maxFailedMutations)
                break;

            List<bool> offspring = Mutate(parent);
            int offspringVolume = TotalVolume(offspring, items);

            if (offspringVolume > backpackCapacity) break;

            if (offspringVolume > parentVolume || Math.Abs(backpackCapacity - offspringVolume) < Math.Abs(backpackCapacity - parentVolume)) {
                parent = offspring;
                parentVolume = offspringVolume;
                failedMutations = 0;
            }
            else {
                failedMutations++;
            }
        }

        stopwatch.Stop();
        Console.WriteLine("Najlepsze rozwiązanie znalezione:");
        Console.WriteLine("Łączna wartość przedmiotów: " + parentVolume);
        Console.WriteLine("Łączna objętość: " + parentVolume);
        Console.WriteLine("Znalezione rozwiązanie: " + string.Join("", parent.Select(b => b ? "1" : "0")));
        Console.WriteLine("Objętości wybranych przedmiotów: " + string.Join(", ", parent.Select((b, i) => b ? items[i].ToString() : "").Where(s => !string.IsNullOrEmpty(s))));
    }

    static List<bool> GenerateRandomSolution(List<int> items) {
        List<bool> solution;
        do {
            solution = items.Select(_ => random.NextDouble() < 0.5).ToList();
        } while (TotalVolume(solution, items) > backpackCapacity);
        return solution;
    }

    static List<bool> Mutate(List<bool> parent) {
        List<bool> offspring = new List<bool>(parent);
        int index = random.Next(parent.Count);
        offspring[index] = !offspring[index];
        return offspring;
    }

    static int TotalVolume(List<bool> solution, List<int> items) {
        return solution.Select((included, i) => included ? items[i] : 0).Sum();
    }
}

