// DivDLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "DivDLL.h"

double _stdcall div(double a, double b)
{
	return a / b;
}


