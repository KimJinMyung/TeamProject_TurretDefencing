using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Command_Input_Mark : MonoBehaviour
{
    [SerializeField] private Image[] inputImage;
    [SerializeField] private Sprite[] directImage;
    [SerializeField] private Sprite xImage;
    [SerializeField] private Button button;
    [SerializeField] private Button exit;

    private void OnEnable()
    {
        foreach (Image item in inputImage)
        {
            item.sprite = null;
        }
    }
    public void CommandMark()
    { 
        StartCoroutine(OnCommandMark());
    }
    private IEnumerator OnCommandMark()
    {
        int Count = 0;
        while(Count < inputImage.Length)
        {
            yield return new WaitUntil(() => Input.anyKeyDown);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                inputImage[Count].sprite = directImage[0];
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                inputImage[Count].sprite = directImage[1];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                inputImage[Count].sprite = directImage[2];
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                inputImage[Count].sprite = directImage[3];
            }
            else
            {
                inputImage[Count].sprite = xImage;
            }
            Count++;
        }
        if (Count == inputImage.Length)
        {
            yield return new WaitUntil(() => Input.anyKeyDown);
            if(Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                button.interactable = true;
                exit.interactable = true;
                Focus(button);
            }
        }
    }

    private void Focus(Button button)
    {
        EventSystem.current.SetSelectedGameObject(button.gameObject);
    }

}
