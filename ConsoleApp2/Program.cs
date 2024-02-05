using System;

class Program
{
    static void Main(string[] args)
    {
        // Program header
        Console.WriteLine("Virtual Pet Simulator\n");

        // 1. Pet creation
        Console.Write("What type of pet would you like (cat, dog, rabbit): ");
        string petType = Console.ReadLine();

        Console.Write("What would you like to name your pet: ");
        string petName = Console.ReadLine();

        Pet pet = new Pet(petType, petName);

        // 2. Display pet details
        Console.WriteLine($"\nWelcome to your new {pet.Type} named {pet.Name}!");

        // 4. Track time
        int hour = 0;

        // 3. Main game loop
        bool gameOver = false;
        while (!gameOver)
        {
            // 4. Simulate time
            hour++;
            pet.UpdateAttributes();

            // 5. Check for special events
            pet.CheckStatus();

            // Display menu options
            Console.WriteLine("\n1. Feed \n2. Play \n3. Let Rest \n4. Check Status");

            Console.Write("\nChoose an action: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    pet.Feed();
                    break;

                case 2:
                    pet.Play();
                    break;

                case 3:
                    pet.Rest();
                    break;

                case 4:
                    pet.CheckStatus();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            // Display updated stats
            Console.WriteLine(pet);

            // Check game over
            if (pet.Health <= 0 || pet.Hunger >= 10 || pet.Happiness <= 0)
            {
                gameOver = true;
            }
        }

        // Game over
        Console.WriteLine("\nUnfortunately, your pet has become too unhealthy. Game over!");
    }
}

class Pet
{
    private string type;
    private string name;
    private int hunger;
    private int happiness;
    private int health;

    public string Type => type;
    public string Name => name;
    public int Hunger => hunger;
    public int Happiness => happiness;
    public int Health => health;

    // Parameterized constructor
    public Pet(string type, string name)
    {
        this.type = type;
        this.name = name;
        hunger = 5;
        happiness = 5;
        health = 5;
    }

    // Feed method
    public void Feed()
    {
        hunger -= 2;
        health += 1;

        Console.WriteLine($"You feed {name}. Hunger reduces to {hunger}. Health rises to {health}.");
    }

    // Play method
    public void Play()
    {
        happiness += 2;
        hunger += 1;

        Console.WriteLine($"You play with {name}. Happiness rises to {happiness}. Hunger rises to {hunger}");
    }

    // Rest method 
    public void Rest()
    {
        health += 2;
        happiness -= 1;

        Console.WriteLine($"{name} takes rest. Health rises to {health}. Happiness reduces to {happiness}.");
    }

    // Hourly effects 
    public void UpdateAttributes()
    {
        hunger += 2;
        happiness -= 1;
    }

    // Status warnings
    public void CheckStatus()
    {
        if (hunger > 7)
            Console.WriteLine($"{name} is very hungry! Please feed.");

        if (happiness < 4)
            Console.WriteLine($"{name} seems sad. Play to cheer up!");

        if (health < 4)
            Console.WriteLine($"{name} is unwell. Let it rest.");
    }

    public override string ToString()
    {
        return ($"Hunger: {hunger}\nHappiness: {happiness}\nHealth: {health}");
    }
}
