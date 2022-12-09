#pragma once
#include <stack>
#include <string>
#include <iostream>
#include "Crate.h"

using namespace std;

class Ship
{
public:
	const int Id;
	stack<Crate> Crates;

	explicit Ship(const int id);
	void AddCrate(const Crate& crate);
	Crate RemoveCrate();
	string GetCratesString() const;
};

