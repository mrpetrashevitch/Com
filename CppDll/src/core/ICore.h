#pragma once
#include <initguid.h>
#include <objbase.h>

class ICore : public IUnknown
{
public:
	virtual int __stdcall sum(int x, int y) = 0;
	virtual int __stdcall sum(int x, int y, void(__stdcall* progress_func)(double progress)) = 0;
};