using System.Drawing;

namespace RT.AOC2019.CMD.Day3
{
  public class Intersection
  {
    public Intersection(Point point, int totalSteps)
    {
      this.Point = point;
      this.TotalSteps = totalSteps;

    }
    public Point Point { get; set; }
    public int TotalSteps { get; set; }
  }
}