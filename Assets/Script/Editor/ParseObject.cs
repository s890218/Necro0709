using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public partial class ParseObject : MonoBehaviour {

	private static string m_Path = Path.Combine(Application.dataPath, "DataParse/Data");

	private static string m_PathC = Path.Combine("Assets", "Resources/ScriptObject");
	private static string m_PathCU = Path.Combine("Assets", "Resources/ScriptObjectUnit");

	private static int m_Index = 0;

	static string[] m_TotalName =
	{
		"CharData",
		"MonsterData",
	};


	[MenuItem("G_Tools/創建角色Object", false, 201)]
	public static void BuildCharObject()
	{
		int index = 0;
		CharDataTotal BData = ScriptableObject.CreateInstance<CharDataTotal>();
		//ScriptObject
		string pathCreate = Path.Combine(m_PathC , m_TotalName[index]+ ".asset");
		string pathLoad = Path.Combine(m_Path, m_TotalName[index]+".txt");
		string pathCreateUnit = Path.Combine(m_PathCU, m_TotalName[index]);
		string[] s = File.ReadAllLines(pathLoad);

		AddData(s, BData, pathCreateUnit);

		AssetDatabase.DeleteAsset(pathCreate);
		AssetDatabase.CreateAsset(BData, pathCreate);
		AssetDatabase.SaveAssets();
	}

	[MenuItem("G_Tools/創建怪物Object", false, 202)]
	public static void BuildMonsterObject()
	{
		int index = 1;
		MonsterDataTotal BData = ScriptableObject.CreateInstance<MonsterDataTotal>();
		//ScriptObject
		
		string pathCreate = Path.Combine(m_PathC, m_TotalName[index] + ".asset");
		string pathLoad = Path.Combine(m_Path, m_TotalName[index] + ".txt");
		string pathCreateUnit = Path.Combine(m_PathCU, m_TotalName[index] );
		string[] s = File.ReadAllLines(pathLoad);

		AddData(s, BData, pathCreateUnit);

		AssetDatabase.DeleteAsset(pathCreate);
		AssetDatabase.CreateAsset(BData, pathCreate);
		AssetDatabase.SaveAssets();
	}






	private static int ReturnValue(string[] data)
	{
		m_Index++;
		return int.Parse(data[m_Index-1]);
	}

	private static string ReturnValues(string[] data)
	{
		m_Index++;
		return data[m_Index-1];
	}
	
}
