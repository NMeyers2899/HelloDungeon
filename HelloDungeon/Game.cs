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
            Console.WriteLine("A man approaches you, a monkey sits happily on his shoulder. As they get closer, they stop suddenly.\n Despite the hood over their face, shielding their eyes, it is clear that they are staring at you." +
                " For\n a moment, you stand there. Staring at the hooded figure. The monkey stands up, and puts a fist\n to its mouth. 'Ahem!' it coughs. 'I require you to solve my riddle! If you do, I'll grant you\n" +
                " something few can ever hope to acquire.' It isn't every day that you come across monkeys giving\n riddles, so you accept the offer. 'However, you have only a few attempts. Four to be exact." +
                " If\n you cannot solve it in those attempts, you lose. And do not get your reward.'");

            int attempts = 4;
            for (int i = 0; i < 4; i++)
            {
                int attemptsRemaining = attempts - i;
                Console.WriteLine("You have " + attemptsRemaining + " attempts left.");
                Console.Write("What is under this cloak?\n > ");
                playerChoice = Console.ReadLine().ToLower();
                if (playerChoice == "goblin")
                {
                    Console.WriteLine("The monkey lets out a loud shriek of a laugh, falling onto its back and rolling around. 'Oh,\n what a good guess! I suppose its time for your reward. Sick 'em!' The cloak is pulled" +
                        " back,\n revealing a green goblin beneath wielding a hatchet. It lets out a roar, and rushes in to fight you.");
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
                    Console.WriteLine("The monkey laughs, pointing at you as it does so. 'Oh you fool! You failed at such a simple task.\n Oh well, time to die!' The hooded figure pulls back their veil to reveal" +
                    " they're a goblin. It\n rushes at you, roaring its battle cry!");
                    ClearScreen();
                }
            }

            
            // Starts the battle.
            Console.WriteLine("You come across a small goblin. It readies it's weapon to attack!");
            Console.WriteLine("Battle Start!");

            // Initializes Goblin Stats
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
                    Console.WriteLine("You feel refreshed!\n You recovered " + (maxPlayerHealth - playerHealth) + " health and " + (maxPlayerSkillPoints - playerSkillPoints) + " skill points!");
                    ClearScreen();
                    Console.WriteLine("You stand from your makeshift campsite, prepared to face the challenge ahead. You look back to your fallen foe, only to recoil as the body seems\n to have vanished!" +
                        " What remains is a small puddle of goo.\n Refreshed, but now slightly unsettled, you make your way into the cave.");
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
        /// Runs through combat whenever the player encounters an enemy.
        /// </summary>
        void DoCombat()
        {
            bool validInputRecieved = false;
            while (playerHealth > 0 && enemyHealth > 0)
            {
                while (validInputRecieved == false)
                {
                    choice = GetInput("What will you do?", "Attack", "Skills");
                    if (choice == 1)
                    {
                        Console.WriteLine("You take a swing at the foe with your weapon!");
                        enemyHealth -= DealDamage(playerPower, enemyDefense);
                        Console.WriteLine("Foe takes " + DealDamage(playerPower, enemyDefense) + " damage!");
                        ClearScreen();
                        validInputRecieved = true;
                    }
                    else if (choice == 2 && knowsFireBall)
                    {
                        choice = GetInput("What will you use?", "Fireball", "Back");
                        if (choice == 1)
                        {
                            if (playerSkillPoints >= 2)
                            {
                                playerSkillPoints -= 2;
                                Console.WriteLine("You thrust your palm forward, a sphere of fire rockets out towards the\n foe, engulfing them in its flame.");
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
                        else if (choice == 2)
                        {
                            validInputRecieved = true;
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

                if (enemySkillPoints > 0)
                {
                    enemySkillPoints--;
                    Console.WriteLine();
                }
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
                InitializeStats();

                ClearScreen();

                Encounter1And2();

                if(playerHealth <= 0)
                {
                    playerContinues = false;
                    break;
                }

                Encounter3();

                choice = GetInput("Would you like to replay?", "Yes", "No");
                if (choice == 1)
                {
                    ClearScreen();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Thank you for playing");
                    playerContinues = false;
                }
            }
        }
    }
}
