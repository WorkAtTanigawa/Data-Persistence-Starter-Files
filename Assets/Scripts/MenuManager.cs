using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField]private InputField inputUserName ;
    [SerializeField]GameObject notification;
    private SavedataManager saveData;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( this.name + "=> in Start\t"+ SavedataManager.Instance);
        if( SavedataManager.Instance !=null){
        }
        saveData = SavedataManager.Instance.GetComponent<SavedataManager>();
        inputUserName.text = saveData.NowUser.name ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoMainScene(){
        SceneManager.LoadScene( "main");
    }

    public void EnableButton(){
        saveData.NowUser.name = inputUserName.text;
        if( string.IsNullOrEmpty(inputUserName.text) ){
            notification.gameObject.SetActive(true);
            startButton.interactable =false;
        }else{
            notification.gameObject.SetActive(false);
            startButton.interactable =true;
        }
    }

    public void ExitGame(){
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        // original Code to quite Unity-Player 
        Application.Quit();
#endif
    }
}
