namespace ChessLogic
{
    public enum MoveType
    {
        Normal, // standard piece movement 
        CastleKS, // kingside castling
        CastleQS, // queenside castling
        DoublePawn, // pawn moving two squares forward
        EnPassant, // special pawn capture
        PawnPromotion  // pawn reaching the eighth rank and promoting
    }
}
