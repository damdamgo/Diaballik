#include "utils.h"
#include "Starting.h"
#include <iostream>



Starting::Starting(int** board, int sizeBoard, int player) {
	this->board = board;
	this->sizeBoard = sizeBoard;
	this->player = player;
	srand(time(NULL));
}


/**
	M�thode permettant de rep�rer les pieces ennemy potentiel � bloquer

	@return position des pieces ennemie � blocker
*/
vector<Coordinate> Starting::findPotentielPieceToBlock() {
	int ennemy = this->player == 1 ? 2 : 1;
	std::vector<Coordinate> potentielPieceToBlock;
	if (this->player == 1) {
		for (int line = 0; line <this->sizeBoard; line++) {
			for (int column = 0; column < this->sizeBoard; column++) {
				if (this->board[line][column] == ennemy) {
					potentielPieceToBlock.push_back(Coordinate(line, column));
				}
			}
			if (!potentielPieceToBlock.empty())
				break;
		}
	}
	else {
		for (int line = this->sizeBoard-1; line >=0; line--) {
			for (int column = 0; column < this->sizeBoard; column++) {
				if (this->board[line][column] == ennemy) {
					potentielPieceToBlock.push_back(Coordinate(line, column));
				}
			}
			if (!potentielPieceToBlock.empty())
				break;
		}
	}
	return potentielPieceToBlock;

}

/**
	M�thode permettant de rep�rer la piece pr�cise � bloquer pendant cette action

	@return Position de la piece � bloquer (position -1,-1 si aucune piece n'est � bloquer)
*/
Coordinate Starting::findPieceToBlock() {
	vector<Coordinate> pieceToBlock = this->findPotentielPieceToBlock();
	for (int i = 0; i < pieceToBlock.size(); i++) {
		if (this->player == 1 && pieceToBlock[i].getLine() - 1 >= 0 && this->board[pieceToBlock[i].getLine() - 1][pieceToBlock[i].getColumn()] == TileEmpty) {
		return pieceToBlock[i];
	}
	else if (this->player == 2 && pieceToBlock[i].getLine() + 1 < this->sizeBoard && this->board[pieceToBlock[i].getLine() + 1][pieceToBlock[i].getColumn()] == TileEmpty)
			return pieceToBlock[i];
	}
	return Coordinate();
}

/**
	M�thode permettant de r�cup�rer la piece allier la plus proche de la piece ennemie � bloquer 

	@param Position de la piece ennemie

	@return Position de la piece allier � utiliser pour bloquer la piece ennemie
*/
Coordinate Starting::choosePieceFromMinimumDistanceToPieceToBlock(Coordinate ennemyPosition) {
	int distance;
	int minDistance = 10;
	Coordinate positionPiece;
	if (this->player == 1) {
		for (int line = 0; line < this->sizeBoard; line++) {
			for (int column = 0; column < this->sizeBoard; column++) {
				if (this->board[line][column] == this->player && this->board[line + 1][column] != 2) {
					distance = abs(line - (ennemyPosition.getLine() -1)) + abs( column - ennemyPosition.getColumn());
					if (distance < minDistance) {
						minDistance = distance;
						positionPiece.setLine(line);
						positionPiece.setColumn(column);
					}
				}
			}
		}
	}
	else if(this->player == 2) {
		for (int line = 0; line < this->sizeBoard; line++) {
			for (int column = 0; column < this->sizeBoard; column++) {
				if (this->board[line][column] == this->player && this->board[line-1][column] != 1) {
					distance = abs(line - (ennemyPosition.getLine() + 1)) + abs(column - ennemyPosition.getColumn());
					if (distance < minDistance) {
						minDistance = distance;
						positionPiece.setLine(line);
						positionPiece.setColumn(column);
					}
				}
			}
		}
	}
	return positionPiece;
}

/**
	M�thode permettant de r�cup�rer la position de la case o� il doit aller pour bloquer la piece ennemy

	@param Position de la piece ennemie

	@return Position de la case o� aller pour la piece allier pour bloquer la piece ennemie
*/
Coordinate Starting::positionWhoBlockEnnemyPiece(Coordinate positionEnnemyPiece) {
	if (this->player == 1) {
		return Coordinate(positionEnnemyPiece.getLine() - 1, positionEnnemyPiece.getColumn());
	}
	else {
		return Coordinate(positionEnnemyPiece.getLine() + 1, positionEnnemyPiece.getColumn());
	}
}

