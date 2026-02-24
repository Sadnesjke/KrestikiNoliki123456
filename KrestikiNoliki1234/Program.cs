using System;

namespace KrestikiNoliki123456
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            Console.WriteLine("=== КРЕСТИКИ-НОЛИКИ ===");
            Console.WriteLine("Первая версия");
            Console.WriteLine("Автор: Диянов Даниил Сергеевич");
            Console.WriteLine("Используйте номера строк и столбцов от 1 до 3");
            Console.WriteLine();

            StartGame();
        }

        static void StartGame()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = ' ';

            currentPlayer = 'X';

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
                    break;
                }

                if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("Ничья!");
                    break;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
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