using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare variables for our game marker position
            int x_coord = 0;
            int y_coord = 0;

            //create 2d array for tic-tac-toe board
            string[,] gameBoard = new string[3, 3] { {"*","*","*"},
                                                     {"*","*","*"},
                                                     {"*","*","*"} };

            //function calls
            drawBoard(gameBoard);
            GameLoop(gameBoard, x_coord, y_coord);
        }//end main

        static void drawBoard(string[,] gameBoard)
        {
            //get length of the rows. grabs the elements in the first dimension of our array.
            var rows = gameBoard.GetLength(0);

            //get length of columns. grabs the elements in the second dimension of our array.
            var columns = gameBoard.GetLength(1);

            //greet our user
            Console.WriteLine("Welcome to Tic-Toe-Toe, here is our starting board. ");
            Console.WriteLine("Our rows and columns start at number 0. For row one and column two enter rows at 0 and columns at 1. ");
            Console.WriteLine();

            // for loop to run though 2d array (rows & columns) 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //writes our rows and columns with a tab inbetween *
                    Console.Write("\t" + gameBoard[i, j]);

                }//end inside for loop   

                //writes new line for row 1 and so on so the board is in a grid and not on one line                                   
                Console.WriteLine();
            }//end outside for loop

            //ask user if they would like to play
            Console.WriteLine("\nPress 'enter' to play. ");
            Console.ReadLine();
     
        }//end function

        static void placeMarkerX(string[,] gameBoard, string markerX, int x_coord, int y_coord)
        {
            //declare empty string variable so we can place our players marker inside of currentPos
            string currentPos = " ";

            //get the length of our rows. grabs the elements in the first dimension of our array.
            var rows = gameBoard.GetLength(0);

            //get the length of our columns. grabs the elements in the second dimension of our array.                      
            var columns = gameBoard.GetLength(1);

            Console.WriteLine();

            //prompt user to input the coordinates of where they would like to place their marker. X will always be player one 
            x_coord = rangeCheck(0,2, PromptInt("Player 1 please input the row you would like to place your 'X' at : "));
            y_coord = rangeCheck(0,2, PromptInt("Player 1 please input the column you would like to place your 'X' at : "));
            Console.WriteLine();

            //for loop to modify our board with users input
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //our current position is x and y coordinates
                    currentPos = gameBoard[x_coord, y_coord];

                    //determine if our current position holds a '*'
                    if (currentPos == "*")
                    {
                        //if current position '*' , replace it with an 'X'
                        gameBoard[x_coord, y_coord] = markerX;

                    }//end if

                    //write updated board to console
                    Console.Write("\t" + gameBoard[i, j]);
                }//end inside for loop

                //writes new line for row 1 and so on so the board is in a grid and not on one line 
                Console.WriteLine();
            }//end outside for loop

            //check if the position on our board already has the opposite player marker
            for (int i = 0; i < gameBoard.Length; i++)
            {
                //our current position is x and y coordinates
                currentPos = gameBoard[x_coord, y_coord];

                //if our position already has the opposite marker then
                if (currentPos == "o")
                {
                    //display that they cannot steal that spot
                    Console.WriteLine("You can't steal positions! Try again!");

                    //recall our loop function so user can place a marker on the board
                    GameLoop(gameBoard, x_coord, y_coord);

                }//end if
            }//end for loop

        }//end function

        static void placeMarkerO(string[,] gameBoard, string markerO, int x_coord, int y_coord)
        {
            //declare empty string variable so we can place our players marker inside of currentPos
            string currentPos = " ";

            //get length of rows. grabs the elements in the first dimension of our array.
            var rows = gameBoard.GetLength(0);

            //get length of columns. grabs the elements in the second dimension of our array.
            var columns = gameBoard.GetLength(1);

            Console.WriteLine();

            //prompt user to input the coordinates of where they would like to place their marker. O will always be player 2.
            x_coord = rangeCheck(0,2, PromptInt("Player 2 please input the row you would like to place your 'o' at : "));
            y_coord = rangeCheck(0,2, PromptInt("Player 2 please input the column you would like to place your 'o' at : "));
            Console.WriteLine();

            //for loop to modify our board with users input
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //our current position is x and y coordinates
                    currentPos = gameBoard[x_coord, y_coord];

                    //determine if our current position holds a '*'
                    if (currentPos == "*")
                    {
                        //if current position '*' , replace it with an 'O'
                        gameBoard[x_coord, y_coord] = markerO;

                    }//end if                 

                    //write updated board to console
                    Console.Write("\t" + gameBoard[i, j]);
                }//end inside for

                //writes new line for row 1 and so on so the board is in a grid and not on one line
                Console.WriteLine();
            }//end outside for loop

            //check if the position on our board already has the opposite player marker
            for (int i = 0; i < gameBoard.Length; i++)
            {
                //our current position is x and y coordinates
                currentPos = gameBoard[x_coord, y_coord];

                //if our position already has the opposite marker then
                if (currentPos == "x")
                {
                    //display that they cannot steal that spot
                    Console.WriteLine("You can't steal positions! Try again!");

                    //recall our place marker function so user can place a marker on the board
                    placeMarkerO(gameBoard, "o", x_coord, y_coord);
                    break;
                }//end else if
            }//end for loop

        }//end function
        static int CompleteRow(string[,] gameBoard)
        {

            if (gameBoard[0, 0] == gameBoard[0,1] && gameBoard[0, 0] == gameBoard[0,2] && gameBoard[0, 0] != "*")
            {
                //winner in first row
                return 1;
            }
            else if (gameBoard[1, 0] == gameBoard[1, 1] && gameBoard[1, 0] == gameBoard[1,2] && gameBoard[1, 0] != "*")
            {
                //winner in second row               
                return 1;
            }
            else if (gameBoard[2, 0] == gameBoard[2,1] && gameBoard[2, 0] == gameBoard[2, 2] && gameBoard[2, 0] != "*")
            {
                //winner in third row               
                return 1;
            }
              
            return 0;
        }//end function
        static int CompleteCol(string[,] gameBoard)
        {
            
            if (gameBoard[0, 0] == gameBoard[1,0] && gameBoard[0, 0] == gameBoard[2,0] && gameBoard[0, 0] != "*")
            {
                //first column              
                return 2;
            }
            else if (gameBoard[0, 1] == gameBoard[1, 1] && gameBoard[0,1] == gameBoard[2,1] && gameBoard[0, 1] != "*")
            {
                //second column               
                return 2;
            }
            else if (gameBoard[0,2] == gameBoard[1,2] && gameBoard[0,2] == gameBoard[2, 2] && gameBoard[0,2] != "*")
            {
                //third column        
                return 2;
            }
            return -1;
        }//end function
        static int CompleteDiagonal(string[,] gameBoard)
        {
            if (gameBoard[2,0] == gameBoard[1,1] && gameBoard[2,0] == gameBoard[0,2] && gameBoard[2,0] != "*")
            {
                //diagonal from bottom left to top right
                return 3;
            }
            else if (gameBoard[0,2] == gameBoard[1,1] && gameBoard[0,2] == gameBoard[2,0] && gameBoard[0,2] != "*")
            {
                //diagonal from top right to bottom left
                return 3;
            }
            else if (gameBoard[2,2] == gameBoard[1,1] && gameBoard[2,2] == gameBoard[0,0] && gameBoard[2,2] != "*")
            {
                //diagnal from bottom right to the top left
                return 3;
            }
            else if (gameBoard[0,0] == gameBoard[1,1] && gameBoard[0,0] == gameBoard[2,2] && gameBoard[0,0] != "*")
            {
                //diagonal from top left to bottom right
                return 3;
            }
            return -1;
        }//end function

        static int winCheck(string[,] gameBoard, string markerX, string markerO, double gameTurns)
        {
            
            //tie
            if (gameTurns > 4.5)
            {
                Console.WriteLine("Its a tie!");
                return 1;
            }//end if
            
            //rows
            if (CompleteRow(gameBoard) == 1)
            {
                Console.WriteLine("Congrats! Winner by rows!");
                return 1;
            }//end if
            
            //columns
            if (CompleteCol(gameBoard) == 2)
            {
                Console.WriteLine("Congrats! Winner by columns!");
                return 1;
            }//end if
            
            //diagonally
            if (CompleteDiagonal(gameBoard) == 3)
            {
                Console.WriteLine("Congrats! Winner diagonally! ");
                return 1;
            }//end if
           
            return -1;
        }//end function
        static void GameLoop(string[,] gameBoard, int x_coord, int y_coord)
        {
            //counter for our game to see if we have a tie or not
            double gameTurns = 0.5; 

            //if our return value from winCheck is -1 that means no one has won yet and continue playing on
            while (winCheck(gameBoard, "x", "o", gameTurns) == -1)
            {
                
                //player 1
                placeMarkerX(gameBoard, "x", x_coord, y_coord); 

                //check if board has winner after player 1 turn. If player 1 has won it wont prompt player 2 to play. w/o this it will display the winner after player 2s turn.
                winCheck( gameBoard, "x",  "o", gameTurns); 

                //player 2
                placeMarkerO(gameBoard, "o", x_coord, y_coord); 
              
                //increase our counter
                gameTurns++;

                //if our return value from winCheck is not -1 than someone has won and we should break out of our loop
                if (winCheck(gameBoard, "x", "o", gameTurns) != -1)
                {
                    break;
                }//end if

            }//end while          
        }//end function
        static string Prompt(string message)
        {
            //reads the input that our user types in 
            Console.Write(message);
            return Console.ReadLine().ToLower();
        
        
        }//end function
        static int PromptInt(string message)
        {
            //error checking. takes our input from the Prompt Function and if anything but a # is inputted this will turn to false
            //and display our error message for the user

            int value = 0;

            //this will parse our string input to a integer representation of that value
            while (int.TryParse(Prompt(message), out value) == false)
            {
                Console.WriteLine("Please input integer");
            }//end while

            return value;
        }//end function
        static int rangeCheck(int lowestRange, int highestRange, int userRange)
        {
            //check if the user inputted values to place a marker on our board are within range
            while (userRange < lowestRange || userRange > highestRange)
            {
                //if not in range display message
                Console.WriteLine("Sorry, that is out of range for our board. ");

                //prompt the user to enter a new value
                userRange = PromptInt("Enter a value inside our range 0-2. ");
            }//end while

            return userRange;
        }//end function
    }//end class
}//end namespace
