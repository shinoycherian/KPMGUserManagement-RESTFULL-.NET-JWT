

namespace Mover.CandidateTest.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mover.CandidateTest.Application.ViewModels.WatchHand;
    /// <summary>
    /// 
    /// </summary>
    public class WatchService : IWatchService

    {
        /// <summary>
        /// .ctor
        /// </summary>
        public WatchService()  
        {
           
        }/// <summary>
        /// Calculate the smaller angle between Hour hand and Minutehad of Watch.
        /// </summary>
        /// <param name="watchhandsmodel"></param>
        /// <returns></returns>
        public double GetLeastAngle(CalculateLeastAngleRequestModel watchhandsmodel)
        {
            DateTime dateTime = watchhandsmodel.DateTime;
            //take the hour part.
            int hour = dateTime.Hour;
            //manage the 24 hour based hour part.
            if (dateTime.Hour > 12)
            {
                hour=hour- 12;
            }
            //take the minute part.
            int minute = dateTime.Minute;
            return GetLeastAngle( hour, minute);
        }

        public double GetLeastAngle(int hour, int minute)
        {


            if (hour < 0 || minute < 0 || hour > 12 || minute > 60)
                throw new Exception("Invalid Input.");
                ///the angle moved by Hour hand in 1H = 30 degree.
                ///the angle moved by Hour hand in 1 M = 0.5 degree.
                ///the angle moved by Hour hand in H hour :M Minute = H*60*0.5+M*0.5= 0.5(H*60+M) Degree.

                double hourangle = (double)(0.5 * (hour * 60 + minute));

            /// the angle moved by Minute hand in 60 M= 360 Degree  
            /// the angle moved by Minute hand in 1 M= 6 Degree  
            ///the angle moved by Minute hand in H hour :M Minute =(M*6) Degree.

            double minuteangle = (double)(6 * minute);

            /// The delta between  the angle progressed by Hour and Minute Hand.
            /// 0.5(H*60+M) - (M*6)
            /// 
            double angle = Math.Abs(hourangle - minuteangle);

            //Calculate the smaller angle .
            angle = Math.Min(360 - angle, angle);

            return angle;


        }
    }
}
