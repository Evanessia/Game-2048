using System;
using System.IO;

namespace Game2048
{
    public class GameCore2048
    {
        ulong[,] Square = null;

        ulong Score = 0;
        
        public GameCore2048(byte Size_Board)
        {
            Square = new ulong[Size_Board, Size_Board];

            Score = 0;
        }
        
        public GameCore2048()
        {
            //Only when loading a saved game!
        }

        //

        public bool OneStep(byte direction)
        {
            //2-down, 4-left, 6-right, 8-up.

            switch (direction)
            {
                case 2:
                    {
                        byte Number = (byte)Math.Sqrt(Square.Length);

                        // Move down

                        bool action = false;

                        for (sbyte j = 0; j < Number; j++)  // move
                        {
                            for (sbyte i = (sbyte)(Number - 2); i >= 0; i--)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                sbyte g = i;

                                for (sbyte k = (sbyte)(i + 1); k < Number; k++)
                                {
                                    if (Square[k, j] != 0)
                                    {
                                        break;
                                    }

                                    g = k;
                                }

                                if (g != i)
                                {
                                    Square[g, j] = Square[i, j];

                                    Square[i, j] = 0;

                                    action = true;
                                }
                            }
                        }

                        for (sbyte j = 0; j < Number; j++)  // sum
                        {
                            for (sbyte i = (sbyte)(Number - 1); i > 0; i--)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                if (Square[i, j] == Square[i - 1, j])
                                {
                                    Square[i, j] += Square[i - 1, j];

                                    Square[i - 1, j] = 0;

                                    Score += Square[i, j];

                                    action = true;
                                }
                            }
                        }
                        
                        for (sbyte j = 0; j < Number; j++)  // move
                        {
                            for (sbyte i = (sbyte)(Number - 2); i >= 0; i--)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                sbyte g = i;

                                for (sbyte k = (sbyte)(i + 1); k < Number; k++)
                                {
                                    if (Square[k, j] != 0)
                                    {
                                        break;
                                    }

                                    g = k;
                                }

                                if (g != i)
                                {
                                    Square[g, j] = Square[i, j];

                                    Square[i, j] = 0;

                                    action = true;
                                }
                            }
                        }
                        
                        if (action)
                        {
                            AddNewCell();
                        }

                        return action;
                    }
                case 4:
                    {
                        sbyte Number = (sbyte)Math.Sqrt(Square.Length);

                        // Move left

                        bool action = false;

                        for(sbyte i = 0; i < Number; i++)  // move
                        {
                            for(sbyte j = 1; j < Number; j++)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                sbyte g = j;

                                for(sbyte k = (sbyte)(j - 1); k >= 0; k--)
                                {
                                    if (Square[i, k] != 0)
                                    {
                                        break;
                                    }

                                    g = k;
                                }

                                if (g != j)
                                {
                                    Square[i, g] = Square[i, j];

                                    Square[i, j] = 0;

                                    action = true;
                                }
                            }
                        }

