// Yasser Meza
//ITCS 3112-051
//Feb 5 2019
//Assignment 1

using System;

namespace CRAPS
{

    class Craps
    {

        static void Main(string[] args)
        {
            //Initializing all variables and the random number generator
            Random random = new Random();
            int D1 = random.Next(1, 7);
            int D2 = random.Next(1, 7);
            int sum = 0;
            int intWager = 0;
            int chips = 100;                 // all players start with 100 chips at begining of game
            string wager = null;
            int point = 0;
            string playStatus = null;
            int keepPlaying = 0;


            //Game output beings 
            Console.WriteLine("Welcome to Craps!");
            Console.WriteLine("Are you ready to play? Y or N?");
            playStatus = Console.ReadLine();

            //Player chooses yes allowing the script to loop

            if (playStatus == "y" || playStatus == "Y")
            {
                Console.WriteLine("You have 100 chips.");
                keepPlaying = 1;
                //keepPlaying set to 1 allows script to loop and game to begin
            }
            else if (playStatus == "n" || playStatus == "N")
            {
                //player may choose to back out of game 
                //and leave with the 100 starting coins
                keepPlaying = 0;
            }

            //loop begins here and ends when player decides to stop playing
            while (keepPlaying == 1)
            {

                //player chooses how much to bet
                Console.WriteLine("How much is your wager?");
                wager = Console.ReadLine();

                intWager = Convert.ToInt32(wager); //easier to manage the wager in an int type

                Console.WriteLine("");
                Console.WriteLine("Your wager is {0}", intWager);



                Console.WriteLine("Rolling Dice...");

                //two seprate die are rolled allowing for higher probablity
                D1 = random.Next(1, 7);
                D2 = random.Next(1, 7);
                sum = D1 + D2; //die are summed up

                Console.WriteLine("Your dice rolls are {0} and {1}", D1, D2);

                //first stage of the game:
                //7 and 11 are automatic wins for the player
                if (sum == 7 || sum == 11) 
                {
                    Console.WriteLine("You rolled a {0} !", sum);
                    Console.WriteLine("Congratulations you win!");
                    Console.WriteLine("7 and 11 first rolls are automatic wins!");
                    Console.WriteLine("This was your wager: {0}", intWager);
                    intWager = intWager * 2; //wager is doubled as winnings
                    Console.WriteLine("Here are your winnings: {0}", intWager);

                    //total chips in players possesion after win
                    chips = chips + intWager;
                    Console.WriteLine("Total chips: {0}", chips);

                    Console.WriteLine("");

                    //Asking player to continue if they wish so that the keepPlaying loop continues to run or end
                    Console.WriteLine("You're on a roll! Play again? Y or N?");
                    playStatus = Console.ReadLine();

                    Console.WriteLine("");

                        if (playStatus == "y" || playStatus == "Y")
                        {
                            keepPlaying = 1;
                        }
                        else if (playStatus == "n" || playStatus == "N")
                        {
                             keepPlaying = 0;
                        }

                }

                //first stage of the game:
                // 2, 3, 12 are automatic losses
                else if (sum == 2 || sum == 3 || sum == 12)
                {
                    Console.WriteLine("You rolled a {0} !", sum);
                    Console.WriteLine("First roll cannot be 2,3, or 12. You lose.");
                    Console.WriteLine("Wager lost: {0} ", wager);
                    chips = chips - intWager; //subtracting wager over total chips on hand
                    Console.WriteLine("Total chips: {0}", chips);

                    //player cannot keep playing if chips equal to 0 or less
                    //this if statement stops the keepPlaying loop if
                    //player loses all their chips
                    if (chips > 0)
                    {
                        //with enough chips, player can decide to continue playing or not
                        Console.WriteLine("Play again? Y or N?");
                        playStatus = Console.ReadLine();

                        if (playStatus == "y" || playStatus == "Y")
                        {
                            keepPlaying = 1;
                        }
                        else if (playStatus == "n" || playStatus == "N")
                        {
                            keepPlaying = 0;
                        }
                    }
                    else
                    {
                        //player cannot decide to continue if all chips are zero
                        //script ends to out put at bottom of script
                        keepPlaying = 0;
                    }
                }
                //first stage of the game:
                //if the player neither loses or wins automatically
                //game continues to second stage: 
                else
                {
                    //set point to sum for comparing
                    point = sum;
                    Console.WriteLine("Your point: {0}", point);
                    //player will now roll begin to roll continously until they
                    //a) roll the same sum/point needed again
                    //b) roll a 7 to lose
                    Console.WriteLine("Press enter to roll for your point.");
                    Console.ReadLine();

                    int needPoint = 1; //next stage of game begins. 
                                       //player requires point or loss for needPoint loop to end

                    while (needPoint == 1)
                    {
                        //players subsequent rolls are
                        //randomized again
                        D1 = random.Next(1, 7);
                        D2 = random.Next(1, 7);
                        sum = D1 + D2;


                        //second stage of the game:
                        //player rolls must match sum for win
                        if (point == sum)
                        {
                            Console.WriteLine("You rolled a {0} !", sum);
                            Console.WriteLine("Your point: {0}", point);
                            Console.WriteLine("Congratulations you won!");
                            Console.WriteLine("This was your wager: {0}", intWager);
                            intWager = intWager * 2; //same as before, wager is doubled for winnings
                            Console.WriteLine("Here are your winnings: {0}", intWager);

                            chips = chips + intWager;
                            Console.WriteLine("Total chips: {0}", chips);

                            Console.WriteLine("");

                            //player continues to choose for replay maintainted in first stage
                            //keepPlaying loop
                            Console.WriteLine("Play again? Y or N?");
                            playStatus = Console.ReadLine();

                            if (playStatus == "y" || playStatus == "Y")
                            {
                                keepPlaying = 1;
                            }
                            else if (playStatus == "n" || playStatus == "N")
                            {
                                keepPlaying = 0;
                            }

                            //second stage needPoint loop stops. Current game was won.
                            needPoint = 0;
                        }

                        //second stage of game:
                        //7 roll is a loss for player
                        else if (sum == 7)
                        {
                            Console.WriteLine("You rolled a {0} !", sum);
                            Console.WriteLine("Your point: {0}", point);
                            Console.WriteLine("7's don't win here.");
                            Console.WriteLine("Wager lost: {0} ", wager);
                            chips = chips - intWager;// wager subtrated from running total of chips
                            Console.WriteLine("Chips left: {0}", chips);


                            Console.WriteLine("");

                            //player cannot keep playing if chips equal to 0 or less
                            //this if statement stops the keepPlaying loop if
                            //player loses all their chips                            
                            if (chips > 0)
                            {
                                //with enough chips, player can decide to continue playing or not

                                needPoint = 0;//current game still ends due to loss, end needPoint loop

                                Console.WriteLine("Play again? Y or N?");
                                playStatus = Console.ReadLine();


                                if (playStatus == "y" || playStatus == "Y")
                                {
                                    keepPlaying = 1;
                                    Console.WriteLine("");

                                }
                                else if (playStatus == "n" || playStatus == "N")
                                {
                                    keepPlaying = 0;
                                    Console.WriteLine("");

                                }

                            }
                            else
                            {
                                //player cannot decide to continue if all chips are zero
                                //script ends to output at bottom of script

                                needPoint = 0; //needPoint loop ends
                               
                                keepPlaying = 0;//keepPlaying loop ends

                            }
                        }
                        else
                        {
                            //second stage of game:
                            //player must continue to roll until either of the above conditionals are met.
                            //keepPlaying and needPoint loops continue to be set to 1 allowing for re-rolls and play again.

                            Console.WriteLine("You rolled a {0} !", sum);
                            Console.WriteLine("Your point: {0}", point);
                            Console.WriteLine("Roll again to reach your point!");
                            Console.WriteLine("Press enter ");
                            Console.ReadLine();

                        }

                    }//end of needPoint loop, allows for re-rolls during second stage


                }//end of second stage of game



            }//end of keepPlaying loop


            // final output shows total chips whether loss or win
            // loss of all chips automatically ends script
            //players choice of N or n at keepPlaying  ends the script
            Console.WriteLine("");

            Console.WriteLine("Chips left: {0}", chips);
            Console.WriteLine("Cash in your chips or buy more at the kiosk. Hope to see you again soon!", chips);

        } // end of main 



    }//end of class Craps


} //end of namespace CRAPS


