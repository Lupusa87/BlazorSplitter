using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
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


        public BSplitter bSplitter { get; set; } = new BSplitter();

        [Parameter]
        public Action<int> OnPositionChange { get; set; }

        protected override void OnInit()
        {
            bSplitter.bsbSettings = bsSettings;

            bSplitter.PropertyChanged += BSplitter_PropertyChanged;

            base.OnInit();
        }


        private void BSplitter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int k = 0;
            builder.OpenElement(k++, "div");
            builder.AddAttribute(k++, "style", bSplitter.bsbSettings.GetStyle());
            builder.AddAttribute(k++, "onmousedown", OnMouseDown);
            builder.AddAttribute(k++, "onmousemove", OnMouseMove);

            builder.CloseElement();

            base.BuildRenderTree(builder);
        }


        public void OnMouseMove(UIMouseEventArgs e)
        {
            if (e.Buttons == 1)
            {
                int NewPosition= (int)e.ClientX;

                if (bSplitter.PreviousPosition != NewPosition)
                {
                    OnPositionChange?.Invoke(NewPosition - bSplitter.PreviousPosition);
                    bSplitter.PreviousPosition = NewPosition;
                }

            }
        }


        public void OnMouseDown(UIMouseEventArgs e)
        {
            bSplitter.PreviousPosition = (int)e.ClientX;
        }

        public void Dispose()
        {
            bSplitter.PropertyChanged -= BSplitter_PropertyChanged;
        }

    }
}
