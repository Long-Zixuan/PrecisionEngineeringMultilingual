using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static ColossalFramework.Globalization.Locale;
using UnityEngine;

namespace PrecisionEngineering.Data.Language
{
    internal class Language
    {
        Dictionary<string,string> simChinese = new Dictionary<string, string>();
        Dictionary<string, string> traChinese = new Dictionary<string, string>();
        Dictionary<string, string> currentLanguage;

        static Language instance = new Language();
        
        public static Language Instance
        {
            get
            {
                return Instance;
            }
        }

        Dictionary<string, string> LangStringToDictionary<TKey, TValue>(string langStr)
        {
            Dictionary<string, string> langDict = new Dictionary<string, string>();
            foreach (var key in langStr.Split('\n'))
            {
                Console.WriteLine(key);
                try
                {
                    langDict.Add(key.Split(':')[0], key.Split(':')[1]);
                }
                catch { }
                Console.ReadLine();
            }
            return langDict;
        }

        Dictionary<string, string> initLangDictionary(string sysLang)
        {
            string jsonPath = Path.GetFullPath(sysLang);
            string jsonString = File.ReadAllText(jsonPath);
            return LangStringToDictionary<string, string>(jsonString);
        }

        Language() 
        {
            string sysLanguage = System.Globalization.CultureInfo.InstalledUICulture.Name;
            if(sysLanguage == "zh-CN")
            {
                currentLanguage = initLangDictionary("./zh_cn.lang");
            }
            if(sysLanguage == "zh-TW" ||  sysLanguage == "zh-HK")
            {
                currentLanguage = initLangDictionary("./zh_tw.lang");
            }
        }

        public string trans(string text) 
        {
            if (currentLanguage.Count > 0) 
            {
                try
                {
                    return currentLanguage[text];
                }
                catch 
                {
                    return "MSGNotFound";
                }
            }
            return text;
        }

    }
}

//LZX-T-VS2022-2025-04-03-001

