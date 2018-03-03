using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models {
    class ParticipantList : List<Participant> {
        public string Name { get; set; }
        /*public List<Participant> Participants { get; set; }

        public ParticipantList()
        {
            this.Participants = new List<Participant>();
        }

        public void AddParticipant(Participant participant)
        {
            this.Participants.Add(participant);
        }

        public void RemoveParticipant(Participant participant)
        {
            this.Participants.Remove(participant);
        }*/
    }
}
