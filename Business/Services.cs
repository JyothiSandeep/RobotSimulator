namespace Business
{
    using Data;
    public  class Services
    {
        public static int X { get; private set; }
        public static int Y { get; private set; }

        public static int width { get; private set; }
        public static int height { get; private set; }
        public static Direction Facing { get; private set; }
        //private Place _table;

        public Services(int x, int y)
        {
            width = x;
            height = y;
        }

        public void Move()
        {
            int x1 = X, y1 = Y;
            switch (Facing)
            {
                case Direction.NORTH:
                    y1++; 
                    break;
                case Direction.EAST:
                    x1++; 
                    break;
                case Direction.SOUTH:
                    y1--; 
                    break;
                case Direction.WEST: 
                    x1--;
                    break;
            }

         //   if (_table.IsPositionValid(newX, newY))
         if (x1 >= 0 && x1 < width && y1 >= 0 && y1 < height)
            {
                X = x1;
                Y = y1;
            }
        }

        public bool IsValid(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        public void TurnLeft()
        {
            Facing = (Direction)(((int)Facing + 3) % 4);
        }

        /// <summary>
        /// 90° clockwise turn. (% 4-> result within the range [0, 3])
        /// </summary>
        public void TurnRight() {
            Facing = (Direction)(((int)Facing + 1) % 4);
            }

        public void Place(int x, int y, int face)
        {
            if (IsValid(x, y))
            {
                X = x;
                Y = y;
                Facing = (Direction) face;
            }
        }
        public string Report() => $"{X},{Y},{Facing}";
    }
}
