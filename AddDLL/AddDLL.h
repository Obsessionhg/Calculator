#pragma once
#ifndef _DECL
#define _DECL _declspec(dllexport)
#endif // !_DECL

extern "C" _DECL double _stdcall add(double a, double b);
