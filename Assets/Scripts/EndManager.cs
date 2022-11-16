using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    [SerializeField]Button menuButton;

    [SerializeField]Text bestName;
    [SerializeField]Text bestScore;
    [SerializeField]Text nowName;
    [SerializeField]Text nowScore;

    [SerializeField]GameObject rankRow;
    [SerializeField]Canvas canvas;
    SavedataManager savedataManager;
    [SerializeField]float topOffset = -20f;
    [SerializeField]float rankingRowHeight = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        if( SavedataManager.Instance != null ){
            savedataManager = SavedataManager.Instance.GetComponent<SavedataManager>() ;
            // bestName.text  = savedata.HighScoreUser.name;
            // bestScore.text = savedata.HighScoreUser.score.ToString();
            nowName.text  = savedataManager.NowUser.name;
            nowScore.text = savedataManager.NowUser.score.ToString();
            GenerateRanking();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoMenuScene(){
        SceneManager.LoadScene( "Menu");
    }

    void GenerateRanking(){
        var ranking = savedataManager.ranking;
        for(int i=0;i<ranking.Count;i++){
            GameObject rankR = Instantiate( rankRow , new Vector3( 0 , topOffset-(i*rankingRowHeight) ,0 ) , Quaternion.identity );
            RankRow r = rankR.GetComponent<RankRow>();
            r.rank.text = (i+1).ToString();
            r.playerName.text = ranking[i].name;
            r.playerName.color = (i==0)?Color.red:new Color( 150f,150f,150f);
            r.playerName.fontStyle = ( ranking[i].registScore == savedataManager.NowUser.registScore )?FontStyle.BoldAndItalic:FontStyle.Normal ;
            r.playerScore.text = ranking[i].score.ToString() ;
            rankR.transform.SetParent( canvas.transform ,false);
        }
    }
}
