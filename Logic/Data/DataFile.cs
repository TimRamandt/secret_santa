using Logic.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data {
    public class DataFile {
        public string Path { get; set; }
        private string content;

        public ParticipantList Participants { get; private set; }
        
        public DataFile(string path)
        {
            this.Path = path;
            this.ReadData();
        }
        
        public DataFile() {
            this.Participants = new ParticipantList();
        }
        
        public void RenameParticipantsList(string name)
        {
            this.Participants.Name = name;
        }

        public void AddParticipant(Participant participant)
        {
            this.Participants.Add(participant);
        }

        public void RemoveParticipant(Participant participant)
        {
            this.Participants.Remove(participant);
        }

        public void ReadData()
        {
            this.content = File.ReadAllText(this.Path);
            this.Participants = FileParser.ParseList(this.content);
        }

        public void SaveData()
        {
            this.content = FileParser.ParseToText(this.Participants);
            File.WriteAllText(this.Path, this.content);
        }

    }
}
