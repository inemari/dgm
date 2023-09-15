# Dungeon Master


## Product Overview:
DungeonMaster is a C# console application developed in .NET 6. It serves as a role-playing game (RPG) simulation, allowing users to explore different hero classes, equip weapons and armor, level up heroes, and manage their attributes.

## About Me:
I'm Ine, a creative individual hailing from North Norway. My journey spans international fashion modeling in Athens, Milan, and Istanbul, but my true passion lies in crafting digital experiences. My academic background in IT and Information Systems introduced me to User Experience (UX) design, which I find both enjoyable and fulfilling. I'm actively working towards becoming a full-stack developer, with a particular focus on front-end development. In my free time, I relish moments with my beloved dog, Chico, enjoy girls' nights, retail therapy, and savor outdoor beers on sunny days.

## Implementation:
The project is implemented in C# using the .NET 6 framework, following robust object-oriented programming principles. It features a structured hierarchy of hero classes, weapon classes, and armor classes, each designed to represent key elements of the game. Custom exceptions are incorporated to handle invalid equipment choices.

### Testing:
Our testing approach primarily consists of unit tests, targeting specific components or functions in isolation. This meticulous assessment ensures that each function operates correctly and produces expected results. The xUnit testing framework streamlines test creation and execution. Various test scenarios, including equipment interactions and hero leveling, are covered.

### Class Structure:
DungeonMaster's class structure revolves around hero classes, weapon classes, armor classes, and enums. This architecture enhances code organization and maintainability.

Hero Classes: 
- DungeonMaster features diverse hero classes such as Wizard, Archer, Barbarian, and Swashbuckler. They inherit essential attributes from a common parent class, "Hero," including strength, dexterity, and intelligence. Heroes can equip specific armor and weapon types, with unique attribute variations specified within enums.

HeroAttribute Class: 
- The HeroAttribute class manages a hero's attributes, including strength, dexterity, and intelligence. It enables structured attribute management and tracking as heroes level up and equip items.

Item Classes: 
- The project relies on a well-defined hierarchy of item classes. The "Item" parent class serves as the foundation for weapons and armor, providing consistent attributes like name, required level, and slot. Enums categorize weapon and armor types, simplifying item management.

