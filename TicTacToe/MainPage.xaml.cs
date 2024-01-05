using Microsoft.Maui.Controls;
using System;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        private const int GridSize = 3;
        private Button[,] _buttons;
        private bool _isPlayerX = true;
        private bool _gameOver = false;

        public MainPage()
        {
            InitializeComponent();
            InitializeGameGrid();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void InitializeGameGrid()
        {
            _buttons = new Button[GridSize, GridSize];

            for (int row = 0; row < GridSize; row++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                for (int col = 0; col < GridSize; col++)
                {
                    GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    _buttons[row, col] = new Button
                    {
                        Text = "",
                        FontSize = 30,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Command = new Command(() => OnButtonClick(row, col))
                    };

                    GameGrid.Children.Add(_buttons[row, col], col, row);
                }
            }
        }
        private void OnButtonClick(int row, int col)
        {
            if (!_gameOver && string.IsNullOrEmpty(_buttons[row, col].Text))
            {
                _buttons[row, col].Text = _isPlayerX ? "X" : "O";
                CheckForWinner(row, col);
                _isPlayerX = !_isPlayerX;
            }
        }

        private void CheckForWinner(int row, int col)
        {
            // Implement your winning condition logic here

            // For simplicity, you can set _gameOver to true and display a message
            // For a complete Tic Tac Toe implementation, you'd need to check rows, columns, and diagonals for a winning combination.
            _gameOver = true;
            ResultLabel.Text = $"Result: Player {_buttons[row, col].Text} Wins!";
        }

        private void OnRestartClicked(object sender, EventArgs e)
        {
            // Restart the game
            foreach (var button in _buttons)
            {
                button.Text = "";
            }

            ResultLabel.Text = "Result: ";
            _gameOver = false;
        }
    }
}
