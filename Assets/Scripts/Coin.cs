using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    void Start()
    {
        collectableName = "Coin";
        description = "increase score by 10";
        DontDestroyOnLoad(this.gameObject);
    }

    override public void Use()
    {
        player.GetComponent<playerManager>().ChangeScore(10);
        Destroy(this.gameObject);
    }

}
