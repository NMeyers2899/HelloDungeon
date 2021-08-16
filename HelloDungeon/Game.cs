using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Game
    {
        public void Run()
        {
            // Health Exercise : Initializes health and healthRegen, then adds one to the other and prints it out.
            //int healthRegen = 50;
            //int health = 100;
            //health += healthRegen;
            //Console.WriteLine(health);

            // Name Exercise : Initializes the name, asks the user to enter their name and prints it out with a nice greeting.
            //string name = "Empty";
            //Console.Write("Please enter your name : ");
            //name = Console.ReadLine();
            //Console.WriteLine("Hello " + name + "!");

            // Initializes all player stats.
            string playerName = "No Name";
            float maxPlayerHealth = 10.0f;
            float currentPlayerHealth = maxPlayerHealth;
            int playerGold = 0;
            float playerPower = 3.0f;
            float playerArmor = 1.0f;
            bool isGameOver = false;
            string playerChoice = "Nothing";

            // Initializes all enemy stats.
            string enemyName = "No Name";
            float maxEnemyHealth = 1.0f;
            float currentEnemyHealth = maxEnemyHealth;
            float enemyPower = 1.0f;
            float enemyArmor = 1.0f;

            // Initializes how damage is dealt and taken.
            float playerDamageDealt = (playerPower - enemyArmor);
            float enemyDamageDealt = (enemyPower - enemyArmor);


            // Begins the game, and gives a description of the setting.
            Console.WriteLine("The Dawnlow Mountains tower above you, reaching up far beyond into the sky. The valley you find yourself \n in is covered in the shadows of the great " +
                "peaks. The snow crunches beneath your feet as you make your way towards \n Arden's Cross, a town found at the foot of the mountain. The sight of the fires of torches" +
                " burning around the outer \n walls brings a sense of excitement to your wander-weary mind, carrying you the rest of the way to the gates.");
            Console.Write("''old it!' The voice brings you back to your senses, no longer lost in thoughts. In front of you stands two \n fairly large guards, covered " +
                "in garb with the crest of Arden's Cross on it. 'oo might you be?' One of the guards says, his accent thick and his voice scruffy. Please enter a name : ");
            playerName = Console.ReadLine();
            Console.WriteLine("'Right den " + playerName + " yer free to go in. But don't let me 'ere ya cause any trouble.' The guard says, motioning for you to \n move inside" +
                " the gates.");
            Console.WriteLine("The town itself is as the valley surrounding it, cold and quiet. Even the town square, which you enter soon after \n passing the gates, is" +
                " filled with the sounds of feet shuffling in the snow and small whispers as others pass one \n another on the street.");
            Console.Write("There are a few local areas you can enter. A tavern at the end of the square, the faint sound of music coming from withing. The only other building" +
                " that would seem to welcome you is a small shop close to you, the name on the sign reads 'General'. Where would you like to go?");
            playerChoice = Console.ReadLine();

            // The choice between the tavern and the shop.
            if(playerChoice == "tavern" || playerChoice == "Tavern")
            {

            }
            else if (playerChoice == "shop" || playerChoice == "Shop")
            {

            }
        }
    }
}
