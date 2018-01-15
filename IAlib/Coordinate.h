#pragma once
#include "utils.h"


class Coordinate {
	int line;
	int column;

public:
	Coordinate(int line, int column);
	Coordinate();
	int getLine();
	int getColumn();
	void setLine(int line);
	void setColumn(int column);
};