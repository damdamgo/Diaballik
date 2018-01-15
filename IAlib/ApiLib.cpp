#include "ApiLib.h"
#include "Noob.h"
#include "Starting.h"
#include "Progressive.h"
#include "ConvertDataAPI.h"





//API



/**
	M�thode de l'API permettant de r�cup�rer les coordonn�es des actions d'un tour de l'IA Noob

	@param board Tableau 1 dimension contenant le plateau de jeu
	@param sizeBoard Taille du plateau
	@param player Num�ro du joueur
	@param res Tableau 1D contenant les r�sultats des actions du tour de jeu de l'IA Noob
	
*/
void ApiLib::play_Noob(int* board,int sizeBoard,int player,int* res) {
	int** board2D = ConvertDataAPi::ConvertCSToCPP(board, sizeBoard);
	Noob noobAI(board2D, sizeBoard, player);
	vector<Coordinate> moveAINoob = noobAI.play();
	ConvertDataAPi::ConvertCPPToCSP(res, board2D, moveAINoob, sizeBoard,12);
}

/**
	M�thode de l'API permettant de r�cup�rer les coordonn�es des actions d'un tour de l'IA Starting

	@param board Tableau 1 dimension contenant le plateau de jeu
	@param sizeBoard Taille du plateau
	@param player Num�ro du joueur
	@param res Tableau 1D contenant les r�sultats des actions du tour de jeu de l'IA Starting

*/
void ApiLib::play_Starting(int* board, int sizeBoard, int player, int* res) {
	int** board2D = ConvertDataAPi::ConvertCSToCPP(board, sizeBoard);
	Starting startingIA(board2D, sizeBoard, player);
	vector<Coordinate> moveAIStarting = startingIA.play();
	ConvertDataAPi::ConvertCPPToCSP(res, board2D, moveAIStarting, sizeBoard, 12);
}

/**
	M�thode de l'API permettant de r�cup�rer les coordonn�es des actions d'un tour de l'IA Progressive

	@param board Tableau 1 dimension contenant le plateau de jeu
	@param sizeBoard Taille du plateau
	@param player Num�ro du joueur
	@param res Tableau 1D contenant les r�sultats des actions du tour de jeu de l'IA Noob
	@param numTurn Num�ro du tour de jeu du joueur

*/
void ApiLib::play_Progressive(int* board, int sizeBoard, int player, int* res, int numTurn) {
	int** board2D = ConvertDataAPi::ConvertCSToCPP(board, sizeBoard);
	Progressive progressiveIA(board2D, sizeBoard, player,numTurn);
	vector<Coordinate> moveAIProgressive = progressiveIA.play();
	ConvertDataAPi::ConvertCPPToCSP(res, board2D, moveAIProgressive, sizeBoard, 12);
}

/**
	M�thode de l'API permettant de r�cup�rer les coordonn�es de destination possible d'une piece

	@param board Tableau 1 dimension contenant le plateau de jeu
	@param sizeBoard Taille du plateau
	@param linePiece Num�ro de ligne de la pi�ce
	@param columnLine Num�ro de colonne de la pi�ce
	@param res Tableau 1D contenant les destinations possibles de la pi�ce

*/
void ApiLib::play_selectionPiece(int * board, int sizeBoard, int linePiece, int columnPiece, int* res) {
	int** board2D = ConvertDataAPi::ConvertCSToCPP(board, sizeBoard);
	SelectionPiece selectPiece(board2D, sizeBoard);
	Coordinate coordinatePiece(linePiece, columnPiece);
	vector<Coordinate> possibleMovePiece = selectPiece.possibleDestinationPiece(coordinatePiece);
	ConvertDataAPi::ConvertCPPToCSP(res, board2D, possibleMovePiece, sizeBoard, 8);
}

/**
	M�thode de l'API permettant de r�cup�rer les coordonn�es de destination possible d'une balle

	@param board Tableau 1 dimension contenant le plateau de jeu
	@param sizeBoard Taille du plateau
	@param player Num�ro du joueur
	@param res Tableau 1D contenant les destinations possibles de la balle

*/
void ApiLib::play_selectionBall(int * board, int sizeBoard, int player, int* res) {
	int** board2D = ConvertDataAPi::ConvertCSToCPP(board, sizeBoard);
	SelectionBall selectBall(board2D, sizeBoard);
	vector<Coordinate> possibleMovePiece = selectBall.possibleDestinationBall(player);
	ConvertDataAPi::ConvertCPPToCSP(res, board2D, possibleMovePiece, sizeBoard, 16);
}

//API
//
//D�finition de toutes les portes d'acc�s de l'API
//

EXPORTCDECL ApiLib* createAPI() {
	return new ApiLib();
}

EXPORTCDECL void removeAPI(ApiLib* api) {
	delete api;
}

EXPORTCDECL void play_Noob(ApiLib* api, int* board, int sizeBoard, int player, int* res) {
	api->play_Noob(board,sizeBoard,player,res);
}

EXPORTCDECL void play_Starting(ApiLib* api, int* board, int sizeBoard, int player, int* res) {
	api->play_Starting(board, sizeBoard, player, res);
}

EXPORTCDECL void play_Progressive(ApiLib* api, int* board, int sizeBoard, int player, int* res, int numTurn) {
	api->play_Progressive(board, sizeBoard, player, res, numTurn);
}

EXPORTCDECL void play_selectionPiece(ApiLib* api, int * board, int sizeBoard, int linePiece, int columnPiece, int* res) {
	api->play_selectionPiece(board, sizeBoard, linePiece, columnPiece, res);
}

EXPORTCDECL void play_selectionBall(ApiLib* api, int * board, int sizeBoard, int player, int* res) {
	api->play_selectionBall(board, sizeBoard, player, res);
}










