namespace DependencyInjectionExample.BusinessLogic
{
	public abstract class Pet : IPet
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public PetType Type { get; set; }

		public Pet()
		{

		}

		public Pet(string name, int age, PetType type)
		{
			Name = name;
			Age = age;
			Type = type;
		}

		public abstract void Speak();

		public override string ToString()
		{
			return $"Name: {Name}\nAge: {Age}\nType: {Type}\n";
		}
	}
}