                        for (sbyte i = 0; i < Number; i++)  // sum
                        {
                            for (sbyte j = 0; j < Number - 1; j++)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                if (Square[i, j] == Square[i, j + 1])
                                {
                                    Square[i, j] += Square[i, j + 1];

                                    Square[i, j + 1] = 0;

                                    Score += Square[i, j];

                                    action = true;
                                }
                            }
                        }

                        for (sbyte i = 0; i < Number; i++)  // move
                        {
                            for (sbyte j = 1; j < Number; j++)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                sbyte g = j;

                                for (sbyte k = (sbyte)(j - 1); k >= 0; k--)
                                {
                                    if (Square[i, k] != 0)
                                    {
                                        break;
                                    }

                                    g = k;
                                }

                                if (g != j)
                                {
                                    Square[i, g] = Square[i, j];

                                    Square[i, j] = 0;

                                    action = true;
                                }
                            }
                        }
                        
                        if (action)
                        {
                            AddNewCell();
                        }

                        return action;
                    }
                case 6:
                    {
                        sbyte Number = (sbyte)Math.Sqrt(Square.Length);

                        // Move right

                        bool action = false;

                        for (sbyte i = 0; i < Number; i++)  // move
                        {
                            for (sbyte j = (sbyte)(Number - 2); j >= 0; j--)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                sbyte g = j;

                                for (sbyte k = (sbyte)(j + 1); k < Number; k++)
                                {
                                    if (Square[i, k] != 0)
                                    {
                                        break;
                                    }

                                    g = k;
                                }

                                if (g != j)
                                {
                                    Square[i, g] = Square[i, j];

                                    Square[i, j] = 0;

                                    action = true;
                                }
                            }
                        }
                        
                        for (sbyte i = 0; i < Number; i++)  // sum
                        {
                            for (sbyte j = (sbyte)(Number - 1); j > 0; j--)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                if (Square[i, j] == Square[i, j - 1])
                                {
                                    Square[i, j] += Square[i, j - 1];

                                    Square[i, j - 1] = 0;

                                    Score += Square[i, j];

                                    action = true;
                                }
                            }
                        }

                        for (sbyte i = 0; i < Number; i++)  // move
                        {
                            for (sbyte j = (sbyte)(Number - 2); j >= 0; j--)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                sbyte g = j;

                                for (sbyte k = (sbyte)(j + 1); k < Number; k++)
                                {
                                    if (Square[i, k] != 0)
                                    {
                                        break;
                                    }

                                    g = k;
                                }

                                if (g != j)
                                {
                                    Square[i, g] = Square[i, j];

                                    Square[i, j] = 0;

                                    action = true;
                                }
                            }
                        }

                        if (action)
                        {
                            AddNewCell();
                        }

                        return action;
                    }
                case 8:
                    {
                        sbyte Number = (sbyte)Math.Sqrt(Square.Length);

                        // Move up

                        bool action = false;

                        for (sbyte j = 0; j < Number; j++)  // move
                        {
                            for (sbyte i = 1; i < Number; i++)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                sbyte g = i;

                                for (sbyte k = (sbyte)(i - 1); k >= 0; k--)
                                {
                                    if (Square[k, j] != 0)
                                    {
                                        break;
                                    }

                                    g = k;
                                }

                                if (g != i)
                                {
                                    Square[g, j] = Square[i, j];

                                    Square[i, j] = 0;

                                    action = true;
                                }
                            }
                        }

                        for (sbyte j = 0; j < Number; j++)  // sum
                        {
                            for (sbyte i = 0; i < Number - 1; i++)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                if (Square[i, j] == Square[i + 1, j])
                                {
                                    Square[i, j] += Square[i + 1, j];

                                    Square[i + 1, j] = 0;

                                    Score += Square[i, j];

                                    action = true;
                                }
                            }
                        }

                        for (sbyte j = 0; j < Number; j++)  // move
                        {
                            for (sbyte i = 1; i < Number; i++)
                            {
                                if (Square[i, j] == 0)
                                {
                                    continue;
                                }

                                sbyte g = i;

                                for(sbyte k = (sbyte)(i - 1); k >= 0; k--)
                                {
                                    if (Square[k, j] != 0)
                                    {
                                        break;
                                    }

                                    g = k;
                                }

                                if (g != i)
                                {
                                    Square[g, j] = Square[i, j];

                                    Square[i, j] = 0;

                                    action = true;
                                }
                            }
                        }
                        
                        if (action)
                        {
                            AddNewCell();
                        }

                        return action;
                    }
            }

            return false;
        }

        public bool TheEnd()
        {
            if (Square == null)
            {
                return true;
            }

            sbyte n = (sbyte)Math.Sqrt(Square.Length);

            bool action = true;

            for(sbyte i = 0; i < n; i++)
            {
                for(sbyte j = 0; j < n; j++)
                {
                    if (Square[i, j] == 0)
                    {
                        return action = false;
                    }

                    if (i != 0)
                    {
                        if (Square[i, j] == Square[i - 1, j])
                        {
                            return action = false;
                        }
                    }

                    if (i != n - 1)
                    {
                        if (Square[i, j] == Square[i + 1, j])
                        {
                            return action = false;
                        }
                    }

                    if (j != 0)
                    {
                        if (Square[i, j] == Square[i, j - 1])
                        {
                            return action = false;
                        }
                    }

                    if (j != n - 1)
                    {
                        if (Square[i, j] == Square[i, j + 1])
                        {
                            return action = false;
                        }
                    }
                }
            }
            
            return action;
        }

        private bool AddNewCell()
        {
            byte Number = (byte)Math.Sqrt(Square.Length);

            byte Count = 0;

            for (byte i = 0; i < Number; i++)
            {
                for(byte j = 0; j < Number; j++)
                {
                    if(Square[i, j] == 0)
                    {
                        Count++;
                    }
                }
            }

            if (Count == 0)
            {
                return false;
            }
            
            byte s = (byte)new Random().Next(Count);

            byte n = 0;

            for (byte i = 0; i < Number; i++)
            {
                for (byte j = 0; j < Number; j++)
                {
                    if (Square[i, j] == 0)
                    {
                        if (n == s)
                        {
                            Square[i, j] = RandomNumber();

                            return true;
                        }
                        else
                        {
                            n++;
                        }
                    }
                }
            }

            return false;
        }

        //

        public bool NewGame()
        {
            if (Square == null)
            {
                return false;
            }

            byte t = (byte)Square.Length;

            for(byte i = 0; i < Math.Sqrt(t); i++)
            {
                for(byte j = 0; j < Math.Sqrt(t); j++)
                {
                    Square[i, j] = 0;
                }
            }

            byte FirstRandomCell = (byte)new Random().Next(t);

            byte SecondRandomCell = (byte)new Random().Next(t - 1);

            if (SecondRandomCell >= FirstRandomCell)
            {
                SecondRandomCell++;
            }

            Square[FirstRandomCell / (byte)Math.Sqrt(t), FirstRandomCell % (byte)Math.Sqrt(t)] = RandomNumber();

            Square[SecondRandomCell / (byte)Math.Sqrt(t), SecondRandomCell % (byte)Math.Sqrt(t)] = RandomNumber();

            Score = 0;

            return true;
        }

        public bool SaveGame()
        {
            if (Square == null)
            {
                return false;
            }

            StreamWriter _stream = new StreamWriter("save0");
            
            _stream.WriteLineAsync(Score.ToString());

            _stream.WriteLineAsync(Square.Length.ToString());

            byte n = 1;

            for (byte i = 0; i < (byte)Math.Sqrt(Square.Length); i++)
            {
                for (byte j = 0; j < (byte)Math.Sqrt(Square.Length); j++)
                {
                    _stream.WriteAsync(Square[i, j].ToString());

                    if (n < Square.Length)
                    {
                        _stream.WriteLineAsync();
                    }

                    n++;
                }
            }

            _stream.Close();

            _stream.Dispose();
            
            return true;
        }

        public bool LoadGame()
        {
            if (!File.Exists("save0"))
            {
                return false;
            }

            StreamReader _stream = new StreamReader("save0");

            //

            string str = null;

            str = _stream.ReadLine();

            if(!ulong.TryParse(str, out Score))
            {
                _stream.Close();

                _stream.Dispose();

                return false;
            }

            //
            
            str = _stream.ReadLine();
            
            if(!byte.TryParse(str,out byte Number))
            {
                _stream.Close();

                _stream.Dispose();

                return false;
            }
            
            if (Number != 16 && Number != 36)
            {
                _stream.Close();

                _stream.Dispose();

                return false;
            }
            
            //
            
            byte Edge = (byte)Math.Sqrt(Number);

            Square = new ulong[Edge, Edge];

            //

            for(byte i = 0; i < Edge; i++)
            {
                for(byte j = 0; j < Edge; j++)
                {
                    str = _stream.ReadLine();

                    if(!ulong.TryParse(str, out Square[i, j]))
                    {
                        _stream.Close();

                        _stream.Dispose();

                        return false;
                    }
                }
            }

            _stream.Close();

            _stream.Dispose();

            return true;
        }
        
        public byte Size => (byte)Math.Sqrt(Square.Length);
        
        public ulong ScoreGame => Score;
        
        public ulong GetCell(byte line, byte column) => Square[line, column];
        
        private byte RandomNumber() => (byte)new Random().Next(100) < 90 ? (byte)2 : (byte)4;
    }

    class Program
    {
        static void BoardRendering(ref GameCore2048 in_core)
        {
            if (in_core == null)
            {
                Console.Clear();

                Console.WriteLine("Error! Game core is null.");

                Console.Write("Press key...");

                Console.ReadKey();
                
                Environment.Exit(0);
            }

            Console.Clear();

            Console.WriteLine("'Esc' - Exit from the game, 'N' - New game, 'S' - Save game.");

            Console.WriteLine("==============================");

            for (byte i = 0; i < in_core.Size; i++)
            {
                for(byte j = 0; j < in_core.Size; j++)
                {
                    switch (in_core.GetCell(i, j))
                    {
                        case 0:
                            {
                                
                            }
                            break;
                        case 2:
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            break;
                        case 4:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            break;
                        case 8:
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            break;
                        case 16:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            break;
                        case 32:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            break;
                        case 64:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                            break;
                        case 128:
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            break;
                        case 256:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                            }
                            break;
                        case 512:
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            break;
                        case 1024:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                            }
                            break;
                        case 2048:
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            break;
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            }
                            break;
                    }
                    
                    Console.Write(" {0, 5} ", in_core.GetCell(i, j));

                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }

            Console.WriteLine("==============================");

            Console.WriteLine("Score: {0}", in_core.ScoreGame);
        }
        
        static void Main()
        {
            GameCore2048 _Core = null;

            bool SaveGame = false;

            Console.Title = "2048";

            ConsoleKeyInfo KeyNow;

            byte left;

            byte top;

            if (File.Exists("save0"))
            {
                _Core = new GameCore2048();

                SaveGame = _Core.LoadGame();
            }

            Console.CursorVisible = false;
            
            Console.SetWindowSize(63, 20);

            if (!SaveGame)
            {
                Console.WriteLine("'Esc' - exit from the game.");

                Console.WriteLine("==============================");

                Console.Write("Enter board dimension (4 or 6): ");

                left = (byte)Console.CursorLeft;

                top = (byte)Console.CursorTop;

                bool t = false;

                do
                {
                    KeyNow = Console.ReadKey();

                    switch (KeyNow.Key)
                    {
                        case ConsoleKey.D4:
                            {
                                _Core = new GameCore2048(4);

                                _Core.NewGame();

                                t = true;
                            }
                            break;

                        case ConsoleKey.D6:
                            {
                                _Core = new GameCore2048(6);

                                _Core.NewGame();

                                t = true;
                            }
                            break;

                        case ConsoleKey.Escape:
                            {
                                Console.Write("\nPress key...");

                                Console.ReadKey();

                                Environment.Exit(0);
                            }
                            break;

                        default:
                            {
                                Console.SetCursorPosition(left, top);
                            }
                            break;
                    }

                } while (!t);
            }
            
            if (_Core == null)
            {
                Console.WriteLine("Game creation error!");

                Console.WriteLine("==============================");

                Console.Write("Press key...");

                Console.ReadKey();

                Environment.Exit(0);
            }

            BoardRendering(ref _Core);

            left = (byte)Console.CursorLeft;

            top = (byte)Console.CursorTop;
            
            bool UpdateWindow = false;

            do
            {
                KeyNow = Console.ReadKey();

                Console.SetCursorPosition(left, top);

                switch (KeyNow.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            UpdateWindow = _Core.OneStep(8);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        {
                            UpdateWindow = _Core.OneStep(2);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        {
                            UpdateWindow = _Core.OneStep(4);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        {
                            UpdateWindow = _Core.OneStep(6);
                        }
                        break;

                    case ConsoleKey.Escape:
                        {
                            Console.Clear();

                            Console.WriteLine("The game will automatically save when you exit!");

                            Console.WriteLine("==============================");

                            Console.Write("Exit from the game. Are you sure (Y-Yes, N-No)? ");

                            byte leftExit = (byte)Console.CursorLeft;

                            byte topExit = (byte)Console.CursorTop;

                            ConsoleKeyInfo ExitKey;

                            bool ExitBoolean = false;

                            do
                            {
                                ExitKey = Console.ReadKey();

                                Console.SetCursorPosition(leftExit, topExit);

                                switch (ExitKey.Key)
                                {
                                    case ConsoleKey.Y:
                                        {
                                            if (_Core.SaveGame())
                                            {
                                                Console.Clear();

                                                Console.WriteLine("Game saved successfully!");

                                                Console.Write("Press key...");

                                                Console.ReadKey();
                                                
                                                Environment.Exit(0);
                                            }
                                            else
                                            {
                                                Console.Clear();

                                                Console.WriteLine("The program was unable to successfully save the game!");

                                                Console.Write("Press key...");

                                                Console.ReadKey();

                                                ExitBoolean = true;

                                                UpdateWindow = true;
                                            }
                                        }
                                        break;

                                    case ConsoleKey.N:
                                        {
                                            ExitBoolean = true;

                                            UpdateWindow = true;
                                        }
                                        break;
                                }
                                
                            } while (!ExitBoolean);
                        }
                        break;

                    case ConsoleKey.N:
                        {
                            Console.Clear();

                            Console.WriteLine("Previous game won't save!");

                            Console.WriteLine("==============================");

                            Console.Write("Are you sure you want to start a new game (Y-Yes, N-No)? ");

                            byte leftNew = (byte)Console.CursorLeft;

                            byte topNew = (byte)Console.CursorTop;

                            ConsoleKeyInfo NewKey;

                            bool NewBoolean = false;

                            do
                            {
                                NewKey = Console.ReadKey();

                                Console.SetCursorPosition(leftNew, topNew);

                                switch (NewKey.Key)
                                {
                                    case ConsoleKey.Y:
                                        {
                                            Console.Clear();
                                            
                                            Console.WriteLine("==============================");

                                            Console.Write("Enter board dimension (4 or 6): ");

                                            left = (byte)Console.CursorLeft;

                                            top = (byte)Console.CursorTop;

                                            bool t = false;

                                            do
                                            {
                                                KeyNow = Console.ReadKey();

                                                switch (KeyNow.Key)
                                                {
                                                    case ConsoleKey.D4:
                                                        {
                                                            _Core = new GameCore2048(4);

                                                            _Core.NewGame();

                                                            t = true;
                                                        }
                                                        break;

                                                    case ConsoleKey.D6:
                                                        {
                                                            _Core = new GameCore2048(6);

                                                            _Core.NewGame();

                                                            t = true;
                                                        }
                                                        break;
                                                        
                                                    default:
                                                        {
                                                            Console.SetCursorPosition(left, top);
                                                        }
                                                        break;
                                                }

                                            } while (!t);
                                            
                                            _Core.NewGame();

                                            NewBoolean = true;

                                            UpdateWindow = true;
                                        }
                                        break;

                                    case ConsoleKey.N:
                                        {
                                            NewBoolean = true;

                                            UpdateWindow = true;
                                        }
                                        break;
                                }

                            } while (!NewBoolean);
                        }
                        break;

                    case ConsoleKey.S:
                        {
                            Console.Clear();

                            if (_Core.SaveGame())
                            {
                                Console.WriteLine("Game saved successfully!");
                            }
                            else
                            {
                                Console.WriteLine("The game has not been saved!");
                            }
                            
                            Console.WriteLine("==============================");

                            Console.Write("Press key to continue...");

                            Console.ReadKey();

                            UpdateWindow = true;
                        }
                        break;
                }

                if (UpdateWindow)
                {
                    BoardRendering(ref _Core);

                    if (_Core.TheEnd())  // the end?
                    {
                        Console.WriteLine("Game over!");

                        Console.WriteLine("Your result is {0}.", _Core.ScoreGame);

                        Console.WriteLine("==============================");

                        Console.Write("Are you sure you want to start a new game (Y-Yes, N-No)? ");

                        byte leftNew = (byte)Console.CursorLeft;

                        byte topNew = (byte)Console.CursorTop;

                        ConsoleKeyInfo NewKey;

                        bool NewBoolean = false;

                        do
                        {
                            NewKey = Console.ReadKey();

                            Console.SetCursorPosition(leftNew, topNew);

                            switch (NewKey.Key)
                            {
                                case ConsoleKey.Y:
                                    {
                                        Console.Clear();

                                        Console.WriteLine("==============================");

                                        Console.Write("Enter board dimension (4 or 6): ");

                                        left = (byte)Console.CursorLeft;

                                        top = (byte)Console.CursorTop;

                                        bool t = false;

                                        do
                                        {
                                            KeyNow = Console.ReadKey();

                                            switch (KeyNow.Key)
                                            {
                                                case ConsoleKey.D4:
                                                    {
                                                        _Core = new GameCore2048(4);

                                                        _Core.NewGame();

                                                        t = true;
                                                    }
                                                    break;

                                                case ConsoleKey.D6:
                                                    {
                                                        _Core = new GameCore2048(6);

                                                        _Core.NewGame();

                                                        t = true;
                                                    }
                                                    break;

                                                default:
                                                    {
                                                        Console.SetCursorPosition(left, top);
                                                    }
                                                    break;
                                            }

                                        } while (!t);

                                        _Core.NewGame();

                                        NewBoolean = true;

                                        UpdateWindow = true;
                                    }
                                    break;

                                case ConsoleKey.N:
                                    {
                                        if (File.Exists("save0"))
                                        {
                                            File.Delete("save0");
                                        }

                                        Environment.Exit(0);
                                    }
                                    break;
                            }

                        } while (!NewBoolean);
                    }
                    
                    UpdateWindow = false;
                }
                
            } while (true);
        }
    }
}