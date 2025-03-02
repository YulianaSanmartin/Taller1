using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Taller1
{
    public class Time
    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour)
        {
            _hour = ValidateHour(hour);
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour, int minute)
        {
            _hour = ValidateHour(hour);
            _minute = ValidateMinute(minute);
            _second = 0;
            _millisecond = 0;
        }

        public Time(int hour, int minute, int second)
        {
            _hour = ValidateHour(hour);
            _minute = ValidateMinute(minute);
            _second = ValidateSecond(second);
            _millisecond = 0;
        }
        public Time(int hour, int minute, int second, int millisecond)
        {
            _hour = ValidateHour(hour);
            _minute = ValidateMinute(minute);
            _second = ValidateSecond(second);
            _millisecond = ValidateMillisecond(millisecond);
        }
        public int Hour
        {
            get => _hour;
            set => _hour = value;
        }
        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = value;

        }
        public int Minute
        {
            get => _minute;
            set => _minute = value;

        }
        public int Second
        {
            get => _second;
            set => _second = value;

        }
        public override string ToString()
        {
            return $"{(_hour == 0 ? "00" : _hour % 12 == 0 ? "12" : (_hour % 12).ToString("D2"))}:{_minute:D2}:{_second:D2}.{_millisecond:D3} {(_hour < 12 ? "AM" : "PM")}";
        }
        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException($"La hora : {hour} es inválida");
            }
            return hour;
        }

        private int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException($"El minuto : {minute} es inválido");
            }
            return minute;
        }

        private int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException($"El segundo : {second} es inválido");
            }
            return second;
        }

        private int ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentOutOfRangeException($"El milisegundo : {millisecond} es inválido");
            }
            return millisecond;
        }

        public int ToMilliseconds()
        {
            return _hour * 3600000 + _minute * 60000 + _second * 1000 + _millisecond;
        }

        public int ToSeconds()
        {
            return _hour * 3600 + _minute * 60 + _second;
        }

        public int ToMinutes()
        {
            return _hour * 60 + _minute;
        }
       
        public Time Add(Time other)

        {
            long totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();
            int hours = (int)((totalMilliseconds / 3600000) % 24);
            int minutes = (int)((totalMilliseconds / 60000) % 60);
            int seconds = (int)((totalMilliseconds / 1000) % 60);
            int milliseconds = (int)(totalMilliseconds % 1000);
            return new Time(hours, minutes, seconds, milliseconds);
        }

        public bool IsOtherDay(Time other) => (this.ToMilliseconds() + other.ToMilliseconds()) >= 86400000;
    }


}







