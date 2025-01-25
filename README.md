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

## ChessUI
- Contains assets (images) for the chessboard and pieces.
- Designed to visually represent the game state based on the logic provided by `ChessLogic`.

## How to Run
1. Clone the repository.
2. Open the project in your preferred IDE.
3. Run the main application file to start the game.
