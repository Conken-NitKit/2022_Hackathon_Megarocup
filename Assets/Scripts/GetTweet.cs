using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Responses;

public class GetTweet : MonoBehaviour {
    public static string Tweet;
    private string[] word = new string[] {"政治"};
    int w = 0;
    void Start () {
        Twity.Oauth.consumerKey       = "sa8ZnjENATdmEVIgXUpZlo9N1";
        Twity.Oauth.consumerSecret    = "IGvZ5wXPnb9fCqt4yftBli95XwFckppeezjF1oXgnOShPj1m8d";
        Twity.Oauth.accessToken       = "1208376401134407680-H8jSCykAstsIcemk8b0pGfTkOdvm8o";
        Twity.Oauth.accessTokenSecret = "XzHYeSql4FHiMW12UMVRhxlldQ5OTdr73E3juFvRnn40M";

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters ["q"] = word[w];
        Debug.Log(parameters["q"]);
        parameters ["count"] = "1";
        StartCoroutine (Twity.Client.Get ("search/tweets", parameters, Callback));
    }

    void Callback(bool success, string response) {
        if (success) {
            SearchTweetsResponse Response = JsonUtility.FromJson<SearchTweetsResponse>(response);
            for(int i = 0;i <Response.statuses.Length;i++){
                string text = Response.statuses[i].text;
                Tweet = text;
                Debug.Log(Tweet);
            }
        } else {
            Debug.Log(response);
        }
    }
}