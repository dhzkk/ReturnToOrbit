using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BaseParts : MonoBehaviour
{
    [SerializeField]
    private Image _coolDownImage;
    private Text _coolDownText;
    [SerializeField]
    private float _coolDownTime;
    private float _currentTime = 0;
    private bool isAvailable = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAvailable)
        {
            CoolDown();
            if (_currentTime <= 0)
            {
                isAvailable = true;
            }
        }
    }

    public virtual void UseParts()
    {
        
    }

    private void CoolDown()
    {
        _currentTime -= Time.deltaTime;
        _coolDownImage.fillAmount = 0 + _currentTime / _coolDownTime;
    }
    public virtual void Activate()
    {
        isAvailable = false;
        _currentTime = _coolDownTime;
    }

    public bool IsAvailable()
    {
        return isAvailable;
    }

    public void SetCoolDownImage(Image image)
    {
        _coolDownImage = image;
        _coolDownImage.fillAmount = 1f;
    }

    public void SetCoolDownText(Text text)
    {
        _coolDownText = text;
        _coolDownText.text = "";
    }
}
