#include "Coordinate.h"

Coordinate::Coordinate() {
	this->line = -1;
	this->column = -1;
}

Coordinate::Coordinate(int line, int column) {
	this->line = line;
	this->column = column;
}
int Coordinate::getLine() { return this->line; }
int Coordinate::getColumn() { return this->column; }

void Coordinate::setLine(int line) { this->line = line; }
void Coordinate::setColumn(int column) { this->column = column; }