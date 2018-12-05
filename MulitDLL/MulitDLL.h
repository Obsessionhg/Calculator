#pragma once

#ifndef _DECL
#define _DECL _declspec(dllimport)
#endif // !_DECL

extern "C" _DECL double _stdcall mulit(double a, double b);

