#include "SelectionBall.h"

SelectionBall::SelectionBall(int** board, int sizeBoard) {
	this->board = board;
	this->sizeBoard = sizeBoard;
}



/**
	Méthode permettant de récupérer les coordonnés de la Balle d'un joueur

	@param player Numero du joueur

	@return Cordinate contenant la position x et y de la balle
*/
Coordinate SelectionBall::getBall(int player) {
	for (int line = 0; line < this->sizeBoard; line++) {
		for (int column = 0; column < this->sizeBoard; column++) {
			if (this->board[line][column] == player + 2)
				return Coordinate(line, column);
		}
	}
}


/**
	Méthode permettant de récupérer toutes les destinations possibles de la balle

	@param player Numero du joueur

	@return Vector de Coordiante contenant toutes les destinations possibles de la balle
*/
std::vector<Coordinate> SelectionBall::possibleDestinationBall(int player) {
	Coordinate ball = this->getBall(player);
	std::vector<Coordinate> listPossiblePositionBall;
	int playerEnnemi = player == 1 ? 2 : 1;
	int diagLine;
	int diagColumn;
	//Verification line west
	for (int column = ball.getColumn(); column >= 0; column--) {
		if (this->board[ball.getLine()][column] == player) {
			listPossiblePositionBall.push_back(Coordinate(ball.getLine(), column));
			break;
		}
		else if (this->board[ball.getLine()][column] == playerEnnemi) {
			break;
		}
	}

	//Verification line north
	for (int line = ball.getLine(); line >= 0; line--) {
		if (this->board[line][ball.getColumn()] == player) {
			listPossiblePositionBall.push_back(Coordinate(line, ball.getColumn()));
			break;
		}
		else if (this->board[line][ball.getColumn()] == playerEnnemi) {
			break;
		}
	}

	//Verification line east
	for (int column = ball.getColumn(); column < this->sizeBoard; column++) {
		if (this->board[ball.getLine()][column] == player) {
			listPossiblePositionBall.push_back(Coordinate(ball.getLine(), column));
			break;
		}
		else if (this->board[ball.getLine()][column] == playerEnnemi) {
			break;
		}
	}

	//Verification line south
	for (int line = ball.getLine(); line <this->sizeBoard; line++) {
		if (this->board[line][ball.getColumn()] == player) {
			listPossiblePositionBall.push_back(Coordinate(line, ball.getColumn()));
			break;
		}
		else if (this->board[line][ball.getColumn()] == playerEnnemi) {
			break;
		}
	}
	//Verification diag north-west
	diagLine = ball.getLine();
	diagColumn = ball.getColumn();
	while (diagLine >= 0 && diagColumn >= 0 && diagLine <this->sizeBoard && diagColumn<this->sizeBoard) {
		diagLine--;
		diagColumn--;
		if (diagLine < 0 || diagLine >= 7 || diagColumn < 0 || diagColumn >= 7)
			break;
		else if (diagLine < 0 || diagLine >= 7 || diagColumn < 0 || diagColumn >= 7)
			break;
		else if (this->board[diagLine][diagColumn] == player) {
			listPossiblePositionBall.push_back(Coordinate(diagLine, diagColumn));
			break;
		}
		else if (this->board[diagLine][diagColumn] == playerEnnemi) {
			break;
		}
	}

	//Verification diag north-east
	diagLine = ball.getLine();
	diagColumn = ball.getColumn();
	while (diagLine >= 0 && diagColumn >= 0 && diagLine <this->sizeBoard && diagColumn<this->sizeBoard) {
		diagLine--;
		diagColumn++;
		if (diagLine < 0 || diagLine >= 7 || diagColumn < 0 || diagColumn >= 7)
			break;
		else if (this->board[diagLine][diagColumn] == player) {
			listPossiblePositionBall.push_back(Coordinate(diagLine, diagColumn));
			break;
		}
		else if (this->board[diagLine][diagColumn] == playerEnnemi) {
			break;
		}
	}

	//Verification diag south-east
	diagLine = ball.getLine();
	diagColumn = ball.getColumn();
	while (diagLine >= 0 && diagColumn >= 0 && diagLine <this->sizeBoard && diagColumn<this->sizeBoard) {
		diagLine++;
		diagColumn++;
		if (diagLine < 0 || diagLine >= 7 || diagColumn < 0 || diagColumn >= 7)
			break;
		else if (this->board[diagLine][diagColumn] == player) {
			listPossiblePositionBall.push_back(Coordinate(diagLine, diagColumn));
			break;
		}
		else if (this->board[diagLine][diagColumn] == playerEnnemi) {
			break;
		}
	}

	//Verification diag south-west
	diagLine = ball.getLine();
	diagColumn = ball.getColumn();
	while (diagLine >= 0 && diagColumn >= 0 && diagLine <this->sizeBoard && diagColumn<this->sizeBoard) {
		diagLine++;
		diagColumn--;
		if (diagLine < 0 || diagLine >= 7 || diagColumn < 0 || diagColumn >= 7)
			break;
		else if (this->board[diagLine][diagColumn] == player) {
			listPossiblePositionBall.push_back(Coordinate(diagLine, diagColumn));
			break;
		}
		else if (this->board[diagLine][diagColumn] == playerEnnemi) {
			break;
		}
	}

	return listPossiblePositionBall;


}