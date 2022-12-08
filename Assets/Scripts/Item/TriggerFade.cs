using UnityEngine;

public class TriggerFade : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Get the gameobject we have collided with, and then get all the Obscuring Item Fader components on it and its children - and then trigger the fade out

        Fader_Item[] obscuringItemFader = collision.gameObject.GetComponentsInChildren<Fader_Item>();

        if (obscuringItemFader.Length > 0)
        {
            for (int i = 0; i < obscuringItemFader.Length; i++)
            {
                obscuringItemFader[i].FadeOut();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Get the gameobject we have collided with, and then get all the Obscuring Item Fader components on it and its children - and then trigger the fade in

        Fader_Item[] obscuringItemFader = collision.gameObject.GetComponentsInChildren<Fader_Item>();

        if (obscuringItemFader.Length > 0)
        {
            for (int i = 0; i < obscuringItemFader.Length; i++)
            {
                obscuringItemFader[i].FadeIn();
            }
        }

    }
}
