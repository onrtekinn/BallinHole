using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button Play;
    public Button Replay;
    private Button Quit;
    private Button Jump;
   void Start () {
		
        Button play = Play.GetComponent<Button>();play.onClick.AddListener(TaskOnClickPlay);
        Button replay =Replay.GetComponent<Button>();replay.onClick.AddListener(TaskOnClickReplay);
        Button quit = Quit.GetComponent<Button>();quit.onClick.AddListener(TaskOnClickQuit);
        Button jump = Jump.GetComponent<Button>();jump.onClick.AddListener(TaskOnClickJump);
	}

	void TaskOnClickPlay(){
		//SceneManager.LoadScene(LevelSelect);
	}
    void TaskOnClickReplay(){
		string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene,LoadSceneMode.Single);
	}
    void TaskOnClickJump(){
		//SceneManager.LoadScene(LevelSelect);
	}
    void TaskOnClickQuit(){
		Application.Quit();
	}
}
