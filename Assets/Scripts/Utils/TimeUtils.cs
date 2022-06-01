using System;

namespace TimeUtils {
    public static class TimeConvert{
        public static string IntToTime(int t){
            int min = t/60;
            int sec = t%60;
            string strMin = min<=9 ? $"0{min}" : $"{min}";
            string strSec = sec<=9 ? $"0{sec}" : $"{sec}";
            return $"{strMin}:{strSec}";
        }
    }
}