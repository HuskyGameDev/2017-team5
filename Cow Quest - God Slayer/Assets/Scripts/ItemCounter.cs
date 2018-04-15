using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour {

    private int pieces;
    private bool collected = false;
    private Text itemText;

    public Text levelItem;
    public int collectedItems;
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

        if (pieces == levelPieces)
        {
            //addItem(levelItem);
            collected = true;
        }
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
