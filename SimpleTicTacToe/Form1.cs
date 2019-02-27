using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true;//true O false X
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe by Alex","About",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            turn_count++;
            b.Enabled = false;
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            
            bool there_is_a_winner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            String winner = turn ? "O" : "X";

            DialogResult d = DialogResult.None;
            if (there_is_a_winner)
            {
                disableButtons();
                d = MessageBox.Show(winner + " is a WINNER, he get's a cookie", "End", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                
            }
            else
            {
                if(turn_count==9)
                    d = MessageBox.Show("X and O can share a cookie", "End", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            if (d == DialogResult.OK)
                EndGame();

        }
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void EndGame()
        {
            turn_count = 0;
            turn = true;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EndGame();
        }
    }
}
