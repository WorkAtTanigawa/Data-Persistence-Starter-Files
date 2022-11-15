using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
public class SavedataManager : MonoBehaviour
{
    [SerializeField]private string savefileName ="savedata.json";
    private string saveFilePath ;
    public static SavedataManager Instance;
    
    public UserData NowUser ;
    public UserData HighScoreUser;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        // Debug.Log( "In Awake");
        saveFilePath = Application.persistentDataPath +"/"+ savefileName ; 
        // Debug.Log( nameof(saveFilePath) + "\t"+saveFilePath );

        if( Instance != null ){
            // nowUser を 仮入力？

            Destroy(gameObject);
            return ;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(){
        // Debug.Log( nameof(saveFilePath) + "\t"+ File.Exists(saveFilePath) );
        if( File.Exists( saveFilePath)){
            string json = File.ReadAllText(saveFilePath);
            HighScoreUser = JsonUtility.FromJson<UserData>( json);
        }else{
            HighScoreUser = new UserData(){ score=0,name=string.Empty};
        }
        NowUser = new UserData(){ name = string.Empty , score = 0 };
    }

    public void SaveData(){
        string json = JsonUtility.ToJson( HighScoreUser);
        File.WriteAllText( saveFilePath , json);
    }

}
[System.Serializable]
public class UserData{
    public string name;
    public int score;
}

