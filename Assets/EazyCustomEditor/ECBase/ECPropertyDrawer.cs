/*=============================================================================
Project Name    : EazyCustomEditor
File Name       : ECPropertyDrawer
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

using System.Linq;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ECPropertyAttribute))]
public class ECPropertyDrawer : PropertyDrawer
{
	public Rect rect;
	public SerializedProperty serializedProperty;
	public GUIContent guiContent;

	/// <summary>
	/// Raises the GU event.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="property">Property.</param>
	/// <param name="label">Label.</param>
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		rect = position;
		serializedProperty = property;
		guiContent = label;

		ECPropertyAttribute _baseAttribute = Attribute<ECPropertyAttribute>();
		if (_baseAttribute.LocalizeTitle != null && _baseAttribute.LocalizeTitle.text != null)
			guiContent.text = _baseAttribute.LocalizeTitle.text;
		
		CustomGUI(rect, serializedProperty, guiContent);
	}

	/// <summary>
	/// Customs the GU.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="property">Property.</param>
	/// <param name="label">Label.</param>
	protected virtual void CustomGUI(Rect position, SerializedProperty property, GUIContent label)
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

	/// <summary>
	/// base.OnGUI()
	/// </summary>
	public void BaseGUI() 
	{
		base.OnGUI(rect, serializedProperty, guiContent);
	}

	/*====================================*
	 * Input Assistance
	 *====================================*/
	public void Label(string leftText_jp) 
	{
		Label(leftText_jp, null, null, null);
	}
	public void Label(string leftText_jp, string rightText_jp) 
	{
		Label(leftText_jp, null, rightText_jp, null);
	}
	public void Label(string leftText_jp, string leftText_en, string rightText_jp, string rightText_en) 
	{
		string left = null;
		string right = null;
		if (leftText_en != null && Application.systemLanguage != SystemLanguage.Japanese)
			left = leftText_en;
		else left = leftText_jp;
		if (rightText_en != null && Application.systemLanguage != SystemLanguage.Japanese)
			right = rightText_en;
		else right = rightText_jp;
		if (right != null) EditorGUI.LabelField(rect, left, right);
		else EditorGUI.LabelField(rect, left);
	}

	/*====================================*
	 * Input Field Assistance
	 *====================================*/
	public int Popup(string[] options, int num) 
	{
		return EditorGUI.Popup(rect, guiContent.text, num, options);
	}

	/*====================================*
	 * Input Field
	 *====================================*/
	public void BoundsField()
	{
		EditorGUI.BeginChangeCheck();
		Bounds bounds = EditorGUI.BoundsField(rect, guiContent.text, serializedProperty.boundsValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.boundsValue = bounds;
	}

	public void ColorField()
	{
		EditorGUI.BeginChangeCheck();
		Color color = EditorGUI.ColorField(rect, guiContent.text, serializedProperty.colorValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.colorValue = color;
	}

	public void CurveField()
	{
		EditorGUI.BeginChangeCheck();
		AnimationCurve animationCurve = EditorGUI.CurveField(rect, guiContent.text, serializedProperty.animationCurveValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.animationCurveValue = animationCurve;
	}

	public void DelayedDoubleField()
	{
		EditorGUI.BeginChangeCheck();
		double num = EditorGUI.DelayedDoubleField(rect, guiContent.text, serializedProperty.doubleValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.doubleValue = num;
	}

	public void DelayedFloatField()
	{
		EditorGUI.BeginChangeCheck();
		float num = EditorGUI.DelayedFloatField(rect, guiContent.text, serializedProperty.floatValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.floatValue = num;
	}

	public void DelayedIntField()
	{
		EditorGUI.BeginChangeCheck();
		int num = EditorGUI.DelayedIntField(rect, guiContent.text, serializedProperty.intValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.intValue = num;
	}

	public void DelayedTextField()
	{
		EditorGUI.BeginChangeCheck();
		string text = EditorGUI.DelayedTextField(rect, guiContent.text, serializedProperty.stringValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.stringValue = text;
	}

	public void DoubleField()
	{
		EditorGUI.BeginChangeCheck();
		double num = EditorGUI.DoubleField(rect, guiContent.text, serializedProperty.doubleValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.doubleValue = num;
	}

	public void FloatField()
	{
		EditorGUI.BeginChangeCheck();
		float num = EditorGUI.FloatField(rect, guiContent.text, serializedProperty.floatValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.floatValue = num;
	}

	public void IntField()
	{
		EditorGUI.BeginChangeCheck();
		int num = EditorGUI.IntField(rect, guiContent.text, serializedProperty.intValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.intValue = num;
	}

	public void EnumField() 
	{
		//デフォルトのEnumの値の名前を設定
		Dictionary<string, string> customEnumNames = new Dictionary<string, string>();
		foreach (string enumName in serializedProperty.enumNames)
			customEnumNames.Add(enumName, enumName);

		//別名を付けたEnumの値の名前を設定
		//Enumの変数からEnumの値に設定されているECEnumを取得する
		object[] customAttributes = this.fieldInfo.GetCustomAttributes(typeof(ECEnum), false);
		foreach (ECEnum customAttribute in customAttributes)
		{
			//EnumのTypeを取得
			foreach (string enumName in serializedProperty.enumNames)
			{
				//EnumからEnumの要素を取得
				System.Reflection.FieldInfo field = this.fieldInfo.FieldType.GetField(enumName);
				if (field != null)
				{
					//Enumの値の名前を差し替える
					ECEnum[] attrs = (ECEnum[])field.GetCustomAttributes(customAttribute.GetType(), false);
					if (customEnumNames.ContainsKey(enumName) && 0 < attrs.Length && attrs[0] != null && !string.IsNullOrEmpty(attrs[0].LocalizeTitle.text))
						customEnumNames[enumName] = attrs[0].LocalizeTitle.text;
				}
			}
		}

		string[] displayedOptions = serializedProperty.enumNames.Where(enumName => customEnumNames.ContainsKey(enumName)).Select<string, string>(enumName => customEnumNames[enumName]).ToArray();
		EditorGUI.BeginChangeCheck();
		int num = Popup(displayedOptions, serializedProperty.enumValueIndex);
		if (EditorGUI.EndChangeCheck()) serializedProperty.enumValueIndex = num;
	}

	public void LayerField()
	{
		EditorGUI.BeginChangeCheck();
		int num = EditorGUI.LayerField(rect, guiContent.text, serializedProperty.intValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.intValue = num;
	}

	public void LongField()
	{
		EditorGUI.BeginChangeCheck();
		long num = EditorGUI.LongField(rect, guiContent.text, serializedProperty.longValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.longValue = num;
	}

	public void ObjectField()
	{
		EditorGUI.BeginChangeCheck();
		UnityEngine.Object obj = EditorGUI.ObjectField(rect, guiContent.text, serializedProperty.objectReferenceValue, serializedProperty.GetType());
		if (EditorGUI.EndChangeCheck()) serializedProperty.objectReferenceValue = obj;
	}

	public void PasswordField()
	{
		EditorGUI.BeginChangeCheck();
		string text = EditorGUI.PasswordField(rect, guiContent.text, serializedProperty.stringValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.stringValue = text;
	}

	public void RectField()
	{
		EditorGUI.BeginChangeCheck();
		Rect _rect = EditorGUI.RectField(rect, guiContent.text, serializedProperty.rectValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.rectValue = _rect;
	}

	public void TagField()
	{
		EditorGUI.BeginChangeCheck();
		string text = EditorGUI.TagField(rect, guiContent.text, serializedProperty.stringValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.stringValue = text;
	}

	public void TextField()
	{
		EditorGUI.BeginChangeCheck();
		string text = EditorGUI.TextField(rect, guiContent.text, serializedProperty.stringValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.stringValue = text;
	}

	public void Vector2Field()
	{
		EditorGUI.BeginChangeCheck();
		Vector2 vector = EditorGUI.Vector2Field(rect, guiContent.text, serializedProperty.vector2Value);
		if (EditorGUI.EndChangeCheck()) serializedProperty.vector2Value = vector;
	}

	public void Vector3Field()
	{
		EditorGUI.BeginChangeCheck();
		Vector3 vector = EditorGUI.Vector3Field(rect, guiContent.text, serializedProperty.vector3Value);
		if (EditorGUI.EndChangeCheck()) serializedProperty.vector3Value = vector;
	}

	public void Vector4Field()
	{
		EditorGUI.BeginChangeCheck();
		Vector4 vector = EditorGUI.Vector4Field(rect, guiContent.text, serializedProperty.vector4Value);
		if (EditorGUI.EndChangeCheck()) serializedProperty.vector4Value = vector;
	}

	public void PopupIntField(string[] options) 
	{
		EditorGUI.BeginChangeCheck();
		int num = Popup(options, serializedProperty.intValue);
		if (EditorGUI.EndChangeCheck()) serializedProperty.intValue = num;
	}

	public void BuildSceneField(bool EnableOnly) 
	{
		List<EditorBuildSettingsScene> scenes = (EnableOnly ? EditorBuildSettings.scenes.Where(scene => scene.enabled) : EditorBuildSettings.scenes).ToList();
		HashSet<string> sceneNameList = new HashSet<string>();
		scenes.ForEach(scene => { sceneNameList.Add(scene.path.Substring(scene.path.LastIndexOf("/") + 1).Replace(".unity", string.Empty)); });
		string[] sceneNames = sceneNameList.ToArray();

		if (0 < sceneNames.Length)
		{
			int num = 0;
			if (!string.IsNullOrEmpty(serializedProperty.stringValue))
			{
				num = ArrayUtility.IndexOf<string>(sceneNames, serializedProperty.stringValue);
				if (num < 0 || num >= sceneNames.Length) num = 0;
			}

			EditorGUI.BeginChangeCheck();
			num = Popup(sceneNames, num);
			if (EditorGUI.EndChangeCheck()) serializedProperty.stringValue = sceneNames[num];
		}
		else Label(guiContent.text, "Scene is Empty");
	}
}
#endif