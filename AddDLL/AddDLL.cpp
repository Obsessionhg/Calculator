// AddDLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "AddDLL.h"

double _stdcall add(double a, double b)
{
	return a + b;
}

