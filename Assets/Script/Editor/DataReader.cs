using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class DataReader : MonoBehaviour {
	
	[MenuItem ("G_Tools/將所有CSV資料夾路徑下的檔案轉存成UTF-8的txt",false,101)]
	public static void ReadCSVAll ()
	{
		//並不會搜尋子資料夾
		string[] pathAll = Directory.GetFiles(Path.Combine(Application.dataPath, "CSV"), "*.csv");
		for (int i = 0; i < pathAll.Length; i++)
		{
			string path = Path.Combine(Application.dataPath, "DataParse/Data");
			string fileName =  Path.GetFileName(pathAll[i]);
			string[] s = File.ReadAllLines(pathAll[i], System.Text.Encoding.UTF8);
			path += "/" + fileName.Split('_')[0]+".txt";
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			Debug.LogWarning(path);
			File.WriteAllLines(path, s, System.Text.Encoding.UTF8);


		}
		AssetDatabase.Refresh();

	}

	[MenuItem("G_Tools/將選取的CSV檔案轉成UTF-8的txt", false, 101)]
	public static void ReadCSV()
	{
		Caching.CleanCache();
		Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

		for (int i = 0; i < selection.Length; i++)
		{
			string path = Path.Combine(Application.dataPath, "DataParse/Data");
			string fileName = selection[i].name;
			string pathTemp = AssetDatabase.GetAssetPath(selection[i]);
			string[] s = File.ReadAllLines(pathTemp, System.Text.Encoding.UTF8);
			path += "/" + fileName.Split('_')[0] + ".txt";
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			Debug.LogWarning(path);
			File.WriteAllLines(path, s, System.Text.Encoding.UTF8);
		}

		AssetDatabase.Refresh();

	}



}
