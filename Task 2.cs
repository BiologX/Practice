/*

Используем интерфейс для соблюдения DIP.
Класс имеет единственную ответственность — управление историей.

*/

using System;
using System.Collections.Generic;

IBrowserHistory history = new BrowserHistory();

history.AddPage("https://example.com");
history.AddPage("https://modsen.by");
history.AddPage("https://github.com");

Console.WriteLine("Назад: " + history.Back());
Console.WriteLine("Назад: " + history.Back());
Console.WriteLine("Есть ли история? " + history.HasHistory);


public interface IBrowserHistory
{
    void AddPage(string url);
    string Back();
    bool HasHistory { get; }
}

public class BrowserHistory : IBrowserHistory
{
    private readonly Stack<string> _history;

    public BrowserHistory()
    {
        _history = new Stack<string>();
    }

    public void AddPage(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("URL не может быть пустым.", nameof(url));

        _history.Push(url);
    }

    public string Back()
    {
        if (_history.Count == 0)
            throw new InvalidOperationException("История пуста.");

        return _history.Pop();
    }

    // Проверка наличия истории
    public bool HasHistory => _history.Count > 0;
}
