#pragma once
#include "utils.h"
#include "Coordinate.h"

class SelectionBall {

private:
	int** board;
	int sizeBoard;


public:
	SelectionBall(int** board, int sizeBoard);
	Coordinate getBall(int player);
	std::vector<Coordinate> possibleDestinationBall(int player);
};