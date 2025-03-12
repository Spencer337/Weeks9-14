using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpriteSwap : MonoBehaviour
{
    public SpriteRenderer CurrentSprite;
    public Sprite RedLight;
    public Sprite GreenLight;

    public void StopLight()
    {
        CurrentSprite.sprite = RedLight;
    }

    public void GoLight()
    {
        CurrentSprite.sprite = GreenLight;
    }
}
