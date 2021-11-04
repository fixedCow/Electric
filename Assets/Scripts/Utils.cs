using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
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
