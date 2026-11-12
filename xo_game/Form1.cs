using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xo_game.Properties;

namespace xo_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum enWinner
        {
            Player1, Player2,GameInprogress,Draw
        }
        enum enPlayer
        {
            Player1,Player2
        }
        struct StGameStatus
        {
           public  enWinner Winner;
           public  bool GameOver;
            public short PlayCount;


        }
        enPlayer PlayerTurn = enPlayer.Player1;
        StGameStatus GameStatus;

        void EndGame()
        {
            lbPlayerTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lbWinner.Text = "Player 1";
                    break;
                case enWinner.Player2:
                    lbWinner.Text = "Player 2";
                    break;
                    case enWinner.Draw:
                    lbWinner.Text = "Draw ";
                    break;

            }
            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        bool CheckValues(Button btn1, Button btn2, Button btn3) {
            if (btn1.Tag.ToString() != "?" && btn1.Tag == btn2.Tag && btn1.Tag == btn3.Tag)
            {
                btn1.BackColor = Color.YellowGreen;
                btn2.BackColor=Color.YellowGreen;
                btn3.BackColor=Color.YellowGreen;
                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                   EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner=enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }
            GameStatus.GameOver = false;
            return false;
        
        }



        void CheckWinner()
        {
            if(CheckValues(button1, button2, button3))
                return ;
            if (CheckValues(button4, button6, button5))
                return;
            if (CheckValues(btn8, button9, button7))
                return;
            if(CheckValues(button1,button6,button9))
                return ;
            if (CheckValues(button2, button5, btn8))
                return;
            if (CheckValues(button3, button4, button7))
                return;
            if (CheckValues(button1, button5, button7))
                return;
            if (CheckValues(button3, button5, button9))
                return;


        }
        void ChangeImage(Button btn)
        {

            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        btn.Tag = "X";
                        GameStatus.PlayCount++;
                        PlayerTurn = enPlayer.Player2;
                        lbPlayerTurn.Text = "Player 2";
                        CheckWinner();
                        break;
                        case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn= enPlayer.Player1;
                        lbPlayerTurn.Text = "Player 1";
                        btn.Tag = "O";
                        GameStatus.PlayCount++;
                        CheckWinner();
                        break;




                }
            }
            else
            {
               MessageBox.Show("Wronge Choice","Wronge",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            if (GameStatus.PlayCount == 9)
            {
                GameStatus.Winner = enWinner.Draw;
                GameStatus.GameOver = true;

                EndGame();
            }
           
        }
        
       
        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

       
        
       

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255, 255);
            Pen whitePen = new Pen(white);
            whitePen.Width = 15;
           
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(whitePen, 240, 180, 580, 180);
            e.Graphics.DrawLine(whitePen, 240, 330, 580, 330);

           
            e.Graphics.DrawLine(whitePen, 350, 60, 350, 450);
            e.Graphics.DrawLine(whitePen, 470, 60, 470, 450);

        }
        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;

        }
        private void btnRestert_Click(object sender, EventArgs e)
        {
            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(btn8);
            RestButton(button9);

            PlayerTurn = enPlayer.Player1;
            lbPlayerTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInprogress;
            lbWinner.Text = "In Progress";

        }

       
    }
}
