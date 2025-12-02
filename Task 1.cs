using System;
using System.Linq;

Random rand = new Random();

int[] arr = Enumerable.Range(0, 20)
                      .Select(_ => rand.Next(10, 101))
                      .ToArray();

Console.WriteLine("Массив: " + string.Join(" ", arr));

int sumEvenIndex = arr.Where((value, index) => index % 2 == 0)
                      .Sum();

long productMultiplesOf5 = arr.Where(x => x % 5 == 0)
                              .DefaultIfEmpty(0)
                              .Aggregate((acc, x) => acc == 0 ? x : acc * x);


Console.WriteLine($"Сумма элементов на чётных позициях {sumEvenIndex}");
Console.WriteLine($"Произведение элементов, кратных 5: {productMultiplesOf5}");