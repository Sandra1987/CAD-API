using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Helper
{
    public enum RetrievalOptions
    {
        GetAll,
        GetFollowingOnes,
        GetPreviousOnes
    }

    public static class EnumUtils {
        public static void GetStartAndEndTimes(RetrievalOptions option, out DateTime startTime, out DateTime endTime) {

            startTime = DateTime.MinValue;
            endTime = DateTime.MaxValue;

            switch (option)
            { 
                case RetrievalOptions.GetFollowingOnes:
                    startTime = DateTime.Now;
                    break;
                case RetrievalOptions.GetPreviousOnes:
                    endTime = DateTime.Now;
                    break;
            }
        }
        
    }
}
