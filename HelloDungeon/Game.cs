using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Game
    {
        // Initialize Player Stats
        int maxPlayerHealth = 5;
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
        int maxEnemyHealth = 0;
        int enemyHealth = 0;
        int enemySkillPoints = 0;
        int enemyPower = 0;
        int enemyDefense = 0;
        int enemyMagicPower = 0;
        int enemyMagicDefense = 0;
        string enemyName = "None";

        // Clears the screen of text to keep out clutter.
        void ClearScreen()
        {
            Console.WriteLine("Please press ENTER to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        // Finds the difference between power and defense in order to change the target's health.
        int DealDamage(int unitPower, int targetDefense)
        {
            if((unitPower - targetDefense) >= 0){
                return unitPower - targetDefense;
            }
            else
            {
                return 0;
            }
        }

        // Runs through combat whenever the player encounters an enemy.
        void DoCombat()
        {
            bool validInputRecieved = false;
            string playerChoice = "Nothing";
            while (playerHealth > 0 && enemyHealth > 0)
            {
                while (validInputRecieved == false)
                {
                    Console.Write("What will you do?\n 1. Attack\n 2. Skills\n 3. Inspect\n > ");
                    playerChoice = Console.ReadLine().ToLower();
                    if (playerChoice == "1" || playerChoice == "attack")
                    {
                        Console.WriteLine("You take a swing at the foe with your weapon!");
                        enemyHealth -= DealDamage(playerPower, enemyDefense);
                        Console.WriteLine("Foe takes " + DealDamage(playerPower, enemyDefense) + " damage!");
                        ClearScreen();
                        validInputRecieved = true;
                    }
                    else if (playerChoice == "2" || playerChoice == "skills")
                    {
                        if (knowsFireBall)
                        {
                            bool validActionInputRecieved = false;
                            while (validActionInputRecieved == false)
                            {
                                Console.Write("Choose a skill.\n 1. Fireball\n 2. Back\n > ");
                                playerChoice = Console.ReadLine().ToLower();
                                if (playerChoice == "1" || playerChoice == "fireball")
                                {
                                    playerSkillPoints -= 2;
                                    Console.WriteLine("You thrust your palm forward, a sphere of fire rockets out towards the\n foe, engulfing them in its flame.");
                                    enemyHealth -= DealDamage(playerMagicPower, enemyMagicDefense);
                                    Console.WriteLine("Foe takes " + DealDamage(playerMagicPower, enemyMagicDefense) + " damage!");
                                    ClearScreen();
                                    validActionInputRecieved = true;
                                }
                                else if (playerChoice == "2" || playerChoice == "back")
                                {
                                    validActionInputRecieved = true;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid input.");
                                }
                            }
                        }
                    }
                    else if (playerChoice == "3" || playerChoice == "inspect")
                    {
                        Console.WriteLine("The enemy before you seems feeble and weak, but ready to attack.\n");
                        ClearScreen();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input.");
                    }
                }
                validInputRecieved = false;
            }

            if (enemyHealth <= 0)
            {
                Console.WriteLine("The enemy is dead, you win!");
            }
            else if (playerHealth <= 0)
            {
                Console.WriteLine("You are dead. Game Over.");
            }
        }
        public void Run()
        {
            // Sets up an input checker for choices in the future.
            bool validInputRecieved = false;

            // Player Chooses Starting Name and Job
            Console.Write("What is your name?\n" + "> ");
            playerName = Console.ReadLine();
            while (validInputRecieved == false)
            {
                Console.Write("Welcome " + playerName + "! Now, pick a job.\n 1. Fighter\n 2. Caster\n> ");
                playerChoice = Console.ReadLine().ToLower();

                // Looks at the choice the player makes.
                if (playerChoice == "1" || playerChoice == "fighter")
                {
                    playerHealth = 10;
                    playerSkillPoints = 3;
                    playerPower = 5;
                    playerDefense = 3;
                    playerMagicPower = 1;
                    playerMagicDefense = 2;
                    playerJob = "Fighter";
                    validInputRecieved = true;
                }
                else if (playerChoice == "2" || playerChoice == "caster")
                {
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
                else if (playerChoice == "3" || playerChoice == "adventurer")
                {
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
            Console.WriteLine("Your stats are as follows :\n" + "Health : " + playerHealth + "\n" + "Power : " + playerPower + "\n" +
                "Skill Points : " + playerSkillPoints + "\n" + "Defense : " + playerDefense + "\n" + "Magic Power : " + playerMagicPower + "\n" +
                "Magic Defense : " + playerMagicDefense);

            ClearScreen();

            Console.WriteLine("A man approaches you, a monkey sits happily on his shoulder. As they get closer, they stop suddenly.\n Despite the hood over their face, shielding their eyes, it is clear that they are staring at you." +
                " For\n a moment, you stand there. Staring at the hooded figure. The monkey stands up, and puts a fist\n to its mouth. 'Ahem!' it coughs. 'I require you to solve my riddle! If you do, I'll grant you\n" +
                " something few can ever hope to acquire.' It isn't every day that you come across monkeys giving\n riddles, so you accept the offer. 'However, you have only a few attempts. Four to be exact." +
                " If\n you cannot solve it in those attempts, you lose. And do not get your reward.'");

            int attempts = 4;
            for(int i = 0; i < 4; i++)
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
                else if(attemptsRemaining > 1)
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
            maxEnemyHealth = 3;
            enemyHealth = 3;
            enemyPower = 2;
            enemyDefense = 2;
            enemyMagicPower = 0;
            enemyMagicDefense = 1;
            enemyName = "Goblin";

            DoCombat();
        }
    }
}
