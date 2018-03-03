using Logic.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data {
    class DataFile {
        private string path;
        private string content;

        public ParticipantList Participants { get; private set; }
        
        public DataFile(string path)
        {
            this.path = path;
        }

        public void ReadData()
        {
            this.content = File.ReadAllText(this.path);
            this.Participants = FileParser.ParseList(this.content);
        }

        public void SaveData()
        {
            this.content = FileParser.ParseToText(this.Participants);
            File.WriteAllText(this.path, this.content);
        }


    }
}
