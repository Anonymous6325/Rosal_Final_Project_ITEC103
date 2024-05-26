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
    public partial class Moderate : Form
    {
        int correctAnswer;
        int questionNumber;
        int score;
        int percentage;
        int totalQuestions;
        int incorrectAnswers; // Counter for incorrect answers
        List<int> askedQuestions; // List to keep track of asked questions

        public Moderate()
        {
            InitializeComponent();
            totalQuestions = 20;
            label2.Text = "Score: 0"; // Initialize the score label
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
                    pictureBox1.Image = Properties.Resources.M1;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "Divisor";
                    btn2.Text = "Dividend";
                    btn4.Text = "Division";
                    btn5.Text = "Quotient";
                    correctAnswer = 5;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.M2;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = " Parentheses, Exponents, Multiplication and Division, and Addition and Subtraction";
                    btn2.Text = "Please Excuse My Dear Aunt Sally";
                    btn4.Text = "Purple Elephants Make Dirty Apple Sauce";
                    btn5.Text = "People Eat Muffins Daily At Sea";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources.M3;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "Exponent";
                    btn2.Text = "Parenthesis";
                    btn4.Text = "Division";
                    btn5.Text = "None";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources.M4;
                    lblQuestion.Text = "Answer the Math Question";
                    btn2.Text = "2";
                    btn4.Text = "3";
                    btn5.Text = "1";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 5:
                    pictureBox1.Image = Properties.Resources.M5;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "13";
                    btn2.Text = "23";
                    btn4.Text = "33";
                    btn5.Text = "43";
                    correctAnswer = 4;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 6:
                    pictureBox1.Image = Properties.Resources.M6;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "26";
                    btn2.Text = "6";
                    btn4.Text = "3";
                    btn5.Text = "None";
                    correctAnswer = 4;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 7:
                    pictureBox1.Image = Properties.Resources.M7;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "36";
                    btn2.Text = "5";
                    btn4.Text = "4.65";
                    btn5.Text = "5.75";
                    correctAnswer = 5;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 8:
                    pictureBox1.Image = Properties.Resources.M8;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "5.13";
                    btn2.Text = "51.3";
                    btn4.Text = "13.5";
                    btn5.Text = "1.35";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 9:
                    pictureBox1.Image = Properties.Resources.M9;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "6";
                    btn2.Text = "7";
                    btn4.Text = "5.45";
                    btn5.Text = "None";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 10:
                    pictureBox1.Image = Properties.Resources.M10;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "95 degrees";
                    btn2.Text = "90 degrees";
                    btn4.Text = "90.5 degrees";
                    btn5.Text = "80 degrees";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 11:
                    pictureBox1.Image = Properties.Resources.M11;
                    lblQuestion.Text = "Answer the Math Question"; ;
                    btn1.Text = " 94 square meters";
                    btn2.Text = " 86 square meters";
                    btn4.Text = " 90 square meters";
                    btn5.Text = " 96 square meters";
                    correctAnswer = 5;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 12:
                    pictureBox1.Image = Properties.Resources.M12;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "50 miles per hour";
                    btn2.Text = "54.5 miles per hour";
                    btn4.Text = "56 miles per hour";
                    btn5.Text = "50.65 miles per hour";
                    correctAnswer = 4;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 13:
                    pictureBox1.Image = Properties.Resources.M13;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "Cylinder";
                    btn2.Text = "Trapezoid";
                    btn4.Text = "Circle";
                    btn5.Text = "Cube";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 14:
                    pictureBox1.Image = Properties.Resources.M14;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "444 dollars";
                    btn2.Text = "666 dollars";
                    btn4.Text = "582 dollars";
                    btn5.Text = "434 dollars";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 15:
                    pictureBox1.Image = Properties.Resources.M15;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "Hemisphere";
                    btn2.Text = "Pyramid";
                    btn4.Text = "Tetrahedron";
                    btn5.Text = "Triangular Prism";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 16:
                    pictureBox1.Image = Properties.Resources.M16;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "Rectangular Prism";
                    btn2.Text = "Cuboid";
                    btn4.Text = "Cube";
                    btn5.Text = "Torus";
                    correctAnswer = 4;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 17:
                    pictureBox1.Image = Properties.Resources.M17;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "Sphere";
                    btn2.Text = "Dodecahedron";
                    btn4.Text = "Cylindrical Tube";
                    btn5.Text = "None";
                    correctAnswer = 1;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 18:
                    pictureBox1.Image = Properties.Resources.M18;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "11.616";
                    btn2.Text = "116.6";
                    btn4.Text = "√136";
                    btn5.Text = "None";
                    correctAnswer = 4;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 19:
                    pictureBox1.Image = Properties.Resources.M19;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "10.21";
                    btn2.Text = "√10.4";
                    btn4.Text = "104";
                    btn5.Text = "√104";
                    correctAnswer = 5;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;

                case 20:
                    pictureBox1.Image = Properties.Resources.M20;
                    lblQuestion.Text = "Answer the Math Question";
                    btn1.Text = "141.3";
                    btn2.Text = "√208";
                    btn4.Text = "14.43";
                    btn5.Text = "√20.8";
                    correctAnswer = 2;
                    btn1.Tag = 1;
                    btn2.Tag = 2;
                    btn4.Tag = 4;
                    btn5.Tag = 5;
                    break;
            }

        }

        private void btn3_Click(object sender, EventArgs e)
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

