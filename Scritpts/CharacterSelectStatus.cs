using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectStatus : MonoBehaviour
{
    //cached references
    [SerializeField] TextMeshProUGUI p1SelectText;
    [SerializeField] TextMeshProUGUI p2SelectText;

    [SerializeField] Button SentryManIcon;
    [SerializeField] Button LaserGalIcon;

    [SerializeField] Selector selector;

    [SerializeField] GameObject SentryManPreFab;
    [SerializeField] GameObject LaserGalPreFab;

    Player player1;
    Player player2;

    // Start is called before the first frame update
    void Start()
    {
        //p1SelectText.GetComponent<Renderer>().enabled = false;
        p2SelectText.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Select(Player player)
    {
        if(selector.GetPosition().Equals(SentryManIcon) && selector.GetClicked())
        {
            
        }
    }
}
