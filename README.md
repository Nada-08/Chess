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
- Provides methods for move generation:
  - `GetMoves(Position from, Board board)`: Returns all valid moves for the piece from a given position.
  - `MovePositionsInDir(Position from, Board board, Direction dir)`: Yields positions in a specific direction until an obstruction is encountered.
  - `MovePositionsInDirs(Position from, Board board, Direction[] dirs)`: Combines positions from multiple directions.

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

### 8. GameState Class
- Tracks the current state of the game.
- **Attributes:**
  - `Board`: Represents the current board configuration.
  - `CurrentPlayer`: Tracks whose turn it is (White or Black).
- **Functions:**
  - `LegalMovesForPiece(Position pos)`: Returns all legal moves for a piece at a given position, ensuring it belongs to the current player.
  - `MakeMove(Move move)`: Executes the move and switches the turn to the opponent.

### 9. MoveType Enum
- Represents the types of moves in chess:
  - `Normal`: Standard piece movement.
  - `CastleKS`: Kingside castling.
  - `CastleQS`: Queenside castling.
  - `DoublePawn`: Pawn moving two squares forward.
  - `EnPassant`: Special pawn capture.
  - `PawnPromotion`: Pawn reaching the eighth rank and promoting.

### 10. Move Class (Abstract)
- Defines the base structure for all chess moves.
- **Abstract Properties:**
  - `Type`: Returns the `MoveType`.
  - `FromPos`: The starting position of the move.
  - `ToPos`: The destination position of the move.
- **Abstract Method:**
  - `Execute(Board board)`: Executes the move on the board.

### 11. NormalMove Class
- Represents a standard move in chess.
- Inherits from `Move` and implements:
  - `Type`: Returns `MoveType.Normal`.
  - `FromPos` and `ToPos`: The starting and destination positions.
  - `Execute(Board board)`: Moves the piece from `FromPos` to `ToPos` and updates its state.

---

## ChessUI

### 1. MainWindow Class
- Manages the graphical representation of the chessboard and pieces.
- **Attributes:**
  - `pieceImages`: A 2D array of `Image` controls to display pieces on the board.
  - `highlights`: A 2D array of `Rectangle` for highlighting valid moves.
  - `moveCache`: A dictionary to store positions and their corresponding moves.
  - `selectedPos`: Tracks the currently selected position (initialized as `null`).
  - `gameState`: Tracks the current state of the game.
- **Key Functionalities:**
  - `InitializeBoard()`: Initializes the `pieceImages` and `highlights` arrays and sets up the `PieceGrid` (8x8 UniformGrid).
  - `DrawBoard(Board board)`: Updates the UI to reflect the current state of the board by rendering piece images.
  - `BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)`: Handles board clicks to select and move pieces based on `selectedPos`.
  - `CacheMoves(IEnumerable<Move> moves)`: Stores valid moves in `moveCache`.
  - `ShowHighlights()`: Highlights all valid moves for a selected piece.
  - `HideHighlights()`: Clears all move highlights.
  - `SetCursor(Player player)`: Sets the cursor to indicate the current player's turn.

### 2. Images Class
- Handles the loading and retrieval of piece images.
- **Attributes:**
  - `whiteSources`: A dictionary mapping `PieceType` to `ImageSource` for white pieces.
  - `blackSources`: A dictionary mapping `PieceType` to `ImageSource` for black pieces.
- **Key Functionalities:**
  - `LoadImage(string path)`: Loads an image from the specified file path.
  - `GetImage(Piece piece)`: Returns the appropriate image for a given piece (or `null` if the piece is `null`).
  - `GetImage(Player player, PieceType type)`: Returns the image for a specific piece type and color.

---

## How to Run
1. Clone the repository.
2. Open the project in your preferred IDE.
3. Run the main application file to start the game.
