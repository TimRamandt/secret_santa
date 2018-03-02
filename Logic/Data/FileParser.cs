﻿using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data {
    static class FileParser {

        public static ParticipantList ParseList(string content)
        {
            ParticipantList list = new ParticipantList();

            var lines = content.Split('\n');

            if (!lines[0].StartsWith("Name:")) {
                throw new Exception("Parse Error, textfile is missing a name on line 1");
            }

            list.Name = lines[0].Substring(5).Trim();

            for (int i = 1; i < lines.Length; i++) {

                if (string.IsNullOrWhiteSpace(lines[i])) {
                    continue;
                }

                if(!lines[i].Contains("<") && !lines[i].Contains(">")) {
                    throw new Exception($"Parse Error, invalid participant Syntax on line {i + 1}");
                }

                list.Add(new Participant() {
                            Name = lines[i].Substring(0, lines[i].IndexOf("<")).Trim(),
                            Email = DetermineEmail(lines[i])
                        }
                );
            }
            return list;
        }

        private static string DetermineEmail(string line)
        {
            int length = line.IndexOf(">") - line.IndexOf("<") -1;
            return line.Substring((line.IndexOf("<")+1),length);
        }
    }
}
