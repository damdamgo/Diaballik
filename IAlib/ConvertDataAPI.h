#pragma once
#include "utils.h"
#include "Coordinate.h"

class  ConvertDataAPi {
public:
	static int** ConvertCSToCPP(int* board, int size);
	static void ConvertCPPToCSP(int* res, int** board, vector<Coordinate> moves, int size,int sizeMax);

};



