#include "SelectionPiece.h"

SelectionPiece::SelectionPiece(int** board, int sizeBoard) {
	this->board = board;
	this->sizeBoard = sizeBoard;
}


/**
	Méthode permettant de récupérer toutes les destinations possibles de la piece

	@param player Numero du joueur

	@return Vector de Coordiante contenant toutes les destinations possibles de la piece
*/
std::vector<Coordinate> SelectionPiece::possibleDestinationPiece(Coordinate &piece) {
	std::vector<Coordinate> destinationPiece;

	if (piece.getLine() - 1 >=0 && this->board[piece.getLine() - 1][piece.getColumn()] == TileEmpty)
		destinationPiece.push_back(Coordinate(piece.getLine() - 1, piece.getColumn()));
	if (piece.getColumn() - 1 >=0 && this->board[piece.getLine()][piece.getColumn() - 1] == TileEmpty)
		destinationPiece.push_back(Coordinate(piece.getLine(), piece.getColumn() - 1));
	if (piece.getLine() + 1 < this->sizeBoard && this->board[piece.getLine() + 1][piece.getColumn()] == TileEmpty)
		destinationPiece.push_back(Coordinate(piece.getLine() + 1, piece.getColumn()));
	if (piece.getColumn() + 1 < this->sizeBoard && this->board[piece.getLine()][piece.getColumn() + 1] == TileEmpty)
		destinationPiece.push_back(Coordinate(piece.getLine(), piece.getColumn() + 1));
	return destinationPiece;



}
