namespace ChessLogic
{
    public class Pawn : Piece
    {
        // pawn can move one direction forward only, two if it's the first move 
        // pawn can move diagonally (one step only) if there's an opponent to be captured
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        private readonly Direction forward;

        public Pawn(Player color) 
        {
            Color = color;
            if (color == Player.White)
            {
                forward = Direction.North;
            }
            else if (color == Player.Black) 
            {
                forward = Direction.South;
            }
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board) 
        {
            return Board.IsInside(pos) && board.IsEmpty(pos); 
        }

        private bool CanCaptureAt(Position pos, Board board) 
        {
            if (!Board.IsInside(pos) || board.IsEmpty(pos) )
            {
                return false;
            }
            return board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position oneMovePos = from + forward;

            if (CanMoveTo(oneMovePos, board))
            {
                yield return new NormalMove(from, oneMovePos);

                Position twoMovesPos = oneMovePos + forward;    
                if (!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new NormalMove(from, twoMovesPos);

                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] {Direction.West, Direction.East})
            {
                Position to = from + forward + dir;
                if (CanCaptureAt(to, board))
                {
                    yield return new NormalMove(from, to);
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from, board));
        }
    }
}
