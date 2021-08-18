using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Game
    {
        public void Run()
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
            bool isPlayerAlive = true;

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

            // Sets Damage Dealing
            int playerPhysicalAttack = playerPower - enemyDefense;
            int enemyPhysicalAttack = enemyPower - enemyDefense;
            int playerMagicAttack = playerMagicPower - enemyMagicDefense;
            int enemyMagicAttack = enemyMagicPower - playerMagicDefense;

            // Player Chooses Starting Name and Job
            Console.Write("What is your name?\n" + "> ");
            playerName = Console.ReadLine();
            Console.Write("Welcome " + playerName + "! Now, pick a job.\n" + "1. Fighter\n" + "2. Caster\n" + "> ");
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
            }
            else if (playerChoice == "2" || playerChoice == "caster")
            {
                playerHealth = 8;
                playerSkillPoints = 5;
                playerPower = 2;
                playerDefense = 2;
                playerMagicPower = 4;
                playerMagicDefense = 3;
                knowsFireBall = true;
                playerJob = "Caster";
            }
            else
            {
                Console.WriteLine("You chose Adventurer.");
            }

            Console.WriteLine("Welcome to the world " + playerName + " the " + playerJob + "!");
            Console.Write("Your stats are as follows :\n" + "Health : " + playerHealth + "\n" + "Power : " + playerPower + "\n" +
                "Skill Points : " + playerSkillPoints + "\n" + "Defense : " + playerDefense + "\n" + "Magic Power : " + playerMagicPower + "\n" +
                "Magic Defense : " + playerMagicDefense);

            Console.WriteLine();

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

            // Gives the player their first prompt.
            Console.Write("You get the first swing, what will you do?\n" + "1. Attack\n" + "2. Skill\n" + "3. Inspect\n" + "> ");
            playerChoice = Console.ReadLine().ToLower();

            if (playerChoice == "1" || playerChoice == "attack")
            {
                Console.WriteLine("You swing your weapon!");
                enemyHealth -= playerPhysicalAttack;
                Console.WriteLine("Goblin takes " + playerPhysicalAttack + " damage!");
                Console.ReadKey();
            }
            else if (playerChoice == "2" || playerChoice == "skill")
            {
                if (knowsFireBall)
                {
                    Console.Write("Choose a skill to use.\n" + "1. Fireball\n" + "> ");
                    playerChoice = Console.ReadLine().ToLower();
                    
                    if(playerChoice == "1" || playerChoice == "fireball")
                    {
                        Console.WriteLine("You hold up your hand, and conjure a flaming sphere in your palm. The sphere is thrust forth, rocketing towards\n the goblin!");
                        enemyHealth -= playerMagicAttack;
                        Console.WriteLine("Goblin takes " + playerMagicAttack + " damage!");
                    }
                    else
                    {
                        Console.WriteLine("That is not an option, so you swing your weapon!");
                        enemyHealth -= playerPhysicalAttack;
                        Console.WriteLine("Goblin takes " + playerPhysicalAttack + " damage!");
                    }
                }
                else
                {
                    Console.WriteLine("You don't know any skills. And instead swing your weapon!");
                    enemyHealth -= playerPhysicalAttack;
                    Console.WriteLine("Goblin takes " + playerPhysicalAttack + " damage!");
                }
            }
            else if (playerChoice == "3" || playerChoice == "inspect")
            {
                Console.WriteLine("The goblin seems feeble and weak, though it stands ready to strike.");
            }

            if(enemyHealth <= 0)
            {
                Console.WriteLine("Goblin is dead! Congrats, you win!");
            }
        }
    }
}
