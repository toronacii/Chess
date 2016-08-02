namespace Chess
{
    public interface IPieceContext
    {
        SquareCoordinate Position { get; set; }
        bool Moved { get; set; }
             
        PieceColor Color { get; set; }
    }
}