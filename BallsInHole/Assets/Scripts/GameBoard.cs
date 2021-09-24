using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard :MonoBehaviour
{
	[SerializeField]
	GameObject tilePrefab;
	[SerializeField]
	GameObject wallPrefab;
	[SerializeField]
	GameObject coinsPrefab;
	[SerializeField]
	GameObject ballPrefab;
	[SerializeField]
	GameObject holePrefab;
	[SerializeField]
	GameObject icecubePrefab;
	[SerializeField]
	GameObject cactusPrefab;
	[SerializeField]
	GameObject GameOverPanel;
	[SerializeField]
	GameObject RetryPanel;
	[SerializeField]
	GameObject Score;
	[SerializeField]
	GameObject ScoreText;



	public Game game;

	private void Start()
	{
		game=GetComponent<Game>();
		//Score.SetActive(true);
		
	}
	public void Initialize () {
		Vector2Int size=new Vector2Int(11,18);
		GameObject gameOverPanel=Instantiate(GameOverPanel);
        //tiles = new GameObject[size.x * size.y];
		for (int y = 0; y < size.y; y++) {
			for (int x = 0; x < size.x; x++) {
				//GameObject score=Instantiate(Score);
				
				GameObject tiles=Instantiate(tilePrefab);
				tiles.transform.SetParent(transform,false);
				tiles.transform.localPosition = new Vector3(x,0,y);
				if(game.Map4[x,y]==0)
				{
				}
				else if(game.Map4[x,y]==1)
				{
				//1:Adding walls//
				GameObject walls=Instantiate(wallPrefab);
				walls.transform.SetParent(transform,false);
				walls.transform.localPosition = new Vector3(x,1,y);
				}
				//2:Adding ball//
				else if(game.Map4[x,y]==2)
				{
				GameObject ball=Instantiate(ballPrefab);
				ball.transform.SetParent(transform,false);
				ball.transform.localPosition = new Vector3(x,1,y);
				}
				//3:Adding hole//
				else if(game.Map4[x,y]==3)
				{
				GameObject hole=Instantiate(holePrefab);
				hole.transform.SetParent(transform,false);
				hole.transform.localPosition = new Vector3(x,1,y);
				}
				//4:Adding coins//
				else if(game.Map4[x,y]==4)
				{
				GameObject coins=Instantiate(coinsPrefab);
				coins.transform.SetParent(transform,false);
				coins.transform.localPosition = new Vector3(x,1,y);
				}
				//5:Adding icecubes//
				else if(game.Map4[x,y]==5)
				{
				GameObject icecube=Instantiate(icecubePrefab);
				icecube.transform.SetParent(transform,false);
				icecube.transform.localPosition = new Vector3(x,1,y);
				}
				//6:Adding cactus//
				else if(game.Map4[x,y]==6)
				{
				GameObject cactus=Instantiate(cactusPrefab);
				cactus.transform.SetParent(transform,false);
				cactus.transform.localPosition = new Vector3(x,1,y);
				}
			}
		}
	}
	 
}
