using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour {

    private int pieces;
    private Text itemText;

    public int collectedItems;
    public int levelPieces;
    public Text levelItem;

    private void Start()
    {
            itemText = GetComponent<Text>();
            pieces = 0;
    }

    private void Update()
    {
        itemText.text = "Item Pieces Collected: " + pieces;
    }

    public void addPiece()
    {
        pieces++;

        if (pieces == levelPieces)
        {
            //addItem(levelItem);
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
