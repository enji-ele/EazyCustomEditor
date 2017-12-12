/*=============================================================================
Project Name    : EazyCustomEditor
File Name       : ECTagName
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

[AttributeUsage(AttributeTargets.Field)]
public class ECTagName : ECPropertyAttribute
{
	public ECTagName() : this(null, null)
	{

	}
	public ECTagName(string title_jp) : this(title_jp, null)
	{

	}
	public ECTagName(string title_jp, string title_en) : base(title_jp, title_en)
	{
		
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ECTagName))]
public class ECTagNameDrawer : ECPropertyDrawer
{
	protected override void CustomGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		TagField();
    }
}
#endif