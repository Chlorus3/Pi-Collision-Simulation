using Pi_Collision_Simulation_CSharp;

public class Program
{
	static readonly int DigitsOfPi = 5; // number of decimal places you want to calculate Pi to, must be >= 1

	public static void Main()
	{
		Cube cube1 = new(1, 0);
		Cube cube2 = new(Math.Pow(100, DigitsOfPi), -1);

		int collisions = CollisionSimulator.RunSimulation(cube1, cube2);

		Console.WriteLine(collisions / Math.Pow(10, DigitsOfPi));
	}
}