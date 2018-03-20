using System;

namespace csharp_intermediate_exercises
{
    public class Stopwatch
    {

        private DateTime _startTime = new DateTime();
        private DateTime _stopTime = new DateTime();
        private TimeSpan _totalTime = new TimeSpan();
        private bool _started = false;

        public Stopwatch()
        {

        }

        public TimeSpan Duration
        {
            get
            {
                return _totalTime;
            }
        }

        public void Start()
        {
            if (_started)
                throw new InvalidOperationException("Stopwatch has already started.");
            
            _startTime = DateTime.Now;
            _started = true;
        }

        public void Stop()
        {
            if(!_started)
                throw new InvalidOperationException("Stopwatch has not been started.");

            _stopTime = DateTime.Now;
            _totalTime += _stopTime.Subtract(_startTime);
            _started = false;
        }

    }
}
