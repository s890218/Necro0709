using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public partial class ParseObject : MonoBehaviour {
	
	private static void AddData(string[] s, CharDataTotal BData, string pathCreateUnit)
	{
		for (int i = 1; i < s.Length; i++)
		{
			m_Index = 0;
			CharDataObject Data = ScriptableObject.CreateInstance<CharDataObject>();

			string[] split = s[i].Split(',');

			Data.m_index = ReturnValue(split);
			Data.m_CharName = ReturnValues(split);
			Data.m_Hp = ReturnValue(split);
			Data.m_Atk = ReturnValue(split);
			Data.m_Temp1 = ReturnValue(split);
			Data.m_Temp2 = ReturnValue(split);
			Data.m_Temp3 = ReturnValue(split);

			AssetDatabase.DeleteAsset(pathCreateUnit + i + ".asset");
			AssetDatabase.CreateAsset(Data, pathCreateUnit + i + ".asset");

			BData.m_TotalData.Add(Data);
		}
	}

	private static void AddData(string[] s, MonsterDataTotal BData, string pathCreateUnit)
	{


		for (int i = 1; i < s.Length; i++)
		{
			m_Index = 0;
			MonsterDataObject Data = ScriptableObject.CreateInstance<MonsterDataObject>();

			string[] split = s[i].Split(',');

			Data.m_index = ReturnValue(split);
			Data.m_UnitName = ReturnValues(split);
			Data.m_Hp = ReturnValue(split);
			Data.m_Atk = ReturnValue(split);
			Data.m_Temp1 = ReturnValue(split);
			Data.m_Temp2 = ReturnValue(split);
			Data.m_Temp3 = ReturnValue(split);
			Data.m_Money = ReturnValue(split);
			Data.m_Model = ReturnValues(split);

			AssetDatabase.DeleteAsset(pathCreateUnit+i+ ".asset");
			AssetDatabase.CreateAsset(Data, pathCreateUnit + i + ".asset");

			BData.m_TotalData.Add(Data);
		}
	}








}
