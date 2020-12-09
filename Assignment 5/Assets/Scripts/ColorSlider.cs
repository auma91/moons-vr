using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSlider : MonoBehaviour
{
    // Start is called before the first frame update

    // Drag & drop slider
    public UnityEngine.UI.Slider ColSlider;

    // Drag & drop handle
    public UnityEngine.UI.Image handle;

    public Image background;
    public Image fill;
    public Text txt;
    public Text txt1;
    public Text txt2;
    public Text txt3;
    public GameObject VRReticle;
    public void Start()
    {
        Color[] colors = new Color[] { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta, Color.red };
        var hueTex = new Texture2D(colors.Length, 1);
        hueTex.SetPixels(colors);
        hueTex.Apply();
        background.sprite = Sprite.Create(hueTex, new Rect(Vector2.zero, new Vector2(colors.Length, 1)), Vector2.one * 0.5f);
        fill.sprite = background.sprite;
        ColSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        handle.color = Color.HSVToRGB(ColSlider.value, 1, 1);
        txt.color = handle.color;
        txt1.color = handle.color;
        txt2.color = handle.color;
        txt3.color = handle.color;
        var VRRenderer = VRReticle.GetComponent<Renderer>();
        PlayerPrefs.SetFloat("ThemeAlpha", handle.color.a);
        PlayerPrefs.SetFloat("ThemeRed", handle.color.r);
        PlayerPrefs.SetFloat("ThemeBlue", handle.color.b);
        PlayerPrefs.SetFloat("ThemeGreen", handle.color.g);

        //Call SetColor using the shader property name "_Color" and setting the color to red
        VRRenderer.material.SetColor("_Color", handle.color);
    }
}
