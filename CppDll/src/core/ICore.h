#pragma once
#include <initguid.h>
#include <objbase.h>

enum class core_callback_type : unsigned int
{
	status,
	progress,
};

class ICore : public IUnknown
{
public:
	virtual int __stdcall sum(int x, int y, void(__stdcall* progress_func)(double progress)) = 0;
};