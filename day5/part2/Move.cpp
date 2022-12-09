#include "Move.h"

Move Move::FromString(const string& moveStr) {
	regex parseExp("move (\\d+) from (\\d+) to (\\d+)");
	smatch matches;
	regex_match(moveStr, matches, parseExp);

	if (matches.empty() || matches.length() < 4) {
		throw invalid_argument("Invalid move.");
	}
	
	int count = stoi(matches[1].str().c_str());
	int fromShipId = stoi(matches[2].str().c_str());
	int toShipId = stoi(matches[3].str().c_str());

	Move move(count, fromShipId, toShipId);
	return move;
}

Move::Move(int count, int fromShipId, int toShipId) : Count(count), FromShipId(fromShipId), ToShipId(toShipId) {}