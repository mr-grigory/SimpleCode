namespace CrazySnake.Domain;


/// <summary>
/// Местоположениие на карте для любого объекта
/// </summary>
/// <param name="X">Местоположение по горизонтали</param>
/// <param name="Y">Местоположениие по вертикали</param>
public readonly record struct Point(int X, int Y);