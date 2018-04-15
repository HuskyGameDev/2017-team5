using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour {

    private int pieces;
    private int collectedItems;
    private bool collected = false;
    private Text itemText;

    public Text levelItem;
<<<<<<< HEAD
=======
    public int collectedItems;
>>>>>>> 9af39300d26a0939acfb1d960f6d680018d56ca0
    public int levelPieces;

    private void Start()
    {
        itemText = GetComponent<Text>();
        pieces = 0;
    }

    private void Update()
    {
        if (collected)
        {
            itemText.text = levelItem.text + " collected!";
        }
        else
        {
            itemText.text = "Pieces: " + pieces;
        }
    }

    public void addPiece()
    {
        pieces++;

        if (pieces == 3)
        {
            //addItem(levelItem);
            collected = true;
            GameObject.Find("LifeCounter").GetComponent<LifeCounter>().AddLife();
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        pieces = 0;
        collected = false;
    }

    public int getPieces()
    {
        return pieces;
    }

    public void addItem(Text item)
    {
        collectedItems++;
        //toInventory(item);
    }

    public void useItem(Text item)
    {
        collectedItems--;
        //fromInventory(item);
    }
}
