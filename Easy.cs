using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITEC_103_ROSAL___MAKASAYAN
{
    public partial class Easy : Form
    {
        int correctAnswer;
        int questionNumber;
        int score;
        int percentage;
        int totalQuestions;
        int incorrectAnswers; // Counter for incorrect answers
        List<int> askedQuestions; // List to keep track of asked questions

        public Easy()
        {
            InitializeComponent();
            totalQuestions = 20;
            label2.Text = "Score: 0"; // Initialize the score label
            label2.ForeColor = Color.White;
            askedQuestions = new List<int>();
            RestartQuiz();
        }

        private void ClickAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if (buttonTag == correctAnswer)
            {
                // Correct answer, increment score
                score++;
                label2.Text = "Score: " + score; // Update score label
               
            }
            else
            {
                // Incorrect answer, increment incorrect answer counter
                incorrectAnswers++;
            }

            if (incorrectAnswers >= 3)
            {
                // User has answered incorrectly 3 times
                var result = MessageBox.Show("You lose!" + Environment.NewLine +
                                             "You have answered incorrectly 3 times." + Environment.NewLine +
                                             "Would you like to try again?", "Game Over",
                                             MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // User chose to restart the quiz
                    RestartQuiz();
                }
                else
                {
                    // User chose not to restart, open Form1
                    OpenMind_Testcs();
                }

                return; // Exit the method to avoid further processing
            }

            if (questionNumber == totalQuestions)
            {
                // Calculate the percentage
                percentage = (int)Math.Round((double)(100 * score) / totalQuestions);

                if (incorrectAnswers == 0)
                {
                    MessageBox.Show("Congratulations, you win!" + Environment.NewLine +
                                    "You have answered all questions correctly." + Environment.NewLine +
                                    "Your total score is " + score + " out of " + totalQuestions + ".");
                }
                else if (incorrectAnswers <= 2)
                {
                    MessageBox.Show("Almost there!" + Environment.NewLine +
                                    "You have answered " + score + " questions correctly." + Environment.NewLine +
                                    "Your total percentage is " + percentage + " %." + Environment.NewLine +
                                    "Click OK to play again.");
                }
                else
                {
                    MessageBox.Show("Quiz Ended" + Environment.NewLine +
                                    "You have answered " + score + " questions correctly" + Environment.NewLine +
                                    "Your total percentage is " + percentage + " %" + Environment.NewLine +
                                    "Click OK to play again.");
                }

                // Optionally, reset the quiz
                RestartQuiz();
            }
            else
            {
                askQuestion();
            }
        }

        private void RestartQuiz()
        {
            questionNumber = 0;
            score = 0;
            incorrectAnswers = 0; // Reset incorrect answer counter
            askedQuestions.Clear(); // Clear the list of asked questions
            label2.Text = "Score: " + score; // Update score label to reflect the reset
            askQuestion();
        }

        private void OpenMind_Testcs()
        {
            Mind_Testcs mainForm = new Mind_Testcs();
            mainForm.Show();
            this.Hide();
        }

        private void askQuestion()
        {
            Random rand = new Random();
            int nextQuestion;

            // Find a question that hasn't been asked yet
            do
            {
                nextQuestion = rand.Next(1, totalQuestions + 1);
            } while (askedQuestions.Contains(nextQuestion));

            askedQuestions.Add(nextQuestion); // Add the question to the list of asked questions
            questionNumber++;

            switch (nextQuestion)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.easy1;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "479";
                    btn2.Text = "489";
                    btn3.Text = "439";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.easy2;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "5478";
                    btn2.Text = "4656";
                    btn3.Text = "8562";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources.easy3;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "2468";
                    btn2.Text = "6482";
                    btn3.Text = "4824";
                    correctAnswer = 3;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources.easy4;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "75";
                    btn2.Text = "49";
                    btn3.Text = "95";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 5:
                    pictureBox1.Image = Properties.Resources.easy5;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "552";
                    btn2.Text = "555";
                    btn3.Text = "553";
                    correctAnswer = 3;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 6:
                    pictureBox1.Image = Properties.Resources.easy6;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "770";
                    btn2.Text = "750";
                    btn3.Text = "760";
                    correctAnswer = 3;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 7:
                    pictureBox1.Image = Properties.Resources.easy7;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "2654";
                    btn2.Text = "3707";
                    btn3.Text = "3506";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 8:
                    pictureBox1.Image = Properties.Resources.easy8;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "8989 ";
                    btn2.Text = "9898";
                    btn3.Text = "9989";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 9:
                    pictureBox1.Image = Properties.Resources.easy9;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "3726";
                    btn2.Text = "2376";
                    btn3.Text = "3763";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 10:
                    pictureBox1.Image = Properties.Resources.easy10;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "324";
                    btn2.Text = "264";
                    btn3.Text = "114";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 11:
                    pictureBox1.Image = Properties.Resources.easy11;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "50";
                    btn2.Text = "54";
                    btn3.Text = "20";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 12:
                    pictureBox1.Image = Properties.Resources.easy12;
                    btn1.Text = "2627";
                    btn2.Text = "2728";
                    btn3.Text = "2829";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 13:
                    pictureBox1.Image = Properties.Resources.easy13;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "174";
                    btn2.Text = "154";
                    btn3.Text = "74";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 14:
                    pictureBox1.Image = Properties.Resources.easy14;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "3192";
                    btn2.Text = "7412";
                    btn3.Text = "1892";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 15:
                    pictureBox1.Image = Properties.Resources.easy15;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "999";
                    btn2.Text = "90";
                    btn3.Text = "9";
                    correctAnswer = 3;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 16:
                    pictureBox1.Image = Properties.Resources.easy16;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "2.0";
                    btn2.Text = "20";
                    btn3.Text = ".20";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 17:
                    pictureBox1.Image = Properties.Resources.easy17;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "1692";
                    btn2.Text = "1.692";
                    btn3.Text = "169.2";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 18:
                    pictureBox1.Image = Properties.Resources.easy18;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = " 999.9";
                    btn2.Text = "999";
                    btn3.Text = "9999";
                    correctAnswer = 3;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 19:
                    pictureBox1.Image = Properties.Resources.easy19;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "2628";
                    btn2.Text = "2268";
                    btn3.Text = "2862";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;

                case 20:
                    pictureBox1.Image = Properties.Resources.easy20;
                    lblQuestion.Text = "Answer the Math Equation:";
                    btn1.Text = "1230";
                    btn2.Text = "4560";
                    btn3.Text = "1120";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn3.Tag = 3;
                    break;
            }
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            // Create an instance of Form1
            Mind_Testcs mainForm = new Mind_Testcs();

            // Show Form1
            mainForm.Show();

            // Close the current form
            this.Hide();

            // Ask a new question in the difficult form
            askQuestion();
        }



        private void label2_Click(object sender, EventArgs e)
        {
            // Reset the score to zero
            score = 0;
            label2.Text = "Score: " + score; // Update score label to reflect the reset
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            // Reset the score to zero
            score = 0;
            label2.Text = "Score: " + score; // Update score label to reflect the reset
        }

    }
}
