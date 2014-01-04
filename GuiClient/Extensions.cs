using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ThriftInterface
{
    partial class DateInfo
    {
        public DateInfo(DateTime SourceDate)
        {
            this.Year = SourceDate.Year;
            this.Day = SourceDate.Day;
            this.Month = SourceDate.Month;
            this.Hour = SourceDate.Hour;
            this.Minutes = SourceDate.Minute;
            this.Seconds = SourceDate.Second;
        }
        public DateTime ToDateTime()
        {
            return new DateTime(this.Year, this.Month, this.Day, this.Hour, this.Minutes, this.Seconds);
        }
    }
    partial class Capsule
    {
        public string DisplayProp
        {
            get
            {
                return this.Title + " (" + Utils.ToGb(this.AvailableSizeInBytes)
                    + "/" + Utils.ToGb(this.TotalSizeInBytes) + ") GB";
            }
        }
    }
    partial class Archive
    {
        public string DisplayProp { get { return this.Info.Title; } }
    }
    partial class Certificate
    {
        public string DisplayProp { get { return this.RelatedArchive.Title; } }
    }
    
    static class Utils
    {
        const int decimals = 2;
        private static int bytesInMb = 1024 * 1024;
        private static int bytesInGb = 1024 * 1024 * 1000;
        public static double ToMb(long bytes)
        {
            return Math.Round(bytes / ((double)bytesInMb), decimals);
        }
        public static double ToGb(long bytes)
        {
            return Math.Round(bytes / ((double)bytesInGb), decimals);
        }
    }

}
