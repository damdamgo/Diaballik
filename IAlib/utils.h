#pragma once
#include <stdlib.h>
#include <time.h>
#include <vector>

using namespace std;

#define DLL __declspec(dllexport)


enum TileType {
	TileEmpty = 0,
	PieceJ1 = 1,
	PieceJ2 = 2,
	BallJ1 = 3,
	BallJ2 = 4
};

