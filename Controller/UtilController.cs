using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewSkills.Controller
{
    class UtilController
    {
        private static int rounds = 4;
        private static int sekWork = 1500; 
        private static int sekPause = 300; 

        private static int thirtyMinutesPauseCountDown = 0;
        
        private static int workTime = sekWork;
        private static int pauseTime = sekPause;
        private static string progessInPerCent;
        private static int afterWorkTime = sekWork;
        private static int afterPauseTime = sekPause;
        private static int startWorkTime = sekWork;
        public static int StartWorkTime { get { return startWorkTime; } set { startWorkTime = value; } }

        private static int commonRounds = rounds;
        public static int CommonRounds { get { return commonRounds; } set { commonRounds = value; } }
        public static int Rounds { get { return rounds; } set { rounds = value; } }
        public static string ProgessInPerCent { get { return progessInPerCent; } set { progessInPerCent = value; } }
        
        private static int endSum = 0;
        public static int EndSum { get { return endSum; } set { endSum = value; } }
        private static bool blockTextFieldAndTimer = false;


        private static bool doSoundPause5 = false;
        private static bool doSoundPause30 = false;
        private static bool doSoundReadyForWork = false;

        public static bool DoSoundPause5 { get { return doSoundPause5; } set { doSoundPause5 = value; } }
        public static bool DoSoundPause30 { get { return doSoundPause30; } set { doSoundPause30 = value; } }
        public static bool DoSoundReadyForWork { get { return doSoundReadyForWork; } set { doSoundReadyForWork = value; } }

        public static bool ActivateWorkOrPause { get; set; }
        public static int WorkTime { get { return workTime; } set { workTime = value; } }
        public static int PauseTime { get { return pauseTime; } set { pauseTime = value; } }
        public static int AfterPauseTime { get { return afterPauseTime; } set { afterPauseTime = value; } }
        public static int AfterWorkTime { get { return afterWorkTime; } set { afterWorkTime = value; } }
        public static bool BlockTextFieldAndTimer { get { return blockTextFieldAndTimer; } set { blockTextFieldAndTimer = value; } }

        public static int ThirtyMinutesPauseCountDown { get { return thirtyMinutesPauseCountDown; } set { thirtyMinutesPauseCountDown = value; } }

        // высчитать кол-во процентов
        public static int getProgressInPercent(int fileLineNumber, int fileLength)
        {
           return ((fileLineNumber-1) * 100) / fileLength;
           
        }

        public static void showPause(Label pauseLbl, string labelText)
        {
            pauseLbl.Visibility = Visibility.Visible;
            pauseLbl.Content = labelText;
            pauseLbl.Foreground = new SolidColorBrush(Colors.Red);
        }
    }
}
