namespace LevelBuilder2d.Building
{
    public interface IFigureFactory
    {
        bool TryCreateFigure(out IFigure figureInstance);
    }
}
