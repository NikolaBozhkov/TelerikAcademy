using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TicTacToe
{
    public sealed partial class GameControl : UserControl
    {
        public GameControl()
        {
            this.InitializeComponent();
            this.SetRandomCurrentPlayer();
            this.IsGameOver = false;
        }

        private String CurrentPlayer { get; set; }
        private bool IsGameOver { get; set; }

        private void SwitchCurrentPlayer()
        {
            this.CurrentPlayer = this.CurrentPlayer == "X" ? "O" : "X";
            this.CurrentPlayerLabel.Text = this.CurrentPlayer; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsGameOver)
            {
                return;
            }

            Button clickedButton = sender as Button;
            if (clickedButton.Content != null)
            {
                return;
            }

            clickedButton.Content = this.CurrentPlayer;

            bool isDraw = false;
            if (this.checkGameOver(out isDraw))
            {
                this.EndGame(isDraw);
                return;
            }

            this.SwitchCurrentPlayer();
        }

        private bool checkGameOver(out bool isDraw)
        {
            isDraw = false;

            if (Button_0_0.Content != null &&
                Button_0_1.Content != null &&
                Button_0_2.Content != null &&
                Button_1_0.Content != null &&
                Button_1_1.Content != null &&
                Button_1_2.Content != null &&
                Button_2_0.Content != null &&
                Button_2_1.Content != null &&
                Button_2_2.Content != null)
            {
                isDraw = true;
                return true;
            }

            return
                // Check rows
                (Button_0_0.Content != null && Button_0_1.Content != null && Button_0_2.Content != null &&
                Button_0_0.Content.ToString() == Button_0_1.Content.ToString() &&
                Button_0_0.Content.ToString() == Button_0_2.Content.ToString()) ||
                (Button_1_0.Content != null && Button_1_1.Content != null && Button_1_2.Content != null &&
                Button_1_0.Content.ToString() == Button_1_1.Content.ToString() &&
                Button_1_0.Content.ToString() == Button_1_2.Content.ToString()) ||
                (Button_2_0.Content != null && Button_2_1.Content != null && Button_2_2.Content != null &&
                Button_2_0.Content.ToString() == Button_2_1.Content.ToString() &&
                Button_2_0.Content.ToString() == Button_2_2.Content.ToString()) ||
                // Check columns
                (Button_0_0.Content != null && Button_1_0.Content != null && Button_2_0.Content != null &&
                Button_0_0.Content.ToString() == Button_1_0.Content.ToString() &&
                Button_0_0.Content.ToString() == Button_2_0.Content.ToString()) ||
                (Button_0_1.Content != null && Button_1_1.Content != null && Button_2_1.Content != null &&
                Button_0_1.Content.ToString() == Button_1_1.Content.ToString() &&
                Button_0_1.Content.ToString() == Button_2_1.Content.ToString()) ||
                (Button_0_2.Content != null && Button_1_2.Content != null && Button_2_2.Content != null &&
                Button_0_2.Content.ToString() == Button_1_2.Content.ToString() &&
                Button_0_2.Content.ToString() == Button_2_2.Content.ToString()) ||
                // Check diags
                (Button_0_0.Content != null && Button_1_1.Content != null && Button_2_2.Content != null &&
                Button_0_0.Content.ToString() == Button_1_1.Content.ToString() &&
                Button_0_0.Content.ToString() == Button_2_2.Content.ToString()) ||
                (Button_0_2.Content != null && Button_1_1.Content != null && Button_2_0.Content != null &&
                Button_0_2.Content.ToString() == Button_1_1.Content.ToString() &&
                Button_0_2.Content.ToString() == Button_2_0.Content.ToString());
        }

        private void SetRandomCurrentPlayer()
        {
            Random random = new Random();
            CurrentPlayer = random.Next() % 2 > 0 ? "X" : "O";
            CurrentPlayerLabel.Text = CurrentPlayer;
        }

        private void EndGame(bool isDraw)
        {
            this.IsGameOver = false;
            this.winnerTextBlock.Text = isDraw ? "Draw!" : this.CurrentPlayer + "Wins!";
            FlyoutBase.ShowAttachedFlyout(this);
        }
    }
}
