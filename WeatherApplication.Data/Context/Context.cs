using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Data.Service;

namespace WeatherApplication.Data.Context
{
    public class Context
    {
        private const string KEY = "62aba845660b543d538a3f624bd9fcc2";

        private WeatherRepository _weatherRepository;

        public WeatherRepository WeatherRepository
        {
            get
            {
                if (this._weatherRepository == null)
                    _weatherRepository = new WeatherRepository(KEY);
                return this._weatherRepository;
            }
        }

    }
}
