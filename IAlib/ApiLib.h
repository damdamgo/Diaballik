#pragma once
#include "utils.h"

#define EXPORTCDECL extern "C" DLL

class ApiLib {
public:
	void play_Noob(int* board, int sizeBoard, int player, int* res);
	void play_selectionPiece(int * board, int sizeBoard, int linePiece, int columnPiece, int* res);
	void play_selectionBall(int * board, int sizeBoard, int player, int* res);
	void play_Starting(int* board, int sizeBoard, int player, int* res);
	void play_Progressive(int* board, int sizeBoard, int player, int* res, int numTurn);

};

EXPORTCDECL ApiLib* createAPI();

EXPORTCDECL void removeAPI(ApiLib* api);

EXPORTCDECL void play_Noob(ApiLib* api, int* board, int sizeBoard, int player, int* res);

EXPORTCDECL void play_Starting(ApiLib* api, int* board, int sizeBoard, int player, int* res);

EXPORTCDECL void play_Progressive(ApiLib* api, int* board, int sizeBoard, int player, int* res, int numTurn);

EXPORTCDECL void play_selectionPiece(ApiLib* api, int * board, int sizeBoard, int linePiece, int columnPiece, int* res);

EXPORTCDECL void play_selectionBall(ApiLib* api, int * board, int sizeBoard, int player, int* res);

//API
