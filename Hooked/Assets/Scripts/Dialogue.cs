/*---------The Platformers-------
 * Contributors: Patrick
 * Prupose: Class to display and advance the dialogue on the tutorial level
 * GameObjects associated: Branch, Arrow
 * Files Associated: 
 * Source:
 *--------------------------------*/
using System.Collections;
using UnityEngine;
using TMPro;

//script added by Patrick Sepnio

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        } //end outer if statement
        
    } //end Update method

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //type each character 1 by 1
        foreach (char c in lines[index].ToCharArray() )
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } //end if statement
        else
        {
            gameObject.SetActive(false);
        }
    }

}
