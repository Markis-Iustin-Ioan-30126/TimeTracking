namespace TimeTrackingClient
{
    class TimeTrackingRecordWrapper
    {
        public int employeeId { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int checkInHour { get; set; }
        public int checkInMinute { get; set; }
        public int checkInSecond { get; set; }
        public int checkOutHour { get; set; }
        public int checkOutMinute { get; set; }
        public int checkOutSecond { get; set; }

        public TimeTrackingRecordWrapper(int employeeId, int year, int month,
            int day, int checkInHour, int checkInMinute, int checkInSecond,
            int checkOutHour, int checkOutMinute, int checkOutSecond)
        {
            this.employeeId = employeeId;
            this.year = year;
            this.month = month;
            this.day = day;
            this.checkInHour = checkInHour;
            this.checkInMinute = checkInMinute;
            this.checkInSecond = checkInSecond;
            this.checkOutHour = checkOutHour;
            this.checkOutMinute = checkOutMinute;
            this.checkOutSecond = checkOutSecond;
        }
    }
}
