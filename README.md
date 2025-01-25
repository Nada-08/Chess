# Chess
This project is a Chess game implementation with a focus on logic and UI separation. It consists of two main components: **ChessLogic** (game logic) and **ChessUI** (user interface).

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
Represents the types of chess pieces: `Bishop`, `King`, `Knight`, `Pawn`, `Queen`, and `Rook`.

### 5. Piece Class (Abstract)
- Defines the base structure for all chess pieces.
- Includes abstract methods:
  - `Type`: Returns the `PieceType`.
  - `Color`: Returns the `Player` (White or Black).
  - `Copy`: Returns a deep copy of the piece.
- Includes a `HasMoved` property (default: `false`) to track if a piece has moved, which is crucial for special moves like castling.

### 6. Piece Subclasses
- **King, Knight, Bishop, Pawn, Queen, Rook**: Each inherits from `Piece` and implements the required methods to define their behavior.

### 7. Board Class
- Manages the 8x8 grid of pieces.
- Key functionalities:
  - `GetPiece(Position)`: Retrieves a piece at a specific position.
  - `AddStartPieces()`: Initializes the board with pieces in their starting positions.
  - `IsInside(Position)`: Checks if a position is within the board boundaries.
  - `IsEmpty(Position)`: Checks if a position is unoccupied.

### 8. GameState Class
- Tracks the current state of the game.
- Attributes:
  - `Board`: Represents the current board configuration.
  - `CurrentPlayer`: Tracks whose turn it is (White or Black).
- Acts as the bridge between the game logic (`ChessLogic`) and the user interface (`ChessUI`).

## ChessUI

### 1. MainWindow Class
- Manages the graphical representation of the chessboard and pieces.
- Attributes:
  - `pieceImages`: A 2D array of `Image` controls to display pieces on the board.
  - `gameState`: Tracks the current state of the game.
- Key Functionalities:
  - `InitializeBoard()`: Initializes the `pieceImages` array and sets up the `PieceGrid` (8x8 UniformGrid).
  - `DrawBoard(Board board)`: Updates the UI to reflect the current state of the board by rendering piece images.

### 2. Images Class
- Handles the loading and retrieval of piece images.
- Attributes:
  - `whiteSources`: A dictionary mapping `PieceType` to `ImageSource` for white pieces.
  - `blackSources`: A dictionary mapping `PieceType` to `ImageSource` for black pieces.
- Key Functionalities:
  - `LoadImage(string path)`: Loads an image from the specified file path.
  - `GetImage(Piece piece)`: Returns the appropriate image for a given piece (or `null` if the piece is `null`).
  - `GetImage(Player player, PieceType type)`: Returns the image for a specific piece type and color.

## How to Run
1. Clone the repository.
2. Open the project in your preferred IDE.
3. Run the main application file to start the game.
