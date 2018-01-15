#include "utils.h"
#include "Progressive.h"
#include "Noob.h"
#include "Starting.h"
#include <iostream>



Progressive::Progressive(int** board, int sizeBoard, int player, int numTurn) {
	this->board = board;
	this->sizeBoard = sizeBoard;
	this->player = player;
	this->numTurn = numTurn;
	srand(time(NULL));
}

vector<Coordinate> Progressive::play() {
	if (this->numTurn < 10) {
		Noob noobIA(this->board, this->sizeBoard, this->player);
		return noobIA.play();
	}
	else {
		Starting startingIA(this->board, this->sizeBoard, this->player);
		return startingIA.play();
	}
}