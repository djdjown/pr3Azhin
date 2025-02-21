# Отладка программы различными способами ПР3

## Методы отладки

| Метод отладки                                  | Фибоначчи | Галактики | Буквы  |
|-----------------------------------------------|-----------|-----------|--------|
| Точки останова                                | ✅        | ✅        | ✅      |
| Пошаговая отладка (Шаг с заходом/Шаг/Выход)   | ✅        | ✅        | ✅      |
| Просмотр переменных (Locals, Autos, Watch)    | ✅        | ✅        | ✅      |
| Стек вызовов                                  | ❌        | ✅        | ✅      |
| Условные точки останова                       | ❌        | ✅        | ✅      |
| Точки трассировки                             | ❌        | ❌        | ❌      |

---

## Исправленный код

### Фибоначчи
```csharp
int result = Fibonacci(5);
Console.WriteLine(result);

static int Fibonacci(int n)
{
    int n1 = 0;
    int n2 = 1;
    int sum;

    for (int i = 2; i <= n; i++)
    {
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
    }

    return n == 0 ? n1 : n2;
}
