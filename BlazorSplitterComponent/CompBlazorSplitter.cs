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
        [Inject]
        private IJSRuntime jsRuntimeCurrent { get; set; }

        [Parameter]
        protected BsSettings bsSettings { get; set; }

        [Parameter]
        public Action<bool, int, int> OnPositionChange { get; set; }

        [Parameter]
        public Action<int, int,int> OnDiagonalPositionChange { get; set; }

        [Parameter]
        public Action<int, int, int> OnDragStart { get; set; }


        [Parameter]
        public Action<int, int, int> OnDragEnd { get; set; }

        private BSplitter bSplitter { get; set; } = new BSplitter();

        private bool DragMode = false;

        protected override void OnInit()
        {
            bSplitter.bsbSettings = bsSettings;

            bSplitter.PropertyChanged = BSplitter_PropertyChanged;

            DragMode = false;

            base.OnInit();
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

            builder.AddAttribute(k++, "onpointerdown", EventCallback.Factory.Create<UIPointerEventArgs>(this, OnPointerDown));
            builder.AddAttribute(k++, "onpointermove", EventCallback.Factory.Create<UIPointerEventArgs>(this, OnPointerMove));
            builder.AddAttribute(k++, "onpointerup", EventCallback.Factory.Create<UIPointerEventArgs>(this, OnPointerUp));

            builder.AddAttribute(k++, "onmousemove", EventCallback.Factory.Create<UIMouseEventArgs>(this, "return false;")); //event.preventDefault()


            builder.CloseElement();

            base.BuildRenderTree(builder);
        }


        private void OnPointerDown(UIPointerEventArgs e)
        {
            BsJsInterop.SetPointerCapture(jsRuntimeCurrent, bSplitter.bsbSettings.ID, e.PointerId);
            DragMode = true;

            if (bsSettings.IsDiagonal)
            {
                bSplitter.PreviousPosition = (int)e.ClientX;
                bSplitter.PreviousPosition2 = (int)e.ClientY;
                
            }
            else
            {
                if (bsSettings.VerticalOrHorizontal)
                {
                    bSplitter.PreviousPosition = (int)e.ClientY;
                    bSplitter.PreviousPosition2 = (int)e.ClientX;
                }
                else
                {

                    bSplitter.PreviousPosition = (int)e.ClientX;
                    bSplitter.PreviousPosition2 = (int)e.ClientY;
                }
            }


            OnDragStart?.Invoke(bSplitter.bsbSettings.index, (int)e.ClientX, (int)e.ClientY);
        }


        private void OnPointerMove(UIPointerEventArgs e)
        {
            if (DragMode)
            {


                if (e.Buttons == 1)
                {

                    int NewPosition = 0;
                    int NewPosition2 = 0;


                    if (bsSettings.IsDiagonal)
                    {
                        NewPosition = (int)e.ClientX;
                        NewPosition2 = (int)e.ClientY;
                       
                        
                            if (bSplitter.PreviousPosition != NewPosition || bSplitter.PreviousPosition2 != NewPosition2)
                            {

                                OnDiagonalPositionChange?.Invoke(bsSettings.index, NewPosition - bSplitter.PreviousPosition, NewPosition2 - bSplitter.PreviousPosition2);


                                bSplitter.PreviousPosition = NewPosition;
                                bSplitter.PreviousPosition2 = NewPosition2;
                            }
                        
                    }
                    else
                    {
                        if (bsSettings.VerticalOrHorizontal)
                        {
                            NewPosition = (int)e.ClientY;
                            NewPosition2 = (int)e.ClientX;
                        }
                        else
                        {
                            NewPosition = (int)e.ClientX;
                            NewPosition2 = (int)e.ClientY;
                        }


                        if (Math.Abs(bSplitter.PreviousPosition2 - NewPosition2) < 100)
                        {
                            if (bSplitter.PreviousPosition != NewPosition)
                            {

                                OnPositionChange?.Invoke(bsSettings.VerticalOrHorizontal, bsSettings.index, NewPosition - bSplitter.PreviousPosition);


                                bSplitter.PreviousPosition = NewPosition;
                            }
                        }
                        //else
                        //{
                        //    //BsJsInterop.StopDrag(bSplitter.bsbSettings.ID);
                        //}
                    }
                }
            }
        }



        private void OnPointerUp(UIPointerEventArgs e)
        {
            BsJsInterop.releasePointerCapture(jsRuntimeCurrent, bSplitter.bsbSettings.ID, e.PointerId);
            DragMode = false;

            OnDragEnd?.Invoke(bSplitter.bsbSettings.index, (int)e.ClientX, (int)e.ClientY);
        }


        public void Dispose()
        {
          
        }

        public void SetColor(string c)
        {
            bSplitter.bsbSettings.BgColor = c;
            StateHasChanged();
        }
    }
}
