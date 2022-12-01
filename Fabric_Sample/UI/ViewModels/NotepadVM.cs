using Fabric.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fabric_Sample.UI.ViewModels
{
    public class NotepadVM : ViewModel
    {
        private string _notepadContent;

        public string NotepadContent
        {
            get { return Get(ref _notepadContent); }
            set { Set(ref _notepadContent, value); }
        }

        public NotepadVM()
        {
        }

        private ICommand _validate;

        public ICommand Validate
        {
            get { return _validate ?? (_validate = new CommandHandler(ValidateCommand)); }
        }

        private void ValidateCommand(object obj)
        {
            MessageBox.Show(NotepadContent);
        }

        private ICommand _cancel;

        public ICommand Cancel
        {
            get { return _cancel ?? (_cancel = new CommandHandler(CancelCommand)); }
        }

        private void CancelCommand(object obj)
        {
            NotepadContent = String.Empty;
        }
    }
}
