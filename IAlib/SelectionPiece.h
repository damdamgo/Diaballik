#pragma once
#include "utils.h"
#include "Coordinate.h"

class SelectionPiece {

private:
	int** board;
	int sizeBoard;
public:
	SelectionPiece(int** board, int sizeBoard);
	std::vector<Coordinate> possibleDestinationPiece(Coordinate &piece);
};