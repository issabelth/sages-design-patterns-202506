using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.Models
{
    public class CurrentUser
    {
        public static string Role { get; set; }
    }

    public class Document
    {
        public DocumentState State { get; private set; }    

        public void ChangeState(DocumentState state)
        {
            State = state;
        }

        public void Publish()
        {
            switch (State)
            {
                case DocumentState.Draft: 
                    State = DocumentState.Moderation; 
                    break;

                case DocumentState.Moderation:
                    if (CurrentUser.Role == "admin")
                        State = DocumentState.Published;
                    break;

                case DocumentState.Published:
                    // nic nie rób
                    break;
            }
        }
    }

    public enum DocumentState
    {
        Draft,
        Moderation,
        Published
    }
}
