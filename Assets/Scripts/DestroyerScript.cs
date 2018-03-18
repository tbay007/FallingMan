using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("FloorShortBarrierTransparent") || collision.name.Equals("FloorLongBarrierTransparent"))
        {
            PublicSettingsManagerScript.score += 1;
            PublicSettingsManagerScript.ScoreString = "Score: " + PublicSettingsManagerScript.score.ToString();
            PublicSettingsManagerScript.CheckLevel();
        }
        //if (collision.tag == "")
        //{
        //    Debug.Break();
        //    return;
        //}
        if(collision.gameObject.transform.parent)
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

}
