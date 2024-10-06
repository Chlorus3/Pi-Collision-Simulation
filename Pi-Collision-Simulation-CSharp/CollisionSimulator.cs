namespace Pi_Collision_Simulation_CSharp
{
	public class Cube(double _mass, double _velocity)
	{
		public double mass = _mass;
		public double velocity = _velocity;
	}

	public class CollisionSimulator
	{
		public static (double, double) SimulateCollision(Cube cube1, Cube cube2)
		{
			// Simulates a perfect inelastic collision
			return (
				(cube1.mass - cube2.mass) /
				(cube1.mass + cube2.mass) *
				cube1.velocity + 2 * cube2.mass /
				(cube1.mass + cube2.mass) *
				cube2.velocity,

				2 * cube1.mass /
				(cube1.mass + cube2.mass) *
				cube1.velocity + (cube2.mass - cube1.mass) /
				(cube1.mass + cube2.mass) *
				cube2.velocity
			);
		}


		public static int RunSimulation(Cube cube1, Cube cube2)
		{
			int collisions = 0;

			// Collision cannot happen if cube2 is equal to or greater than cube1
			while (cube2.velocity < cube1.velocity)
			{
				(cube1.velocity, cube2.velocity) = SimulateCollision(cube1, cube2); collisions++;

				/*
				 * There can not be a collision with the wall if cube1 is not going towards the left
				 * It must have a velocity less than 1
				 */
				if (cube1.velocity >= 0) break;

				cube1.velocity *= -1; collisions++; // Collision with wall. The velocity of cube is multiplied by -1 to go towards the right
			}

			return collisions;
		}
	}
}
