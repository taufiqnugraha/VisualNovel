using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class CharacterPashing : MonoBehaviour {
	List<DialogLine> lines;

	struct DialogLine{
		string name;
		string content;
		int pose;

		public DialogLine(string n,string c,int p){
			name = n;
			content = c;
			pose = p;
		}
	}
	// Use this for initialization
	void Start () {
		string file = "Dialog";
		string sceneNum  = EditorApplication.currentScene;
		sceneNum = Regex.Replace(sceneNum, "[^0-9]", "" );
		file += sceneNum;
		file += ".txt";

		LoadDialog(file);
	}
	 
	// Update is called once per frame
	void Update () {
	
	}
	void LoadDialog(string filename){
		string file = "Assets/Resources/"+ filename;
		string line;
		StreamReader r= new StreamReader(file);

		using (r){
			do{

				line = r.ReadLine();
				if(line != null) {
					string[] line_values = line.Split(',');
					DialogLine line_entry = new DialogLine(line_values[0],line_values[1], int.Parse (line_values[2]));
					lines.Add(line_entry);
				}
			}
			while(line != null);
			r.Close();
		
		}
	}
}
