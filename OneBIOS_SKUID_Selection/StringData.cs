using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBIOS_SKUID_Selection
{

    public static class StringData{
        const int NO_ANS = -1;
        public static List<List<Selection>> getButtonData
        {
            get
            {
                return new List<List<Selection>>() { 
                new List<Selection>(){ new Selection("FreeDOS",-1,0),new Selection("Windows",1,NO_ANS),new Selection("Linux",-1,13)}, 
                new List<Selection>(){ new Selection("Single load",1,NO_ANS),new Selection("Dual load",7,NO_ANS)},
                new List<Selection>(){ new Selection("Win7",1,NO_ANS),new Selection("Win10 Pro",5,NO_ANS) ,new Selection("Win10",4,NO_ANS)},
                new List<Selection>(){ new Selection("EFI",1,NO_ANS),new Selection("Lagacy",2,NO_ANS)},
                new List<Selection>(){ new Selection("RAID",-1,1),new Selection("AHCI",-1,2)},//q5
                new List<Selection>(){ new Selection("RAID",-1,3),new Selection("AHCI",-1,4)},//q5
                new List<Selection>(){ new Selection("RAID",-1,5),new Selection("AHCI",-1,6)},//q4
                new List<Selection>(){ new Selection("RAID",-1,7),new Selection("AHCI",-1,8)},//q4
                new List<Selection>(){ new Selection("Win7/Win7",1,NO_ANS),new Selection("Win10/Win7",2,NO_ANS)},//q3
                new List<Selection>(){ new Selection("RAID",-1,9),new Selection("AHCI",-1,10)},//q4
                new List<Selection>(){ new Selection("RAID",-1,11),new Selection("AHCI",-1,12)},//q4
            };
            }
        }

        public static List<string> getQuestionData 
        {
            get
            {
                return new List<string>(new string[] { 
                "Q1:FreeDOS, Linux or Windows?",
                "Q2:Single load or Dual load?",
                "Q3:Win7, Win10 or Win10 Pro?",
                "Q4:Legacy or EFI?",
                "Q5:AHCI or RAID?",
                "Q5:AHCI or RAID?",
                "Q4:AHCI or RAID?",
                "Q4:AHCI or RAID?",
                "Q3:Win7/Win7 or Win10/Win7?",
                "Q4:AHCI or RAID?",
                "Q4:AHCI or RAID?"
            });
            }   
        }
        public static List<string> getAnsData
        {
            get
            {
                return new List<string>(){
                "FreeDOS/Legacy/AHCI \r\nSKU ID: 0001h \r\nFDOSMBAH.BAT",
                "Win7 64bit/EFI/RAID \r\nSKU ID: 0006h \r\nWIN7GPRD.BAT",
                "Win7 64bit/EFI/AHCI \r\nSKU ID: 0002h \r\nWIN7GPAH.BAT",
                "Win7 64bit/Legacy/RAID \r\nWin7 32bit/Legacy/RAID \r\nSKU ID: 0007h \r\nWIN7MBRD.BAT",
                "Win7 64bit/Legacy/AHCI \r\nWin7 32bit/Legacy/AHCI \r\nSKU ID: 0003h \r\nWIN7MBAH.BAT",
                "Win10/EFI/RAID \r\nSKU ID: 0008h \r\nWINAGPRD.BAT",
                "Win10/EFI/AHCI \r\nSKU ID: 0004h \r\nWINAGPAH.BAT",
                "Win10 Pro/EFI/RAID \r\nSKU ID: 000Bh \r\nWAPRGPRD.BAT",
                "Win10 Pro/EFI/AHCI \r\nSKU ID: 000Ah \r\nWAPRGPAH.BAT",
                "Win7 64bit/Win7 32bit/Legacy/RAID \r\nSKU ID: 0007h \r\nWIN7MBRD.BAT",
                "Win7 64bit/Win7 32bit/Legacy/AHCI \r\nSKU ID: 0003h \r\nWIN7MBAH.BAT",
                "Win10/Win7/EFI/RAID \r\nSKU ID: 0009h \r\nWAW7GPRD.BAT",
                "Win10/Win7/EFI/AHCI \r\nSKU ID: 0005h \r\nWAW7GPAH.BAT",
                "Linpus Linux/EFI/AHCI \r\nSKU ID: 000Ch \r\nLNUXGPAH.BAT"

            };
            }
        }
        public static Dictionary<string, BUTTON_POSIOION> ButtonType
        {
            get
            {
                return new Dictionary<string, BUTTON_POSIOION>()
                {
                    {"LButton",BUTTON_POSIOION.left},
                    {"RButton",BUTTON_POSIOION.right},
                    {"MButton",BUTTON_POSIOION.mid},
                    {"UndoButton",BUTTON_POSIOION.undo}
                };
            }
        }

    }
}
