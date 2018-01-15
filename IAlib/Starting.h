#pragma once
#include "utils.h"
#include "Coordinate.h"
#include "SelectionBall.h"
#include "SelectionPiece.h"

class Starting {

public:
	Starting(int** board, int sizeBoard, int player);

	std::vector<Coordinate> play();



private :
	int** board;
	int sizeBoard;
	int player;

	vector<Coordinate> findPotentielPieceToBlock();
	Coordinate findPieceToBlock();
	Coordinate choosePieceFromMinimumDistanceToPieceToBlock(Coordinate ennemyPosition);
	vector<Coordinate> choosedestinationPieceWhoBlock(Coordinate piecesToBlock);
	Coordinate positionWhoBlockEnnemyPiece(Coordinate positionEnnemyPiece);
	vector<Coordinate> Starting::chooseDestinationBall();
	void playTurn(std::vector<Coordinate> &action);

};
