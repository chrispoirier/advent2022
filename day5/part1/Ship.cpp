#include "Ship.h"

Ship::Ship(const int id) : Id(id) {}

void Ship::AddCrate(const Crate& crate) {
	Crates.push(crate);
}

Crate Ship::RemoveCrate() {
	Crate first = Crates.top();
	Crates.pop();
	return first;
}

string Ship::GetCratesString() const {
	string cratesStr("");
	for (const Crate& crate : Crates._Get_container()) {
		cratesStr.append(1, crate.Label);
	}
	return cratesStr;
}