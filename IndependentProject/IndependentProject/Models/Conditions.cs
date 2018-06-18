using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject.Models
{
    class Conditions
    {
    }

    public class Features
    {
        public int Conditions { get; set; }
    }

    public class Response
    {
        public string Version { get; set; }
        public string TermsofService { get; set; }
        public Features Features { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public class DisplayLocation
    {
        public string Full { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string State_name { get; set; }
        public string Country { get; set; }
        public string Country_iso3166 { get; set; }
        public string Zip { get; set; }
        public string Magic { get; set; }
        public string Wmo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elevation { get; set; }
    }

    public class ObservationLocation
    {
        public string Full { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Country_iso3166 { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elevation { get; set; }
    }

    public class Estimated
    {
    }

    public class CurrentObservation
    {
        public Image Image { get; set; }
        public DisplayLocation Display_location { get; set; }
        public ObservationLocation Observation_location { get; set; }
        public Estimated Estimated { get; set; }
        public string Station_id { get; set; }
        public string Observation_time { get; set; }
        public string Observation_time_rfc822 { get; set; }
        public string Observation_epoch { get; set; }
        public string Local_time_rfc822 { get; set; }
        public string Local_epoch { get; set; }
        public string Local_tz_short { get; set; }
        public string Local_tz_long { get; set; }
        public string Local_tz_offset { get; set; }
        public string Weather { get; set; }
        public string Temperature_string { get; set; }
        public double Temp_f { get; set; }
        public double Temp_c { get; set; }
        public string Relative_humidity { get; set; }
        public string Wind_string { get; set; }
        public string Wind_dir { get; set; }
        public double Wind_degrees { get; set; }
        public double Wind_mph { get; set; }
        public string Wind_gust_mph { get; set; }
        public double Wind_kph { get; set; }
        public string Wind_gust_kph { get; set; }
        public string Pressure_mb { get; set; }
        public string Pressure_in { get; set; }
        public string Pressure_trend { get; set; }
        public string Dewpoint_string { get; set; }
        public double Dewpoint_f { get; set; }
        public double Dewpoint_c { get; set; }
        public string Heat_index_string { get; set; }
        public string Heat_index_f { get; set; }
        public string Heat_index_c { get; set; }
        public string Windchill_string { get; set; }
        public string Windchill_f { get; set; }
        public string Windchill_c { get; set; }
        public string Feelslike_string { get; set; }
        public string Feelslike_f { get; set; }
        public string Feelslike_c { get; set; }
        public string Visibility_mi { get; set; }
        public string Visibility_km { get; set; }
        public string Solarradiation { get; set; }
        public string UV { get; set; }
        public string Precip_1hr_string { get; set; }
        public string Precip_1hr_in { get; set; }
        public string Precip_1hr_metric { get; set; }
        public string Precip_today_string { get; set; }
        public string Precip_today_in { get; set; }
        public string Precip_today_metric { get; set; }
        public string Icon { get; set; }
        public string Icon_url { get; set; }
        public string Forecast_url { get; set; }
        public string History_url { get; set; }
        public string Ob_url { get; set; }
        public string Nowcast { get; set; }
    }

    public class ConditionsRootObject
    {
        public Response Response { get; set; }
        public CurrentObservation Current_observation { get; set; }
    }
}
