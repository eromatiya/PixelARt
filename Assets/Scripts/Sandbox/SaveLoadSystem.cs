using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO; 
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour {


	public GameObject spawnContainer;
	private string savefileName;
	private string loadDirName;


	// Use this for initialization
	void Start () {


		//MODIFY THIS!!!
		//Add more case if you intend to add scenes
		Scene activeScene;
		string sceneName;
		activeScene = SceneManager.GetActiveScene ();
		sceneName = activeScene.name;

		switch (sceneName) {

		    case("book1Page1"):

			    savefileName = "safari.xml";
			    loadDirName = "Sandbox/SafariPrefabs";
			    break;

		    case("book1Page2"):

			    savefileName = "sea.xml";
			    loadDirName = "Sandbox/SeaPrefabs";
			    break;

            case ("book1Page3"):

                savefileName = "forest.xml";
                loadDirName = "Sandbox/ForestPrefabs";
                 break;

            case ("book2Page1"):

                savefileName = "space1.xml";
                loadDirName = "Sandbox/Space1Prefabs";
                break;

            case ("book2Page2"):

                savefileName = "space2.xml";
                loadDirName = "Sandbox/Space2Prefabs";
                break;

            case ("book2Page3"):

                savefileName = "space3.xml";
                loadDirName = "Sandbox/Space3Prefabs";
                break;

            case ("book3Page1"):

                savefileName = "skyline.xml";
                loadDirName = "Sandbox/SkylinePrefabs";
                break;




            default:
			break;

		}


		//Load on Start
		//Load(SpawnContainer, savefileName);
	}

	// Update is called once per frame
	void Update () {

	}

	public class SpawnInfo
	{
		public string prefabName;
		public Vector3 position;
		public Quaternion rotation;
		public Vector3 localscale;

		public SpawnInfo()
		{
		}

		public SpawnInfo(Transform spawned) 
		{
			prefabName = spawned.name.Replace("(Clone)", string.Empty);
			position = spawned.position;
			rotation = spawned.rotation;
			localscale = spawned.localScale;
		}
	}


	public class BuildingInfo
	{ // Stores info about all the spawned.

		// Make a List holding objects of type spawnList
		public List<SpawnInfo> spawnList;

		public BuildingInfo() 
		{
			// Make a new instance of the List "spawnList"
		}

		public BuildingInfo(GameObject rootObject) 
		{
			spawnList = new List<SpawnInfo>();

			foreach (Transform child in rootObject.transform) 
			{
				spawnList.Add (new SpawnInfo(child));
				//print (child);
			}
		}

		public void reload(GameObject rootObject, string loadir)
		{
			// Rebuild the spawned objects after loading building info:
			foreach (var spawnInfo in spawnList) 
			{
				print (spawnInfo.prefabName);
				GameObject spawn = Instantiate(Resources.Load(loadir + "/" + spawnInfo.prefabName),spawnInfo.position, spawnInfo.rotation) as GameObject;
				spawn.transform.localScale = spawnInfo.localscale;
				spawn.transform.parent = rootObject.transform;
			}
		}
	}


	void Save(GameObject rootObject, string filename) 
	{
		BuildingInfo buildingInfo = new BuildingInfo(rootObject);
		XmlSerializer serializer = new XmlSerializer(typeof(BuildingInfo));
		TextWriter writer = new StreamWriter(Application.persistentDataPath + filename);
		serializer.Serialize(writer, buildingInfo);
		writer.Close();
		print ("Objects saved into XML file\n");
	}

	void Load(GameObject rootObject, string filename) 
	{
        if (System.IO.File.Exists(Application.persistentDataPath + filename))
        {   
            //destroy unsaved objects
            DestroyChildren();
            XmlSerializer serializer = new XmlSerializer(typeof(BuildingInfo));
            TextReader reader = new StreamReader(Application.persistentDataPath + filename);
            BuildingInfo buildingInfo = serializer.Deserialize(reader) as BuildingInfo;
            buildingInfo.reload(rootObject, loadDirName);
            reader.Close();
            print("Objects loaded from XML file\n");
        }
	}

	/*
	void OnGUI()
	{
		if (GUI.Button (new Rect (30, 60, 150, 30), "Save State")) 
		{
			Save (spawnContainer, "savefile.xml");
		}

		if (GUI.Button (new Rect (30, 90, 150, 30), "Load State")) 
		{
			Load (spawnContainer, "savefile.xml");
		}
	}
	*/

	public void DestroyChildren(){
	
		int child = spawnContainer.transform.childCount;
		for (int i = child - 1; i >= 0; i--) {
		
			//GameObject.Destroy (transform.GetChild (i).gameObject);
			GameObject.Destroy (spawnContainer.transform.GetChild (i).gameObject);
		}

	}


	public void SaveState(){
	
		Save (spawnContainer, savefileName);

	
	}

	public void LoadState(){

		Load (spawnContainer, savefileName);

	}
}
