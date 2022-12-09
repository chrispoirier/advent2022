#include "GameInput.h"

GameInput GameInput::FromFile(const string &filename) {
	GameInput input;

	string inputStr = input.readInput(filename);
	input.parseInput(inputStr);

	return input;
}

string GameInput::readInput(const string &filename) const {
	ifstream file(filename);
	string contents((istreambuf_iterator<char>(file)), (istreambuf_iterator<char>()));
	return contents;
}

void GameInput::parseInput(const string &input) {
	string nextLine;
	stringstream inputStr(input);
	getline(inputStr, nextLine);

	initShips((nextLine.length() + 1) / 4);

	bool doneShips = false; 
	map<int, list<Crate>> crateQueue;
	do {
		if (nextLine.length() == 0 || isShipIdLine(nextLine)) {
			doneShips = true;
		}
		else if (!doneShips) {
			queueCrates(nextLine, crateQueue);
		}
		else if (doneShips) {
			addMove(nextLine);
		}
	} while (getline(inputStr, nextLine));
	addCrates(crateQueue);
}

void GameInput::initShips(int numShips) {
	for (int i = 0; i < numShips; i++) {
		Ship ship(i + 1);
		ships.push_back(ship);
	}
}

bool GameInput::isShipIdLine(const string& line) const {
	regex shipIdExp("\\s+\\d");
	smatch matches;
	regex_match(line, matches, shipIdExp);
	return matches.length() == ships.size();
}

void GameInput::queueCrates(const string& line, map<int, list<Crate>>& crates) const {
	for (int i = 0; i < signed(line.length()); i++) {
		char chr = line[i];
		if (isalpha(chr)) {
			Crate crate(chr);
			int crateInd = (i - 1) / 4;
			if (crates.count(crateInd) == 0) {
				list<Crate> newCrates;
				newCrates.push_front(crate);	
				crates.insert(*make_unique<pair<int, list<Crate>>>(crateInd, newCrates));
			}
			else {
				crates[crateInd].push_front(crate);
			}
		}
	}
}

void GameInput::addCrates(const map<int, list<Crate>>& crates) {
	for (Ship &ship : ships) {
		for (const Crate& crate : crates.at(ship.Id - 1)) {
			ship.AddCrate(crate);
		}
	}
}

void GameInput::addMove(const string& line) {
	moves.push_back(Move::FromString(line));
}

void GameInput::RunGame() {
	for (const Move &move : moves) {
		for (int i = 0; i < move.Count; i++) {
			printBoard();
			Crate crate = ships[move.FromShipId - 1].RemoveCrate();
			ships[move.ToShipId - 1].AddCrate(crate);
		}
	}
	printBoard();
}

string GameInput::GetTopCratesAsString() const {
	string topCrates("");
	for (const Ship &ship : ships) {
		topCrates.append(1, ship.Crates.top().Label);
	}
	return topCrates;
}

void GameInput::printBoard() const {
	for (const Ship& ship : ships) {
		cout << "Ship " << ship.Id << ": " << ship.GetCratesString() << "\n";
	}
	cout << "--------------------------\n";
}