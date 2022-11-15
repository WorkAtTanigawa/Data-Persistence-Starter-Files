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
    // Start is called before the first frame update
    void Start()
    {
        SavedataManager savedata = SavedataManager.Instance.GetComponent<SavedataManager>();
        bestName.text  = savedata.HighScoreUser.name;
        bestScore.text = savedata.HighScoreUser.score.ToString();

        nowName.text  = savedata.NowUser.name;
        nowScore.text = savedata.NowUser.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoMenuScene(){
        SceneManager.LoadScene( "Menu");
    }}
