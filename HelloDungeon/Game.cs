using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Game
    {
        // Initialize Player Stats
        int maxPlayerHealth = 5;
        int maxPlayerSkillPoints = 2;
        int playerHealth = 5;
        int playerSkillPoints = 2;
        int playerPower = 3;
        int playerDefense = 1;
        int playerMagicPower = 2;
        int playerMagicDefense = 0;
        string playerJob = "Adventurer";
        string playerName = "None";
        string playerChoice = "None";

        // Initializes Player Skills
        bool knowsFireBall = false;

        // Initializes Enemy Stats
        int enemyHealth = 0;
        int enemySkillPoints = 0;
        int enemyPower = 0;
        int enemyDefense = 0;
        int enemyMagicPower = 0;
        int enemyMagicDefense = 0;

        // Initializes options of choices.
        bool validInputRecieved = false;
        int choice = 0;

        /// <summary>
        /// Clears the screen of text to keep out clutter and to allow the player to read the current information displayed on the screen.
        /// </summary>
        void ClearScreen()
        {
            Console.WriteLine("Please press ENTER to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Finds the difference between power and defense in order to change the target's health.
        /// </summary>
        /// <param name="unitPower"> The attacker's power or magic power. </param>
        /// <param name="targetDefense"> The target's defense or magic defense. </param>
        /// <returns></returns>
        int DealDamage(int unitPower, int targetDefense)
        {
            if ((unitPower - targetDefense) >= 0) {
                return unitPower - targetDefense;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Lets the player choose their name and class. Then it sets their stats accordingly, displaying it to the player.
        /// </summary>
        void InitializeStats()
        {
            // Player Chooses Starting Name and Job
            Console.Write("What is your name?\n" + "> ");
            playerName = Console.ReadLine();
            while (validInputRecieved == false)
            {
                choice = GetInput("Now, pick a job", "Fighter", "Caster");

                // Looks at the choice the player makes and sets their stats accordingly.
                if (choice == 1)
                {
                    maxPlayerHealth = 10;
                    playerHealth = 10;
                    playerPower = 5;
                    playerDefense = 3;
                    playerMagicDefense = 2;
                    playerJob = "Fighter";
                    validInputRecieved = true;
                }
                else if (choice == 2)
                {
                    maxPlayerHealth = 8;
                    maxPlayerSkillPoints = 6;
                    playerHealth = 8;
                    playerSkillPoints = 6;
                    playerPower = 2;
                    playerDefense = 2;
                    playerMagicPower = 4;
                    playerMagicDefense = 3;
                    knowsFireBall = true;
                    playerJob = "Caster";
                    validInputRecieved = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid answer.");
                }
            }

            // Resets input checker for future choices.
            validInputRecieved = false;

            Console.WriteLine("Welcome to the world " + playerName + " the " + playerJob + "!");
            Console.WriteLine("Your stats are as follows\n" + "Health : " + playerHealth + "\n" + "Power : " + playerPower + "\n" +
                "Skill Points : " + playerSkillPoints + "\n" + "Defense : " + playerDefense + "\n" + "Magic Power : " + playerMagicPower + "\n" +
                "Magic Defense : " + playerMagicDefense);

            ClearScreen();
        }

        /// <summary>
        /// Gets the user's input by giving them a description of the choice and both possible options.
        /// </summary>
        /// <param name="description"> The description of the choice. </param>
        /// <param name="option1"> The first option the player may choose. </param>
        /// <param name="option2"> The second option the player may choose. </param>
        /// <returns></returns>
        int GetInput(string description, string option1, string option2)
        {
            int input = 0;
            string inputRecieved = "None";

            // Asks the user for an input.
            Console.Write(description + "\n1. " + option1 + "\n2. " + option2 + "\n> ");
            inputRecieved = Console.ReadLine().ToLower();
            if (inputRecieved == "1" || inputRecieved == option1.ToLower())
            {
                input = 1;
            }
            else if (inputRecieved == "2" || inputRecieved == option2.ToLower())
            {
                input = 2;
            }

            return input;
        }

        /// <summary>
        /// Sends the player into the riddle encounter and to fight the goblin shortly after.
        /// </summary>
        void Encounter1And2()
        {

            // This is the beginning of the riddle encounter.
            Console.WriteLine("A man approaches you, a monkey sits happily on his shoulder. As they get closer, they stop suddenly. \nDespite the hood over their face, shielding their eyes, it is clear that they are staring at you." +
                " For \na moment, you stand there. Staring at the hooded figure. The monkey stands up, and puts a fist \nto its mouth. 'Ahem!' it coughs. 'I require you to solve my riddle! If you do, I'll grant you \n" +
                "something few can ever hope to acquire.' It isn't every day that you come across monkeys giving \nriddles, so you accept the offer. 'However, you have only a few attempts. Four to be exact." +
                " If \nyou cannot solve it in those attempts, you lose. And do not get your reward.'");

            // This checks the number of attempts left and tells the user how many are left.
            int attempts = 4;
            for (int i = 0; i < 4; i++)
            {
                int attemptsRemaining = attempts - i;
                Console.WriteLine("You have " + attemptsRemaining + " attempts left.");
                Console.Write("What is under this cloak?\n > ");
                playerChoice = Console.ReadLine().ToLower();
                if (playerChoice == "goblin")
                {
                    Console.WriteLine("The monkey lets out a loud shriek of a laugh, falling onto its back and rolling around. 'Oh, \nwhat a good guess! I suppose its time for your reward. Sick 'em!' The cloak is pulled" +
                        " back, \nrevealing a green goblin beneath wielding a hatchet. It lets out a roar, and rushes in to fight you.");
                    ClearScreen();
                    break;
                }
                else if (attemptsRemaining > 1)
                {
                    Console.WriteLine("The monkey simply shakes its furry little head. 'I'm afraid not, wanderer. Try again.' It grins at you.");
                    ClearScreen();
                }
                else
                {
                    Console.WriteLine("The monkey laughs, pointing at you as it does so. 'Oh you fool! You failed at such a simple task. \nOh well, time to die!' The hooded figure pulls back their veil to reveal" +
                    " they're a goblin. It \nrushes at you, roaring its battle cry!");
                    ClearScreen();
                }
            }

            
            // Starts the first battle.
            Console.WriteLine("You come across a small goblin. It readies it's weapon to attack!");
            Console.WriteLine("Battle Start!");

            // Initializes the Goblins' stats
            enemyHealth = 6;
            enemyPower = 4;
            enemyDefense = 2;
            enemyMagicDefense = 1;

            DoCombat();
        }

        /// <summary>
        /// This encounter allows the player to regain their stats before the final battle.
        /// </summary>
        void Encounter3()
        {
            Console.WriteLine("You stand tall, the goblin fallen before you. The monkey is seen, skittering towards the entrance of a cave.");
            while (validInputRecieved == false)
            {

                // Gives the player the choice to run into the cave, or take a chance to heal.
                choice = GetInput("Will you-", "Run into the cave!", "Wait and rest.");
                if (choice == 1)
                {
                    Console.WriteLine("You run into the cave after the monkey!");
                    ClearScreen();
                    validInputRecieved = true;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("You find no reason to rush. After all, there's probably not another exit to that cave. So you sit and rest.");
                    ClearScreen();

                    Console.WriteLine("You feel refreshed! \nYou recovered " + (maxPlayerHealth - playerHealth) + " health and " + (maxPlayerSkillPoints - playerSkillPoints) + " skill points!");
                    playerHealth = maxPlayerHealth;
                    playerSkillPoints = maxPlayerSkillPoints;
                    ClearScreen();

                    Console.WriteLine("You stand from your makeshift campsite, prepared to face the challenge ahead. \nYou look back to your fallen foe, only to recoil as the body seems to have \nvanished!" +
                        " What remains is a small puddle of something viscous. Refreshed, \nbut now slightly unsettled, you make your way into the cave.");
                    ClearScreen();
                    validInputRecieved = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
            validInputRecieved = false;
        }

        /// <summary>
        /// The player faces off against the monkey and gets to the end of the game.
        /// </summary>
        void Encounter4()
        {
            Console.WriteLine("As you enter the cave, you notice it is well lit. Torches line the walls, close \nenough to keep shadows at bay. The distinct sound of footsteps fills the natural \nhallway" +
                " as you step down into the unknown. As you approach the end of the tunnel, \nthe sounds of laughter echo through the hall. The laughter of that monkey. The \npath opens up considerably" +
                " as you reach the end, into a large makeshift room.");
            ClearScreen();
            Console.WriteLine("The monkey stands high on a pile of boxes, screeching orders to a band of goblins. \nThe monkey spots you, looking up and smiling. 'Ah, you finally made it.' It says, \n" +
                "adjusting its hat. 'You're just in time, my ascension is nigh!' It raises its arms \nup to the ceiling and the ground begins to rumble. After a few moments, the monkey begins to " +
                "grow. \nSimply bigger at first, but then something changes.");
            ClearScreen();
            Console.WriteLine("The monkey's flesh begins to morph, \nas large, discolored tumors sprout from its back. It crys out, the growths changing the creature's form \ninto something monstrous. " +
                "Something snuffs out the torches closest to it, keeping the \nmonkey's transformation hidden in shadow. The screams are clearly no longer that of something \nfrom this world. The goblin's" +
                " attempt to run as tendrils rip through the darkness and impale \nthe goblins on them. The tendrils retreat with their prey." + " 'Oh gods, why!' The now distorted, \nmonstrous voice" +
                " of the monkey crys out. The tendrils emerge, ready to strike at you.\n");
            Console.WriteLine("Battle Start!");

            ClearScreen();

            // Initalizes the Monkeys'? stats.
            enemyHealth = 9;
            enemySkillPoints = 3;
            enemyPower = 5;
            enemyDefense = 3;
            enemyMagicPower = 4;
            enemyMagicDefense = 1;

            DoCombat();

            if(playerHealth <= 0)
            {
                return;
            }


            // End of final encounter.
            Console.WriteLine("You still stand, though barely. The tendrils are relentless and the form \nyou face is inconcievable to your mind. And the screams, dear gods the screams.");
            ClearScreen();
            Console.WriteLine("Out of options, you swing at the beast wildly. Hitting the monstrous form with \nyour weapon. The futility of it is obvious, but you try anyway.");
            ClearScreen();
            Console.WriteLine("The screams begin to die down and the tendrils begin to fade back into nothing. \nThe form emerges from the shadows once more and a face forms, still \nshifting but for a moment" +
                " you can clearly make it out. The face is anguished, \nbut it soon too dissolves into shadows. The torches light back up, and the \ncreature is gone. The screams, echo in your ear. Though," +
                " whether they're \nstill there or just your imagination, it's hard to tell.");
            ClearScreen();
            Console.WriteLine("A voice suddenly starts up behind you. 'Punished for its hubris by those it sought \nto steal power from. How fitting.' You turn, as a form in a cloak walks towards you." +
                " \nYou raise your weapon, though the figure simply waves the attempt aside with a gloved \nhand. 'I am not here to fight you, just to admire your work.' True to their word, they \nscan the room." +
                " No sign of the beast, the goblins, or anything they could have left behind \ncan be seen. 'You did wonderful indeed, " + playerName + ".' As if they knew how you would react, they \nface you." +
                " All that is visible know is a row of perfectly straight, perfectly white teeth, \nstaring at you from beneath the hood. 'Good work indeed.' They walk off, leaving you in \nthe quiet cave alone.");
            ClearScreen();
        }

        /// <summary>
        /// Runs through combat whenever the player encounters an enemy.
        /// </summary>
        void DoCombat()
        {
            bool validInputRecieved = false;

            // Checks to see if either the player or the enemy is dead. If either are, combat cannot occur.
            while (playerHealth > 0 && enemyHealth > 0)
            {
                while (validInputRecieved == false)
                {

                    // Gives the player a choice of either a physical or magic attack.
                    choice = GetInput("What will you do?", "Attack", "Magic");
                    if (choice == 1)
                    {
                        Console.WriteLine("You take a swing at the foe with your weapon!");
                        enemyHealth -= DealDamage(playerPower, enemyDefense);
                        Console.WriteLine("Foe takes " + DealDamage(playerPower, enemyDefense) + " damage!");
                        ClearScreen();
                        validInputRecieved = true;
                    }

                    // Checks to see if the player knows fireball, if they do not, the skill cannot be used.
                    else if (choice == 2 && knowsFireBall)
                    {

                        // Checks to see if the player has enough skill points to use fireball. If they don't, it lets them know.
                        if (playerSkillPoints >= 2)
                        {
                            playerSkillPoints -= 2;
                            Console.WriteLine("You thrust your palm forward, a sphere of fire rockets out towards the \nfoe, engulfing them in its flame.");
                            enemyHealth -= DealDamage(playerMagicPower, enemyMagicDefense);
                            Console.WriteLine("Foe takes " + DealDamage(playerMagicPower, enemyMagicDefense) + " damage!");
                            ClearScreen();
                            validInputRecieved = true;
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough Skill Points to use that.");
                            ClearScreen();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input.");
                    }
                }
                validInputRecieved = false;

                // Checks if the enemy is dead.
                if (enemyHealth <= 0)
                {
                    Console.WriteLine("The enemy is dead, you win!");
                    break;
                }

                // Checks to see if the enemy has skill points to do a special attack.
                if (enemySkillPoints > 0)
                {
                    enemySkillPoints--;
                    Console.WriteLine("From the darkness, something emerges. The form shifts, assualting your mind with its presence.");
                    playerHealth -= DealDamage(enemyMagicPower, playerMagicDefense);
                    Console.WriteLine("You take " + DealDamage(enemyMagicPower, playerMagicDefense) + " damage!");
                    ClearScreen();
                }

                // Enemy's physical attack.
                else
                {
                    Console.WriteLine("The foe lashes out!");
                    playerHealth -= DealDamage(enemyPower, playerDefense);
                    Console.WriteLine("You take " + DealDamage(enemyPower, playerDefense) + " damage!");
                    ClearScreen();
                }

                //Checks if the player is dead.
                if (playerHealth <= 0)
                {
                    Console.WriteLine("You are dead. Game Over.");
                }
            }
        }
    
        public void Run()
        {
            bool playerContinues = true;
            while (playerContinues)
            {
                // Start of the game.
                InitializeStats();

                Encounter1And2();

                // Checks to see if the player is alive befrore running through the rest of the game.
                if (playerHealth > 0)
                {
                    Encounter3();

                    Encounter4();
                }

                // At the end of the game, it checks to see if the player wishes to play again.
                while (validInputRecieved == false)
                {
                    choice = GetInput("Would you like to play again?", "Yes", "No");
                    if (choice == 1)
                    {
                        ClearScreen();
                        validInputRecieved = true;
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Thank you for playing!");
                        validInputRecieved = true;
                        playerContinues = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input.");
                    }
                }
            }
        }
    }
}
