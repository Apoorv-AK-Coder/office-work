using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace TravelSite.Models
{
    public class flynowpaylater
    {


        public Itinerary Itinerary { set; get; }
        public List<Pax> Pax { set; get; }
        public PaymentCallbackDetails PaymentCallbackDetails { set; get; }
        public string Guid { get; set; }

        public string merchantreference { get; set; }
        public string loanamount { get; set; }
        public string BookingRef { get; set; }
       
        public string Email { get; set; }
        public string Destination { get; set; }
        public string MobileNo { get; set; }
        public string Phone { get; set; }
        public string BookingDate { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string PaxCount { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public string Country { get; set; }
       


        public static string GetVirtualCard(string RefNo)
        {
            var responseString = string.Empty;
            try
            {
                //test Integration Key HURE0WYV25-SW39Q1RHKW
                //LIve Integration Key N21YO5RXH4-EG8DPS40AQ
                var request = (HttpWebRequest)WebRequest.Create("https://merchants.flynowpaylater.com/app.service/N21YO5RXH4-EG8DPS40AQ/virtualcard.issue"); //N21YO5RXH4-EG8DPS40AQ
                var postData = "reference=" + RefNo + "";
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
            }
            return responseString;
        }
                
        private static string PostRequest()
        {
            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://pi-test.sagepay.com/api/v1");

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://pi-live.sagepay.com/api/v1");


            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "[  { \"ReferenceId\": \"a123\"  } ]";
                Debug.Write(json);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var result = string.Empty;
            try
            {
                using (var response = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    if (httpWebRequest.HaveResponse && response != null)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)e.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            result = error.ToString();
                        }
                    }

                }
            }

            return result;

        }
    }
}