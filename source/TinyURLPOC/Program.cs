﻿using System;
using System.Collections;
using TinyURLPOC.Controllers;
using TinyURLPOC.Data;
using TinyURLPOC.Helpers;
using TinyURLPOC.Models;
using TinyURLPOC.Parser;
using TinyURLPOC.View;

namespace TinyURLPOC
{
    public class TinyURLPOC 
    {
        public static void Main(string[] args)
        {

            /*
             * UNIT TESTS CAN BE FOUND ON TintURLPOC.Test
             */

            //You can run any type of Encoding - for testing purposes I use Base64
            URLsController controller = new URLsController(new Base64Encoding());

            string longUrl = ""; 
            //shorturl can be either the aliasUrl or the autogeneratedUrl
            string shortUrl = "";
            string alias = "";



            /*** REQUIEREMENTS ***/

            //Creating and Deleting short URLs with associated long URLs.
                //Creating
                //Entering a custom short URL or letting the app randomly generate one, while maintaining uniqueness of short URLs.
            controller.GetShortUrl(longUrl);
            controller.GetShortUrlUsingAlias(longUrl, shortUrl);
            //Deleting
            controller.DeleteLongUrl(shortUrl);


            //Getting the long URL from a short URL.
            controller.GetLongUrl(shortUrl);

            //Getting statistics on the number of times a short URL has been "clicked" i.e. the number of times its long URL has been retrieved.
            controller.GetOriginalUrlCount(longUrl);


        }

    }

}
