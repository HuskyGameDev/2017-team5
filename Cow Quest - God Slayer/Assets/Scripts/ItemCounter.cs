using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour {

    private int pieces;
    private bool collected = false;
    private Text itemText;
    private Text levelItem;

    public int collectedItems;
    public int levelPieces;

    private void Start()
    {
        itemText = GetComponent<Text>();
        levelItem = GameObject.Find("/LevelPack/UI/level_item").GetComponent<Text>();
        pieces = 0;
    }

    private void Update()
    {
        if (collected)
        {
            itemText.text = levelItem + " collected!";
        }
        else
        {
            itemText.text = "Item Pieces Collected: " + pieces;
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
