#include "core.h"
#include <urlmon.h>

namespace core
{
	HRESULT __stdcall core::QueryInterface(REFIID riid, void** ppObj)
	{
		if (riid == IID_IUnknown)
		{
			*ppObj = this;
			AddRef();

			// ѕри уничтожении класса core, clr выполн€ет лишний вызов высвобождени€ ресурсов core::Release(). 
			// ≈сли не добавить лишнюю ссылку, то произойдет исключение в 36 строке при попытке удалить уже не существующий класс.
			AddRef();
			return S_OK;
		}
		if (riid == IID_ICore)
		{
			*ppObj = this;
			AddRef();
			return S_OK;
		}
		*ppObj = NULL;
		return E_NOINTERFACE;
	}
	ULONG __stdcall core::AddRef()
	{
		return InterlockedIncrement(&_ref_this);
	}
	ULONG __stdcall core::Release()
	{
		int nRefCount = 0;
		nRefCount = InterlockedDecrement(&_ref_this);
		if (nRefCount == 0)
			delete this;
		return nRefCount;
	}

	int __stdcall core::sum(int x, int y)
	{
		return sum(x, y, nullptr);
	}

	int __stdcall core::sum(int x, int y, void(__stdcall* progress_func)(double progress))
	{
		for (int i = 0; i < 100; i++)
		{
			Sleep(50);
			if (progress_func) progress_func(0.01 * (i + 1));
		}
		return x + y;
	}
}
