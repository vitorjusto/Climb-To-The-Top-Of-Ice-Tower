# Climb To The Top Of The Ice Tower
This game is a rage inducing game witch horrible ice controls
you can play this game [Here](https://vitorjusto.itch.io/climb-to-the-top-of-ice-tower)

Godot 4.1.1 Stable Mono · C# · Solo dev

## Technical decisions

**Chain Of Responsability**
- The death transition and scene transition reuse the same transition animation and loading algorithm. Since they need to happen in a specific order, I implemented this using the Chain of Responsibility pattern.

## Running the project
- Godot 4.1.1 Mono
- .NET 6
- Clone the repo, open `project.godot` in Godot
- No external dependencies

## Credits
Everything such as Programing, Music and Pixel Art is made by: Vitorjusto

Everything else made by [vitorjusto](https://github.com/vitorjusto)
