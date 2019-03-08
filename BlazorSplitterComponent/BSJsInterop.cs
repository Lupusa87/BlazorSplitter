using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSplitterComponent
{
    internal static class BsJsInterop
    {

        internal static Task<bool> Alert(IJSRuntime jsRuntime, string msg)
        {

            return jsRuntime.InvokeAsync<bool>(
                "BsJsFunctions.alertmsg", msg);
        }

        internal static Task<bool> SetPointerCapture(IJSRuntime jsRuntime, string elementID, long pointerID)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BsJsFunctions.setPCapture", elementID, pointerID);
        }
        internal static Task<bool> releasePointerCapture(IJSRuntime jsRuntime, string elementID, long pointerID)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BsJsFunctions.releasePCapture", elementID, pointerID);
        }

    }
}
