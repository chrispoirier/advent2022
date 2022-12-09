#pragma once
#include <list>
#include <vector>
#include <map>
#include <string>
#include <fstream>
#include <sstream>
#include <iostream>
#include "Ship.h"
#include "Move.h"

using namespace std;

class GameInput
{
public:
	vector<Ship> ships;
	list<Move> moves;

	static GameInput FromFile(const string& filename);
	explicit GameInput() = default;
	void RunGame();
	string GetTopCratesAsString() const;

private:
	string readInput(const string& filename) const;
	void parseInput(const string& input);
	void initShips(const int numShips);
	bool isShipIdLine(const string& line) const;
	void queueCrates(const string& line, map<int, list<Crate>>& crateQueue) const;
	void addCrates(const map<int, list<Crate>>& crateQueue);
	void addMove(const string& line);
	void printBoard() const;
};

