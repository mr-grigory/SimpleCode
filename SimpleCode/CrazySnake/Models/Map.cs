namespace CrazySnake.Models;

/// <summary>
/// Класс содержащий карту, по которой двигается змея
/// </summary>
public static class Map
{
    
    private static int _height = 10;
    private static int _width = 10;
    private static char[,] _map = new char[_height, _width];
    private static char _emptyArea = '.';
    private static char _wall = '#';
    //!TODO Добавить положение змеи на карте, это группа пар значений (y, x)

    /// <summary>
    /// Генерация самой карты. Используется внутри класса, при изменениях на карте
    /// </summary>
    private static void GenerateMap()
    {

    }
    
    /// <summary>
    /// Изменяет размер карты
    /// </summary>
    /// <param name="width">Ширина поля</param>
    /// <param name="height">Высота поля</param>
    public static void Resize(int width, int height)
    {
        
    }
    
    /// <summary>
    /// Отрисовывает поле в консоль
    /// </summary>
    public static void Print()
    {
        
    }

    /// <summary>
    /// Проверка, можно ли переместиться в эти координаты
    /// </summary>
    /// <param name="y">Высота</param>
    /// <param name="x">Ширина</param>
    /// <returns></returns>
    public static bool IsFreeArea(int y, int x)
    {
        return true;
    }
}