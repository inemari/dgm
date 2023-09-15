# Dungeon Master


## Product Overview:
DungeonMaster is a C# console application developed in .NET 6. It serves as a role-playing game (RPG) simulation, allowing users to explore different hero classes, equip weapons and armor, level up heroes, and manage their attributes.

## About Me:
I'm Ine, a creative individual originating from North Norway. My journey spans international fashion modeling in Athens, Milan, and Istanbul, but my true passion lies in crafting digital experiences. My academic background in IT and Information Systems introduced me to User Experience (UX) design and development, which I find both enjoyable and fulfilling. I'm actively working towards becoming a full-stack developer, with a particular focus on front-end development. In my free time, I relish moments with my beloved dog, Chico, enjoy girls' nights, retail therapy, and savor outdoor beers on sunny days.

## Implementation:
The project is implemented in C# using the .NET 6 framework, following robust object-oriented programming principles. It features a structured hierarchy of hero classes, weapon classes, and armor classes, each designed to represent key elements of the game. Custom exceptions are incorporated to handle invalid equipment choices.

### Testing:
Our testing approach primarily consists of unit tests, targeting specific components or functions in isolation. This meticulous assessment ensures that each function operates correctly and produces expected results. The xUnit testing framework streamlines test creation and execution. Various test scenarios, including equipment interactions and hero leveling, are covered.

### Class Structure:
DungeonMaster's class structure revolves around hero classes, weapon classes, armor classes, and enums. This architecture enhances code organization and maintainability.

**Hero Classes:** 
- DungeonMaster features diverse hero classes such as Wizard, Archer, Barbarian, and Swashbuckler. They inherit essential attributes from a common parent class, "Hero," including strength, dexterity, and intelligence. Heroes can equip specific armor and weapon types, with unique attribute variations specified within enums.

**HeroAttribute Class:**
- The HeroAttribute class manages a hero's attributes, including strength, dexterity, and intelligence. It enables structured attribute management and tracking as heroes level up and equip items.

**Item Classes:**
- The project relies on a well-defined hierarchy of item classes. The "Item" parent class serves as the foundation for weapons and armor, providing consistent attributes like name, required level, and slot. Enums categorize weapon and armor types, simplifying item management.

## Running the Project
To run DungeonMaster and embark on your RPG adventure, follow these steps:

### Prerequisites
- Make sure you have [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) installed on your system.<br>

### Clone the Repository
If you haven't already, clone the DungeonMaster repository to your local machine using Git:<br>
```git clone https://github.com/your-username/DungeonMaster.git```

### Navigate to the Project Directory
Move to the project directory:<br>
```cd DungeonMaster```

###Build the Project
To build the project and compile the code, run the following command:<br>
```dotnet build```


###Run the Application
Now, you're ready to run DungeonMaster! Use the following command to start the application:<br>
```dotnet run```<br>
This command will launch the console application, and you'll be greeted with options to explore different hero classes, equip weapons and armor, level up heroes, and manage their attributes within the RPG simulation.<br>
Enjoy your DungeonMaster experience!
