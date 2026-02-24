using System;

namespace KrestikiNoliki123456
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char player1Symbol;
        static char player2Symbol;
        static char currentPlayer;
        static int scorePlayer1 = 0;
        static int scorePlayer2 = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("=== КРЕСТИКИ-НОЛИКИ v2.0 ===");
            Console.WriteLine("Счётчик побед + кастомизация");
            Console.WriteLine("Автор: Диянов Даниил Сергеевич");
            Console.WriteLine("Используйте номера строк и столбцов от 1 до 3");
            Console.WriteLine();

            Console.Write("Введите символ для первого игрока (Enter = X): ");
            string input = Console.ReadLine();
            player1Symbol = string.IsNullOrEmpty(input) ? 'X' : input[0];

            Console.Write("Введите символ для второго игрока (Enter = O): ");
            input = Console.ReadLine();
            player2Symbol = string.IsNullOrEmpty(input) ? 'O' : input[0];

            Console.WriteLine();

            while (true)
            {
                PlayRound();

                Console.WriteLine($"СЧЁТ: {player1Symbol} = {scorePlayer1}  |  {player2Symbol} = {scorePlayer2}");
                Console.Write("Хотите сыграть ещё? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    break;
                Console.WriteLine();
            }

            Console.WriteLine("Игра завершена. Спасибо!");
        }

        static void PlayRound()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = ' ';

            currentPlayer = player1Symbol;

            while (true)
            {
                PrintBoard();
                Console.WriteLine($"Ход игрока {currentPlayer}");

                Console.Write("Введите строку (1, 2, 3): ");
                int row = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Введите столбец (1, 2, 3): ");
                int col = int.Parse(Console.ReadLine()) - 1;

                if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
                {
                    Console.WriteLine("Некорректный ход! Попробуйте снова.");
                    Console.WriteLine();
                    continue;
                }

                board[row, col] = currentPlayer;

                if (CheckWinner())
                {
                    PrintBoard();
                    Console.WriteLine($"Игрок {currentPlayer} победил!");

                    if (currentPlayer == player1Symbol)
                        scorePlayer1++;
                    else
                        scorePlayer2++;
                    break;
                }

                if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("Ничья!");
                    break;
                }

                currentPlayer = (currentPlayer == player1Symbol) ? player2Symbol : player1Symbol;
            }
        }

        static void PrintBoard()
        {
            Console.WriteLine();
            Console.WriteLine("    1   2   3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($" {i + 1}  ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("    ---------");
            }
            Console.WriteLine();
        }

        static bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;

            for (int j = 0; j < 3; j++)
                if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                    return true;

            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;

            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }

        static bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j] == ' ')
                        return false;
            return true;
        }
    }
}