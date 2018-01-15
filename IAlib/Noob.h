#pragma once
#include "utils.h"
#include "Coordinate.h"
#include "SelectionBall.h"
#include "SelectionPiece.h"

class Noob {

public:
	Noob(int** board, int sizeBoard, int player);

	std::vector<Coordinate> play();

private:
	int** board;
	int sizeBoard;
	int player;

	int numberMove();
	int choosePieceOrBall();
	Coordinate choosePiece();
	std::vector<Coordinate> chooseDestinationPiece();
	std::vector<Coordinate> chooseDestinationBall();
	void playTurn(std::vector<Coordinate> &action);
	std::vector<Coordinate> playAction();

};
