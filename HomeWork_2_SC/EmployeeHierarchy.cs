public class Employee // Сотрудник
{
    public string Name { get; set; } // Автоматическое свойство для хранения имени сотрудника (строковый тип) c аксессорами { get; set; }
    public decimal BaseSalary { get; set; } // Свойство для базовой зарплаты. Используется тип decimal, так как он идеален для финансовых расчетов.

    public Employee(string name, decimal baseSalary) // Конструктор класса Employee, принимающий имя и базовую ставку при создании объекта.
    {
        Name = name; // Записывает переданное в конструктор имя во внутреннее свойство Name.
        BaseSalary = baseSalary; // Тоже самое только с BaseSalary.
    }

    public virtual decimal CalculateMonthlySalary() //  Объявление виртуального метода. Ключевое слово virtual позволяет
                                                    //  классам-наследникам переопределять этот метод.
    {
        return BaseSalary; // По умолчанию метод возвращает просто базовую ставку, как указано в задании.
    }
}

public class Manager : Employee // Объявление класса Manager, который наследуется (:) от базового класса Employee.
{
    public decimal Bonus { get; set; } // Новое уникальное свойство менеджера — его фиксированный бонус.

    public Manager(string name, decimal baseSalary, decimal bonus) : base(name, baseSalary) // Конструктор менеджера. Ключевое слово :
                                                                                            // base(...) передает имя и базовую зарплату вверх
                                                                                            // в конструктор базового класса Employee,
                                                                                            // чтобы не дублировать код инициализации.
    {
        Bonus = bonus; // Инициализирует уникальное для менеджера свойство Bonus.
    }

    public override decimal CalculateMonthlySalary() // Переопределение виртуального метода. Ключевое слово override указывает,
                                                     // что мы заменяем базовую логику расчета на новую.
    {
        return BaseSalary + Bonus; // Возвращает сумму базовой зарплаты и бонуса менеджера.
    }
}

public class Developer : Employee // Объявление класса Developer (Разработчик), который также наследуется от Employee.
{
    public int LinesOfCodeWritten { get; set; } // Уникальное свойство разработчика — количество написанных строк кода (целое число int).

    public Developer(string name, decimal baseSalary, int linesOfCodeWritten) : base(name, baseSalary) // Конструктор разработчика. Передает общие
                                                                                                       // параметры в базовый класс Employee.
    {
        LinesOfCodeWritten = linesOfCodeWritten; // Инициализирует количество строк кода.
    }

    public override decimal CalculateMonthlySalary() // Переопределение метода расчета зарплаты для разработчика.
    {
        decimal ratePerLine = 0.5m; // Локальная переменная. Устанавливаем тариф (например, 50 копеек или 0.5 у.е.)
                                    // за каждую написанную строку кода. Буква m означает тип decimal.
        return BaseSalary + (LinesOfCodeWritten * ratePerLine); // Формула расчета: к базовой зарплате прибавляется премия,
                                                                // которая зависит от количества строк кода.
    }
}