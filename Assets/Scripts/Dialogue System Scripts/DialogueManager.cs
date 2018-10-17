using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    public static DialogueManager instance;

    [SerializeField]
    private Canvas dialogueCanvas;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text sentenceText;
    [SerializeField]
    [Range(0, 1)]
    private float waitTime;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        sentences = new Queue<string>();

    }

    internal void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        dialogueCanvas.gameObject.SetActive(true);
        nameText.text = dialogue.npcName;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            string text = sentences.Dequeue();
            StopCoroutine("SentenceDisplayer");
            StartCoroutine(SentenceDisplayer(text));
        }
    }
    IEnumerator SentenceDisplayer(string sentence) {
        sentenceText.text = "";
        foreach (char letter in sentence) {
            sentenceText.text += letter;
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void EndDialogue()
    {
        dialogueCanvas.gameObject.SetActive(false);
        Player.instance.endDialogue();
    }
}
