#include "utils.h"
#include "Noob.h"


Noob::Noob(int** board, int sizeBoard, int player) {
	this->board = board;
	this->sizeBoard = sizeBoard;
	this->player = player;
	srand(time(NULL));
}

/**
	Méthode permettant de connaitre le nombre d'action de l'IA pendant le tour de jeu

	@return Nombre d'action entre 1 et 3

*/
int Noob::numberMove() {
	return (rand() % 3 + 1);
}





/**
	Méthode permettant de décidé le type de la piece joué pendant le tour (piece ou ball)

	@return 1 -> balle / 0 -> piece

*/
int Noob::choosePieceOrBall() {
	return rand() % 2 == 0 ? 1 : 0;
}


/**
	Méthode permettant de choisir aléatoirement la pièce qui va effectuer l'action

	@return Coordinate correspondant à la position de la piece selectionné aléatoirement
*/
Coordinate Noob::choosePiece() {

	int numberPiece = rand() % (this->sizeBoard-1);

	for (int line = 0; line < this->sizeBoard; line++) {
		for (int column = 0; column < this->sizeBoard; column++) {
			if (this->board[line][column] == this->player) {
				if (numberPiece != 0)
					numberPiece--;
				else
					return Coordinate(line, column);
			}
		}
	}

}




/**
	Méthode permettant d'effectuer le tirage aléatoire de la destination de la Piece parmis ses destinations possibles

	@return Vector de Coordinate : le 1er est la position initiale de la piece, le 2nd est la destination de la piece
*/
std::vector<Coordinate> Noob::chooseDestinationPiece() {
	std::vector<Coordinate> cordinateTurnPiece;
	Coordinate positionPieceInitial(-1, -1);
	std::vector<Coordinate> possibleDestinationPiece;
	Coordinate positionPieceFinal(-1, -1);
	SelectionPiece selectPiece(this->board, this->sizeBoard);
	while (true) {
		positionPieceInitial = this->choosePiece();
		if (!selectPiece.possibleDestinationPiece(positionPieceInitial).empty()) {
			possibleDestinationPiece = selectPiece.possibleDestinationPiece(positionPieceInitial);
			positionPieceFinal = possibleDestinationPiece[rand() % possibleDestinationPiece.size()];
			break;
		}
	}

	cordinateTurnPiece.push_back(positionPieceInitial);
	cordinateTurnPiece.push_back(positionPieceFinal);
	return cordinateTurnPiece;
}


/**
	Méthode permettant d'effectuer le tirage aléatoire de la destination de la Balle parmis ses destinations possibles

	@return Vector de Coordinate : le 1er est la position initiale de la Balle, le 2nd est la destination de la Balle
*/
std::vector<Coordinate> Noob::chooseDestinationBall() {
	std::vector<Coordinate> cordinateTurnBall;
	SelectionBall selectBall(this->board, this->sizeBoard);
	std::vector<Coordinate> possibleDestinationBall = selectBall.possibleDestinationBall(this->player);
	int numRandomCoordinate = rand() % possibleDestinationBall.size();
	cordinateTurnBall.push_back(selectBall.getBall(this->player));
	cordinateTurnBall.push_back(possibleDestinationBall[numRandomCoordinate]);
	return cordinateTurnBall;
}

/**
	Méthode effectuant le déroulement de l'action sur le plateau de jeu (int** board) pour permettre de continuer les prochaines actions avec les modifications sur le plateau

	@param action Vector de Coordinate qui contient les coordonnées initial et la destination de la piece/balle à bouger
*/
void Noob::playTurn(std::vector<Coordinate> &action) {
	if (this->board[action[0].getLine()][(action[0]).getColumn()] == this->player + 2) {
		this->board[action[0].getLine()][(action[0]).getColumn()] = this->player;
		this->board[(action[1]).getLine()][(action[1]).getColumn()] = this->player + 2;
	}
	else {
		this->board[action[0].getLine()][action[0].getColumn()] = 0;
		this->board[action[1].getLine()][action[1].getColumn()] = this->player;
	}
}




//Si jamais la balle est choisit mais qu'elle ne peut pas bouger on déplace une piece à sa place
/**
	Méthode choississant la piece ou ball à jouer puis sa destination, et enfin effectue l'action sur le plateau de jeu
	Si jamais la balle est choisie mais qu'elle ne peut pas bouger on déplace une piece à sa place

	@return Vector contenant l'action du tour, position initial et destination de la piece/balle

*/
std::vector<Coordinate> Noob::playAction() {
	std::vector<Coordinate> action;
	int tile = this->choosePieceOrBall();
	if (this->choosePieceOrBall()) {
		action = chooseDestinationBall();
	}
	if (!tile || action.empty()) {
		action = chooseDestinationPiece();
	}
	this->playTurn(action);
	return action;
}

/**
	Méthode effectuant le déroulement de tout le tour de jeu de l'IANoob

	@return Vector contenant tous les actions effectuées pendant le tour

*/
std::vector<Coordinate> Noob::play() {
	std::vector<Coordinate> turn;
	int numAction = this->numberMove();
	for (int i = 0; i < numAction; i++) {
		std::vector<Coordinate> action = this->playAction();

		turn.insert(turn.end(), action.begin(), action.end());


	}
	return turn;
}