/**
	M�thode permettant de r�cup�rer la destination de la piece � bouger


	@return vector de la position initial de la piece � bouger puis de sa position final
*/
vector<Coordinate> Starting::choosedestinationPieceWhoBlock(Coordinate pieceToBlock) {
	Coordinate pieceToMove = this->choosePieceFromMinimumDistanceToPieceToBlock(pieceToBlock);
	vector<Coordinate> destinationPieceToMove;
	destinationPieceToMove.push_back(pieceToMove);
	Coordinate positionToGo = this->positionWhoBlockEnnemyPiece(pieceToBlock);
	int line;
	int column;

	line = positionToGo.getLine() - pieceToMove.getLine();
	column = positionToGo.getColumn() - pieceToMove.getColumn();

	if (line > 0) {
		if (this->board[pieceToMove.getLine() + 1][pieceToMove.getColumn()] == TileEmpty) {
			destinationPieceToMove.push_back(Coordinate(pieceToMove.getLine() + 1, pieceToMove.getColumn()));
			return destinationPieceToMove;
		}
	}
	else if (line == 0) {
		if (column < 0 && this->board[pieceToMove.getLine()][pieceToMove.getColumn() - 1] == TileEmpty) {
			destinationPieceToMove.push_back(Coordinate(pieceToMove.getLine(), pieceToMove.getColumn() - 1));
			return destinationPieceToMove;
		}
		else if (column > 0 && this->board[pieceToMove.getLine()][pieceToMove.getColumn() + 1] == TileEmpty) {
			destinationPieceToMove.push_back(Coordinate(pieceToMove.getLine(), pieceToMove.getColumn() + 1));
			return destinationPieceToMove;
		}
	}
	else {
		if (this->board[pieceToMove.getLine() - 1][pieceToMove.getColumn()] == TileEmpty) {
			destinationPieceToMove.push_back(Coordinate(pieceToMove.getLine() - 1, pieceToMove.getColumn()));
			return destinationPieceToMove;
		}
	}
}

/**
	M�thode permettant de choisir al�atoirement la destination de la balle


	@return vector de la position initial de la balle et de sa destination
*/
vector<Coordinate> Starting::chooseDestinationBall() {
	vector<Coordinate> cordinateTurnBall;
	SelectionBall selectBall(this->board, this->sizeBoard);
	vector<Coordinate> possibleDestinationBall = selectBall.possibleDestinationBall(this->player);
	int numRandomCoordinate = rand() % possibleDestinationBall.size();
	cordinateTurnBall.push_back(selectBall.getBall(this->player));
	cordinateTurnBall.push_back(possibleDestinationBall[numRandomCoordinate]);
	return cordinateTurnBall;
}

/**
	M�thode effectuant le d�roulement de l'action sur le plateau de jeu (int** board) pour permettre de continuer les prochaines actions avec les modifications sur le plateau

	@param action Vector de Coordinate qui contient les coordonn�es initial et la destination de la piece/balle � bouger
*/
void Starting::playTurn(std::vector<Coordinate> &action) {
	if (this->board[action[0].getLine()][(action[0]).getColumn()] == this->player + 2) {
		this->board[action[0].getLine()][(action[0]).getColumn()] = this->player;
		this->board[(action[1]).getLine()][(action[1]).getColumn()] = this->player + 2;
	}
	else {
		this->board[action[0].getLine()][action[0].getColumn()] = 0;
		this->board[action[1].getLine()][action[1].getColumn()] = this->player;
	}
}

/**
	M�thode effectuant le d�roulement de tout le tour de jeu de l'IAStarting

	@return Vector contenant tous les actions effectu�es pendant le tour
*/
std::vector<Coordinate> Starting::play() {
	vector<Coordinate> turn;
	
	for (int i = 0; i < 3; i++) {
		Coordinate pieceToBlock = this->findPieceToBlock();
		if (pieceToBlock.getLine() == -1 && pieceToBlock.getColumn() == -1) {
			break;
		}
		else {
			std::vector<Coordinate> action = choosedestinationPieceWhoBlock(pieceToBlock);
				
			turn.insert(turn.end(), action.begin(), action.end());
			this->playTurn(action);
		}
	}

	if (turn.empty()) {
		std::vector<Coordinate> action = this->chooseDestinationBall();
		turn.insert(turn.end(), action.begin(), action.end());
	}

	return turn;

}









