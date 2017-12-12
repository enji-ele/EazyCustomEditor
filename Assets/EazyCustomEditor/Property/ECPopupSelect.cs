/*=============================================================================
Project Name    : EazyCustomEditor
File Name       : ECPopupSelect
Creation Date   : 2017/12/05
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

public class ECPopupSelect : ECPropertyAttribute
{
	public object[] list_jp;
	public object[] list_en;
	public object[] list 
	{
		get {
			if (list_en != null && Application.systemLanguage != SystemLanguage.Japanese)
				return list_en;
			else return list_jp;
		}
	}

	public ECPopupSelect(object[] list_jp) : this(null, null, list_jp, null)
	{
		
	}
	public ECPopupSelect(string title_jp, object[] list_jp) : this(title_jp, null, list_jp, null)
	{

	}
	public ECPopupSelect(string title_jp, string title_en, object[] list_jp) : this(title_jp, title_en, list_jp, null)
	{

	}
	public ECPopupSelect(string title_jp, string title_en, object[] list_jp, object[] list_en) : base(title_jp, title_en)
	{
		this.list_jp = list_jp;
		this.list_en = list_en;
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ECPopupSelect))]
public class ECPopupSelectDrawer : ECPropertyDrawer
{
	private Action<int> setValue;
	private Func<int, int> validateValue;
	private string[] _list = null;
	private string[] list
	{
		get {
			if (_list == null)
			{
				object[] list =  Attribute<ECPopupSelect>().list;
				_list = new string[list.Length];
				for (int i = 0; i < list.Length; i++)
					_list[i] = list[i].ToString();
			}
			return _list;
		}
	}

	protected override void CustomGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if (validateValue == null && setValue == null)
		{
			_setUp();
			BaseGUI();
			return;
		}

		int selectedIndex = 0;
		for (int i = 0; i < list.Length; i++)
		{
			selectedIndex = validateValue(i);
			if (selectedIndex != 0) break;
		}

		EditorGUI.BeginChangeCheck();
		selectedIndex = Popup(list, selectedIndex);
		if (EditorGUI.EndChangeCheck()) setValue(selectedIndex);
	}

	private void _setUp()
	{
		if (_variableType == typeof(string))
		{
			validateValue = (index) => { return serializedProperty.stringValue == list[index] ? index : 0; };
			setValue = (index) => { serializedProperty.stringValue = list[index]; };
		}
		else if (_variableType == typeof(int))
		{
			validateValue = (index) => { return serializedProperty.intValue == Convert.ToInt32(list[index]) ? index : 0; };
			setValue = (index) => { serializedProperty.intValue = Convert.ToInt32(list[index]); };
		}
		else if (_variableType == typeof(float))
		{
			validateValue = (index) => { return serializedProperty.floatValue == Convert.ToSingle(list[index]) ? index : 0; };
			setValue = (index) => { serializedProperty.floatValue = Convert.ToSingle(list[index]); };
		}
	}

	private Type _variableType
	{
		get { return Attribute<ECPopupSelect>().list[0].GetType(); }
	}
}
#endif