using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {

	public Dictionary<LoadType, string> m_DicPath = new Dictionary<LoadType, string>
	{
		{LoadType.Monster,"ScriptObject/MonsterData" },
		{LoadType.Char,"ScriptObject/CharData" },
	};


	private void Awake()
	{
		//目前資料不多 直接放awake讀取就可以 如果開場load太久 可改update
		GetSetMonsterData();
		GetSetCharData();
	}

	private void GetSetMonsterData()
	{
		var data = Resources.Load<MonsterDataTotal>(m_DicPath[LoadType.Monster]);
		for (int i = 0; i<data.m_TotalData.Count; i++)
		{
			MonsterDataObject o = data.m_TotalData[i];
			GameGlobalValue.s_MonsterData[o.m_index] = o;
			//Debug.Log(o.name);
		}
	}

	private void GetSetCharData()
	{
		var data = Resources.Load<CharDataTotal>(m_DicPath[LoadType.Char]);
		for (int i = 0; i < data.m_TotalData.Count; i++)
		{
			CharDataObject o = data.m_TotalData[i];
			GameGlobalValue.s_CharData[o.m_index] = o;
			//Debug.Log(o.name);
		}
	}

}
