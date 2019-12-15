using System;
using System.Collections.Generic;

namespace RT.AOC2019.CMD.Day3
{
    public enum Direction
    {
        Right = 'R',
        Left = 'L',
        Up = 'U',
        Down = 'D'
    }

    public class Instruction
    {
        public Instruction(string instruction)
        {
            Moves = int.Parse(instruction.Substring(1));

            switch (instruction.ToUpper()[0])
            {
                case 'R':
                    Direction = Direction.Right;
                    break;
                case 'L':
                    Direction = Direction.Left;
                    break;
                case 'U':
                    Direction = Direction.Up;
                    break;
                case 'D':
                    Direction = Direction.Down;
                    break;
            }

        }

        public int Moves { get; set; }
        public Direction Direction { get; set; }

        public void Apply(CoordinateList coordinates) {
            switch (Direction)
            {
                case Direction.Right:
                    coordinates.MoveRight(Moves);
                    break;
                case Direction.Left:
                    coordinates.MoveLeft(Moves);
                    break;
                case Direction.Up:
                    coordinates.Moveup(Moves);
                    break;
                case Direction.Down:
                    coordinates.MoveDown(Moves);
                    break;
            }

        }
    }
}
