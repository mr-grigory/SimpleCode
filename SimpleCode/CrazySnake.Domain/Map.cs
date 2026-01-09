using CSharpFunctionalExtensions;

namespace CrazySnake.Domain;


/// <summary>
///  Класс описывающий игровое поле
/// </summary>
public class Map
{
    public Map(uint width, uint height)
    {
        Height = height;
        Width = width;
        BodyMap = GenerateBaseMap(height, width);
    }

    public Map(ItemsTypes[,] map)
    {
        Height = (uint)map.GetLength(0);
        Width = (uint)map.GetLength(1);
        BodyMap = map;
    }
    
    public uint Height { get; private set; }
    public uint Width { get; private set; }
    public ItemsTypes[,] BodyMap {get; private set;}
    

    /// <summary>
    /// Создает стандартную пустую карту, по всем 4 краям - стенки
    /// </summary>
    /// <param name="height">общая высота с учетом стен</param>
    /// <param name="width">общая ширина с учетом стен</param>
    /// <returns></returns>
    private static ItemsTypes[,] GenerateBaseMap(uint height, uint width)
    {
        var baseMap = new ItemsTypes[height, width];
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                if (i == 0 || i == height - 1 || j == 0 || j == width - 1 )
                    baseMap[i, j] = ItemsTypes.Wall;
                else
                    baseMap[i, j] = ItemsTypes.Empty;
            }
        }
        return baseMap; 
    }

    /// <summary>
    /// Проверяет, входят ли координаты в поле
    /// </summary>
    /// <param name="x">width</param>
    /// <param name="y">height</param>
    /// <returns></returns>
    private bool IsCell(uint x, uint y)
    {
        return x < Width && y < Height;
    }

    /// <summary>
    /// Получить данные из ячейки. Возвращает тип объекта в ячейке
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Result<ItemsTypes, Error> GetCell(uint x, uint y)
    {
        if (IsCell(x, y))
            return BodyMap[y, x];
        else 
            return Error.Validation(ErrorsTypes.VALIDATION, "X or Y are out of range.");
    }

    /// <summary>
    /// Установить объект в ячейку
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public UnitResult<Error> SetCell(uint x, uint y, ItemsTypes value)
    {
        if (IsCell(x, y))
        {
            BodyMap[y, x] = value;
            return UnitResult.Success<Error>();
        }
        else
            return Error.Validation(ErrorsTypes.VALIDATION, "X or Y are out of range.");
    }
}