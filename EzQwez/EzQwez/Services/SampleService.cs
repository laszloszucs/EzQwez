using System;

namespace EzQwez.Services
{
    public class SampleService : ISampleService
    {
        public string GetCurrentDate() => DateTime.Now.ToLongDateString();
    }
}
