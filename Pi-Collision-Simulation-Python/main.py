class Cube():
	mass: float = 0
	velocity: float = 0

	def __init__(self, _mass: float, _velocity: float) -> None:
		self.mass = _mass
		self.velocity = _velocity


class CollisionSimulator():
	def __init__(self) -> None:
		...
		
	def SimulateCollision(self, cube1: Cube, cube2: Cube) -> float | float:
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
			)
	
	def RunSimulation(self, cube1: Cube, cube2: Cube) -> int:
		collisions: int = 0

		while cube2.velocity < cube1.velocity:
			cube1.velocity, cube2.velocity = self.SimulateCollision(cube1, cube2)
			collisions += 1

			if cube1.velocity >= 0: break

			cube1.velocity *= -1
			collisions += 1

		return collisions
	

if __name__ == '__main__':
	DecimalPlacesOfPi: int = 6

	sim = CollisionSimulator()
	cube1 = Cube(1, 0)
	cube2 = Cube(100 ** DecimalPlacesOfPi, -1)

	collisions = sim.RunSimulation(cube1, cube2)

	print(collisions / 10 ** DecimalPlacesOfPi)