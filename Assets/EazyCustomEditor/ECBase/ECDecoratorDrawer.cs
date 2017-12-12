/*=============================================================================
Project Name    : EazyCustomEditor
File Name       : ECDecoratorDrawer
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

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomPropertyDrawer(typeof(ECPropertyAttribute))]
public class ECDecoratorDrawer : DecoratorDrawer
{
	public Rect rect;
	public string text;

	/// <summary>
	/// Raises the GU event.
	/// </summary>
	/// <param name="position">Position.</param>
	public override void OnGUI(Rect position)
	{
		rect = position;

		ECPropertyAttribute _baseAttribute = Attribute<ECPropertyAttribute>();
		if (_baseAttribute.LocalizeTitle != null && _baseAttribute.LocalizeTitle.text != null)
			text = _baseAttribute.LocalizeTitle.text;

		CustomGUI(rect);
	}

	/// <summary>
	/// Customs the GU.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="property">Property.</param>
	/// <param name="label">Label.</param>
	protected virtual void CustomGUI(Rect position)
	{

	}

	/// <summary>
	/// Attribute this instance.
	/// </summary>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public T Attribute<T>() where T : PropertyAttribute
	{
		return (T)this.attribute;
	}

	/*====================================*
	 * Decorator Assistance
	 *====================================*/
	public void HelpBox() 
	{
		HelpBox(-1, -1, MessageType.None);
	}
	public void HelpBox(MessageType type) 
	{
		HelpBox(-1, -1, type);
	}
	public void HelpBox(float leftSpace, float rightSpace) 
	{
		HelpBox(leftSpace, rightSpace, MessageType.None);
	}
	public void HelpBox(float LeftSpace, float RightSpace, MessageType type) 
	{
		Rect _rect = this.rect;
		if (0 <= LeftSpace && 0 <= RightSpace)
		{
			_rect.center = new Vector2(_rect.center.x+(LeftSpace-RightSpace), _rect.center.y);
			_rect.size = new Vector2(_rect.size.x-(LeftSpace+RightSpace), _rect.size.y);
		}
		EditorGUI.HelpBox(_rect, text, type);
		GUILayout.Height(_rect.size.y);
	}
}