using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Tester : MonoBehaviour
{
    [Range(1,6)]
    public int NumOfTrial = 1; //1=12, 2=24

    public List<AudioClip> AS;
    private AudioSource audioSource;

    List<string> pitch = new List<string> { "ド", "ド＃", "レ", "レ＃", "ミ", "ファ", "ファ＃", "ソ", "ソ＃", "ラ", "ラ＃", "シ"};
    List<string> totalPitch = new List<string>();

    public GameObject ColorPickedPrefab;
    private GameObject go;
    private ColorPickerTriangle CP;
    StreamWriter sw;

    private int num = 0;
    private bool isTest = true;

    DateTime dtNow;
    string dtName;

    // Start is called before the first frame update
    void Start()
    {
        for ( int i = 0; i < NumOfTrial; i++) {
            foreach (string a in pitch) {
                totalPitch.Add(a);
            }
        }
        totalPitch = totalPitch.OrderBy(a => Guid.NewGuid()).ToList();
        Debug.Log(totalPitch[num]);

        dtNow = DateTime.Now;
        dtName = dtNow.Month.ToString() + dtNow.Day.ToString() + dtNow.Hour.ToString() + dtNow.Minute.ToString();
        sw = new StreamWriter("../TestData"+ dtName + ".txt", false);

        go = ColorPickedPrefab;
        CP = go.GetComponent<ColorPickerTriangle>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ToNextTest() {
        if (num >= (NumOfTrial * 12) - 1 && isTest) {
            sw.WriteLine(totalPitch[num] + ":" + CP.TheColor.r + ", " + CP.TheColor.g + ", " + CP.TheColor.b);
            sw.Flush();// StreamWriterのバッファに書き出し残しがないか確認
            sw.Close();// ファイルを閉じる
            isTest = false;
            Debug.Log("終了です");
        }
        //カラーピッカーの色を取得
        //ファイル書込み
        if (isTest) {
            sw.WriteLine(totalPitch[num] + ":" + CP.TheColor.r + ", " + CP.TheColor.g + ", " + CP.TheColor.b); //音階：[R, G, B]
            num++;
            Debug.Log(totalPitch[num]);
        }
        //カラーピッカーの色を白にリセット
        CP.TheColor = Color.white;
    }

    private void OnMouseDown() {
        switch(totalPitch[num]) {
            case "ド":
                audioSource.clip = AS[0];
                audioSource.Play();
                break;
            case "ド＃":
                audioSource.clip = AS[1];
                audioSource.Play();
                break;
            case "レ":
                audioSource.clip = AS[2];
                audioSource.Play();
                break;
            case "レ＃":
                audioSource.clip = AS[3];
                audioSource.Play();
                break;
            case "ミ":
                audioSource.clip = AS[4];
                audioSource.Play();
                break;
            case "ファ":
                audioSource.clip = AS[5];
                audioSource.Play();
                break;
            case "ファ＃":
                audioSource.clip = AS[6];
                audioSource.Play();
                break;
            case "ソ":
                audioSource.clip = AS[7];
                audioSource.Play();
                break;
            case "ソ＃":
                audioSource.clip = AS[8];
                audioSource.Play();
                break;
            case "ラ":
                audioSource.clip = AS[9];
                audioSource.Play();
                break;
            case "ラ＃":
                audioSource.clip = AS[10];
                audioSource.Play();
                break;
            case "シ":
                audioSource.clip = AS[11];
                audioSource.Play();
                break;
        }
    }

}
