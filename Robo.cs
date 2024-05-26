using ITEC_103_ROSAL___MAKASAYAN;
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
    public partial class Robo : Form
    {
        //public variables needed for our custom functions
        //controls player position on screen
        bool keyup;
        bool keydown;
        bool keyleft;
        bool keyright;
        string playerDirection = "right";

        //state of game at game start
        bool gameOver = false;

        //player stats at game start
        double health = 100;
        int movementSpeed = 8;
        int ammoLevel = 5;
        int robotSpeed = 2;
        int annihilations = 0;
        Random random = new Random();

        public Robo()
        {
            InitializeComponent();
            InitializeGame();
        }

        //initializes the game state
        private void InitializeGame()
        {
            gameOver = false;
            health = 100;
            movementSpeed = 8;
            ammoLevel = 5;
            robotSpeed = 2;
            annihilations = 0;
            keyup = keydown = keyleft = keyright = false;
            playerDirection = "right";

            // Clear all bullets and robots from the screen
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (x.Tag == "robot" || x.Tag == "bullet" || x.Tag == "ammo"))
                {
                    this.Controls.Remove(x);
                    x.Dispose();
                }
            }

            playerController.Left = this.ClientSize.Width / 2;
            playerController.Top = this.ClientSize.Height / 2;
            playerController.Image = Properties.Resources.mr;
            progressHealth.Value = 100;
            progressHealth.ForeColor = Color.Green;

            textAmmo.Text = ammoLevel.ToString();
            textKills.Text = annihilations.ToString();

            // Spawn initial set of robots
            for (int i = 0; i < 2; i++) // Example: Spawn 3 robots initially
            {
                spawnRobots();
            }

            gameStart.Start();
        }

        //restarts the game
        private void RestartGame()
        {
            InitializeGame();
        }

        //moves player when keys are pressed down
        private void keyDown(object sender, KeyEventArgs e)
        {
            //player won't be able to move if game is over
            if (gameOver)
            {
                return;
            }

            //moves player left with left arrow key and sets image as "man-left"
            if (e.KeyCode == Keys.Left)
            {
                keyleft = true;
                playerDirection = "left";
                playerController.Image = Properties.Resources.ml;
            }

            //moves player right with right arrow key and sets image as "man-right"
            if (e.KeyCode == Keys.Right)
            {
                keyright = true;
                playerDirection = "right";
                playerController.Image = Properties.Resources.mr;
            }

            //moves player down with right down key and sets image as "man-down"
            if (e.KeyCode == Keys.Down)
            {
                keydown = true;
                playerDirection = "down";
                playerController.Image = Properties.Resources.md;
            }

            //moves player up with right up key and sets image as "man-up"
            if (e.KeyCode == Keys.Up)
            {
                keyup = true;
                playerDirection = "up";
                playerController.Image = Properties.Resources.mu;
            }
        }

        //stops player movement when keys arent pressed
        private void keyUp(object sender, KeyEventArgs e)
        {
            //player won't be able to move if game is over
            if (gameOver)
            {
                return;
            }

            //disables keys when not pressed
            if (e.KeyCode == Keys.Left)
            {
                keyleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                keyright = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                keydown = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                keyup = false;
            }

            if (e.KeyCode == Keys.Space && ammoLevel > 0)
            {
                // Reduce ammo and shoot in the direction the player faces
                ammoLevel--;
                shootMain(playerDirection);

                // Spawn ammo if ammo is low
                if (ammoLevel < 1)
                {
                    spawnAmmo();
                }
            }
        }

        private void GameOver()
        {
            gameStart.Stop();
            gameOver = true;
            DialogResult result = MessageBox.Show("You have lost the game! Do you want to restart?", "Game Over", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                RestartGame();
            }
            else
            {
                // Navigate back to the SubMenu
                this.Hide();
                Sub_Menu subMenu = new Sub_Menu();
                subMenu.Show();
            }
        }

        //timer event on game start
        private void gameStartEvent(object sender, EventArgs e)
        {
            //if the player has enough health left, the progressbar will be shown
            if (health > 1)
            {
                progressHealth.Value = Convert.ToInt32(health);
            }
            //else the player will be killed and game over is called
            else
            {
                playerController.Image = Properties.Resources.death;
                gameStart.Stop();
                gameOver = true;
                GameOver();
            }

            //displays our player stats value on the form
            textAmmo.Text = ammoLevel.ToString();
            textKills.Text = annihilations.ToString();

            //if health is less than zero make bar red as warning
            if (health < 20)
            {
                progressHealth.ForeColor = Color.Red;
            }

            //affect speed of payer according to their direction
            if (keyleft && playerController.Left > 0)
            {
                playerController.Left -= movementSpeed;
            }

            if (keyright && playerController.Left + playerController.Width < 910)
            {
                playerController.Left += movementSpeed;
            }

            if (keyup && playerController.Top > 60)
            {
                playerController.Top -= movementSpeed;
            }

            if (keydown && playerController.Top + playerController.Height < 490)
            {
                playerController.Top += movementSpeed;
            }

            foreach (Control x in this.Controls)
            {
                //if the player runs over the ammo picture, they will pick it up (and the picture will dissapear), and their ammo level will increase
                if (x is PictureBox && x.Tag == "ammo")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(playerController.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)x)); // remove the ammo picture box
                        ((PictureBox)x).Dispose();
                        ammoLevel += 5;
                    }
                }

                //if our players bullet hits the frame of the form, the bullet will "dissapear"
                if (x is PictureBox && x.Tag == "bullet")
                {
                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930 || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }
                }

                //player-robot interaction
                if (x is PictureBox && x.Tag == "robot")
                {
                    //if the robot runs into the player, our health goes down and we get a red background to show injury
                    if (((PictureBox)x).Bounds.IntersectsWith(playerController.Bounds) && gameOver == false)
                    {
                        health -= 1;
                        playerController.BackColor = Color.Red;
                    }
                    else
                    {
                        playerController.BackColor = Color.Transparent;
                    }

                    //will allow the robots to move towards the player (just like the player keys above, it will change the robots direction and image)
                    if (((PictureBox)x).Left > playerController.Left)
                    {
                        ((PictureBox)x).Left -= robotSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rl;
                    }

                    if (((PictureBox)x).Top > playerController.Top)
                    {
                        ((PictureBox)x).Top -= robotSpeed;
                        ((PictureBox)x).Image = Properties.Resources.ru;
                    }

                    if (((PictureBox)x).Left < playerController.Left)
                    {
                        ((PictureBox)x).Left += robotSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rr;
                    }

                    if (((PictureBox)x).Top < playerController.Top)
                    {
                        ((PictureBox)x).Top += robotSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rd;
                    }
                }

                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "robot"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            // Up our kill streak
                            annihilations++;

                            // Remove the controls from the form and dispose of them
                            this.Controls.Remove(j);
                            j.Dispose();
                            this.Controls.Remove(x);
                            x.Dispose();

                            // Spawn more robots
                            spawnRobots();
                        }
                    }
                }

                //To prevent the robots from colliding with each other when they are side by side
                foreach (Control i in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "robot")
                    {
                        foreach (Control j in this.Controls)
                        {
                            if (i != j && j is PictureBox && j.Tag == "robot")
                            {
                                if (i.Bounds.IntersectsWith(j.Bounds))
                                {
                                    // Collision detected, now respond to the collision
                                    // For example, you can make the robots move in opposite directions:
                                    if (((PictureBox)i).Left < ((PictureBox)j).Left)
                                    {
                                        ((PictureBox)i).Left -= robotSpeed;
                                        ((PictureBox)i).Image = Properties.Resources.rl; // Robot moving left
                                        ((PictureBox)j).Left += robotSpeed;
                                        ((PictureBox)j).Image = Properties.Resources.rr; // Robot moving right
                                    }
                                    else
                                    {
                                        ((PictureBox)i).Left += robotSpeed;
                                        ((PictureBox)i).Image = Properties.Resources.rr; // Robot moving right
                                        ((PictureBox)j).Left -= robotSpeed;
                                        ((PictureBox)j).Image = Properties.Resources.rl; // Robot moving left
                                    }

                                    if (((PictureBox)i).Top < ((PictureBox)j).Top)
                                    {
                                        ((PictureBox)i).Top -= robotSpeed;
                                        ((PictureBox)i).Image = Properties.Resources.ru; // Robot moving up
                                        ((PictureBox)j).Top += robotSpeed;
                                        ((PictureBox)j).Image = Properties.Resources.rd; // Robot moving down
                                    }
                                    else
                                    {
                                        ((PictureBox)i).Top += robotSpeed;
                                        ((PictureBox)i).Image = Properties.Resources.rd; // Robot moving down
                                        ((PictureBox)j).Top -= robotSpeed;
                                        ((PictureBox)j).Image = Properties.Resources.ru; // Robot moving up
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //function needed to spawn more ammo during game
        private void spawnAmmo()
        {
            // Check if there are no ammo currently on screen
            if (!this.Controls.ContainsKey("ammo"))
            {
                //creates new PictureBox for ammo that will spawn randomly across screen
                PictureBox ammo = new PictureBox();
                ammo.BringToFront();
                ammo.Image = Properties.Resources.ammo;
                ammo.SizeMode = PictureBoxSizeMode.AutoSize;
                ammo.BackColor = Color.Transparent;
                ammo.Left = random.Next(10, 900);
                ammo.Top = random.Next(50, 480);
                ammo.Tag = "ammo";

                //adds the controls needed to pick it up and dispose of it above
                this.Controls.Add(ammo);
                playerController.BringToFront();
            }
        }

        //allows the player to shoot the robots in the direction it faces
        private void shootMain(string direction)
        {
            bullet shoot = new bullet();
            shoot.direction = direction;
            shoot.bulletLeft = playerController.Left + (playerController.Width / 2);
            shoot.bulletTop = playerController.Top + (playerController.Height / 2);
            shoot.spawnBullets(this);
        }

        //spawns robots
        private void spawnRobots()
        {
            PictureBox robots = new PictureBox();
            robots.Tag = "robot";
            robots.Image = Properties.Resources.rl;
            robots.Left = random.Next(0, 900);
            robots.Top = random.Next(0, 800);
            robots.SizeMode = PictureBoxSizeMode.AutoSize;
            robots.BackColor = Color.Transparent;
            this.Controls.Add(robots);
            playerController.BringToFront();
            robots.BringToFront();
        }

        
    }
}
