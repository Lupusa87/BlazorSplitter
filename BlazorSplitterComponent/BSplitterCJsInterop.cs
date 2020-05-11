using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSplitterComponent
{
    public static class BSplitterCJsInterop
    {
        public static IJSRuntime jsRuntime;

        internal static ValueTask<bool> Alert(IJSRuntime jsRuntime, string msg)
        {

            return jsRuntime.InvokeAsync<bool>(
                "BSplitterCJsFunctions.alertmsg", msg);
        }

        internal static ValueTask<bool> SetPointerCapture(IJSRuntime jsRuntime, string elementID, long pointerID)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BSplitterCJsFunctions.setPCapture", elementID, pointerID);
        }
        internal static ValueTask<bool> releasePointerCapture(IJSRuntime jsRuntime, string elementID, long pointerID)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BSplitterCJsFunctions.releasePCapture", elementID, pointerID);
        }

    }
}
