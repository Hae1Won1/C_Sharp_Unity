namespace Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize(25);

            // 30프레임
            const int WAIT_TICK = 1000 / 30;
            const char CIRCLE = '\u25cf';
            // 커서 안보이게
            Console.CursorVisible = false;
            int lastTime = 0;


            while (true)
            {
                #region
                int currentTick = System.Environment.TickCount;

                if (currentTick - lastTime < 1000 / 30)
                    continue;
                lastTime = currentTick;
                #endregion

                // 입력
                // 로직
                // 렌더링

                Console.SetCursorPosition(0, 0);
                board.Render();
                #region
                //Console.SetCursorPosition(0, 0);
                //for (int i = 0; i < 25; i++)
                //{
                //    for (int j = 0; j < 25; j++)
                //    {
                //        Console.ForegroundColor = ConsoleColor.Green;
                //        Console.Write(CIRCLE);
                //        Console.Write(' ');
                //    }
                //    Console.WriteLine();
                //}
                #endregion
            }
        }
    }
}
