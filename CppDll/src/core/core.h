#pragma once
#include "ICore.h"
#include <Windows.h>

namespace core
{
	class core : public ICore
	{
		const IID IID_ICore = { 268435456,0,0,{192,0,0,0,0,0,0,70} };// guid core
		DWORD _ref_this = 0;
	public:
		// interface COM
		HRESULT __stdcall QueryInterface(REFIID riid, void** ppv) override;
		ULONG __stdcall AddRef() override;
		ULONG __stdcall Release() override;

		// interface ICore
		int __stdcall sum(int x, int y, void(__stdcall* progress_func)(double progress)) override;
	};
}

extern "C" __declspec(dllexport) ICore * __stdcall create_core()
{
	return new core::core;
}

