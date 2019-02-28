using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorSplitterComponent
{
    internal class BSplitter
    {
        internal Action PropertyChanged;

        internal BsSettings bsbSettings { get; set; }


        internal int PreviousPosition { get; set; } = 0;
        internal int PreviousPosition2 { get; set; } = 0;
        
        internal int Position { get; set; } = 0;

        internal int Step { get; set; } = 0;





        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        internal void InvokePropertyChanged()
        {
            PropertyChanged?.Invoke();
        }

    }
}
