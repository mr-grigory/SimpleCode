using CSharpFunctionalExtensions;

namespace CrazySnake.Models;

public class Snake
{
    private Snake(List<Point> body) { _body = body; }
    
    private List<Point> _body;
    
    public Point Head { get; private set; }
    
    
    /// <summary>
    /// Метод для валидации полей еще на этапе создания экземпляра класса
    /// </summary>
    /// <param name="body">тело змейки</param>
    /// <returns></returns>
    public UnitResult<Error> Create(List<Point> body)
    {
        if (body.Count == 0)
            return Error.Validation(ErrorsTypes.VALIDATION, "Body is empty");
        
        if (body.Distinct().Count() != body.Count)
            return Error.Validation(ErrorsTypes.VALIDATION, "items in body is not unique");

        for (var i = 1; i < body.Count; i++)
        {
            if (!IsNeighbor(body[i], body[i - 1]))
                return Error.Validation(ErrorsTypes.VALIDATION, "one or more items in body is not neighbor");
        }

        return UnitResult.Success<Error>();
    }
    
    /// <summary>
    /// Метод для перемещения змейки по полю
    /// </summary>
    /// <param name="newPosition">Новые координаты головы</param>
    /// <param name="grow">Увеличить ли змейку?</param>
    /// <returns></returns>
    public UnitResult<Error> Move(Point newPosition, bool grow)
    {
        if (!IsNeighbor(newPosition, _body[^1]))
          return  Error.Validation(ErrorsTypes.VALIDATION, "items in body is not neighbor");

        _body.Insert(0, newPosition);
        
        if (!grow)
            _body.RemoveAt(_body.Count - 1);
        
        return UnitResult.Success<Error>();
    }

    /// <summary>
    /// Проверяет что две координаты находятся ровно на расстоянии 1 клетки
    /// </summary>
    /// <param name="firstPosition"></param>
    /// <param name="secondPosition"></param>
    /// <returns></returns>
    private bool IsNeighbor(Point firstPosition, Point secondPosition)
    {
        var dx = firstPosition.X - secondPosition.X;
        var dy = firstPosition.Y - secondPosition.Y;
        return dx + dy == 1;
    }
    
}