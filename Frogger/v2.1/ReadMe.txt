The main goal is to apply mainly the SOLID principles, as well as other OOP ones.
Second goal is the introduction to the unit testing.

* Models`s logic extracted outside of models, only validations left.
* Dictionarry row collection structure, tried also List, but intuitivly think the array is the most secure structure, having in mind that later I`ll attempt to make the project multy threded.
* RowID enums ditched, using integers now.
* The static classes global constants and methods are now history. Everithing went into one instance class Settings. 
* Memory complexity is naturally rising.
* Because of the sequence of creation and execution of the modules program`s complexity is now going through the roof. Goodby KISS principle. Later will attempt optimizations.
* Making more features so the game to et least start to look more like a real one.