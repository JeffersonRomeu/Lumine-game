using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardMenu : MonoBehaviour {

    public GameObject rewardMenu;
    public GameObject gift;
    public GameObject text1;
    public GameObject text2;
    public GameObject scoreMenu;
    private float countToExit;
    private Animator animGift;
    private Animator animText1;
    private Animator animText2;

    public Text text;

    private Vector3 giftPosition;

	void Start ()
    {
        animGift = gift.GetComponent<Animator>();
        animText1 = text1.GetComponent<Animator>();
        animText2 = text2.GetComponent<Animator>();
        giftPosition = gift.transform.position;
	}
	
	void Update () {
		
	}

    public void Reward()
    {
        rewardMenu.SetActive(true);
        text2.SetActive(true);
        countToExit++;
        animGift.Play("presente");
        animText1.Play("fadeOut");
        animText2.Play("fadeIn");
        // play objeto aleatorio saindo de dentro

        if (countToExit == 2)
        {
            // return text1 alpha color
            //text.text = text.ToString();
            //Color alphaColor = text.color;
            //alphaColor.a = 250f;

            Color alphaColor = text.color;
            alphaColor.a = 250f;
            text.color = alphaColor;

            text2.SetActive(false);
            rewardMenu.SetActive(false);
            scoreMenu.SetActive(true);
            countToExit = 0f;
            gift.transform.position = giftPosition;
        }
    }

    public void openReward()
    {
        //Instantiate<>
    }
}
