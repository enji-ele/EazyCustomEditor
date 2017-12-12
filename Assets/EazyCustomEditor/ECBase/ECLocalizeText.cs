/*=============================================================================
Project Name    : EazyCustomEditor
File Name       : ECLocalizeText
Creation Date   : 2017/12/08
Lastest Update  : 2017/12/08

Copyright 2017 @ele_enji. All rights reserved.

https://github.com/enji-ele/EazyCustomEditor

===============================================================================

MIT License

Copyright (c) 2017 @enji_ele

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER	
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
===============================================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECLocalizeText
{
	private string text_jp;
	private string text_en;

	public ECLocalizeText() : this(null, null)
	{
		
	}
	public ECLocalizeText(string text_jp) : this(text_jp, null)
	{
		
	}
	public ECLocalizeText(string text_jp, string text_en)
	{
		this.text_jp = text_jp;
		this.text_en = text_en;
	}

	public string text
	{
		get {
			if (text_en != null && Application.systemLanguage != SystemLanguage.Japanese)
				return text_en;
			else return text_jp;
		}
	}
}
