using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Textmanager : MonoBehaviour
{
    public GameObject textbox;
    public TextMeshProUGUI theText;
    public TextAsset text;
    public string[] textlines;
    public int currline;
    public int endline;
    public bool active;
    public TextAsset blank;

    // Start is called before the first frame update
    void Start()
    {
        if (text != null)
        {
            textlines = (text.text.Split('\n'));
        }

        if (endline == 0)
        {
            endline = textlines.Length;
        }
        if (active)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            return;
        }
        theText.text = textlines[currline];

        if(currline == endline)
        {
            DisableTextBox();
        }
    }


    public void EnableTextBox()
    {
        textbox.SetActive(true);
        active = true;
    }

    public void DisableTextBox()
    {
        textbox.SetActive(false);
        active = false;
        textlines = new string[]{"  ", "  "};
        theText.text = textlines[currline];
    }
    
    public void Reload(TextAsset texts)
    {
        if (texts != null)
        {
            textlines = new string[1];
            textlines = (texts.text.Split('\n'));
        }
    }

    public void Continue()
    {
        print("testing");
        if (active)
        {
            currline++;
            if(currline < endline)
            {
                theText.text = textlines[currline];
            }
            else
            {
                DisableTextBox();
            }
        }
    }
}
