/*

Вариант 8

Команды CLI которые я использовал:
dotnet new console -n "lecture 4" # создает консольное приложение с названием "lecture 4"
code "lecture 4" # откроет проект в VS Code
dotnet build # сборка приложения
dotnet run # запуск приложения

*/

CurrencyConverter converter = new();

converter.StartConversion();


class CurrencyConverter
{
    private const decimal EUR = 0.2902m;
    private const decimal USD = 0.3358m;
    private const decimal RUB = 27.1457m;

    // Доступные валюты
    readonly List<string> currencies = ["BYN", "EUR", "USD", "RUB"];

    public void StartConversion()
    {
        try
        {
            PrintAvailableCurrencies();

            string sourceCurrency = GetValidatedCurrencyInput("Введите исходную валюту: ");
            string targetCurrency = GetValidatedCurrencyInput("Введите целевую валюту: ");
            decimal amount = GetValidatedAmountInput("Введите сумму для конвертации: ");

            decimal result = ConvertCurrency(amount, sourceCurrency, targetCurrency);

            Console.WriteLine($"{amount} {sourceCurrency} => {result:F2} {targetCurrency}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void PrintAvailableCurrencies()
    {
        Console.WriteLine($"Доступные валюты: {string.Join(", ", currencies)}");
    }

    private string GetValidatedCurrencyInput(string prompt)
    {
        Console.Write(prompt);
        string userInput = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(userInput))
        {
            throw new ArgumentException("Ошибка: Ввод не может быть пустым");
        }

        string normalizedInput = userInput.Trim().ToUpper();

        if (!currencies.Contains(normalizedInput))
        {
            throw new ArgumentException("Ошибка: Неизвестная валюта");
        }

        return normalizedInput;
    }

    private decimal GetValidatedAmountInput(string prompt)
    {
        Console.Write(prompt);
        string userInput = Console.ReadLine() ?? string.Empty;

        if (decimal.TryParse(userInput, out decimal amount) && amount >= 0)
        {
            return amount;
        }

        throw new ArgumentException("Ошибка: Введите корректную положительную сумму");
    }

    private static decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
    {
        // Конвертируем через BYN как базовую валюту
        decimal amountInByn = fromCurrency switch
        {
            "BYN" => amount,
            "EUR" => amount / EUR,
            "USD" => amount / USD,
            "RUB" => amount / RUB,
            _ => throw new ArgumentException("Неизвестная валюта")
        };

        decimal result = toCurrency switch
        {
            "BYN" => amountInByn,
            "EUR" => amountInByn * EUR,
            "USD" => amountInByn * USD,
            "RUB" => amountInByn * RUB,
            _ => throw new ArgumentException("Неизвестная валюта")
        };

        return result;
    }
}