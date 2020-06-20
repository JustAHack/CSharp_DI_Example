namespace DependencyInjectionExample.BusinessLogic
{
	public interface IPet
	{
		void Speak();
		string Name { get; set; }
		int Age { get; set; }
		PetType Type { get; set; }
	}
}