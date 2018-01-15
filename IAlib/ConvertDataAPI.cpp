#include "ConvertDataAPI.h"

/**
	M�thode static permettant de convertir un tableau 1 dimension en tableau 2 dimension

	@param board Plateau de jeu en 1 dimension
	@param size Taille du plateau de jeu

	@return Le tableau 2D du plateau de jeu

*/
int ** ConvertDataAPi::ConvertCSToCPP(int* board, int size) {
	int** res = new int*[size];
	for (int i = 0; i < size; ++i)
		res[i] = new int[size];
	for (int i = 0; i < size; ++i)
		for (int j = 0; j < size; ++j)
			res[i][j] = board[i*size + j];
	return res;
}
/**
	M�thode static permettant de convertir les r�sultats des IA, ou des d�placement possible (vector<Cordinate> -> int *)

	@param res Tableau contenant les r�sultat qui sera renvoy� au C#
	@param board Tableau 2D du plateau de jeu
	@param moves Vector contenant les coordonn�s d�placement possibles
	@param size Taille du plateau
	@param sizeMax Taille maximum de coordonn�s possible
*/
void ConvertDataAPi::ConvertCPPToCSP(int* res, int** board, vector<Coordinate> moves, int size,int sizeMax) {

	int moveWriter = 0;
	for (int i = 0; i < moves.size(); ++i) {
		res[moveWriter] = moves[i].getLine();
		moveWriter++;
		res[moveWriter] = moves[i].getColumn();
		moveWriter++;
	}

	for (; moveWriter < sizeMax; moveWriter++) {
		res[moveWriter] = -1;
	}

	for (int i = 0; i < size; ++i) {
		delete[] board[i];
	}
	delete[] board;
}