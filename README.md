# Tic-Tac-Toe-2D

## Overview

This is a 2D Tic Tac Toe game developed using **Unity 6 (6000.1.1f1)**. It offers two gameplay modes: **1 vs 1 (Local Multiplayer)** and **1 vs PC (Single Player)**. The game features a clean user interface built with Unity's UI Elements, engaging background music, and sound effects for tile selection, winning, and drawing. The game uses Scriptable Objects to manage tile data, ensuring modularity and scalability.

## Features

- **Game Modes**:
  - **Local Multiplayer**: Two players take turns on the same device to compete.
  - **Single Player**: Play against an AI opponent with a simple random tile selection strategy.
- **User Interface**:
  - A main menu with options to select game mode (1 vs 1, 1 vs PC) or exit the game.
  - A 3x3 grid where players click to place their symbols (O or X).
  - Winning cells are highlighted in green-yellow when a player wins.
  - Text prompts display the current turn and game result (win or draw).
- **Audio**:
  - Background music to enhance the gaming experience.
  - Sound effects for tile clicks, winning, and drawing.
- **Technical Details**:
  - Built using Unity's UI Elements for the frontend.
  - Utilizes Scriptable Objects for tile metadata management.
  - Modular scripts for game logic, UI updates, and audio management.

## Project Structure

Below is an overview of the key scripts used in the project:

- **TileDetails.cs**: Manages individual tile properties (index and symbol) using a Scriptable Object (`TileMeta`).
- **TileMeta.cs**: A Scriptable Object to store tile index and symbol data.
- **PromptTexts.cs**: Handles UI text updates for current turn and game results.
- **SFX.cs**: Manages sound effects for tile clicks, wins, and draws using Unity's `AudioSource`.
- **LevelManager.cs**: Controls scene navigation (Main Menu, Local Multiplayer, Single Player) and game exit functionality.
- **GameStatus.cs**: Singleton class to manage game state, tile interactions, and UI updates (e.g., enabling/disabling tiles, highlighting winning cells).
- **GameLogic.cs**: Core logic for the 1 vs 1 mode, including turn management, winner detection, and draw conditions.
- **GameLogicAI.cs**: Extends `GameLogic` for the 1 vs PC mode, adding AI turn logic with random tile selection.

## How to Play

1. **Main Menu**:
   - Choose **Local Multiplayer** for 1 vs 1 or **Single Player** for 1 vs PC.
   - Select **Exit** to quit the game.
2. **Gameplay**:
   - Players take turns clicking on an empty cell in the 3x3 grid to place their symbol (O or X).
   - In Single Player mode, the AI selects a random empty tile after the player's turn (with a 2-second delay).
   - The game ends when a player wins (three matching symbols in a row, column, or diagonal) or when all tiles are filled (draw).
   - Winning cells are highlighted, and the result is displayed on the screen.
3. **Audio Feedback**:
   - A click sound plays when a tile is selected.
   - Distinct sounds play for a win or a draw.

## Installation

1. **Prerequisites**:
   - Unity 6 (6000.1.1f1) or later.
   - Ensure the `TextMeshPro` package is installed in Unity for text rendering.
2. **Setup**:
   - Clone this repository to your local machine.
   - Open the project in Unity.
   - Ensure all scenes (Main Menu, Local Multiplayer, Single Player) are added to the Build Settings.
   - Assign appropriate audio clips (`clickSound`, `winSound`, `drawSound`) in the `SFX` component.
3. **Build and Run**:
   - Build the project for your desired platform (e.g., Windows, macOS).
   - Run the game and select a mode from the main menu to start playing.

## Dependencies

- **Unity 6 (6000.1.1f1)**: Game engine used for development.
- **TextMeshPro**: For rendering dynamic text in the UI.
- **Unity UI Elements**: For building the user interface.

## Future Improvements

- Add difficulty levels for the AI (e.g., minimax algorithm for smarter moves).
- Implement a restart button to reset the game without returning to the main menu.
- Enhance the UI with animations for tile placement and win conditions.
- Add support for online multiplayer.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Submit a pull request with a clear description of your changes.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Acknowledgments

- Built with **Unity 6** for a robust game development experience.
- Special thanks to the Unity community for providing resources and tutorials on UI Elements and Scriptable Objects.