﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Validation;
using System.Web.Http.Validation.Providers;
using CFA.API.Config.Helpers;
using CFA.API.Handlers;

namespace CFA.API.Config
{
    public class WebAPIConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            //Formatters
            var jqueryFormatter = config.Formatters.FirstOrDefault(x => x.GetType() == typeof(JQueryMvcFormUrlEncodedFormatter));
            config.Formatters.Remove(config.Formatters.FormUrlEncodedFormatter);
            config.Formatters.Remove(jqueryFormatter);

            foreach (var formatter in config.Formatters)
            {
                formatter.RequiredMemberSelector = new SuppressedRequiredMemberSelector();
            }

            //Default Services
            config.Services.Replace(typeof(IContentNegotiator), new DefaultContentNegotiator(excludeMatchOnTypeOnly: true));
            config.Services.RemoveAll(typeof(ModelValidatorProvider), validator => !(validator is DataAnnotationsModelValidatorProvider));


            //// Message Handlers
            //config.MessageHandlers.Add(new RequireHttpsMessageHandler());
            config.MessageHandlers.Add(new CFAAuthenticationHandler());

        }



    }
}
