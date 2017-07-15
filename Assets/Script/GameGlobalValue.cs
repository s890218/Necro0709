using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGlobalValue
{

	public static Dictionary<int, MonsterDataObject> s_MonsterData = new Dictionary<int, MonsterDataObject>();	//全部怪物資料
	public static Dictionary<int, CharDataObject> s_CharData = new Dictionary<int, CharDataObject>();       //全部角色資料(目前只有主角,如果可以換角就加在這)

	public static int s_Test = 0;




}
