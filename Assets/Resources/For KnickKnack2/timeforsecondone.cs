using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
public class timeforsecondone : MonoBehaviour
{
    public GameObject timeTextObject;
    public string url = "http://worldtimeapi.org/api/timezone/America/Chicago";
    public class TimeObject{
        public string datetime;
    }
    
    void Start(){
        InvokeRepeating("UpdateTime", 0f, 10f); 
    }

    // Update is called once per frame
    void UpdateTime(){
        StartCoroutine(getthetime());
    }
    public IEnumerator getthetime(){  
        using(UnityWebRequest request = UnityWebRequest.Get(url)){
            yield return request.SendWebRequest();  
            if(request.result == UnityWebRequest.Result.ConnectionError){
                Debug.LogError(request.error);
            }
            else{
                Debug.Log("Success");
                var text = request.downloadHandler.text;
                TimeObject timeforchicago = JsonUtility.FromJson<TimeObject>(text);
                //parse timeforchicago.datetime.substring
                var DISPLAYtime = timeforchicago.datetime.Substring(11,5);
                timeTextObject.GetComponent<TextMeshPro>().text = DISPLAYtime;
            }
        }
        
    }

}
