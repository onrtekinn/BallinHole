using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GridLayerControl : MonoBehaviour
{
   public int noOfLevels;
   public GameObject levelButton;
   public RectTransform ParentPanel;
   int levelReached;
   
   private void Awake() {
       levelButtons();
   }
   void levelButtons(){
       if(PlayerPrefs.HasKey("level"))
       {
            levelReached = PlayerPrefs.GetInt("level");
        }
       else {
            PlayerPrefs.SetInt("level",1);
            levelReached = PlayerPrefs.GetInt("level");
       }
       for(int i=0;i<noOfLevels;i++)
       {    
           int x=new int();
           x=i+1;
           GameObject lvlButton=Instantiate(levelButton);
           lvlButton.transform.SetParent(ParentPanel,false);
           Text buttonText= lvlButton.GetComponentInChildren<Text>();
           buttonText.text= (i+1).ToString();
           
           lvlButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate{
               LevelSelected(x);
           });

           /*if (i+1>levelReached){
               lvlButton.GetComponent<Button>().interactable=false;
           }*/
       }
   }
   void LevelSelected(int index)
   {
       PlayerPrefs.SetInt("levelSelected",index);
       Debug.Log("Level Selected:"+index.ToString());
       Invoke (nameof(LoadGamePlay),1f);
   }
   void LoadGamePlay()
   {
       SceneManager.LoadScene("Level1");
   }
}
