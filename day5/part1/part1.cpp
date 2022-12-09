#include <iostream>
#include "GameInput.h"

int main()
{
    GameInput input = GameInput::FromFile("./input");
    //std::cout << "Ships: " << input.ships.size() << "\n";
    //std::cout << "Moves: " << input.moves.size() << "\n";
    input.RunGame();
    std::cout << "Top Crates: " << input.GetTopCratesAsString();
}

