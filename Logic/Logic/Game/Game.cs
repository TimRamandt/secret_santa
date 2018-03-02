using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic.Game {
    class Game {
        public ParticipantList List { get; set; }
        public ParticipantList GiveToList { get; set; }

        public Game()
        {
            this.List = new ParticipantList();
        }

        public Participant PullName()
        {
            int pulledId = this.FetchId(this.List);

            var participant = this.List[pulledId];
            this.List.RemoveAt(pulledId);

            return participant;
        }

        public Participant LinkParticipant(Participant participant)
        {
            int participantId = -1;
            Participant givingParticipant = null;
            while(givingParticipant == null || givingParticipant.Name == participant.Name)
            {
                participantId = FetchId(this.GiveToList);
                givingParticipant = this.GiveToList[participantId];
            }

            this.GiveToList.RemoveAt(participantId);
            participant.GiveTo = participant;

            return participant;
        }


        private int FetchId(ParticipantList list)
        {
            int amountLeft = this.GiveToList.Count;
            var random = new Random();
            int id = random.Next(0, amountLeft + 1);

            return id;
        }
    }
}
