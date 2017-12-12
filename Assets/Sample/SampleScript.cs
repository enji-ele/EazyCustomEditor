using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour {
	[ECHelpBox("日本語の表示","English Text", 0, 0, UnityEditor.MessageType.None)]
	[ECHelpBox("Info", 140, 0, UnityEditor.MessageType.Info)]
	[ECHelpBox("Error", 0, 10, UnityEditor.MessageType.Error)]
	[ECHelpBox("Warning", 70, 30, UnityEditor.MessageType.Warning)]

	[ECSceneName("Scene選択１", "Select Scene1", true)] public string ECSceneName1;
	[ECSceneName("Scene選択２", "Select Scene2", true)] public string ECSceneName2;

	[ECTagName("タグ選択１", "Select Tag1")] public string ECTagName1;
	[ECTagName("タグ選択２", "Select Tag2")] public string ECTagName2;

	[ECEnum("Enum選択１", "Select Enum1")] public SampleEnum ECEnum1 = SampleEnum.Enum1;
	public enum SampleEnum
	{
		[ECEnum("要素１", "option1")] Enum1,
		[ECEnum("要素２", "option2")] Enum2,
		[ECEnum("要素３", "option3")] Enum3,
		[ECEnum("要素４", "option4")] Enum4,
		[ECEnum("要素５", "option5")] Enum5
	}
	[ECEnum("Enum選択２", "Select Enum2")] public SampleEnum2 ECEnum2 = SampleEnum2.Enum1;
	public enum SampleEnum2
	{
		Enum1,
		[ECEnum("要素２", "option2")] Enum2,
		[ECEnum("要素３", "option3")] Enum3,
		[ECEnum("要素４", "option4")] Enum4,
		[ECEnum("要素５", "option5")] Enum5
	}

	[ECPopupSelect("ポップアップ１", "Popup1", new object[]{"要素１","要素２"}, new object[]{"option1","option2"})] public string ECPopupSelect1;
	[ECPopupSelect("ポップアップ２", "Popup2", new object[]{1,2})] public int ECPopupSelect2;
}