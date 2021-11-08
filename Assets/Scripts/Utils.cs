using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Vector2 mousePos { get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); } }

    char[] familyName = { '고', '서', '김', '이', '박', '최', '정', '한', '강', '조', '성', '장', '송', '벡' };
    char[] middleName = { '정', '혜', '성', '민', '태', '연', '수', '해', '지', '찬', '현', '재', '후', '건', '갑', '말' };
    char[] lastName = { '우', '진', '민', '호', '연', '수', '현', '엽', '자', '돌', '순', '영', '훈', '현', '준', '형', '준' };
    public string MakeName()
    {
        string str = "";
        str += familyName[Random.Range(0, familyName.Length)];
        str += middleName[Random.Range(0, middleName.Length)];
        str += lastName[Random.Range(0, lastName.Length)];
        return str;
    }
}
public class PS
{
    public Vector2 position;
    public Vector3 scale;

    public PS(Vector2 position, Vector3 scale)
    {
        this.position = position;
        this.scale = scale;
    }
    public PS(Vector2 position)
    {
        this.position = position;
        this.scale = new Vector3(1, 1, 1);
    }
}
