using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorSplitterComponent
{

    public class CompBlazorSplitter : ComponentBase, IDisposable
    {
        [Parameter]
        protected BsSettings bsSettings { get; set; }

        [Parameter]
        public Action<bool, int, int> OnPositionChange { get; set; }


        private BSplitter bSplitter { get; set; } = new BSplitter();

       
        bool FirtLoad = true;

        protected override void OnInit()
        {
            bSplitter.bsbSettings = bsSettings;
            


            bSplitter.PropertyChanged = BSplitter_PropertyChanged;

            base.OnInit();
        }


        protected override void OnAfterRender()
        {
           
            if (FirtLoad)
            {

                FirtLoad = false;
                BsJsInterop.HandleDrag(bSplitter.bsbSettings.ID, new DotNetObjectRef(this));
            }


            base.OnAfterRender();
        }


        private void BSplitter_PropertyChanged()
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int k = 0;
            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "id", bSplitter.bsbSettings.ID);
            builder.AddAttribute(k++, "style", bSplitter.bsbSettings.GetStyle());
           // builder.AddAttribute(k++, "onmousedown", OnMouseDown);
           // builder.AddAttribute(k++, "onmousemove", OnMouseMove);

            builder.CloseElement();

            base.BuildRenderTree(builder);
        }


        //public void OnMouseMove(UIMouseEventArgs e)
        //{
        //    if (e.Buttons == 1)
        //    {
        //        int NewPosition= (int)e.ClientX;

        //        if (bSplitter.PreviousPosition != NewPosition)
        //        {
        //            OnPositionChange?.Invoke(NewPosition - bSplitter.PreviousPosition);
        //            bSplitter.PreviousPosition = NewPosition;
        //        }

        //    }
        //}


        //public void OnMouseDown(UIMouseEventArgs e)
        //{
        //    bSplitter.PreviousPosition = (int)e.ClientX;
        //}





        [JSInvokable]
        public void InvokeMoveFromJS(int x, int y)
        {


            int NewPosition = 0;
            int NewPosition2 = 0;

            if (bsSettings.VerticalOrHorizontal)
            {
                NewPosition = y;
                NewPosition2 = x;
            }
            else
            {
                NewPosition = x;
                NewPosition2 = y;
            }


                if (Math.Abs(bSplitter.PreviousPosition2 - NewPosition2) < 100)
            {
                if (bSplitter.PreviousPosition != NewPosition)
                {
                   
                    OnPositionChange?.Invoke(bsSettings.VerticalOrHorizontal, bsSettings.index, NewPosition - bSplitter.PreviousPosition);
                   
                   
                    bSplitter.PreviousPosition = NewPosition;
                }
            }
            else
            {
                BsJsInterop.StopDrag(bSplitter.bsbSettings.ID);
            }
        }

        [JSInvokable]
        public void InvokePointerDownFromJS(int x, int y)
        {
            if (bsSettings.VerticalOrHorizontal)
            {
                bSplitter.PreviousPosition = y;
                bSplitter.PreviousPosition2 = x;
            }
            else
            {

                bSplitter.PreviousPosition = x;
                bSplitter.PreviousPosition2 = y;
            }
       
        }


        public void Dispose()
        {
            BsJsInterop.UnHandleDrag(bSplitter.bsbSettings.ID);
        }



        public void SetColor(string c)
        {
            bSplitter.bsbSettings.BgColor = c;
            StateHasChanged();
        }
    }
}
