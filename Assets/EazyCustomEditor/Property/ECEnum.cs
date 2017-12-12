/*=============================================================================
Project Name    : EazyCustomEditor
File Name       : ECEnum
Creation Date   : 2017/12/05
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

using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif 

[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
public class ECEnum : ECPropertyAttribute
{
	public ECEnum() : this(null, null)
	{

	}
	public ECEnum(string title_jp) : this(title_jp, null)
	{

	}
	public ECEnum(string title_jp, string title_en) : base(title_jp, title_en)
	{

	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ECEnum))]
public class ECEnumDrawer : ECPropertyDrawer
{
	protected override void CustomGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EnumField();
	}
}
#endif