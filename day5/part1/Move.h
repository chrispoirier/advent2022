#pragma once
#include <string>
#include <regex>

using namespace std;

class Move 
{
public:
	const int Count;
	const int FromShipId;
	const int ToShipId;

	static Move FromString(const string &moveStr);
	Move(int count, int fromShipId, int toShipId);
};