using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.user;
using System;
using com.shephertz.app42.paas.sdk.csharp.game;
using UnityEngine.UI;


public class leaderSkripta : MonoBehaviour
{


    public static string[] imeR = new string[10];
    public static string[] scoreR = new string[10];



    public static bool createUser = false;
    public static bool getUserRank = false;
    public static bool getTopNRanks = false;
    public static bool saveScore = false;

    public static string userName;
    public static int gameScore;

    public Text userRank;

    public static string recivedUser = null;
    public static string recivedScore = null;
    // Use this for initialization
    
	void Start () {
        App42API.Initialize("d7c45a342781ca01c76b67ae107ef645816d0cae6ff2a12cecbb310fd4f94261", "c75984ec945c84d924f97577d6a07cf12d375f433117734de67d1cc43fd91604");

    }
	
	// Update is called once per frame
	void Update () {

		if (createUser) {
			createUser=false;
			UserService userService = App42API.BuildUserService();  
			userService.CreateUser(userName, "passwordboka", userName+"@gmail.com", new UnityCallBackCreateUser());  
		}

		if (saveScore) {
			saveScore=false;
			if(PlayerPrefs.HasKey("user") && PlayerPrefs.HasKey("score")){
				ScoreBoardService scoreBoardService = App42API.BuildScoreBoardService();   
				scoreBoardService.SaveUserScore("duckUnder", PlayerPrefs.GetString("user"), PlayerPrefs.GetInt("score"), new UnityCallBackSaveScore()); 
			}
		}

		if (getUserRank) {
			getUserRank=false;
				if(PlayerPrefs.HasKey("user")){
				ScoreBoardService scoreBoardService = App42API.BuildScoreBoardService();   
				scoreBoardService.GetUserRanking("duckUnder", PlayerPrefs.GetString("user"), new UnityCallBackGetUserRank());  
			}
		}

		if (getTopNRanks) {
			getTopNRanks=false;
			ScoreBoardService scoreBoardService = App42API.BuildScoreBoardService();   
			scoreBoardService.GetTopNRankers("duckUnder", 10, new UnityCallBackGetTopRanks()); 
		}

		if (recivedUser != null) {
			saveScore=true;
			recivedUser=null;

		}
		if (recivedScore != null) {
			recivedScore=null;
			getUserRank=true;
		}
	
	}


}

public class UnityCallBackCreateUser : App42CallBack  
{  
	public void OnSuccess(object response)  
	{  
		User user = (User) response;  
		App42Log.Console("userName is " + user.GetUserName());  
		App42Log.Console("emailId is " + user.GetEmail());   
		PlayerPrefs.SetString ("user",user.GetUserName());
		leaderSkripta.recivedUser = user.GetUserName();
	}  
	public void OnException(Exception e)  
	{  
		App42Log.Console("Exception : " + e);  
	}  
}  

public class UnityCallBackSaveScore : App42CallBack  
{  
	public void OnSuccess(object response)  
	{  
		Game game = (Game) response;       
		App42Log.Console("gameName is " + game.GetName());   
		for(int i = 0;i<game.GetScoreList().Count;i++)  
		{  
			App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());  
			App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());  
			App42Log.Console("scoreId is : " + game.GetScoreList()[i].GetScoreId());  
			leaderSkripta.recivedScore=game.GetScoreList()[i].GetValue()+"";
		}  
	}  
	
	public void OnException(Exception e)  
	{  
		App42Log.Console("Exception : " + e);  
	}  
}  

public class UnityCallBackGetUserRank : App42CallBack  
{  
	public void OnSuccess(object response)  
	{  
		Game game = (Game) response;       
		App42Log.Console("gameName is " + game.GetName());   
		for(int i = 0;i<game.GetScoreList().Count;i++)  
		{  
			App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());  
			App42Log.Console("rank is : " + game.GetScoreList()[i].GetRank());  
			App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());  
			App42Log.Console("scoreId is : " + game.GetScoreList()[i].GetScoreId());  

			PlayerPrefs.SetInt("rank",Int32.Parse(game.GetScoreList()[i].GetRank()));
		}  
	}  
	
	public void OnException(Exception e)  
	{  
		App42Log.Console("Exception : " + e);  
	}  
}  

public class UnityCallBackGetTopRanks : App42CallBack  
{  
	public void OnSuccess(object response)  
	{  
		Game game = (Game) response;       
		App42Log.Console("gameName is " + game.GetName());   

		for(int i = 0;i<game.GetScoreList().Count;i++)  
		{  
			App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());  
			App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());  
			App42Log.Console("scoreId is : " + game.GetScoreList()[i].GetScoreId());  
			leaderSkripta.imeR[i] = game.GetScoreList()[i].GetUserName();
			leaderSkripta.scoreR[i] = game.GetScoreList()[i].GetValue()+"";
		}  
		//MeniSkripta.posodobiLeader = true;
	}  
	
	public void OnException(Exception e)  
	{  
		App42Log.Console("Exception : " + e);  
	}  
}  
