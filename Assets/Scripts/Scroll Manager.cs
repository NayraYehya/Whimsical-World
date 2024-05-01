using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    public ScrollRect scrollView;
    public Transform spriteMask;
    public GameObject spritePrefab;

    public int spriteCount = 5;
    public int max;
    public float spriteSpacing;

    private List<GameObject> instantiatedSprites = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        max = spriteCount;
        UpdateContentSize();
    }

    public void InstantiateSprite()
    {
        if (spriteCount > 0)
        {
            spriteCount--;
            GameObject sprite = Instantiate(spritePrefab, spriteMask);
            instantiatedSprites.Add(sprite);
            UpdateContentSize();
        }
    }

    public void RemoveLastSprite()
    {
        if (instantiatedSprites.Count > 0)
        {
            Destroy(instantiatedSprites[instantiatedSprites.Count - 1]);

            instantiatedSprites.RemoveAt(instantiatedSprites.Count - 1);

            spriteCount++;
            UpdateContentSize();
        }
    }
    public void UpdateContentSize()
    {
        float contentHeight = spriteCount * spriteSpacing;
        scrollView.content.sizeDelta = new Vector2(0, contentHeight);
    }
}
