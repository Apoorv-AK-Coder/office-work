using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

/// <summary>
/// Summary description for SecurePage
/// </summary>
namespace TravelSite.Models
{
    #region SecurePage Class
    public class SecurePage
    {
        string _path = string.Empty;
        string _pathType = string.Empty;

        public string Path
        {
            get { return this._path; }
            set { this._path = value; }
        }

        public string PathType
        {
            get { return this._pathType; }
            set { this._pathType = value; }
        }
    }

    #endregion


    #region SecurePath Class
    public class SecurePath
    {

        public static bool IsSecure(string path)
        {
            List<SecurePage> lstPages = new List<SecurePage>();

            bool isSecure = false;

            try
            {
                //Fill the list of pages defined in web.config
                NameValueCollection sectionPages = (NameValueCollection)ConfigurationManager.GetSection("SecurePages");

                foreach (string key in sectionPages)
                {
                    if ((!string.IsNullOrEmpty(key)) && (!string.IsNullOrEmpty(sectionPages.Get(key))))
                    {
                        lstPages.Add(new SecurePage { PathType = sectionPages.Get(key), Path = key });
                    }
                }

                //loop through the list to match the path with the value in the list item
                foreach (SecurePage page in lstPages)
                {
                    switch (page.PathType.ToLower().Trim())
                    {
                        case "directory":
                            if (path.Contains(page.Path))
                            {
                                isSecure = true;
                            }
                            break;
                        case "page":
                            if (path.ToLower().Trim() == page.Path.ToLower().Trim())
                            {
                                isSecure = true;
                            }
                            break;
                        default:
                            isSecure = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isSecure;
        }
    }
    #endregion
}
