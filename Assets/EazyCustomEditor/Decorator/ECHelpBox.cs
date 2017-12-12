/*=============================================================================
Project Name    : EazyCustomEditor
File Name       : ECHelpBox
Creation Date   : 2017/12/11
Lastest Update  : 2017/12/11

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

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class ECHelpBox : ECPropertyAttribute {

	public MessageType Type;
	public float LeftSpace;
	public float RightSpace;

	public ECHelpBox(string message_jp)                                                                                       : this(message_jp,       null,        -1,         -1, MessageType.None)
	{

	}
	public ECHelpBox(string message_jp, MessageType type)                                                                     : this(message_jp,       null,        -1,         -1, type)
	{

	}
	public ECHelpBox(string message_jp, float leftSpace, float rightSpace)                                                    : this(message_jp,       null, leftSpace, rightSpace, MessageType.None)
	{

	}
	public ECHelpBox(string message_jp, float leftSpace, float rightSpace, MessageType type)                                  : this(message_jp,       null, leftSpace, rightSpace, type)
	{

	}
	public ECHelpBox(string message_jp, string message_en, float leftSpace, float rightSpace)                                 : this(message_jp, message_en, leftSpace, rightSpace, MessageType.None)
	{
		
	}
	public ECHelpBox(string message_jp, string message_en, float leftSpace, float rightSpace, MessageType type)               : base(message_jp, message_en)
	{
		this.Type = type;
		this.LeftSpace = leftSpace;
		this.RightSpace = rightSpace;
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ECHelpBox))]
public class ECHelpBoxDrawer : ECDecoratorDrawer
{
	protected override void CustomGUI(Rect rect)
	{
		ECHelpBox ecHelpBox = Attribute<ECHelpBox>();
		HelpBox(ecHelpBox.LeftSpace, ecHelpBox.RightSpace, ecHelpBox.Type);
	}
}
#endif