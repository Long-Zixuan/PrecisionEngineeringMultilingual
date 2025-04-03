using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        void initSimChinese()
        {
            simChinese.Add("Angle", "角度");
            simChinese.Add("facing", "面向");
            simChinese.Add("Distance", "距离");
            simChinese.Add("IsStraight", "是否为直线");
            simChinese.Add("Width", "宽度");
            simChinese.Add("Build with precision. Hold CTRL to enable angle snapping, SHIFT to show more information, ALT to snap to guide-lines.", "精确构建。按住CTRL键可启用角度捕捉，按住SHIFT键可显示更多信息，按住ALT键可捕捉到参考线。");

        }

        void initTraChinese() 
        {
            traChinese.Add("Angle", "角度");
            traChinese.Add("facing", "面向");
            traChinese.Add("Distance", "距離");
            traChinese.Add("IsStraight", "是否為直線");
            traChinese.Add("Width", "寬度");
            traChinese.Add("Build with precision. Hold CTRL to enable angle snapping, SHIFT to show more information, ALT to snap to guide-lines.", "精確構建。 按住CTRL鍵可啟用角度捕捉，按住SHIFT鍵可顯示更多資訊，按住ALT鍵可捕捉到參攷線。");
        }

        Language() 
        {
            string sysLanguage = System.Globalization.CultureInfo.InstalledUICulture.Name;
            if(sysLanguage == "zh-CN")
            {
                initSimChinese();
                currentLanguage = simChinese;
            }
            if(sysLanguage == "zh-TW" ||  sysLanguage == "zh-HK")
            {
                initTraChinese();
                currentLanguage = traChinese;
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

//这个项目不想再导入第三方库和json文件了，就这么招吧
//LZX-T-VS2022-2025-04-03-001

