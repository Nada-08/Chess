namespace ChessLogic
{
    public abstract class Piece
    {   
        public abstract PieceType Type { get; } 
        public abstract Player Color { get; }
        public bool HasMoved { get; set; } = false; // some moves are only legal if a piece has not moved yet
        public abstract Piece Copy();

    }
}
