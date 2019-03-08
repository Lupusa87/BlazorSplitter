using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSplitterComponent
{
    internal static class BsJsInterop
    {

        internal static IJSRuntime jsRuntime;

        internal static Task<bool> Alert(string msg)
        {

            return jsRuntime.InvokeAsync<bool>(
                "BsJsFunctions.alertmsg", msg);
        }
        internal static Task<bool> HandleDrag(string elementID, DotNetObjectRef dotnetHelper)
        {

            return jsRuntime.InvokeAsync<bool>(
                "BsJsFunctions.handleDrag", elementID, dotnetHelper);
        }

        internal static Task<bool> UnHandleDrag(string elementID)
        {

            return jsRuntime.InvokeAsync<bool>(
                "BsJsFunctions.unHandleDrag", elementID);
        }

        internal static Task<bool> StopDrag(string elementID)
        {

            return jsRuntime.InvokeAsync<bool>(
                "BsJsFunctions.stopDrag", elementID);
        }


    }
}
