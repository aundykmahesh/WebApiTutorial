using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;


public class ExceptionHandlingAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is EntryPointNotFoundException)
        {

            //throw new HttpResponseMe EntryPointNotFoundException("{\"message\":\"No HTTP resource was found that matches the request URI\"");



        }
        base.OnException(context);
    }
        
}