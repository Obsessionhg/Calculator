// SubDLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "SubDLL.h"

double _stdcall sub(double a, double b) 
{
	return a - b;
}

