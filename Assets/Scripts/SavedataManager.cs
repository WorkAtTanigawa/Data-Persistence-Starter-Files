using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.IO;
using System.Linq;
public class SavedataManager : MonoBehaviour
{
    [SerializeField]private string savefileName ="savedata.json";
    private string saveFilePath ;
    public static SavedataManager Instance;
    
    public UserData NowUser ;
    public UserData HighScoreUser;

    public List<UserData> ranking ;
    [SerializeField]int limitRank = 5 ;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        // Debug.Log( "In Awake");
        saveFilePath = Application.persistentDataPath +"/"+ savefileName ; 
        Debug.Log( nameof(saveFilePath) + "\t"+saveFilePath );

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
            SaveData saveData = JsonUtility.FromJson<SaveData>( json);
            ranking = saveData.ranking;
            HighScoreUser = saveData.HighScoreUser;
        }else{
            ranking = new List<UserData>();
            HighScoreUser = new UserData();
        }
        NowUser = new UserData();
    }

    public void SaveData(int nowPoint){
        NowUser.score = nowPoint;
        NowUser.registScore = System.DateTime.Now;
        UpdateRanking();

        SaveData saveData = new SaveData(){ ranking = ranking , HighScoreUser = HighScoreUser};
        string json = JsonUtility.ToJson( saveData );
        File.WriteAllText( saveFilePath , json);
    }


    public void UpdateRanking(){
        // if( ranking == null ){
        //     ranking=new List<UserData>();
        // }
        ranking.Add( new UserData(){name = NowUser.name , score = NowUser.score , registScore = NowUser.registScore });
        ranking = ranking.OrderByDescending( x=>x.score).ThenByDescending(x=>x.registScore).Take(limitRank).ToList<UserData>();
    }
}
[System.Serializable]
public class UserData{
    public string name;
    public int score;
    public System.DateTime registScore;
}

[System.Serializable]
public class SaveData{
    public List<UserData> ranking;
    public UserData HighScoreUser;
}
