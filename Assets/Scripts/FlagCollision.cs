using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagCollision : MonoBehaviour
{
    public Text messageText; 
    public string message = "Congrats on reaching the end! Thanks for playing!";
    public float displayTime = 3f; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowMessage();
    }

    void ShowMessage()
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true); 
        StartCoroutine(HideMessageAfterTime());
    }

    IEnumerator HideMessageAfterTime()
    {
        yield return new WaitForSeconds(displayTime);
        messageText.gameObject.SetActive(false); 
    }
}
