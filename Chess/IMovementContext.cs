namespace Chess
{
    public interface IMovementContext
    {
        Square Position { get; set; }
        Square Target { get; set; }

        bool Moved { get; set; }
             
        PieceColor Color { get; set; }
    }
}