#pragma once
#include "utils.h"
#include "Coordinate.h"
#include "SelectionBall.h"
#include "SelectionPiece.h"

class Progressive {

public:
	Progressive(int** board, int sizeBoard, int player,int numTurn);

	std::vector<Coordinate> play();



private:
	int** board;
	int sizeBoard;
	int player;
	int numTurn;


};
