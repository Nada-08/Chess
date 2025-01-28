# Chess
This project is a Chess game implementation with a focus on logic and UI separation. It consists of two main components: **ChessLogic** (game logic) and **ChessUI** (user interface).

---

## ChessLogic

### 1. Player Enum
- Represents the players: `White`, `Black`, and `None`.
- Includes a `PlayerExtensions` class with a method to switch turns between `White` and `Black`.

### 2. Position Class
- Represents a position on the chessboard with `Row` and `Column` attributes.
- Includes methods to determine the square color (light or dark) based on row and column values.
- Overrides operators (`==`, `!=`, `+`, `Equals`, `GetHashCode`) for easy position manipulation.

### 3. Direction Class
- Represents movement directions (e.g., north, south, east, west) with `RowDelta` and `ColumnDelta` attributes.
- Supports addition (`+`) and scalar multiplication (`*`) for combining and scaling directions.

### 4. PieceType Enum
- Represents the types of chess pieces: `Bishop`, `King`, `Knight`, `Pawn`, `Queen`, and `Rook`.

### 5. Piece Class (Abstract)
- Defines the base structure for all chess pieces.
- Includes abstract methods:
  - `Type`: Returns the `PieceType`.
  - `Color`: Returns the `Player` (White or Black).
  - `Copy`: Returns a deep copy of the piece.
- Includes a `HasMoved` property (default: `false`) to track if a piece has moved, which is crucial for special moves like castling.
- **New Method:**
  - `virtual bool CanCaptureOpponentKing(Position from, Board board)`: Determines if a piece can capture the opponent's king from a given position. This method is overridden in the `Pawn` and `King` classes for optimized behavior.

### 6. Piece Subclasses
#### **Pawn Class**
- **Attributes:**
  - `Direction forward`: Determines the forward movement direction (`North` for White, `South` for Black).
- **Functions:**
  - `CanMoveTo(Position pos, Board board)`: Checks if a position is inside the board and empty.
  - `CanCaptureAt(Position pos, Board board)`: Checks if a diagonal position contains an opponent's piece.
  - `ForwardMoves(Position from, Board board)`: Generates moves for the first forward position and, if applicable, the next forward position if the pawn hasn't moved.
  - `DiagonalMoves(Position from, Board board)`: Generates moves for diagonal captures.
  - Overrides `GetMoves(Position from, Board board)` to combine `ForwardMoves` and `DiagonalMoves`.
  - Overrides `CanCaptureOpponentKing(Position from, Board board)` to focus only on diagonal positions for potential captures.

#### **Knight Class**
- **Functions:**
  - `PotentialToPositions(Position from)`: Generates all potential positions based on the knight's movement rules.
  - `MovePositions(Position from, Board board)`: Validates positions from `PotentialToPositions` (inside board, empty, or containing opponent's piece).
  - Overrides `GetMoves(Position from, Board board)` to create `NormalMove` objects from valid positions.

#### **King Class**
- **Attributes:**
  - `Direction[] dirs`: All directions a king can move (one step in any direction).
- **Functions:**
  - `MovePositions(Position from, Board board)`: Validates positions in all directions (inside board, empty, or containing opponent's piece).
  - Overrides `GetMoves(Position from, Board board)` to create `NormalMove` objects from valid positions.
  - Overrides `CanCaptureOpponentKing(Position from, Board board)` to include castling logic (to be expanded later).

#### **Other Subclasses**
- **Bishop**: Moves diagonally in all four directions.
- **Queen**: Combines the moves of a rook and bishop (all eight directions).
- **Rook**: Moves horizontally and vertically in all four directions.

### 7. Board Class
- Manages the 8x8 grid of pieces.
- **Key Functionalities:**
  - `GetPiece(Position)`: Retrieves a piece at a specific position.
  - `AddStartPieces()`: Initializes the board with pieces in their starting positions.
  - `IsInside(Position)`: Checks if a position is within the board boundaries.
  - `IsEmpty(Position)`: Checks if a position is unoccupied.
  - `IEnumerable<Position> PiecePositions()`: Returns all positions on the board that contain a piece.
  - `IEnumerable<Position> PiecePositionsFor(Player player)`: Filters positions from `PiecePositions` to return only those belonging to a specified player.
  - `Board Copy()`: Creates and returns a deep copy of the board.
  - `bool IsInCheck(Player player)`: Determines if a player's king is in check by checking if any opponent piece can capture the king.

### 8. GameState Class
- Tracks the current state of the game.
- **Attributes:**
  - `Board`: Represents the current board configuration.
  - `CurrentPlayer`: Tracks whose turn it is (White or Black).
- **Key Functions:**
  - `LegalMovesForPiece(Position pos)`: Modified to filter all valid moves and retain only the legal ones using the `IsLegal` method of `Move`.
  - `MakeMove(Move move)`: Executes the move and switches the turn to the opponent.

### 9. Move Class (Abstract)
- Defines the base structure for all chess moves.
- **Abstract Properties:**
  - `Type`: Returns the `MoveType`.
  - `FromPos`: The starting position of the move.
  - `ToPos`: The destination position of the move.
- **Abstract Method:**
  - `Execute(Board board)`: Executes the move on the board.
- **Virtual Method:**
  - `virtual bool IsLegal(Board board)`: Checks if the move is legal by copying the board, executing the move on the copy, and verifying the result.

### 10. NormalMove Class
- Represents a standard move in chess.
- Inherits from `Move` and implements:
  - `Type`: Returns `MoveType.Normal`.
  - `FromPos` and `ToPos`: The starting and destination positions.
  - `Execute(Board board)`: Moves the piece from `FromPos` to `ToPos` and updates its state.

---

## ChessUI

### MainWindow Class
- Manages the graphical representation of the chessboard and pieces.
- Handles UI interactions for piece selection, move highlighting, and move execution.

---

## How to Run
1. Clone the repository.
2. Open the project in your preferred IDE.
3. Run the main application file to start the game.
